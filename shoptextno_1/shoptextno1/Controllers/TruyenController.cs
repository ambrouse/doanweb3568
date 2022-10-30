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
            return RedirectToAction("List");
        }
        public ActionResult List()
        {
            dpshopEntities1 db = new dpshopEntities1();
            return View(db.truyens.ToList());
        }
        public ActionResult Listtimkiem(String ten) {
            dpshopEntities1 db = new dpshopEntities1();
            List<pr_timkiemten_Result> timkiem = db.pr_timkiemten(ten).ToList();
            ViewBag.search = ten;
            return View(timkiem);
        }
       
        
    }
}