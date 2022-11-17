using shopxe.Areas.admin.hamxuli;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models;
namespace shopxe.Areas.admin.Controllers
{
    public class QuanlyloaiController : Controller
    {
        // GET: admin/Quanlyloai
        [kiemtradangnhap()]
        public ActionResult Index()
        {
            Database db = new Database();
            return View(db.loais.ToList());
        }
    }
}