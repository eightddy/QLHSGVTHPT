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

using PagedList;
namespace DemoProject.Controllers
{
    public class GiangDayController : Controller
    {
        private MyDbContext db = new MyDbContext();

        // GET: GiangDay
        //public ActionResult Index()
        //{
        //    var tblGiangDays = db.tblGiangDays.Include(t => t.tblGiaoVien).Include(t => t.tblLop);
        //    return View(tblGiangDays.ToList());
        //}

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
            return View(gd.ToPagedList(pageNumber, pageSize));
        }

        // GET: GiangDay/Details/5
        public ActionResult Details(int id1, int id2)
        {
            GiangDayDAO dao = new GiangDayDAO();
            var tblGiangDay = dao.TimKiemTheo2Ma(id1,id2);
            if (tblGiangDay == null)
            {
                return HttpNotFound();
            }
            return View(tblGiangDay);
        }

        // GET: GiangDay/Create
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
        public ActionResult Create([Bind(Include = "MaGV,MaLop,Thu,TietBD,TietKT")] tblGiangDay tblGiangDay)
        {
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
        public ActionResult Edit(int id1, int id2)
        {
            GiangDayDAO dao = new GiangDayDAO();
            //GiangDayDTO tblGiangDay = dao.TimKiemTheo2Ma(id1, id2);

            var tblGiangDay = (from gd in db.tblGiangDays
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
                ) ;
            if (tblGiangDay == null)
            {
                return HttpNotFound();
            }
            //ViewBag.MaGV = tblGiangDay.MaGV;
            //ViewBag.MaLop = tblGiangDay.MaLop;
            GiangDayDTO a = new GiangDayDTO();
            a = tblGiangDay as GiangDayDTO;  
            return View(a);
        }

        // POST: GiangDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,MaLop,Thu,TietBD,TietKT")] tblGiangDay tblGiangDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblGiangDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGV = new SelectList(db.tblGiaoViens, "MaGV", "HoTen", tblGiangDay.MaGV);
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop", tblGiangDay.MaLop);
            return View(tblGiangDay);
        }

        // GET: GiangDay/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblGiangDay tblGiangDay = db.tblGiangDays.Find(id);
            if (tblGiangDay == null)
            {
                return HttpNotFound();
            }
            return View(tblGiangDay);
        }

        // POST: GiangDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblGiangDay tblGiangDay = db.tblGiangDays.Find(id);
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
