using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SFTAddonDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Content(string.Format("Hello World. Time is: {0}", DateTime.Now.ToString("t")));
        }

        public IActionResult Error()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return Content("Internal Server Error");
        }
    }
}
