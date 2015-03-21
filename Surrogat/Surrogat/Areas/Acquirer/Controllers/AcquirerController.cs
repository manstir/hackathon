using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Surrogat.Areas.Acquirer.Controllers
{
    public class AcquirerController : Controller
    {
        public ActionResult Index()
        {
            return View("index");
        }
    }
}