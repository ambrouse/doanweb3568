using shoptextno1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace shoptextno1.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: admin/Admin
        public ActionResult Index()
        {
            if (Session["name"] == null)
            {
                return RedirectToAction("Dangnhap");
            }
            return View();
        }
        public ActionResult Dangnhap(){
            return View();
        }
        [HttpPost]
        public ActionResult Dangnhap(String name, String pass)
        {
            if (name.ToLower() == "admin" && pass == "3568")
            {
                Session["name"] = name;
            }
            else{
                TempData["err"] = "thong tin dang nhap sai";
                return View();
            }
            return RedirectToAction("index");
        }
        public ActionResult Dangxuat() {
            Session.Remove("name");
            FormsAuthentication.SignOut();
            return RedirectToAction("Dangnhap");
            
        }
        public ActionResult Listad()
        {
            dpshopEntities1 db = new dpshopEntities1();
            return View(db.truyens.ToList());
        }
        public ActionResult Them()
        {
            return View(new truyen());
        }
        [HttpPost]
        public ActionResult Them(truyen model, HttpPostedFileBase fileanh)
        {
            dpshopEntities1 db = new dpshopEntities1();
            if (fileanh == null)
            {
                ViewBag.err = "chua nhap anh";
                return View(model);
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
            return RedirectToAction("Listad");
        }
        public ActionResult Delete(int id)
        {
            dpshopEntities1 db = new dpshopEntities1();
            var delete = db.truyens.Find(id);
            db.truyens.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Listad");
        }
        public ActionResult Update(int id)
        {
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
            return RedirectToAction("Listad");
        }
        public ActionResult Listloaitruyen()
        {
            dpshopEntities1 db = new dpshopEntities1();
            return View(db.theloais.ToList());
        }
        public ActionResult Themloaitruyen()
        {
            return View(new theloai());
        }
        [HttpPost]
        public ActionResult Themloaitruyen(theloai model)
        {
            dpshopEntities1 db = new dpshopEntities1();
            if (model.id <= 0)
            {
                ViewBag.err = "id phia lon hon khong";
                return View(model);
            }
            foreach (var i in db.theloais.ToList())
            {
                if (i.id == model.id)
                {
                    ViewBag.err = "id da ton tai";
                    return View(model);
                }
            }
            if (String.IsNullOrEmpty(model.ten))
            {
                ViewBag.err = "khong dc de trong du lieu";
                return View(model);
            }
            db.theloais.Add(model);
            db.SaveChanges();
            return RedirectToAction("listloaitruyen");
        }
        public ActionResult Deleteloaitruyen(int id)
        {
            dpshopEntities1 db = new dpshopEntities1();
            db.theloais.Remove(db.theloais.Find(id));
            db.SaveChanges();
            return RedirectToAction("Listloaitruyen");

        }
        public ActionResult Updateloaitruyen(int id)
        {
            dpshopEntities1 db = new dpshopEntities1();
            return View(db.theloais.Find(id));
        }
        [HttpPost]
        public ActionResult Updateloaitruyen(theloai model)
        {
            dpshopEntities1 db = new dpshopEntities1();
            var update = db.theloais.Find(model.id);
            if (String.IsNullOrEmpty(model.ten))
            {
                ViewBag.err = "khong dc de trong du lieu";
                return View(model);
            }
            update.ten = model.ten;
            db.SaveChanges();
            return RedirectToAction("Listloaitruyen");
        }

    }
}