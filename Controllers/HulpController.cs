using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDPR.Models;

namespace WDPR.Controllers
{
    public class HulpController : Controller
    {
        private readonly MyContext _context;

        public HulpController(MyContext context)
        {
            _context = context;
        }

        // GET: Hulp
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hulpverlener.ToListAsync());
        }

        [Authorize(Roles = "Hulpverlener")]
        public IActionResult Dashboard()
        {
            return View();
        }

        // GET: Hulp/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hulpverlener = await _context.Hulpverlener
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hulpverlener == null)
            {
                return NotFound();
            }

            return View(hulpverlener);
        }

        // GET: Hulp/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hulp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoorNaam,achterNaam,Specialisme,Gebruikersnaam,Telefoonnummer,ProfielFoto,WiebenIk,MijnSTudie,WatAls,HoeHelpen,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Hulpverlener hulpverlener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hulpverlener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hulpverlener);
        }

        // GET: Hulp/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hulpverlener = await _context.Hulpverlener.FindAsync(id);
            if (hulpverlener == null)
            {
                return NotFound();
            }
            return View(hulpverlener);
        }

        // POST: Hulp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VoorNaam,achterNaam,Specialisme,Gebruikersnaam,Telefoonnummer,ProfielFoto,WiebenIk,MijnSTudie,WatAls,HoeHelpen,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Hulpverlener hulpverlener)
        {
            if (id != hulpverlener.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hulpverlener);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HulpverlenerExists(hulpverlener.Id))
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
            return View(hulpverlener);
        }

        // GET: Hulp/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hulpverlener = await _context.Hulpverlener
                .FirstOrDefaultAsync(m => m.Id == id);
            if (hulpverlener == null)
            {
                return NotFound();
            }

            return View(hulpverlener);
        }

        // POST: Hulp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var hulpverlener = await _context.Hulpverlener.FindAsync(id);
            _context.Hulpverlener.Remove(hulpverlener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HulpverlenerExists(string id)
        {
            return _context.Hulpverlener.Any(e => e.Id == id);
        }
    }
}
