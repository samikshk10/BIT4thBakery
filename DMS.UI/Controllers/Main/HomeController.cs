using AutoMapper;
using DMS.DAL.DatabaseContext;
using DMS.DAL.Interfaces;
using DMS.DAL.Repositories.MainRepo;
using DMS.DAL.StaticHelper;
using DMS.Services.General.Interface;
using DMS.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DMS.Controllers
{
    [AllowAnonymous]//change
    public class HomeController : Controller
    {
        private MainEntities db;
        private SystemInfoForSession _ActiveSession;
        private IBranchesRepo _BranchesRepo;

        public HomeController(MainEntities _db, IBranchesRepo BranchesRepo)
        {
            _ActiveSession = SessionHelper.GetSession();
            db = _db;
            _BranchesRepo = BranchesRepo;
        }
        SystemInfoForSession systemSession = SessionHelper.GetSession();

        public ActionResult AccessDeniedPage()
        {
            return View();
        }

        public ActionResult profile()
        {
            return View("profile");
        }

        public ActionResult Index()
        {
            List<producttable> all_data = db.producttables.ToList();
            string path = Server.MapPath("~/Content/productimage");

            string[] imagesfiles = Directory.GetFiles(path);
            ViewBag.productimage = imagesfiles;
            return View(all_data);
            
        }
        //[HttpGet]
        //    public ActionResult Index(int id)
        //{
        //    producttable producttable = new producttable();
        //    using (MainEntities db= new MainEntities())
        //    {
        //        producttable = db.producttables.Where(x => x.pid == id).FirstOrDefault();
        //    }
        //    return View(producttable);
            
        //}

        
        //asdf

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
            ////
            /////
        }
        public ActionResult viewallgallery()
        {
           
            string path = Server.MapPath("~/Content/productimage");

            string[] imagesfiles = Directory.GetFiles(path);
            ViewBag.productimage = imagesfiles;
           
            return View("viewallgallery");
        }

        public ActionResult category()
        {

           List<producttable> all_data = db.producttables.ToList();
            return View(all_data);
           
        }


        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult logout()
        {
            Session.Clear();
           return RedirectToAction("index", "home");
        }

       

        public async Task<ActionResult> Dashboard()
        {
            return RedirectToAction("Index");////
        }



       

    }
}