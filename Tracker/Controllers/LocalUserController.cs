using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tracker.Models;

namespace Tracker.Controllers
{
    [Authorize]
    public class LocalUserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LocalUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LocalUser
        public async Task<IActionResult> Index()
        {
            return View(await _context.LocalUsers.ToListAsync());
        }

        // GET: LocalUser/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localUser = await _context.LocalUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (localUser == null)
            {
                return NotFound();
            }

            return View(localUser);
        }

        // GET: LocalUser/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LocalUser/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,UserName,Name,Password,Role")] LocalUser localUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(localUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(localUser);
        }

        // GET: LocalUser/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localUser = await _context.LocalUsers.FindAsync(id);
            if (localUser == null)
            {
                return NotFound();
            }
            return View(localUser);
        }

        // POST: LocalUser/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,UserName,Name,Password,Role")] LocalUser localUser)
        {
            if (id != localUser.UserId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(localUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalUserExists(localUser.UserId))
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
            return View(localUser);
        }

        // GET: LocalUser/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var localUser = await _context.LocalUsers
                .FirstOrDefaultAsync(m => m.UserId == id);
            if (localUser == null)
            {
                return NotFound();
            }

            return View(localUser);
        }

        // POST: LocalUser/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var localUser = await _context.LocalUsers.FindAsync(id);
            if (localUser != null)
            {
                _context.LocalUsers.Remove(localUser);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalUserExists(int id)
        {
            return _context.LocalUsers.Any(e => e.UserId == id);
        }
    }
}
