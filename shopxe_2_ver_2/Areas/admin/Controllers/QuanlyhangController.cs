using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Areas.admin.hamxuli;
using shopxe_2.Models;

namespace shopxe_2.Areas.admin.Controllers
{
    public class QuanlyhangController : Controller
    {
        // GET: admin/Quanlyhang
        [kiemtradangnhap()]
        public ActionResult Index(String name)
        {
            Database db = new Database();
            if (name == null) {
                return View(db.hangs.ToList());
            }
            return View(db.hangs.Where(c => c.ten.ToLower().Contains(name.ToLower())).ToList());
        }
        public ActionResult Them()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Them(hang model)
        {
            maping_hang h = new maping_hang();
            if (String.IsNullOrEmpty(model.ten))
            {
                ViewBag.err = "khong dc de trong du lieu";
            }
            if (h.Them(model) == -1)
            {
                ViewBag.err = "da co loi xay ra ";
            }
            else
            {
                h.Them(model);
            }
            return RedirectToAction("Index");
        }
        [kiemtradangnhap()]
        public ActionResult Capnhat(int id)
        {
            return View(new maping_hang().chitiet(id));
        }
        [HttpPost]
        public ActionResult Capnhat(hang model)
        {
            maping_hang h = new maping_hang();
            if (String.IsNullOrEmpty(model.ten))
            {
                ViewBag.err = "khong dc de trong du lieu";
            }
            if (h.capnhat(model) == -1)
            {
                ViewBag.err = "da co loi xay ra ";
            }
            else
            {
                h.capnhat(model);
            }
            return RedirectToAction("Index");
        }
        [kiemtradangnhap()]
        public ActionResult Xoa(int id)
        {
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