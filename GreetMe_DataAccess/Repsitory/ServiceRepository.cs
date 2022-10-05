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
    public class ServiceRepository : IServiceRepository
    {
        ////ConnectionString
        private readonly WEXO_GreetMeContext _db;
        public ServiceRepository(WEXO_GreetMeContext db)
        {
            _db = db;
        }

        //-----------------------------------------------------------------------------
        /* GetAll                                                                    */
        //-----------------------------------------------------------------------------

        //GetAll
        public IEnumerable<Service?> GetAll()
        {
            return _db.Services.ToList();
        }

        //GetAll Async
        public async Task<IEnumerable<Service?>> GetAllAsync()
        {
            return await _db.Services.ToListAsync();
        }

        //-----------------------------------------------------------------------------
        /* Get / Read                                                                */
        //-----------------------------------------------------------------------------

        //GetById
        public Service? GetById(int id)
        {
            return _db.Services.FirstOrDefault(service => service.PersonId == id);
        }

        //GetById Async
        public async Task<Service?> GetByIdAsync(int id)
        {
            return await _db.Services.FirstOrDefaultAsync(service => service.PersonId == id);
        }

        //-----------------------------------------------------------------------------
        /* Create / Post                                                              */
        //-----------------------------------------------------------------------------

        //Create
        public Service Create(Service service)
        {
            _db.Services.Add(service);
            _db.SaveChanges();
            return service;
        }

        //Create Async
         public async Task<Service> CreateAsync(Service service)
        {
            _db.Services.Add(service);
            await _db.SaveChangesAsync();
            return service;
        }

        //-----------------------------------------------------------------------------
        /* Update                                                                    */
        //-----------------------------------------------------------------------------

        //Update
        public Service Update(Service service)
        {
            _db.Services.Update(service);
            _db.SaveChanges();
            return service;
        }

        //Update Async
        public async Task<Service> UpdateAsync(Service service)
        {
            _db.Services.Update(service);
            await _db.SaveChangesAsync();
            return service;
        }

        //-----------------------------------------------------------------------------
        /* Delete                                                                    */
        //-----------------------------------------------------------------------------

        //Delete
        public void Delete(int id)
        {
            _db.Services.Remove(_db.Services.Find(id));
            _db.SaveChanges();
        }

        //Delete Async
        public async void DeleteAsync(int id)
        {
            _db.Services.Remove(_db.Services.Find(id));
            _db.SaveChanges();
        }

    }
}
