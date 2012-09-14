using System;
using GenericRepo;
using NUnit.Framework;

namespace GenericRepository.Tests
{
    [TestFixture]
    public class ReposTests
    {
        [Test]
        public void Add_Adds_One_Item_to_Repository()
        {
            var guid = Guid.NewGuid();

            var personRepo = new PersonRepository();
            var expected = new Person { Name = "Test", Id = guid };

            personRepo.Add(expected);

            var actual = personRepo.GetById(guid);

            Assert.AreEqual(expected, actual);
        }
    }
}
