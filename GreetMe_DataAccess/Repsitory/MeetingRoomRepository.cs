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
    public class MeetingRoomRepository : IMeetingRoomRepository
    {
        ////ConnectionString
        private readonly WEXO_GreetMeContext _db;
        public MeetingRoomRepository(WEXO_GreetMeContext db)
        {
            _db = db;
        }

        //-----------------------------------------------------------------------------
        /* GetAll                                                                    */
        //-----------------------------------------------------------------------------

        //GetAll
        public IEnumerable<MeetingRoom?> GetAll()
        {
            return _db.MeetingRooms.ToList();
        }

        //GetAll Async
        public async Task<IEnumerable<MeetingRoom?>> GetAllAsync()
        {
            return await _db.MeetingRooms.ToListAsync();
        }

        //-----------------------------------------------------------------------------
        /* Get / Read                                                                */
        //-----------------------------------------------------------------------------

        //GetById
        public MeetingRoom? GetById(int id)
        {
            return _db.MeetingRooms.FirstOrDefault(meetingRoom => meetingRoom.Id == id);
        }

        //GetById Async
        public async Task<MeetingRoom?> GetByIdAsync(int id)
        {
            return await _db.MeetingRooms.FirstOrDefaultAsync(meetingRoom => meetingRoom.Id == id);
        }

        //-----------------------------------------------------------------------------
        /* Create / Post                                                              */
        //-----------------------------------------------------------------------------

        //Create
        public MeetingRoom Create(MeetingRoom meetingRoom)
        {
            _db.MeetingRooms.Add(meetingRoom);
            _db.SaveChanges();
            return meetingRoom;
        }

        //Create Async
         public async Task<MeetingRoom> CreateAsync(MeetingRoom meetingRoom)
        {
            _db.MeetingRooms.Add(meetingRoom);
            await _db.SaveChangesAsync();
            return meetingRoom;
        }

        //-----------------------------------------------------------------------------
        /* Update                                                                    */
        //-----------------------------------------------------------------------------

        //Update
        public MeetingRoom Update(MeetingRoom meetingRoom)
        {
            _db.MeetingRooms.Update(meetingRoom);
            _db.SaveChanges();
            return meetingRoom;
        }

        //Update Async
        public async Task<MeetingRoom> UpdateAsync(MeetingRoom meetingRoom)
        {
            _db.MeetingRooms.Update(meetingRoom);
            await _db.SaveChangesAsync();
            return meetingRoom;
        }

        //-----------------------------------------------------------------------------
        /* Delete                                                                    */
        //-----------------------------------------------------------------------------

        //Delete
        public void Delete(int id)
        {
            _db.MeetingRooms.Remove(_db.MeetingRooms.Find(id));
            _db.SaveChanges();
        }

        //Delete Async
        public async void DeleteAsync(int id)
        {
            _db.MeetingRooms.Remove(_db.MeetingRooms.Find(id));
            _db.SaveChanges();
        }

    }
}
