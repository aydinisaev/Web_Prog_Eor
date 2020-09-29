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
    public class ContentsController : Controller
    {
        private readonly ModelContext _context;

        public ContentsController(ModelContext context)
        {
            _context = context;
        }

        // GET: Contents1
        public async Task<IActionResult> Index()
        {
            var modelContext = _context.Contents.Include(c => c.Course).Include(c => c.Direction);
            return View(await modelContext.ToListAsync());
        }

        // GET: Contents1/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name");
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name");
            return View();
        }

        // POST: Contents1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Url,LevelEdu,Years,Teacher,CourseId,DirectionId")] Content content)
        {
            if (ModelState.IsValid)
            {
                _context.Add(content);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", content.CourseId);
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name", content.DirectionId);
            return View(content);
        }

        // GET: Contents1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Contents.FindAsync(id);
            if (content == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", content.CourseId);
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name", content.DirectionId);
            return View(content);
        }

        // POST: Contents1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Url,LevelEdu,Years,Teacher,CourseId,DirectionId")] Content content)
        {
            if (id != content.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(content);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContentExists(content.Id))
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
            ViewData["CourseId"] = new SelectList(_context.Courses, "Id", "Name", content.CourseId);
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name", content.DirectionId);
            return View(content);
        }

        // GET: Contents1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var content = await _context.Contents
                .Include(c => c.Course)
                .Include(c => c.Direction)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (content == null)
            {
                return NotFound();
            }

            return View(content);
        }

        // POST: Contents1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var content = await _context.Contents.FindAsync(id);
            _context.Contents.Remove(content);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContentExists(int id)
        {
            return _context.Contents.Any(e => e.Id == id);
        }
    }
}
