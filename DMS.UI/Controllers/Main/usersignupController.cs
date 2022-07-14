using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DMS.Controllers.Main
{
    [AllowAnonymous]
    public class usersignupController : Controller
    {
        //
        // GET: usersignup
        public ActionResult Index()
        {
            return View();
        }
    }
}