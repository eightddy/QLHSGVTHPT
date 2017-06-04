using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DemoProject.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DemoProject.DAO;
using DemoProject.Sessions;

using PagedList;
namespace DemoProject.Controllers
{
    public class GiangDayController : BaseController
    {
        private MyDbContext db = new MyDbContext();

        // GET: GiangDay
        //public ActionResult Index()
        //{
        //    var tblGiangDays = db.tblGiangDays.Include(t => t.tblGiaoVien).Include(t => t.tblLop);
        //    return View(tblGiangDays.ToList());
        //}
        [PhanQuyen(MaQuyen = "1,2,3,4")]
        public ActionResult Index(int? page, int? itemsPerPage, string searchString, string currentFilter, string order, string sort)
        {
            GiangDayDAO dao = new GiangDayDAO();
            var gd = dao.DanhSachGiangDay();

            var currentOrder = (order == null) ? "HoTenGV" : order;
            var currentSort = (sort == null) ? "asc" : sort;
            switch (currentOrder)
            {
                case "HoTenGV":
                    gd = (currentSort == "asc") ? gd.OrderBy(item => item.HoTenGV) : gd.OrderByDescending(item => item.HoTenGV);
                    break;
                default:
                    gd = gd.OrderBy(item => item.HoTenGV);
                    break;
            }
            ViewBag.CurrentOrder = currentOrder;
            ViewBag.CurrentSort = currentSort;
            ViewBag.ReverseSort = (currentSort == "asc") ? "desc" : "asc";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            if (!String.IsNullOrEmpty(searchString))
            {
                gd = gd.Where(item => (item.HoTenGV.Contains(searchString)));
            }

            int pageSize = (itemsPerPage == null) ? 5 : (int)itemsPerPage;
            int pageNumber = (page == null) ? 1 : (int)page;
            ViewBag.ItemsPerPage = pageSize;
            ViewBag.CurrentPage = pageNumber;

            ViewBag.TotalRecord = gd.Count();
            return View(gd.ToPagedList(pageNumber, pageSize));
        }

        // GET: GiangDay/Details/5
        //public ActionResult Details(int id1, int id2)
        //{
        //    GiangDayDAO dao = new GiangDayDAO();
        //    var tblGiangDay = dao.TimKiemTheo2Ma(id1,id2);
        //    if (tblGiangDay == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tblGiangDay);
        //}

        // GET: GiangDay/Create
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Create()
        {
            ViewBag.MaGV = new SelectList(db.tblGiaoViens, "MaGV", "HoTen");
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop");
            
            return View();
        }

        // POST: GiangDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Create([Bind(Include = "MaGV,MaLop,Thu,TietBD,TietKT")] tblGiangDay tblGiangDay)
        {
            /* Cần phải xác minh được 
             * tiết học có bị trùng 
             * hay không ????
            */
            var dao = new GiangDayDAO();
            int check = dao.isCreate(tblGiangDay);

            if (check != 0)
            {
                if(check == 1)
                    ModelState.AddModelError("", "Đã có giáo viên khác dạy vào thời gian này");
                if (check == 2)
                    ModelState.AddModelError("", "Giáo viên này đã dạy một lớp khác trong khoảng thời gian này");
                if (check == 3)
                    ModelState.AddModelError("", "Một giáo viên trong 1 ngày không được dạy 1 lớp 2 lần");
            }

            if (tblGiangDay.TietBD >= tblGiangDay.TietKT)
            {
                ModelState.AddModelError("", "Tiết bắt đầu không được lớn hơn tiết kết thúc");
            }
            if (tblGiangDay.TietBD < 6)
            {
                if (tblGiangDay.TietKT > 6)
                {
                    ModelState.AddModelError("", "Số tiết không hợp lý! (1->6) hoặc (7->12)");
                }
            }
            if (ModelState.IsValid)
            {
                db.tblGiangDays.Add(tblGiangDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGV = new SelectList(db.tblGiaoViens, "MaGV", "HoTen", tblGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop", tblGiangDay.MaLop);
            return View(tblGiangDay);
        }

        // GET: GiangDay/Edit/5
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Edit(int? id1, int? id2, string id3)
        {
            if (id1 == null || id2 == null || id3=="")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblGiangDay = db.tblGiangDays.Where(item => item.MaGV == id1).Where(item => item.MaLop == id2).Where(item => item.Thu.Equals(id3)).SingleOrDefault();

            if (tblGiangDay == null)
            {
                return HttpNotFound();
            }
            var giaovien = db.tblGiaoViens.Where(item => item.MaGV == id1);
            var lop = db.tblLops.Where(item => item.MaLop == id2);

            ViewBag.GV = giaovien;
            ViewBag.Lop = lop;

            return View(tblGiangDay);
        }

        // POST: GiangDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Edit([Bind(Include = "MaGV,MaLop,Thu,TietBD,TietKT")] tblGiangDay tblGiangDay)
        {
            var dao = new GiangDayDAO();
            int check = dao.isCreate(tblGiangDay);

            if (check != 0)
            {
                if (check == 1)
                    ModelState.AddModelError("", "Đã có giáo viên khác dạy vào thời gian này");
                if (check == 2)
                    ModelState.AddModelError("", "Giáo viên này đã dạy một lớp khác trong khoảng thời gian này");
                if (check == 1)
                    ModelState.AddModelError("", "Một giáo viên trong 1 ngày không được dạy 1 lớp 2 lần");
            }

            if (tblGiangDay.TietBD >= tblGiangDay.TietKT)
            {
                ModelState.AddModelError("","Tiết bắt đầu không được lớn hơn tiết kết thúc");
            }
            if(tblGiangDay.TietBD < 6)
            {
                if (tblGiangDay.TietKT > 6)
                {
                    ModelState.AddModelError("","Số tiết không hợp lý! (1->6) hoặc (7->12)");
                }
            }

            if (ModelState.IsValid)
            {
                db.Entry(tblGiangDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.tblGiaoViens, "MaGV", "HoTen", tblGiangDay.tblGiaoVien);
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop", tblGiangDay.tblLop);
            var tblGiangDay1 = db.tblGiangDays.Where(item => item.MaGV == tblGiangDay.MaGV).Where(item => item.MaLop == tblGiangDay.MaGV).Where(item => item.Thu.Equals(tblGiangDay.Thu)).SingleOrDefault();
            return View(tblGiangDay1);
        }

        // GET: GiangDay/Delete/5
        [PhanQuyen(MaQuyen = "1")]
        public ActionResult Delete(int? id1, int? id2, string id3)
        {
            if (id1 == null || id2 == null || id3 == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblGiangDay = db.tblGiangDays.Where(item => item.MaGV == id1).Where(item => item.MaLop == id2).Where(item => item.Thu.Equals(id3)).SingleOrDefault();

            if (tblGiangDay == null)
            {
                return HttpNotFound();
            }

            return View(tblGiangDay);
        }

        // POST: GiangDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [PhanQuyen(MaQuyen = "1")]
        public ActionResult DeleteConfirmed(int? id1, int? id2, string id3)
        {
            if (id1 == null || id2 == null || id3 == "")
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var tblGiangDay = db.tblGiangDays.Where(item => item.MaGV == id1).Where(item => item.MaLop == id2).Where(item => item.Thu.Equals(id3)).SingleOrDefault();

            if (tblGiangDay == null)
            {
                return HttpNotFound();
            }

            db.tblGiangDays.Remove(tblGiangDay);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
