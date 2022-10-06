using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GreetMe_DataAccess.Model;

namespace GreetMe_API.Controllers
{
    public class MeetingsController : Controller
    {
        private readonly WEXO_GreetMeContext _context;

        public MeetingsController(WEXO_GreetMeContext context)
        {
            _context = context;
        }

        // GET: Meetings
        public async Task<IActionResult> Index()
        {
            var wEXO_GreetMeContext = _context.Meetings.Include(m => m.MeetingRoom);
            return View(await wEXO_GreetMeContext.ToListAsync());
        }

        // GET: Meetings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }


            var meeting = await _context.Meetings
                .Include(m => m.MeetingRoom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meetings/Create
        public IActionResult Create()
        {
            ViewData["MeetingRoomId"] = new SelectList(_context.MeetingRooms, "Id", "Decription");
            return View();
        }

        // POST: Meetings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeetingCode,MeetingTitle,StartDateTime,EndDateTime,Status,Decription,PreparationDecription,MeetingRoomId")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meeting);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeetingRoomId"] = new SelectList(_context.MeetingRooms, "Id", "Decription", meeting.MeetingRoomId);
            return View(meeting);
        }

        // GET: Meetings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting == null)
            {
                return NotFound();
            }
            ViewData["MeetingRoomId"] = new SelectList(_context.MeetingRooms, "Id", "Decription", meeting.MeetingRoomId);
            return View(meeting);
        }

        // POST: Meetings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeetingCode,MeetingTitle,StartDateTime,EndDateTime,Status,Decription,PreparationDecription,MeetingRoomId")] Meeting meeting)
        {
            if (id != meeting.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meeting);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeetingExists(meeting.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MeetingRoomId"] = new SelectList(_context.MeetingRooms, "Id", "Decription", meeting.MeetingRoomId);
            return View(meeting);
        }

        // GET: Meetings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(m => m.MeetingRoom)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meetings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meetings == null)
            {
                return Problem("Entity set 'WEXO_GreetMeContext.Meetings'  is null.");
            }
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
          return _context.Meetings.Any(e => e.Id == id);
        }
    }
}
