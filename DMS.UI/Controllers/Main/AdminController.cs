using DMS.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DMS.Controllers.Main
{
    
    public class AdminController : Controller
    {
        // GET: Admin
        MainEntities db=new MainEntities();
        public ActionResult Index()
        {
            Count();
          return View();
            
        }
        public void Count()
        {
            ViewBag.displayproduct = db.producttables.ToList();
            ViewBag.Count = db.producttables.Count();
            ViewBag.Count1 = db.regcustomers.Count();


        }

        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "home");
        }
    }
}