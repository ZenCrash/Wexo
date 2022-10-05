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
    public class MeetingRepository : IMeetingRepository
    {
        ////ConnectionString
        private readonly WEXO_GreetMeContext _db;
        public MeetingRepository(WEXO_GreetMeContext db)
        {
            _db = db;
        }

        //-----------------------------------------------------------------------------
        /* GetAll                                                                    */
        //-----------------------------------------------------------------------------

        //GetAll
        public IEnumerable<Meeting?> GetAll()
        {
            return _db.Meetings.ToList();
        }

        //GetAll Async
        public async Task<IEnumerable<Meeting?>> GetAllAsync()
        {
            return await _db.Meetings.ToListAsync();
        }

        //-----------------------------------------------------------------------------
        /* Get / Read                                                                */
        //-----------------------------------------------------------------------------

        //GetById
        public Meeting? GetById(int id)
        {
            return _db.Meetings.FirstOrDefault(meeting => meeting.Id == id);
        }

        //GetById Async
        public async Task<Meeting?> GetByIdAsync(int id)
        {
            return await _db.Meetings.FirstOrDefaultAsync(meeting => meeting.Id == id);
        }

        //-----------------------------------------------------------------------------
        /* Create / Post                                                              */
        //-----------------------------------------------------------------------------

        //Create
        public Meeting Create(Meeting meeting)
        {
            _db.Meetings.Add(meeting);
            _db.SaveChanges();
            return meeting;
        }

        //Create Async
         public async Task<Meeting> CreateAsync(Meeting meeting)
        {
            _db.Meetings.Add(meeting);
            await _db.SaveChangesAsync();
            return meeting;
        }

        //-----------------------------------------------------------------------------
        /* Update                                                                    */
        //-----------------------------------------------------------------------------

        //Update
        public Meeting Update(Meeting meeting)
        {
            _db.Meetings.Update(meeting);
            _db.SaveChanges();
            return meeting;
        }

        //Update Async
        public async Task<Meeting> UpdateAsync(Meeting meeting)
        {
            _db.Meetings.Update(meeting);
            await _db.SaveChangesAsync();
            return meeting;
        }

        //-----------------------------------------------------------------------------
        /* Delete                                                                    */
        //-----------------------------------------------------------------------------

        //Delete
        public void Delete(int id)
        {
            _db.Meetings.Remove(_db.Meetings.Find(id));
            _db.SaveChanges();
        }

        //Delete Async
        public async void DeleteAsync(int id)
        {
            _db.Meetings.Remove(_db.Meetings.Find(id));
            _db.SaveChanges();
        }

    }
}
