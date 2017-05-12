using DemoProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoProject.DAO
{
    public class GiangDayDAO
    {
        MyDbContext db;
        public GiangDayDAO()
        {
            db = new MyDbContext();
        }

        public IQueryable<GiangDayDTO> DanhSachGiangDay()
        {
            var res = (from gd in db.tblGiangDays
                       join gv in db.tblGiaoViens on gd.MaGV equals gv.MaGV
                       join l in db.tblLops on gd.MaLop equals l.MaLop
                       select new GiangDayDTO()
                       {
                           MaGV = gv.MaGV,
                           HoTenGV = gv.HoTen,
                           MaLop = l.MaLop,
                           TenLop = l.TenLop,
                           Thu = gd.Thu,
                           TietBD = (int)gd.TietBD,
                           TietKT = (int)gd.TietKT
                       }
            );
            
            return res;
        }

        public GiangDayDTO TimKiemTheo2Ma(int id1, int id2)
        {
            var res = (from gd in db.tblGiangDays
                       join gv in db.tblGiaoViens on gd.MaGV equals gv.MaGV
                       join l in db.tblLops on gd.MaLop equals l.MaLop
                       where gd.MaGV == id1 & gd.MaLop == id2
                       select new GiangDayDTO()
                       {
                           MaGV = gv.MaGV,
                           HoTenGV = gv.HoTen,
                           MaLop = l.MaLop,
                           TenLop = l.TenLop,
                           Thu = gd.Thu,
                           TietBD = (int)gd.TietBD,
                           TietKT = (int)gd.TietKT
                       }
            );

            return res as GiangDayDTO;
        }
    }
}