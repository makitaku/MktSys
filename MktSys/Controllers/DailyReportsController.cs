using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MktSys.Models;
using QuickMaster.Models;

namespace MktSys.Controllers
{
    public class DailyReportsController : Controller
    {
        private readonly NpgContext _context;

        public DailyReportsController(NpgContext context)
        {
            _context = context;
        }

        // GET: DailyReports
        public async Task<IActionResult> Index()
        {
            return View(await _context.DailyReport.ToListAsync());
        }

        // GET: DailyReports/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyReport = await _context.DailyReport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyReport == null)
            {
                return NotFound();
            }

            return View(dailyReport);
        }

        // GET: DailyReports/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DailyReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ReportDate,StartTime,EndTime,Comment")] DailyReport dailyReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dailyReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dailyReport);
        }

        // GET: DailyReports/CreateMulti
        public IActionResult CreateMulti()
        {
            return View();
        }

        // POST: DailyReports/CreateMulti
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMulti([Bind("Id,ReportDate,StartTime,EndTime,Comment")] List<DailyReport> dailyReport)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    foreach(var item in dailyReport)
                    {
                        _context.Add(item);
                    }
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    View(dailyReport);
                }
            }
            return View(dailyReport);
        }

        // GET: DailyReports/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyReport = await _context.DailyReport.FindAsync(id);

            if (dailyReport == null)
            {
                return NotFound();
            }
            return View(dailyReport);
        }

        // POST: DailyReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,ReportDate,StartTime,EndTime,Comment")] DailyReport dailyReport)
        {
            if (id != dailyReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dailyReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyReportExists(dailyReport.Id))
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
            return View(dailyReport);
        }

        // GET: DailyReports/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyReport = await _context.DailyReport
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dailyReport == null)
            {
                return NotFound();
            }

            return View(dailyReport);
        }

        // POST: DailyReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var dailyReport = await _context.DailyReport.FindAsync(id);
            _context.DailyReport.Remove(dailyReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DailyReportExists(long id)
        {
            return _context.DailyReport.Any(e => e.Id == id);
        }
    }
}
