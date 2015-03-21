using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surrogat.Controllers
{
    using Surrogat.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        [HttpGet]
        public ActionResult Save(string fieldname)
        {
            var repo = new TestRepository();
            repo.InsertEntry(new TestBE() { TestField = fieldname });

            return RedirectToAction("index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Merchant()
        {
            return View();
        }
    }
}
