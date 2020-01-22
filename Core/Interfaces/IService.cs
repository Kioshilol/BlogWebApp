using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IService<T>
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        int Add(T entity);
        void Edit(T entity);
        void Delete(int id);
    }
}
