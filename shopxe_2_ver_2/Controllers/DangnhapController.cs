using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models.hamxuly;
using shopxe_2.Models;
namespace shopxe_2.Controllers
{
    public class DangnhapController : Controller
    {
        // GET: Dangnhap
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user model)
        {
            Database db = new Database();
            if (new kiemtradangnhap().kiemtra(model.email) == true) {
                if (String.IsNullOrEmpty(model.ten) && String.IsNullOrEmpty(model.sodt.ToString()))
                {
                    Session["user"] = db.users.FirstOrDefault(c => c.email == model.email);
                    return RedirectToAction("index", "Danhsachxe");
                }
                else {
                    if (String.IsNullOrEmpty(model.email) || String.IsNullOrEmpty(model.ten))
                    {
                        ViewBag.err = "khong duoc bo trong du lieu";
                        return View();
                    }

                    if (model.sodt.ToString().Length< 9|| model.sodt.ToString().Length>=10)
                    {
                        ViewBag.err = "so dien thoai khong dung dinh dang";
                        return View();
                    }
                    var x = db.users.FirstOrDefault(c => c.email == model.email);
                    x.ten = model.ten;
                    x.sodt = model.sodt;
                    x.email=model.email;
                    Session["user"] = db.users.FirstOrDefault(c => c.email == model.email);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Danhsachxe");
                }
            }
            if (String.IsNullOrEmpty(model.email) || String.IsNullOrEmpty(model.ten))
            {
                ViewBag.err = "khong duoc bo trong du lieu";
               return View();
            }

            if (model.sodt.ToString().Length < 10 || model.sodt.ToString().Length >= 11)
            {
                ViewBag.err = "so dien thoai khong dung dinh dang";
                return View();
            }

            db.users.Add(model);
            Session["user"] = db.users.Find(model.id);
            db.SaveChanges();
            return RedirectToAction("Index", "Danhsachxe");
        }

    }
}