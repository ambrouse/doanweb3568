using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models;
namespace shopxe.Controllers
{
    public class ChitietController : Controller
    {
        // GET: admin/Chitiet
        public ActionResult Index(int id)
        {
            Database db = new Database();
            var x = db.sanphams.Find(id);
            return View(x);
        }
    }
}