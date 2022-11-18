using shopxe_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopxe_2.Areas.admin.hamxuli
{
    
    public class maping_loai
    {
        private Database db = new Database();
        public List<loai> danhsach() {
            return db.loais.ToList();
        }
        public int Them(loai model)
        {
            try {
                db.loais.Add(model);
                db.SaveChanges();
                return 1;
            
            }
            catch (Exception e) {
                return -1;
            }
        }
        public int capnhat(loai model)
        {
            try {
                var capnhat = db.loais.Find(model.id);
                capnhat.id = model.id;
                capnhat.ten = model.ten;
                db.SaveChanges();
                return 1;
            
            }
            catch (Exception e) {
                return -1;
            }
        }
        public int xoa(int id)
        {
            try {
                var xoa = db.loais.Find(id);
                db.loais.Remove(xoa);
                db.SaveChanges();
                return 1;
            
            }
            catch (Exception e) {
                return -1;
            }
        }
        public loai chitiet(int id) {
            return db.loais.Find(id);
        }
    }   
}