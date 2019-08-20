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
using Project_bkk_api.Models.Permission;

namespace Project_bkk_api.Controllers
{
    [Route("api/StaffHasRole")]
    public class StaffHasRoleController : Controller
    {
        private ILogger<StaffHasRoleController> _logger;

        private readonly IStaffHasRole _staff_has_role;

        public StaffHasRoleController(IStaffHasRole staff_has_role)
        {
            _staff_has_role = staff_has_role;
        }

        /// <summary>
        /// StaffHasRole get all data
        /// </summary>
        /// <remarks>
        /// StaffHasRole get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("")]
        [ProducesResponseType(typeof(List<StaffHasRoleViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _staff_has_role.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// StaffHasRole get By Id
        /// </summary>
        /// <remarks>
        /// StaffHasRole get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<StaffHasRoleViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _staff_has_role.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// StaffHasRole create item
        /// </summary>
        /// <remarks>
        /// StaffHasRole create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPost]
        [ProducesResponseType(typeof(List<StaffHasRoleViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] StaffHasRoleViewModel model)
        {
            try
            {
                if (model != null)
                {
                    _staff_has_role.Create(model);
                }
                return Json(model);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// StaffHasRole Update item
        /// </summary>
        /// <remarks>
        /// StaffHasRole Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(List<StaffHasRoleEntity>), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public IActionResult Update(Guid id, [FromBody] StaffHasRoleEntity model)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return StatusCode(400, $"ID is not valid.");
        //        }
        //        else
        //        {
        //            var res = _staff_has_role.Update(id, model);
        //            return Json(res);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogCritical($"Exception while get list of items.", ex);
        //        return StatusCode(500, $"Exception while get list of items. {ex.Message}");
        //    }
        //}

        /// <summary>
        /// StaffHasRole Update item
        /// </summary>
        /// <remarks>
        /// StaffHasRole Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<StaffHasRoleViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    var res = _staff_has_role.Delete(id);
                    return Json(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }
    }
}
