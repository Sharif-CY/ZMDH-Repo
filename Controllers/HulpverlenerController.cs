using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WDPR.Models;
using Microsoft.AspNetCore.Authorization;
using WDPR.Data;

namespace WDPR.Controllers
{
    public class HulpverlenerController : Controller
    {
        private readonly MyContext _context;

        public HulpverlenerController(MyContext context)
        {
            _context = context;
        }

        [Authorize(Roles = "Hulpverlener")]
        public IActionResult Dashboard(){
            return View();
        }

        // GET: Hulpverlener
        public async Task<IActionResult> Index()
        {
            return View(await _context.Hulpverlener.ToListAsync());
        }

        // GET: Hulpverlener/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hulpverlener = await _context.Hulpverlener
                .FirstOrDefaultAsync(m => m.Hulpverlenerid == id);
            if (hulpverlener == null)
            {
                return NotFound();
            }

            return View(hulpverlener);
        }

        // GET: Hulpverlener/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hulpverlener/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VoorNaam,Hulpverlenerid,achterNaam,Specialisme,Gebruikersnaam,Email,Telefoonnummer,ProfielFoto,WiebenIk,MijnSTudie,WatAls,HoeHelpen")] Hulpverlener hulpverlener)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hulpverlener);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hulpverlener);
        }

        // GET: Hulpverlener/Edit/5
        public async Task<IActionResult> Edit(int? id)
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

        // POST: Hulpverlener/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VoorNaam,Hulpverlenerid,achterNaam,Specialisme,Gebruikersnaam,Email,Telefoonnummer,ProfielFoto,WiebenIk,MijnSTudie,WatAls,HoeHelpen")] Hulpverlener hulpverlener)
        {
            if (id != hulpverlener.Hulpverlenerid)
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
                    if (!HulpverlenerExists(hulpverlener.Hulpverlenerid))
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

        // GET: Hulpverlener/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hulpverlener = await _context.Hulpverlener
                .FirstOrDefaultAsync(m => m.Hulpverlenerid == id);
            if (hulpverlener == null)
            {
                return NotFound();
            }

            return View(hulpverlener);
        }

        // POST: Hulpverlener/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hulpverlener = await _context.Hulpverlener.FindAsync(id);
            _context.Hulpverlener.Remove(hulpverlener);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HulpverlenerExists(int id)
        {
            return _context.Hulpverlener.Any(e => e.Hulpverlenerid == id);
        }
    }
}
