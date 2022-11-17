using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopxe_2.Models;
namespace shopxe.Controllers
{
    public class TrangchuController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Database db = new Database();
            return View(db.sanphams.ToList());
        }
    }
}