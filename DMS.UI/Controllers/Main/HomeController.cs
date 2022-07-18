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

        List<Cart> li = new List<Cart>();
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

        //public ActionResult ordernow(ordertable ordertable)
        //{

        //    db.ordertables.Add(ordertable);
        //    db.SaveChanges();

        //    return RedirectToAction("index", "home");
        //}

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
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlcomm.Parameters.AddWithValue("@cphoto", "a");
            sqlcomm.ExecuteNonQuery();



            return RedirectToAction("profile", "home");
        }

        public ActionResult Index()
        {
            if (TempData["cart"] != null)
            {
                double x = 0;
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                foreach (var item in li2)
                {
                    x += item.bill;
                }
                TempData["total"] = x;
                TempData["item_count"] = li2.Count();
            }

            TempData.Keep();


            List<producttable> all_data = db.producttables.ToList();
            string path = Server.MapPath("~/Content/productimage");

            string[] imagesfiles = Directory.GetFiles(path);
            ViewBag.productimage = imagesfiles;
            return View(all_data);

        }

        [HttpGet]
        public ActionResult Single(int id)
        {
            var query = db.producttables.Where(x => x.pid == id).SingleOrDefault();
            return View(query);
        }
        [HttpPost]
        public ActionResult Single(int id, int qty)
        {
            producttable p = db.producttables.Where(x => x.pid == id).SingleOrDefault();
            Cart c = new Cart();
            
            c.pid = id;
            c.pname = p.pname;
            c.price = Convert.ToDouble(p.pprice);
            c.qty = Convert.ToInt32(qty);
            c.bill = c.price * c.qty;
            if (TempData["cart"] == null)
            {
                li.Add(c);
                TempData["cart"] = li;
            }
            else
            {
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                int flag = 0;
                foreach (var item in li2)
                {
                    if (item.pid == c.pid)
                    {
                        item.qty += c.qty;
                        item.bill += c.bill;
                        flag = 1;
                    }
                }
                if (flag == 0)
                {
                    li2.Add(c);
                }
                TempData["cart"] = li2;
            }
            TempData.Keep();
            return RedirectToAction("index");
        }

        public ActionResult Checkout()
        {
            TempData.Keep();
            return View();
        }

        public ActionResult Checkou()
        {


            if (ModelState.IsValid)
            {

                List<Cart> li2 = TempData["cart"] as List<Cart>;
                var random = new Random();
                const string Charss = "0123456789";
                var result1 = new string(
                    Enumerable.Repeat(Charss, 5)
                        .Select(s => s[random.Next(s.Length)])
                        .ToArray());
                invoicetable iv = new invoicetable();
                iv.id = Convert.ToInt32(Session["cid"].ToString());
                iv.invoicedate = System.DateTime.Now;
                iv.bill = Convert.ToDecimal(TempData["total"]);
                iv.payment = "cash";
                iv.invoiceid = result1;
                db.invoicetables.Add(iv);
                db.SaveChanges();


                foreach (var item in li2)
                {
                    
                    ordertable ot = new ordertable();
                  
                    const string Chars = "ABCDEFGHIJKLMNPOQRSTUVWXYZ0123456789";
                    var result = new string(
                        Enumerable.Repeat(Chars, 9)
                            .Select(s => s[random.Next(s.Length)])
                            .ToArray());

                    ot.pid = item.pid;
                    ot.odate = System.DateTime.Now;

                    ot.invoiceid = iv.invoiceid;
                    ot.oid = "#" + result;
                    ot.oqty = item.qty;
                    ot.oprice = Convert.ToDecimal(item.price);
                    ot.oamount = Convert.ToDecimal(item.bill);
                    ot.id = Convert.ToInt32(Session["cid"]);
                    db.ordertables.Add(ot);
                    db.SaveChanges();




                }
                TempData.Remove("total");
                TempData.Remove("cart");
                TempData.Remove("item_count");
                TempData["msg"] = "order place successfully";
                return RedirectToAction("index");
            }
           
                TempData.Keep();
            return View("Checkout");

                
            
        }

        public ActionResult remove(int? id)
        {
            if(TempData["cart"]==null)
            {
                TempData.Remove("total");
                TempData.Remove("cart");
            }
            else
            {
                List<Cart> li2 = TempData["cart"] as List<Cart>;
                Cart c = li2.Where(x => x.pid == id).SingleOrDefault();
                li2.Remove(c);
                double s = 0;
                foreach(var item in li2)
                {
                    s += item.bill;
                }
                TempData["total"] = s;

            }
            return RedirectToAction("index");
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

        public ActionResult Getalluserorderdetail(int id)
        {
            var query = db.getallorderusers.Where(x => x.id == id).ToList();
            return View(query);
        }

        public ActionResult getallorder()
        {
            var query = db.getallorders.ToList();
            return View(query);
        }
       

        public async Task<ActionResult> Dashboard()
        {
            return RedirectToAction("Index");////
        }



       

    }
}