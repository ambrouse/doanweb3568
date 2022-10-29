using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shoptextno1.Models;
namespace shoptextno1.Controllers
{
    public class TruyenController : Controller
    {
        // GET: Truyen
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List() {
            dpshopEntities1 db = new dpshopEntities1();
            return View(db.truyens.ToList());
        }
        public ActionResult Listad()
        {
            dpshopEntities1 db = new dpshopEntities1();
            return View(db.truyens.ToList());
        }
        public ActionResult Them() {
            return View(new truyen());
        }
        [HttpPost]
        public ActionResult Them(truyen model, HttpPostedFileBase fileanh) {
            dpshopEntities1 db = new dpshopEntities1();
            if (fileanh == null) {
                ViewBag.err = "chua nhap anh";
                return View(model);
            }
            if (String.IsNullOrEmpty(model.ten) || String.IsNullOrEmpty(model.ten) || String.IsNullOrEmpty(model.mota) || String.IsNullOrEmpty(model.tinhtrang)) {
                ViewBag.err = "khong duoc de trong du lieu";
                return View(model);
            }
            if (model.gia == 0) {
                ViewBag.err = "gia phai khac khong";
                return View(model);
            }
            String x = Server.MapPath("/img/");
            string y = x + fileanh.FileName;
            fileanh.SaveAs(y);
            model.img = "/img/" + fileanh.FileName;
            int a = db.truyens.ToList().Count;
            
            model.id = a;
            foreach (var i in db.truyens.ToList())
            {
                if (i.id == model.id)
                {
                    List<truyen> b = db.truyens.ToList();
                    int z = b[a - 1].id + 1;
                    model.id = z;
                    break;
                }
            }
            db.truyens.Add(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int id){
            dpshopEntities1 db = new dpshopEntities1();
            var delete = db.truyens.Find(id);
            db.truyens.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Listad");
        }
        public ActionResult Update(int id) {
            dpshopEntities1 db = new dpshopEntities1();
            var update = db.truyens.Find(id);
            return View(update);
        }
        [HttpPost]
        public ActionResult Update(truyen model, HttpPostedFileBase fileanh)
        {
            dpshopEntities1 db = new dpshopEntities1();
            var update = db.truyens.Find(model.id);
            int a = db.truyens.ToList().Count;
            List<truyen> b = db.truyens.ToList();
            int z = b[a - 1].id + 1;
            if (fileanh != null)
            {
                String x = Server.MapPath("/img/");
                string y = x + fileanh.FileName;
                fileanh.SaveAs(y);
                model.img = "/img/" + fileanh.FileName;
            }
            if (String.IsNullOrEmpty(model.ten) || String.IsNullOrEmpty(model.ten) || String.IsNullOrEmpty(model.mota) || String.IsNullOrEmpty(model.tinhtrang))
            {
                ViewBag.err = "khong duoc de trong du lieu";
                return View(model);
            }
            if (model.gia == 0)
            {
                ViewBag.err = "gia phai khac khong";
                return View(model);
            } 
            update.ten = model.ten;
            update.tinhtrang = model.tinhtrang;
            update.gia = model.gia;
            update.mota = model.mota;
            update.idLoai = model.idLoai;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}