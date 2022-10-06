using GreetMe_DataAccess.Interface;
using GreetMe_DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetMe_DataAccess.Repsitory
{
    public class PersonRepository : IPersonRepository
    {
        ////ConnectionString
        private readonly WEXO_GreetMeContext _db;
        public PersonRepository(WEXO_GreetMeContext db)
        {
            _db = db;
        }

        //-----------------------------------------------------------------------------
        /* GetAll                                                                    */
        //-----------------------------------------------------------------------------

        //GetAll
        public IEnumerable<Person?> GetAll()
        {
            return _db.People.ToList();
        }

        ////GetAll with Dep
        //public IEnumerable<Person?> GetAllWithDep()
        //{
        //    IEnumerable<Person> listPeople;

        //    listPeople = _db.People
        //        .Include(c => c.Customer)
        //        .Include(e => e.Employee);
        //    return listPeople;

        //}

        //GetAll Async
        public async Task<IEnumerable<Person?>> GetAllAsync()
        {
            return await _db.People.ToListAsync();
        }

        //-----------------------------------------------------------------------------
        /* Get / Read                                                                */
        //-----------------------------------------------------------------------------

        //GetById
        public Person? GetById(int id)
        {
            return _db.People.FirstOrDefault(person => person.Id == id);
        }

        //GetById Async
        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _db.People.FirstOrDefaultAsync(person => person.Id == id);
        }

        //-----------------------------------------------------------------------------
        /* Create / Post                                                              */
        //-----------------------------------------------------------------------------

        //Create
        public Person Create(Person person)
        {
            _db.People.Add(person);
            _db.SaveChanges();
            return person;
        }

        //Create Async
         public async Task<Person> CreateAsync(Person person)
        {
            _db.People.Add(person);
            await _db.SaveChangesAsync();
            return person;
        }

        //-----------------------------------------------------------------------------
        /* Update                                                                    */
        //-----------------------------------------------------------------------------

        //Update
        public Person Update(Person person)
        {
            _db.People.Update(person);
            _db.SaveChanges();
            return person;
        }

        //Update Async
        public async Task<Person> UpdateAsync(Person person)
        {
            _db.People.Update(person);
            await _db.SaveChangesAsync();
            return person;
        }

        //-----------------------------------------------------------------------------
        /* Delete                                                                    */
        //-----------------------------------------------------------------------------

        //Delete
        public void Delete(int id)
        {
            _db.People.Remove(_db.People.Find(id));
            _db.SaveChanges();
        }

        //Delete Async
        public async void DeleteAsync(int id)
        {
            _db.People.Remove(_db.People.Find(id));
            _db.SaveChanges();
        }

    }
}
