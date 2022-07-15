using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Controllers.Main
{
    public class favouriteController : Controller
    {
        // GET: favourite
        public ActionResult Index()
        {
            return View();
        }
    }
}