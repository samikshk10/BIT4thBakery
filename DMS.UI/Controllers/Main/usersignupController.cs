﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using DMS.DAL.DatabaseContext;
using System.IO;

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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SaveData(regcustomer regcustomer)
        {
           
            
                db.regcustomers.Add(regcustomer);
                db.SaveChanges();
            Session["IDUsSS"] = regcustomer.id.ToString();
            Session["fullnamess"] = regcustomer.cfullname.ToString();

            return RedirectToAction("Index", "home");
        }

        [HttpPost]
        public ActionResult Index(string namesearch)
        {
            var results = db.regcustomers.Where(x => x.cfullname == namesearch).ToList();
            return View(results);
        }
    }
}