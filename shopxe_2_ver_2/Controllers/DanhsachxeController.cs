using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models;
namespace shopxe.Controllers
{
    public class DanhsachxeController : Controller
    {
        // GET: Danhsachxe
        public ActionResult Index()
        {
            return RedirectToAction("Danhsachxemoinhat");
        }
        public ActionResult Danhsachxemoinhat() {
            Database db = new Database(); 
            var list = (from x in db.sanphams orderby x.id descending select x).ToList();
            return View(list);
        }
        public ActionResult timkiem(String name,String loai,String hang) {
            Database db = new Database();
            var list = db.sanphams.Where(x => x.ten.ToLower().Contains(name.ToLower()));
            return View(list);
        }

    }
}