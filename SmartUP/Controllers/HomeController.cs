using SmartUP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartUP.Controllers
{
    public class HomeController : Controller
    {
    // GET: Index
    public ActionResult Dash()
        {
            return View();
        }
    }
}