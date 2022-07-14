using DMS.DAL.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        public ActionResult SaveData(producttable producttable)
        {
            db.producttables.Add(producttable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int pid)
        {
            producttable old_data = db.producttables.Find(pid);//find data using primary key
            //employee_table data = db.employee_table.FirstOrDefault(x => x.id == id); want to find not from id but from other
            return View(old_data); ;
        }
        public ActionResult UpdateData(producttable producttable)
        {
            db.Entry(producttable).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        [HttpPost]
        public ActionResult Index(string name)
        {
            var results = db.producttables.Where(x => x.pname == name).ToList();
            return View(results);
        }
        [HttpPost]
        public ActionResult Index(int id, string name)
        {
            var result = db.producttables.Where(x => x.pid == id).ToList();
            return View(result);
            var results = db.producttables.Where(x => x.pname == name).ToList();
            return View(results);
        }
    }
}