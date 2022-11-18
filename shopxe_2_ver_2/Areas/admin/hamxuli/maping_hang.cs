using shopxe_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace shopxe_2.Areas.admin.hamxuli
{
    public class maping_hang
    {
        private Database db = new Database();
        public List<hang> danhsach()
        {
            return db.hangs.ToList();
        }
        public int Them(hang model)
        {
            try
            {
                db.hangs.Add(model);
                db.SaveChanges();
                return 1;

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public int capnhat(hang model)
        {
            try
            {
                var capnhat = db.hangs.Find(model.id);
                capnhat.id = model.id;
                capnhat.ten = model.ten;
                db.SaveChanges();
                return 1;

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public int xoa(int id)
        {
            try
            {
                var xoa = db.hangs.Find(id);
                db.hangs.Remove(xoa);
                db.SaveChanges();
                return 1;

            }
            catch (Exception e)
            {
                return -1;
            }
        }
        public hang chitiet(int id)
        {
            return db.hangs.Find(id);
        }
    }
}