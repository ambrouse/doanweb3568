using shopxe.Areas.admin.hamxuli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models;
using System.Web.Security;

namespace shopxe.Areas.admin.Controllers
{
    public class DangnhapadminController : Controller
    {
        // GET: admin/Dangnhapadmin
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(String name,String pass)
        {
            Database db = new Database();
            var check = new kiemtramatkhau().kiemtra(name, pass);
            if (check == true)
            {
                Session["ad"] = db.admins.Find(1);
                return RedirectToAction("Index", "Quanlyxe");
            }
            else {
                ViewBag.err = "sai tai khoan hoat mat khau";
                return View();
            }
            
        }
        public ActionResult Dangxuat() {
            Session.Remove("ad");
            FormsAuthentication.SignOut();
            return RedirectToAction("index");
        }
    }
}