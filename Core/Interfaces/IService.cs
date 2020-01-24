using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IService<T>
    {
        T GetById(int id);
        IEnumerable<T> Get(bool isPaging, int page);
        int Add(T entity);
        void Edit(T entity);
        void Delete(int id);
    }
}
