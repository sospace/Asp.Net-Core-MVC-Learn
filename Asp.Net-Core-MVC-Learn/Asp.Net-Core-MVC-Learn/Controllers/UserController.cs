using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        //文件上传
        public async Task<IActionResult> Upload(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { count = files.Count, size, filePath });
        }
    }
}