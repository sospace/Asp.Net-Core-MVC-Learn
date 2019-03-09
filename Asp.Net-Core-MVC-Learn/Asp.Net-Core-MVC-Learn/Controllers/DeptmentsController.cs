using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.Net_Core_MVC_Learn.Data;
using Learn.Models;

namespace Asp.Net_Core_MVC_Learn.Controllers
{
    public class DeptmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeptmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Deptments
        public async Task<IActionResult> Index()
        {
            return View("Index", await _context.Deptment.ToListAsync());
        }

        // GET: Deptments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptment = await _context.Deptment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deptment == null)
            {
                return NotFound();
            }

            return View(deptment);
        }

        // GET: Deptments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Deptments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Sort")] Deptment deptment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptment);
        }

        // GET: Deptments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptment = await _context.Deptment.FindAsync(id);
            if (deptment == null)
            {
                return NotFound();
            }
            return View(deptment);
        }

        // POST: Deptments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Sort")] Deptment deptment)
        {
            if (id != deptment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptmentExists(deptment.Id))
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
            return View(deptment);
        }

        // GET: Deptments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deptment = await _context.Deptment
                .FirstOrDefaultAsync(m => m.Id == id);
            if (deptment == null)
            {
                return NotFound();
            }

            return View(deptment);
        }

        // POST: Deptments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deptment = await _context.Deptment.FindAsync(id);
            _context.Deptment.Remove(deptment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptmentExists(int id)
        {
            return _context.Deptment.Any(e => e.Id == id);
        }
    }
}
