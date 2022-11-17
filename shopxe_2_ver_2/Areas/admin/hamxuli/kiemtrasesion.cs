using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopxe.Areas.admin.hamxuli
{
    public class kiemtrasesion
    {
        public Boolean kiemtra(String a) {
            var x = HttpContext.Current.Session[a] ;
            if (x == null) {
            return false;
            }
            return true;
        
        }
    }
}