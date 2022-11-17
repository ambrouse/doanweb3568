using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe.Areas.admin.hamxuli;
using shopxe_2.Models;
namespace shopxe.Areas.admin.Controllers
{
    public class QuanlyhangController : Controller
    {
        // GET: admin/Quanlyhang
        [kiemtradangnhap()]
        public ActionResult Index()
        {
            Database db = new Database();
                return View(db.hangs.ToList());
        }
    }
}