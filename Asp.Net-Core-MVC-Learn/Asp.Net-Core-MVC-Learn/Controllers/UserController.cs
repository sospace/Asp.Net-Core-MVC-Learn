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
        public IActionResult TestInject()
        {
            return Json("ok");
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