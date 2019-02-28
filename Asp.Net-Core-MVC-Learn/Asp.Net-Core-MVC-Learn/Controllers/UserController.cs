using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_MVC_Learn.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Users Mange.";
            return View();
        }
    }
}