using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetMe_DataAccess.Interface
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T?> GetAll();
        T? GetById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(int id);
        //Task<IEnumerable<T>> Create(T entity);
        //Task<IEnumerable<T>> Update(T entity);
        //Task<IEnumerable<T>> Delete(Guid id);

    }
}
