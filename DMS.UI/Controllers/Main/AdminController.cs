using DMS.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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

        public ActionResult addgallery()
        {
            return View();
        }

        public ActionResult addgallerys(HttpPostedFileBase galleryphoto)
        {
            string path = Server.MapPath("~/Content/galleryphoto");
            string filename =galleryphoto.FileName;
            string newpath = path + "/" + filename;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            galleryphoto.SaveAs(newpath);
            return View("addgallery");
        }
        public void Count()
        {
            ViewBag.displayproduct = db.producttables.ToList();
            ViewBag.Count = db.producttables.Count();
            ViewBag.Count1 = db.regcustomers.Count();
            ViewBag.Count2 = db.ordertables.Count();
            ViewBag.Total = db.ordertables.Sum(x => x.oamount);
            //string query = @"select * from ordertable;";
            //SqlCommand cmd=new SqlCommand(query);

            //var adapter = new SqlDataAdapter(cmd);
            //adapter.Fill(ds);
            //ViewBag.Count3 = db.ordertables[4].Select().Sum(w => (double)w["oamount"]);






        }

        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie adAuthCookie = FormsAuthentication.GetAuthCookie(FormsAuthentication.FormsCookieName, false);
            adAuthCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(adAuthCookie);
            return RedirectToAction("index", "home");
        }
    }
}