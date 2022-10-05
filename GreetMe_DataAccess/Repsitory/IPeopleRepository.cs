using GreetMe_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetMe_DataAccess.Repsitory
{
    public interface IPeopleRepository : IRepository<Person>
    {
        Task<string> GetFirstName(Guid id); //example Get Spesific Person name By id
    }
}
