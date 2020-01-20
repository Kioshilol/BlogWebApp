using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface IService
    {
        public interface IService<T> where T : class
        {
            T GetById(int id);
            IEnumerable<T> GetAll();
            int Add(T entity);
            void Edit(T entity);
            void Delete(int id);
        }
    }
}
