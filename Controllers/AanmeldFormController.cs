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
    public class AanmeldFormController : Controller
    {
        private readonly MyContext _context;

        public AanmeldFormController(MyContext context)
        {
            _context = context;
        }

        // GET: AanmeldForm
        public async Task<IActionResult> Index()
        {
            return View(await _context.AanmeldForm.ToListAsync());
        }

        // GET: AanmeldForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanmeldForm = await _context.AanmeldForm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aanmeldForm == null)
            {
                return NotFound();
            }

            return View(aanmeldForm);
        }

        // GET: AanmeldForm/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AanmeldForm/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,VoorNaam,achterNaam,Geboortedatum,Aandoening,Email,Orthopedagoog")] AanmeldForm aanmeldForm)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aanmeldForm);
                await _context.SaveChangesAsync();
                return Redirect("/home/Index");
                // return RedirectToAction(nameof(Index));
            }
            return View(aanmeldForm);
        }

        // GET: AanmeldForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanmeldForm = await _context.AanmeldForm.FindAsync(id);
            if (aanmeldForm == null)
            {
                return NotFound();
            }
            return View(aanmeldForm);
        }

        // POST: AanmeldForm/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,VoorNaam,achterNaam,Geboortedatum,Aandoening,Email,Orthopedagoog")] AanmeldForm aanmeldForm)
        {
            if (id != aanmeldForm.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aanmeldForm);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AanmeldFormExists(aanmeldForm.ID))
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
            return View(aanmeldForm);
        }

        // GET: AanmeldForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aanmeldForm = await _context.AanmeldForm
                .FirstOrDefaultAsync(m => m.ID == id);
            if (aanmeldForm == null)
            {
                return NotFound();
            }

            return View(aanmeldForm);
        }

        // POST: AanmeldForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aanmeldForm = await _context.AanmeldForm.FindAsync(id);
            _context.AanmeldForm.Remove(aanmeldForm);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AanmeldFormExists(int id)
        {
            return _context.AanmeldForm.Any(e => e.ID == id);
        }
    }
}
