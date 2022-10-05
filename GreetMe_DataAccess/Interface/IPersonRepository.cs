using GreetMe_DataAccess.Model;
using GreetMe_DataAccess.Repsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetMe_DataAccess.Interface
{
    public interface IPersonRepository : IRepository<Person>
    {
        //Task<string> GetFirstName(Guid id); //example Get Spesific Person name By id

        //-----------------------------------------------------------------------------
        /* GetAll                                                                    */
        //-----------------------------------------------------------------------------

        //GetAll People By Id
        Task<List<Person>> GetAllPeopleAsync();

        //-----------------------------------------------------------------------------
        /* Get / Read                                                                */
        //-----------------------------------------------------------------------------

        //Get Person By Id
        Task<Person> GetPersonByIdAsync(int id);

        //-----------------------------------------------------------------------------
        /* Create / Post                                                              */
        //-----------------------------------------------------------------------------

        //Create Person
        Task<Person> CreatePersonAsync(Person person);

    }
}

