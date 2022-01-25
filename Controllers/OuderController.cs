using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDPR.Models;

namespace WDPR.Controllers
{
    public class OuderController : Controller
    {
        private readonly MyContext _context;

        public OuderController(MyContext context)
        {
            _context = context;
        }

        // GET: Ouder
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ouder.ToListAsync());
        }

        // GET: Ouder/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ouder = await _context.Ouder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ouder == null)
            {
                return NotFound();
            }

            return View(ouder);
        }

        // GET: Ouder/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ouder/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,achterNaam,HoortBijKind,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Ouder ouder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ouder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ouder);
        }

        // GET: Ouder/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ouder = await _context.Ouder.FindAsync(id);
            if (ouder == null)
            {
                return NotFound();
            }
            return View(ouder);
        }

        // POST: Ouder/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Naam,achterNaam,HoortBijKind,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Ouder ouder)
        {
            if (id != ouder.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ouder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OuderExists(ouder.Id))
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
            return View(ouder);
        }

        // GET: Ouder/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ouder = await _context.Ouder
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ouder == null)
            {
                return NotFound();
            }

            return View(ouder);
        }

        // POST: Ouder/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var ouder = await _context.Ouder.FindAsync(id);
            _context.Ouder.Remove(ouder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OuderExists(string id)
        {
            return _context.Ouder.Any(e => e.Id == id);
        }
    }
}
