using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopxe_2.Models;
namespace shopxe.Areas.admin.hamxuli
{
    public class kiemtramatkhau
    {
        Database db = new Database();
        public Boolean kiemtra(String name,String pass) {
            var z = db.admins.Find(1);
            var z_2 = db.admins.Find(2);
            if (z.ten != name && z_2.ten != name)
            {
                return false;
            }
            else if (z.pass != pass && z_2.pass != pass) {
                return false;
            }
            else { return true; }
            
                
           
        }
    }
}