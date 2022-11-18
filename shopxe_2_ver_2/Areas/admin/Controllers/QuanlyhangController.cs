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
        public ActionResult Index()
        {
            Database db = new Database();
                return View(db.hangs.ToList());
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
                ViewBag.err = "Vui lòng nhập tên";
            }
            if (h.Them(model) == -1)
            {
                ViewBag.err = "Đã có lỗi xảy ra hãy thao tác lại";
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
                ViewBag.err = "Vui lòng nhập tên";
            }
            if (h.capnhat(model) == -1)
            {
                ViewBag.err = "Đã có lỗi xảy ra hãy thao tác lại";
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
                ViewBag.err = "Đã có lỗi xảy ra hãy thao tác lại";
            }
            else
            {
                l.xoa(id);
            }
            return RedirectToAction("index");

        }
    }
}