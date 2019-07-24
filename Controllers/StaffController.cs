using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_bkk_api.Models;
using Microsoft.Extensions.Logging;
using Core.Data;
using Todo.Models;

namespace Project_bkk_api.Controllers
{
    public class StaffController : Controller
    {
        private ILogger<StaffController> _logger;

        private readonly DataContext _context;

        public StaffController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Staff get all data
        /// </summary>
        /// <remarks>
        /// Staff get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("Staff")]
        [ProducesResponseType(typeof(List<StaffViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Index()
        {
            try
            {
                return Json(await _context.staff.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        //// GET: Staff/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staffEntity = await _context.staff
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (staffEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(staffEntity);
        //}

        //// GET: Staff/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,fullname,position,ad_username,password,email,tel,is_active,created_by,created_at,updated_by,updated_at,delete_at")] StaffEntity staffEntity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        staffEntity.id = Guid.NewGuid();
        //        _context.Add(staffEntity);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(staffEntity);
        //}

        //// GET: Staff/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staffEntity = await _context.staff.FindAsync(id);
        //    if (staffEntity == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(staffEntity);
        //}

        //// POST: Staff/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("id,fullname,position,ad_username,password,email,tel,is_active,created_by,created_at,updated_by,updated_at,delete_at")] StaffEntity staffEntity)
        //{
        //    if (id != staffEntity.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(staffEntity);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!StaffEntityExists(staffEntity.id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(staffEntity);
        //}

        //// GET: Staff/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var staffEntity = await _context.staff
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (staffEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(staffEntity);
        //}

        //// POST: Staff/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var staffEntity = await _context.staff.FindAsync(id);
        //    _context.staff.Remove(staffEntity);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool StaffEntityExists(Guid id)
        //{
        //    return _context.staff.Any(e => e.id == id);
        //}
    }
}
