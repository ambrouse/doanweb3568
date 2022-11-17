using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using shopxe_2.Models;
namespace shopxe_2.Models.hamxuly
{
    public class kiemtradangnhap
    {
        public bool kiemtra(String email) {
            Database db = new Database();
            foreach (var i in db.users.ToList()) {
                if (email==i.email) {
                    return true;
                }
            }
            return false;
        
        }
    }
}