using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using card.Models;
namespace card.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List() {
            qltruyenEntities db = new qltruyenEntities();
            return View(db.Truyens);
        }
        public ActionResult Themm()
        {

            return View(new Truyen());
        }
        [HttpPost]
        public ActionResult Themm(Truyen model, HttpPostedFileBase Fileanh) {
            qltruyenEntities db = new qltruyenEntities();
            if (model.id < 0) {
                ViewBag.text = "id phai lon hon 0";
                return View(model);
            }
            foreach (var i in db.Truyens) {
                if (i.id == model.id) {
                    ViewBag.text = "id da ton tai";
                    return View(model);
                }
            }
            if (Fileanh == null)
            {
                ViewBag.text = "chua nhap anh";
                return View(model);
            }
            String x = Server.MapPath("/img/");
            String y = x + Fileanh.FileName;
            ViewBag.text = y;
            Fileanh.SaveAs(y);
            model.imgUrl = "/img/" + Fileanh.FileName;
            db.Truyens.Add(model);
            db.SaveChanges();
            return RedirectToAction("Listad");
        }
        public ActionResult Listad() {
            qltruyenEntities db = new qltruyenEntities();
            return View(db.Truyens);
        }
        public ActionResult Delete(int id) {
            qltruyenEntities db = new qltruyenEntities();
            var delete = db.Truyens.Find(id);
            db.Truyens.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Listad");
        }
        public ActionResult Chitietsp(int ID) {
            qltruyenEntities db = new qltruyenEntities();
            Truyen ct = db.Truyens.Find(ID);
            
            return View(ct);
        }
    }
}