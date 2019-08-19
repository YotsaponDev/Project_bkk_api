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
using Project_bkk_api.Models.Staff;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace Project_bkk_api.Controllers
{
    [Authorize]
    [Route("api/Staff")]
    public class StaffController : Controller
    {
        private ILogger<StaffController> _logger;

        private readonly IStaff _staff;

        public StaffController(IStaff staff)
        {
            _staff = staff;
        }

        /// <summary>
        /// Staff get all data
        /// </summary>
        /// <remarks>
        /// Staff get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(List<StaffViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _staff.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Staff get By Id
        /// </summary>
        /// <remarks>
        /// Staff get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<StaffViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _staff.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Staff get By Id via JWT
        /// </summary>
        /// <remarks>
        /// Staff get By Id via JWT
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("GetByIdViaJWT")]
        [ProducesResponseType(typeof(StaffReturnViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetByIdViaJWT()
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                if (authHeader == null)
                {
                    throw new Exception("AuthorizationNone");
                }
                else
                {
                    var data = _staff.GetByIdViaJWT(authHeader.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Staff create item
        /// </summary>
        /// <remarks>
        /// Staff create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="409">Conflict</response>  
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<StaffViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult Create([FromBody] StaffEntity model)
        {
            try
            {
                if (model != null)
                {
                    var x = _staff.Create(model);
                    return Json(x);
                }
                else
                {
                    return Json(model);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(409, $"{ex.Message}");
            }
        }

        /// <summary>
        /// Staff Login
        /// </summary>
        /// <remarks>
        /// Staff Login
        /// </remarks>
        /// <returns>Return staff login</returns>
        /// <response code="200">Returns token</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Login([FromBody] StaffLoginViewModel model)
        {
            try
            {
                if (model != null)
                {
                    var x = _staff.Login(model);
                    return Json(x);
                }
                return null;
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(401, "LoginFailure");
            }
        }

        /// <summary>
        /// Staff Update item
        /// </summary>
        /// <remarks>
        /// Staff Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<StaffViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Update(Guid id, [FromBody] StaffEntity model)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    var res = _staff.Update(id, model);
                    return Json(res);
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// Staff Update item
        /// </summary>
        /// <remarks>
        /// Staff Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<StaffViewModel>), 200)]
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
                    var res = _staff.Delete(id);
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
