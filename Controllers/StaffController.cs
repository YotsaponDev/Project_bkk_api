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
    }
}
