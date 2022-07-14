using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DMS.DAL.DatabaseContext;

namespace DMS.Controllers.Main
{
    [AllowAnonymous]
    public class usersignupController : Controller
    {
        //
        // GET: usersignup
        MainEntities db;

        //
        public usersignupController()
        {
            db = new MainEntities();
        }
        public ActionResult views()
        {
            List<regcustomer> all_data = db.regcustomers.ToList();
            return View(all_data);
        }


     
        public ActionResult SaveData(regcustomer regcustomer)
        {
            db.regcustomers.Add(regcustomer);
            db.SaveChanges();

            return RedirectToAction("Index","home");
        }
    }
}