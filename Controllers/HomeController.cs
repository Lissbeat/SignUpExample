using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using assignment_5.Data;
using Microsoft.AspNetCore.Mvc;
using assignment_5.Models;
using Microsoft.EntityFrameworkCore;

namespace assignment_5.Controllers
{
    public class HomeController : Controller
    {
         private readonly StoreDbContext _context;

        public HomeController(StoreDbContext context)
        {
            _context = context;
        }

        // GET: Signup
        public async Task<IActionResult> Index()
        {
            return View(await _context.Event.ToListAsync());
        }

        // GET: Signup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @home = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@home == null)
            {
                return NotFound();
            }

            return View(@home);
        }

        // GET: Signup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Signup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Age,Email")] Signup @signup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@signup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@signup);
        }

        // GET: Signup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @signup = await _context.Event.FindAsync(id);
            if (@signup == null)
            {
                return NotFound();
            }
            return View(@signup);
        }

        // POST: Signup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Age,Email")] Signup @signup)
        {
            if (id != @signup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@signup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(@signup.Id))
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
            return View(@signup);
        }

        // GET: Signup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @home = await _context.Event
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@home == null)
            {
                return NotFound();
            }

            return View(@home);
        }

        // POST: Signup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @event = await _context.Event.FindAsync(id);
            _context.Event.Remove(@event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       
        
        
        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.Id == id);
        }
    
       

      
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
