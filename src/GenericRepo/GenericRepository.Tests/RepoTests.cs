using System;
using GenericRepo;
using NUnit.Framework;

namespace GenericRepository.Tests
{
    [TestFixture]
    public class ReposTests
    {
        
        private PersonRepository _personRepo = new PersonRepository();

        [TestFixtureSetUp]
        public void CreatePersonRepo()
        {
            _personRepo = new PersonRepository();   
        }

        [TearDown]
        public void RemoveCollectionItems()
        {
            _personRepo = null;
            _personRepo = new PersonRepository();
        }

        [Test]
        public void Add_Adds_One_Item_to_Repository()
        {
            var guid = GetGuid();
            var expected = CreatePerson(guid);

            _personRepo.Add(expected);

            var actual = _personRepo.GetById(guid);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(1, _personRepo.GetCount());
        }

        [Test]
        public void Can_get_by_id()
        {
            var guid = GetGuid();
            var expected = CreatePerson(guid);

            var guid2 = GetGuid();
            var other = CreatePerson(guid2);

            _personRepo.Add(expected);
            _personRepo.Add(other);

            Assert.AreEqual(expected, _personRepo.GetById(expected.Id));
        }

        [Test]
        public void Can_remove()
        {
            var guid = GetGuid();
            var first = CreatePerson(guid);

            var guid2 = GetGuid();
            var second = CreatePerson(guid2);

            var guid3 = GetGuid();
            var third = CreatePerson(guid3);

            _personRepo.Add(first);
            _personRepo.Add(second);
            _personRepo.Add(third);

            _personRepo.Remove(second);

            Assert.AreEqual(2, _personRepo.GetCount());
            Assert.AreEqual(first, _personRepo.GetById(first.Id));
            Assert.AreEqual(third, _personRepo.GetById(third.Id));
        }

        private Guid GetGuid()
        {
            return Guid.NewGuid();
        }

        private Person CreatePerson(Guid id)
        {
            var expected = new Person {Name = "Test" + id, Id = id};
            return expected;
        }
    }
}
