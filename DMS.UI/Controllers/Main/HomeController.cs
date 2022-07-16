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
using System.Configuration;
using System.Data.SqlClient;
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
        MainEntities dba = new MainEntities();

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
            
            //List<producttable> all_data = db.producttables.ToList();
            //return View(all_data);
            
            return View();

        }
        [HttpPost]
        public ActionResult SavePhoto(regcustomer regcustomer, HttpPostedFileBase cphoto)
        {
            string path = Server.MapPath("~/Content/customerimage");
            string filename = cphoto.FileName;
            string newpath = path + "/" + filename;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            cphoto.SaveAs(newpath);

              int customerId = Convert.ToInt32(Session["cid"]);
            regcustomer.cphoto = ("~/Content/customerimage/" + filename);
            string aa = regcustomer.cphoto;
            //var customerData = db.regcustomers.Where(x => x.id == customerId).FirstOrDefault();
            int idd = Convert.ToInt32(Session["id"]);
            //db.Entry(regcustomer).State = System.Data.Entity.EntityState.Modified;
            //db.SaveChanges();
            string mainconn = ConfigurationManager.ConnectionStrings["IdentityConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            
            string sqlquery = "update regcustomer set cphoto='" + aa + "'where id='" + idd + "'";
            sqlconn.Open();
            SqlCommand sqlcomm=new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@cphoto", "a");
            sqlcomm.ExecuteNonQuery();



            return RedirectToAction("profile", "home");
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