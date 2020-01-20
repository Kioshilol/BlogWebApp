using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IRepository<T>
    {
        int Insert(T entity);
        void Delete(int id);
        void Edit(T entity);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
