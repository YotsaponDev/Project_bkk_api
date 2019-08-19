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
using Project_bkk_api.Models.User;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http.Headers;

namespace Project_bkk_api.Controllers
{
    [Authorize]
    [Route("api/User")]
    public class UserController : Controller
    {
        private ILogger<UserController> _logger;

        private readonly IUser _user;

        public UserController(IUser user)
        {
            _user = user;
        }

        /// <summary>
        /// User get all data
        /// </summary>
        /// <remarks>
        /// User get all data
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns all data</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("")]
        [ProducesResponseType(typeof(List<UserViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetAll()
        {
            try
            {
                var data = _user.GetAll();
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// User get By Id
        /// </summary>
        /// <remarks>
        /// User get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [HttpGet("GetById")]
        [ProducesResponseType(typeof(List<UserViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var data = _user.GetById(id);
                return Json(data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(500, $"Exception while get list of items. {ex.Message}");
            }
        }

        /// <summary>
        /// User get By Id
        /// </summary>
        /// <remarks>
        /// User get By Id
        /// </remarks>
        /// <returns>Return all data</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpGet("GetByIdViaJWT")]
        [ProducesResponseType(typeof(UserReturnViewModel), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult GetByIdViaJWT()
        {
            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                if (authHeader == null)
                {
                    throw new Exception("Authorization none");
                }
                else
                {
                    var data = _user.GetByIdViaJWT(authHeader.ToString());
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
        /// User create item
        /// </summary>
        /// <remarks>
        /// User create item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="409">Conflict</response>  
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(typeof(List<UserViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(409)]
        public IActionResult Create([FromBody] UserEntity model)
        {
            try
            {
                if (model != null)
                {
                    var x = _user.Create(model);
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
        /// User Login
        /// </summary>
        /// <remarks>
        /// User Login
        /// </remarks>
        /// <returns>Return user login</returns>
        /// <response code="200">Returns token</response>
        /// <response code="500">Error Occurred</response>  
        [AllowAnonymous]
        [Route("Login")]
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        public IActionResult Login([FromBody] UserLoginViewModel model)
        {
            try
            {
                if (model != null)
                {
                   var x = _user.Login(model);
                    return Json(x);
                }
                return null;
            }
            catch (Exception ex)
            {
                //_logger.LogCritical($"Exception while get list of items.", ex);
                return StatusCode(403, "Forbidden");
            }
        }

        /// <summary>
        /// User Update item
        /// </summary>
        /// <remarks>
        /// User Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(List<UserViewModel>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public IActionResult Update(Guid id, [FromBody] UserEntity model)
        {
            try
            {
                if (id == null)
                {
                    return StatusCode(400, $"ID is not valid.");
                }
                else
                {
                    var res = _user.Update(id, model);
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
        /// User Update item
        /// </summary>
        /// <remarks>
        /// User Update item
        /// </remarks>
        /// <returns>Return create item</returns>
        /// <response code="200">Returns the item</response>
        /// <response code="500">Error Occurred</response>  
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(List<UserViewModel>), 200)]
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
                    var res = _user.Delete(id);
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
