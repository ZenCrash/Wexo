using GreetMe_DataAccess.Interface;
using GreetMe_DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetMe_DataAccess.Repsitory
{
    public class PersonRepository : IPersonRepository
    {
        //ConnectionString
        private readonly Wexo_GreetMeLocal _dbContext;
        public PersonRepository(Wexo_GreetMeLocal dbContext)
        {
            _dbContext = dbContext;
        }



        public Task<IEnumerable<Person>> Add(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> All()
        {
            throw new NotImplementedException();
        }

        public Task<Person> CreatePersonAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Person>> GetAllPeopleAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetPersonByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
