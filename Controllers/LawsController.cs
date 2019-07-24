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
    [Route("api/Laws")]
    public class LawsController : Controller
    {
        private ILogger<LawsController> _logger;

        private readonly DataContext _context;

        public LawsController(DataContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Laws get all data
        /// </summary>
        /// <remarks>
        /// Laws get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("")]
        [ProducesResponseType(typeof(List<LawsViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Index()
        {
            try
            {
                return Json(await _context.laws.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Laws create item
        /// </summary>
        /// <remarks>
        /// Laws create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPost]
        [ProducesResponseType(typeof(List<LawsViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Insert([FromBody] LawsInsertModel model)
        {
            // ...
            var insert = new LawsService();
            var data = insert.Insert(model);
            return Json(data);
        }
        //public async Task<IActionResult> Create()
        //{
        //    try
        //    {
        //        return Json(await _context.laws.ToListAsync());
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogCritical($"Exception while get list of items.", ex);
        //        return StatusCode(500, $"Exception while get list of items. {ex.Message}");
        //    }
        //}

        //// GET: Laws/Details/5
        //public async Task<IActionResult> Details(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var lawsEntity = await _context.laws
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (lawsEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lawsEntity);
        //}

        //// GET: Laws/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        // POST: Laws/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("id,fullname,position,ad_username,password,email,tel,is_active,created_by,created_at,updated_by,updated_at,delete_at")] LawsEntity lawsEntity)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        lawsEntity.id = Guid.NewGuid();
        //        _context.Add(lawsEntity);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(lawsEntity);
        //}

        //// GET: Laws/Edit/5
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var lawsEntity = await _context.laws.FindAsync(id);
        //    if (lawsEntity == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(lawsEntity);
        //}

        //// POST: Laws/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Guid id, [Bind("id,fullname,position,ad_username,password,email,tel,is_active,created_by,created_at,updated_by,updated_at,delete_at")] LawsEntity lawsEntity)
        //{
        //    if (id != lawsEntity.id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(lawsEntity);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!LawsEntityExists(lawsEntity.id))
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
        //    return View(lawsEntity);
        //}

        //// GET: Laws/Delete/5
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var lawsEntity = await _context.laws
        //        .FirstOrDefaultAsync(m => m.id == id);
        //    if (lawsEntity == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(lawsEntity);
        //}

        //// POST: Laws/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(Guid id)
        //{
        //    var lawsEntity = await _context.laws.FindAsync(id);
        //    _context.laws.Remove(lawsEntity);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool LawsEntityExists(Guid id)
        //{
        //    return _context.laws.Any(e => e.id == id);
        //}
    }
}
