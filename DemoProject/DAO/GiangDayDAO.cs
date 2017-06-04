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
        public int isCreate(tblGiangDay giangday)
        {
            // 2 giáo viên dạy 1 lớp vào 1 ngày số tiết phải không được đè lên nhau
            var temp = (from i in db.tblGiangDays
                        where i.Thu.Equals(giangday.Thu) & i.MaLop == giangday.MaLop & i.MaGV != giangday.MaGV
                        select i
                        );
            foreach (var item in temp)
            {
                // |-----------[------]---------||---------------------------|
                // 1                           6                           12
                if (giangday.TietBD == item.TietBD || giangday.TietKT==item.TietBD|| giangday.TietBD == item.TietKT || giangday.TietKT == item.TietKT)
                    return 1;
                if (giangday.TietBD < item.TietBD)
                    if(giangday.TietKT > item.TietBD)
                        return 1;
                if (giangday.TietBD > item.TietBD && giangday.TietKT <= item.TietKT)
                    return 1;
            }
            // Một giáo viên dạy 2 lớp trong 1 ngày thì số tiết không được đè lên nhau
            var temp2 = (from i in db.tblGiangDays
                        where i.Thu.Equals(giangday.Thu) & i.MaGV == giangday.MaGV & i.MaLop != giangday.MaLop
                        select i
                        );
            foreach (var item in temp2)
            {
                // |-----------[------]---------||---------------------------|
                // 1                           6                           12
                if (giangday.TietBD == item.TietBD || giangday.TietKT == item.TietBD || giangday.TietBD == item.TietKT || giangday.TietKT == item.TietKT)
                    return 2;
                if (giangday.TietBD < item.TietBD)
                    if (giangday.TietKT > item.TietBD)
                        return 2;
                if (giangday.TietBD > item.TietBD && giangday.TietKT <= item.TietKT)
                    return 2;
            }

            // Một giáo viên trong 1 ngày không được dạy 1 lớp 2 lần:
            var temp3 = (from i in db.tblGiangDays
                         where i.Thu.Equals(giangday.Thu) & i.MaGV == giangday.MaGV & i.MaLop == giangday.MaLop
                         select i
                        );
            if (temp3 != null)
                return 3;

            // Nếu không rơi vào trường hợp nào ở trên thì return true:
            return 0;
        }

    }
}