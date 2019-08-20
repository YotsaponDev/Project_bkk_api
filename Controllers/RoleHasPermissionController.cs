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
    [Route("api/RoleHasPermission")]
    public class RoleHasPermissionController : Controller
    {
        private ILogger<RoleHasPermissionController> _logger;

        private readonly IRoleHasPermission _role_has_permission;

        public RoleHasPermissionController(IRoleHasPermission role_has_permission)
        {
            _role_has_permission = role_has_permission;
        }

        /// <summary>
        /// RoleHasPermission get all data
        /// </summary>
        /// <remarks>
        /// RoleHasPermission get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("")]
        [ProducesResponseType(typeof(List<RoleHasPermissionEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _role_has_permission.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// RoleHasPermission get By Id
        /// </summary>
        /// <remarks>
        /// RoleHasPermission get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<RoleHasPermissionEntity>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _role_has_permission.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// RoleHasPermission create item
        /// </summary>
        /// <remarks>
        /// RoleHasPermission create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPost]
        [ProducesResponseType(typeof(List<RoleHasPermissionViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Create([FromBody] RoleHasPermissionViewModel model)
        {
            try
            {
                if (model != null)
                {
                    _role_has_permission.Create(model);
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
        /// RoleHasPermission Update item
        /// </summary>
        /// <remarks>
        /// RoleHasPermission Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        //[HttpPut("{id}")]
        //[ProducesResponseType(typeof(List<RoleHasPermissionEntity>), 200)]
        //[ProducesResponseType(400)]
        //[ProducesResponseType(500)]
        //public IActionResult Update(Guid id, [FromBody] RoleHasPermissionEntity model)
        //{
        //    try
        //    {
        //        if (id == null)
        //        {
        //            return StatusCode(400, $"ID is not valid.");
        //        }
        //        else
        //        {
        //            var res = _role_has_permission.Update(id, model);
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
        /// RoleHasPermission Update item
        /// </summary>
        /// <remarks>
        /// RoleHasPermission Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<RoleHasPermissionEntity>), 200)]
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
                    var res = _role_has_permission.Delete(id);
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
