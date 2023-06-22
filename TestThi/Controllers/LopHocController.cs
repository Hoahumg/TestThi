using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Data;
using Test.Models;

namespace Test.Controllers
{
    public class LopHocController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LopHocController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LopHoc
        public async Task<IActionResult> Index()
        {
              return _context.LopHocs != null ? 
                          View(await _context.LopHocs.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LopHocs'  is null.");
        }

        // GET: LopHoc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LopHocs == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHocs
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // GET: LopHoc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LopHoc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaLop,TenLop")] LopHoc lopHoc)
        {
            var isAuth = HttpContext.Session.GetString("user");
            if(isAuth == null)
            {
                ModelState.AddModelError(string.Empty, "Yêu cầu Đăng Nhập");
                return View(lopHoc);
            }
            if (ModelState.IsValid)
            {
                _context.Add(lopHoc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lopHoc);
        }

        // GET: LopHoc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LopHocs == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHocs.FindAsync(id);
            if (lopHoc == null)
            {
                return NotFound();
            }
            return View(lopHoc);
        }

        // POST: LopHoc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaLop,TenLop")] LopHoc lopHoc)
        {
            var isAuth = HttpContext.Session.GetString("user");
            if (isAuth == null)
            {
                ModelState.AddModelError(string.Empty, "Yêu cầu Đăng Nhập");
                return View(lopHoc);
            }
            if (id != lopHoc.MaLop)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopHoc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopHocExists(lopHoc.MaLop))
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
            return View(lopHoc);
        }

        // GET: LopHoc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LopHocs == null)
            {
                return NotFound();
            }

            var lopHoc = await _context.LopHocs
                .FirstOrDefaultAsync(m => m.MaLop == id);
            if (lopHoc == null)
            {
                return NotFound();
            }

            return View(lopHoc);
        }

        // POST: LopHoc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var isAuth = HttpContext.Session.GetString("user");
            if (isAuth == null)
            {
                return Problem("Yêu cầu Đăng Nhập");
            }
            if (_context.LopHocs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LopHocs'  is null.");
            }
            var lopHoc = await _context.LopHocs.FindAsync(id);
            if (lopHoc != null)
            {
                _context.LopHocs.Remove(lopHoc);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopHocExists(int id)
        {
          return (_context.LopHocs?.Any(e => e.MaLop == id)).GetValueOrDefault();
        }
    }
}
