using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetMe_DataAccess.Repsitory
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> Add(T entity);
        Task<IEnumerable<T>> Delete(Guid id);
        Task<IEnumerable<T>> Update(T entity);

    }
}
