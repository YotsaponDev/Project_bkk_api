using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Project_bkk_api.Controllers
{
    public class TestController : Controller
    {
        /// <summary>
        /// Test Get
        /// </summary>
        [HttpGet("Test/")]
        public JsonResult GetAll()
        {

            var name = new { name = "Hello World!" };

            return Json(name);
        }
    }
}