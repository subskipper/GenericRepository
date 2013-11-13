using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericRepo
{
    public class PersonRepository : IRepository<Person>
    {

        private List<Person> m_PersonCollection = new List<Person>(); 

        public void Add(Person item)
        {
            m_PersonCollection.Add(item);
        }

        public void Remove(Person item)
        {
            m_PersonCollection.Remove(item);
        }

        public IQueryable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(Guid id)
        {
            return m_PersonCollection.FirstOrDefault(p => p.Id == id);
        }

        public int GetCount()
        {
            return m_PersonCollection.Count();
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}
