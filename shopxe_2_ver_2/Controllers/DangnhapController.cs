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
                    db.users.FirstOrDefault(c => c.email == model.email).sodt = model.sodt;
                    db.users.FirstOrDefault(c => c.email == model.email).ten = model.ten;
                    db.SaveChanges();
                Session["user"] = db.users.FirstOrDefault(c=>c.email==model.email);
                return RedirectToAction("index","Danhsachxe");
            }
            db.users.Add(model);
            Session["user"] = db.users.Find(model.id);
            db.SaveChanges();
            return RedirectToAction("Index","Trangchu");
        }

    }
}