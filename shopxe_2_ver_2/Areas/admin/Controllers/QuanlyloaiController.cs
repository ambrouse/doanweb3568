using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models;
using shopxe_2.Areas.admin.hamxuli;
using System.Xml.Linq;

namespace shopxe_2.Areas.admin.Controllers
{
    public class QuanlyloaiController : Controller
    {
        // GET: admin/Quanlyloai
        [kiemtradangnhap()]
        public ActionResult Index(String name)
        {
            Database db = new Database();
            if (name == null)
            {
                return View(db.loais.ToList());
            }
            return View(db.loais.Where(c => c.ten.ToLower().Contains(name.ToLower())).ToList());
        }
        [kiemtradangnhap()]
        public ActionResult Them() {
            return View();
        }
        [HttpPost]
        public ActionResult Them(loai model) {
            maping_loai l = new maping_loai();
            if (String.IsNullOrEmpty(model.ten)) {
                ViewBag.err = "khong dc de trong du lieu";
            }
            if (l.Them(model) == -1)
            {
                ViewBag.err = "da co loi xay ra ";
            }
            else {
                l.Them(model);
            }
            return RedirectToAction("Index");
        }
        [kiemtradangnhap()]
        public ActionResult Capnhat(int id)
        {
            return View(new maping_loai().chitiet(id));
        }
        [HttpPost]
        public ActionResult Capnhat(loai model)
        {
            maping_loai l = new maping_loai();
            if (String.IsNullOrEmpty(model.ten))
            {
                ViewBag.err = "khong dc de trong du lieu";
            }
            if (l.capnhat(model) == -1)
            {
                ViewBag.err = "da co loi xay ra ";
            }
            else
            {
                l.capnhat(model);
            }
            return RedirectToAction("Index");
        }
        [kiemtradangnhap()]
        public ActionResult Xoa(int id) {
            var l = new maping_loai();
            if (l.xoa(id) == -1)
            {
                ViewBag.err = "da co loi xay ra ";
            }
            else
            {
                l.xoa(id);
            }
            return RedirectToAction("index");

        }
    }
}