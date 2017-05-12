using DemoProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.DAO
{
    public class GiaoVienDAO
    {
        MyDbContext db;
        public GiaoVienDAO()
        {
            db = new MyDbContext();
        }
        public IQueryable<tblLop> TimLopTheoGVId(int id)
        {
            var res = (from l in db.tblLops
                       where l.GVCN == id
                       select l);
            return res;
        }
        public IQueryable<tblGiangDay> TimGiangDayTheoGVId(int id) {
            var res = (from g in db.tblGiangDays
                       where g.MaGV == id
                       select g);
            return res;
        }
    }
}