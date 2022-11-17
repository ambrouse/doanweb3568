using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using shopxe_2.Models;
namespace shopxe.Areas.admin.hamxuli
{
    public class kiemtradangnhap : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext context)
        {
            var user = (shopxe_2.Models.admin)HttpContext.Current.Session["ad"];
            //kiem tra dang nhap
            if (user != null)
            {
                return;
            }
            else
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                    (new
                    {
                        Controller = "Dangnhapadmin",
                        action = "Index",
                        areas = "admin"
                    }));
            }

        }
    }
}