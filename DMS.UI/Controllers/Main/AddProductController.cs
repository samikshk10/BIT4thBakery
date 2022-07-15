using DMS.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace DMS.Controllers.Main
{
    public class addproductController : Controller
    {
        // GET: addproduct
        MainEntities db;

        //
        public addproductController()
        {
            db = new MainEntities();
        }

        public ActionResult Index()
        {
            List<producttable> all_data = db.producttables.ToList();
            return View(all_data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveData(producttable producttable, HttpPostedFileBase pimage)
        {
            string path = Server.MapPath("~/Content/productimage");
            string filename = pimage.FileName;
            string newpath = path + "/" + filename;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            pimage.SaveAs(newpath);
            producttable.pimage = "~/Content/productimage/" + filename;
           




            db.producttables.Add(producttable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult edit(int id)
        {
            producttable data = db.producttables.Find(id);//find data using primary key
            //employee_table data = db.employee_table.FirstOrDefault(x => x.id == id); want to find not from id but from other
            return View(data); 
        }

        public ActionResult updatedata(producttable producttable)
        {
            db.Entry(producttable).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult deletedata(int pid)
        {
            producttable data = db.producttables.Find(pid);
            db.producttables.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Index(string namesearch)
        {
           var results = db.producttables.Where(x => x.pname == namesearch).ToList();
          return View(results);
        }
        //[HttpPost]
        //public ActionResult Index(int id, string name)
        //{
        //    var result = db.producttables.Where(x => x.pid == id).ToList();
        //    return View(result);

        //}
    }
}