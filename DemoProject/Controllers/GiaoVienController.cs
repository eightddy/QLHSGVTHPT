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

using PagedList;
using System.Text;
using DemoProject.DAO;
using DemoProject.Sessions;
// Lương giáo viên nên giới hạn nhập

namespace DemoProject.Controllers
{
    public class GiaoVienController : BaseController
    {
        private MyDbContext db = new MyDbContext();
        [PhanQuyen(MaQuyen = "1,2,3")]
        public ActionResult Index(int? page, int? itemsPerPage, string searchString, string currentFilter, string order, string sort)
        {
            var gv = db.tblGiaoViens.Include(g => g.tblMonHoc);

            var currentOrder = (order == null) ? "MaGV" : order;
            var currentSort = (sort == null) ? "asc" : sort;
            switch (currentOrder)
            {
                case "HoTen":
                    gv = (currentSort == "asc") ? gv.OrderBy(item => item.HoTen) : gv.OrderByDescending(item => item.HoTen);
                    break;
                case "MaMon":
                    gv = (currentSort == "asc") ? gv.OrderBy(item => item.tblMonHoc.TenMon) : gv.OrderByDescending(item => item.tblMonHoc.TenMon);
                    break;
                case "Luong":
                    gv = (currentSort == "asc") ? gv.OrderBy(item => item.Luong) : gv.OrderByDescending(item => item.Luong);
                    break;
                default:
                    gv = gv.OrderByDescending(item => item.MaGV);
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
                gv = gv.Where(item => (item.HoTen.Contains(searchString) || item.tblMonHoc.TenMon.Contains(searchString)));
            }

            int pageSize = (itemsPerPage == null) ? 5 : (int)itemsPerPage;
            int pageNumber = (page == null) ? 1 : (int)page;
            ViewBag.ItemsPerPage = pageSize;
            ViewBag.CurrentPage = pageNumber;
            return View(gv.ToPagedList(pageNumber, pageSize));
        }

        // GET: GiaoVien/Details/5
        [PhanQuyen(MaQuyen = "1,2,3")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGiaoVien tblGiaoVien = db.tblGiaoViens.Find(id);
            if (tblGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(tblGiaoVien);
        }

        // GET: GiaoVien/Create
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Create()
        {
            ViewBag.MaMon = new SelectList(db.tblMonHocs, "MaMon", "TenMon");
            return View();
        }

        // POST: GiaoVien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Create([Bind(Include = "MaGV,HoTen,GT,NgaySinh,SDT,DiaChi,Luong,MaMon")] tblGiaoVien tblGiaoVien)
        {
            if (ModelState.IsValid)
            {
                db.tblGiaoViens.Add(tblGiaoVien);
                db.SaveChanges();

                Session["SUCCESS_MESSAGE"] = "Data created successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.MaMon = new SelectList(db.tblMonHocs, "MaMon", "TenMon", tblGiaoVien.MaMon);
            return View(tblGiaoVien);
        }

        // GET: GiaoVien/Edit/5
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGiaoVien tblGiaoVien = db.tblGiaoViens.Find(id);
            if (tblGiaoVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMon = new SelectList(db.tblMonHocs, "MaMon", "TenMon", tblGiaoVien.MaMon);
            return View(tblGiaoVien);
        }

        // POST: GiaoVien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [PhanQuyen(MaQuyen = "1,2")]
        public ActionResult Edit([Bind(Include = "MaGV,HoTen,GT,NgaySinh,SDT,DiaChi,Luong,MaMon")] tblGiaoVien tblGiaoVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGiaoVien).State = EntityState.Modified;
                db.SaveChanges();

                Session["SUCCESS_MESSAGE"] = "Data edited successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.MaMon = new SelectList(db.tblMonHocs, "MaMon", "TenMon", tblGiaoVien.MaMon);
            return View(tblGiaoVien);
        }

        // GET: GiaoVien/Delete/5
        [PhanQuyen(MaQuyen = "1")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGiaoVien tblGiaoVien = db.tblGiaoViens.Find(id);
            if (tblGiaoVien == null)
            {
                return HttpNotFound();
            }
            return View(tblGiaoVien);
        }

        // POST: GiaoVien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [PhanQuyen(MaQuyen = "1")]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGiaoVien tblGiaoVien = db.tblGiaoViens.Find(id);

            GiaoVienDAO dao = new GiaoVienDAO();
            bool check = true;

            var test = dao.TimLopTheoGVId(tblGiaoVien.MaGV);
            if (test.Count<tblLop>() != 0)
                check = false;
            if (check){
                var test1 = dao.TimGiangDayTheoGVId(tblGiaoVien.MaGV);
                if(test1.Count<tblGiangDay>() != 0)
                        check = false;
            }
            if (check)
            {
                db.tblGiaoViens.Remove(tblGiaoVien);
                db.SaveChanges();
                Session["SUCCESS_MESSAGE"] = "Data deleted successfully!";
            }
            else
            {
                ViewBag.error = "Lỗi";
                return View("Delete",tblGiaoVien);
            }
            
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
