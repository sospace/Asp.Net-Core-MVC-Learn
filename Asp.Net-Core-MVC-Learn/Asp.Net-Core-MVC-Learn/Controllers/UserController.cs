using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Net_Core_MVC_Learn.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Users Mange.";
            ViewData["NewMessage"] = "新变量.";
            return View();
        }
        public IActionResult TestInject(string msg)
        {
            return Ok(msg);
        }

        public IActionResult Source()
        {
            var url = Url.Action("Destination"); // Generates /custom/url/to/destination
            return Content($"Go check out {url}, it's really great.");
        }
        public IActionResult Des()
        {
            //var url = Url.Action("Buy", "Products", new { id = 17, color = "red" });
            var url = Url.Action("Buy", "Products", new { id = 17 }, protocol: Request.Scheme);
            return Content(url);
        }
        public string HelloMVC(string name, int age, int id, bool isEncode = false)
        {
            
            var text = $"You name:{name} and you age:{age}. encode={isEncode},id:{id}";
            if (isEncode)
                return HtmlEncoder.Default.Encode(text);
            else
                return text;
        }
    }
}