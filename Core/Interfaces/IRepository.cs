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
        IEnumerable<T> Get(bool isPaging, int page);
        T GetById(int id);
    }
}
