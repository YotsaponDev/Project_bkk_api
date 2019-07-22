using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_bkk_api.Models;
using Project_bkk_api.Models.Test;

namespace Project_bkk_api.Controllers
{
    public class TestController : Controller
    {
        private ILogger<TestController> _logger;

        private readonly TestContext _context;

        public TestController(TestContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Test Get
        /// </summary>
        /// <remarks>
        /// Remark na
        /// </remarks>
        /// <returns>Return list of items by request_id</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("Test")]
        [ProducesResponseType(typeof(List<TestViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Index()
        {
            try
            {
                return Json(await _context.test.ToListAsync());
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        // GET: Test/Details/5
        [HttpGet("Test/GeyById/{id}")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testEntity = await _context.test
                .FirstOrDefaultAsync(m => m.id == id);
            if (testEntity == null)
            {
                return NotFound();
            }

            return View(testEntity);
        }

        // GET: Test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,fullname,age,email,date,address,remark")] TestEntity testEntity)
        {
            if (ModelState.IsValid)
            {
                testEntity.id = Guid.NewGuid();
                _context.Add(testEntity);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testEntity);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testEntity = await _context.test.FindAsync(id);
            if (testEntity == null)
            {
                return NotFound();
            }
            return View(testEntity);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("id,fullname,age,email,date,address,remark")] TestEntity testEntity)
        {
            if (id != testEntity.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestEntityExists(testEntity.id))
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
            return View(testEntity);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testEntity = await _context.test
                .FirstOrDefaultAsync(m => m.id == id);
            if (testEntity == null)
            {
                return NotFound();
            }

            return View(testEntity);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var testEntity = await _context.test.FindAsync(id);
            _context.test.Remove(testEntity);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestEntityExists(Guid id)
        {
            return _context.test.Any(e => e.id == id);
        }
    }
}