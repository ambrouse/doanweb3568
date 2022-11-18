
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models.hamxuly;
using shopxe_2.Models;
namespace shopxe_2.Controllers
{
    public class MailController : Controller
    {
        // GET: Text
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(int? id, List<int> soluong)
        {
            if (id == 0 || soluong == null)
            {
                return RedirectToAction("index", "Giohang");
            }
            foreach (var i in soluong) {
                if (i <= 0) {
                    return RedirectToAction("index", "Giohang");
                }
            }

            Database db = new Database();
            var chitiet = db.chitietdonhangs.Where(c => c.iddonhang == id).ToList();
            user u = (user)Session["user"];
            String tomail = u.email;
            decimal? x = 0M;

            for (int i = 0; i < chitiet.Count; i++) {
                chitiet[i].soluong = soluong[i];
            }

            string conten = System.IO.File.ReadAllText(Server.MapPath("~/accect/formemail/formemail.html"));
            conten = conten.Replace("{{ten}}", u.ten);
            conten = conten.Replace("{{sodt}}", u.sodt.ToString());
            conten = conten.Replace("{{email}}", tomail);
            conten = conten.Replace("{{diachi}}", "thong tin bao mat");
            
            foreach (var i in chitiet) {
                string conten_2 = System.IO.File.ReadAllText(Server.MapPath("~/accect/formemail/formmail_2.html"));
                conten_2 = conten_2.Replace("{{ten}}", i.ten);
                conten_2 = conten_2.Replace("{{email}}", tomail);
                conten_2 = conten_2.Replace("{{hang}}", db.sanphams.Find(i.idsanpham).hang1.ten);
                conten_2 = conten_2.Replace("{{dongia}}", i.dongia.ToString());
                conten_2 = conten_2.Replace("{{loai}}", db.sanphams.Find(i.idsanpham).loai1.ten);
                conten_2 = conten_2.Replace("{{soluong}}", i.soluong.ToString());
                conten += conten_2;
                x =x+i.dongia*i.soluong;
            }

            conten = conten.Replace("{{giaca}}",x.ToString());
            conten += "</table><p>Chúng tôi sẽ gọi điện lại sau 5 phút để xác nhận đơn hàng và trao đổi địa chỉ với quý khách</p>";
            conten += "<p>Hoặc bạn có thể chủ động nhắn tin qua Zalo : 0326030299</p>";
            conten += "</body></html>";
            try {
                new mail().sendmail(tomail, conten);
            }
            catch (Exception e) {
                ViewBag.err = "Gửi mail thất bại quý khách vui lòng kiểm tra mail và đặc hàng lại";
                return RedirectToAction("Index", "Mail");
            }
            
            foreach (var i in chitiet) {
                db.chitietdonhangs.Remove(i);
            }

            db.SaveChanges();
            return RedirectToAction("Index","Giohang");
        }
    }
}