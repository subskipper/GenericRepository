using System;
using System.Linq;

namespace GenericRepo
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        void Remove(T item);
        IQueryable<T> GetAll();
        T GetById(Guid id);
        int GetCount();
    }
}
