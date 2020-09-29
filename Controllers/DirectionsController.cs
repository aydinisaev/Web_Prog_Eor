using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Authorize(Roles = "admin")]
    public class DirectionsController : Controller
    {
        private readonly ModelContext _context;

        public DirectionsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Directions
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Directions.Include(d => d.Department);
            return View(await modelContext.ToListAsync());
        }

        // GET: Directions/Create
        public IActionResult Create()
        {
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return View();
        }

        // POST: Directions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DepartmentId")] Direction direction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(direction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", direction.DepartmentId);
            return View(direction);
        }

        // GET: Directions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions.FindAsync(id);
            if (direction == null)
            {
                return NotFound();
            }
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", direction.DepartmentId);
            return View(direction);
        }

        // POST: Directions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DepartmentId")] Direction direction)
        {
            if (id != direction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(direction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectionExists(direction.Id))
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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name", direction.DepartmentId);
            return View(direction);
        }

        // GET: Directions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var direction = await _context.Directions
                .Include(d => d.Department)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (direction == null)
            {
                return NotFound();
            }

            return View(direction);
        }

        // POST: Directions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var direction = await _context.Directions.FindAsync(id);
            _context.Directions.Remove(direction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectionExists(int id)
        {
            return _context.Directions.Any(e => e.Id == id);
        }
        
    }
}
