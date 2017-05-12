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
namespace DemoProject.Controllers
{
    public class HocSinhController : Controller
    {
        private MyDbContext db = new MyDbContext();
        public ActionResult Index(int? page, int? itemsPerPage, string searchString, string currentFilter, string order, string sort)
        {
            var hs = db.tblHocSinhs.Include(s => s.tblLop);

            var currentOrder = (order == null) ? "HoTen" : order;
            var currentSort = (sort == null) ? "asc" : sort;
            switch (currentOrder)
            {
                case "HoTen":
                    hs = (currentSort == "asc") ? hs.OrderBy(item => item.HoTen) : hs.OrderByDescending(item => item.HoTen);
                    break;
                case "MaLop":
                    hs = (currentSort == "asc") ? hs.OrderBy(item => item.MaLop) : hs.OrderByDescending(item => item.MaLop);
                    break;
                default:
                    hs = hs.OrderBy(item => item.HoTen);
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
                hs = hs.Where(item => (item.HoTen.Contains(searchString) || item.tblLop.TenLop.Contains(searchString)));
            }

            int pageSize = (itemsPerPage == null) ? 5 : (int)itemsPerPage;
            int pageNumber = (page == null) ? 1 : (int)page;
            ViewBag.ItemsPerPage = pageSize;
            ViewBag.CurrentPage = pageNumber;
            return View(hs.ToPagedList(pageNumber, pageSize));
        }

        // GET: HocSinh/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHocSinh tblHocSinh = db.tblHocSinhs.Find(id);
            if (tblHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(tblHocSinh);
        }

        // GET: HocSinh/Create
        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop");
            return View();
        }

        // POST: HocSinh/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHS,HoTen,GT,NgaySinh,DiaChi,DanToc,TonGiao,MaLop")] tblHocSinh tblHocSinh)
        {
            if (ModelState.IsValid)
            {
                db.tblHocSinhs.Add(tblHocSinh);
                db.SaveChanges();

                Session["SUCCESS_MESSAGE"] = "Data created successfully!";
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop", tblHocSinh.MaLop);
            return View(tblHocSinh);
        }

        // GET: HocSinh/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHocSinh tblHocSinh = db.tblHocSinhs.Find(id);
            if (tblHocSinh == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop", tblHocSinh.MaLop);
            return View(tblHocSinh);
        }

        // POST: HocSinh/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHS,HoTen,GT,NgaySinh,DiaChi,DanToc,TonGiao,MaLop")] tblHocSinh tblHocSinh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblHocSinh).State = EntityState.Modified;
                db.SaveChanges();

                Session["SUCCESS_MESSAGE"] = "Data edited successfully!";
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.tblLops, "MaLop", "TenLop", tblHocSinh.MaLop);
            return View(tblHocSinh);
        }

        // GET: HocSinh/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblHocSinh tblHocSinh = db.tblHocSinhs.Find(id);
            if (tblHocSinh == null)
            {
                return HttpNotFound();
            }
            return View(tblHocSinh);
        }

        // POST: HocSinh/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblHocSinh tblHocSinh = db.tblHocSinhs.Find(id);
            db.tblHocSinhs.Remove(tblHocSinh);
            db.SaveChanges();

            Session["SUCCESS_MESSAGE"] = "Data deleted successfully!";
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
