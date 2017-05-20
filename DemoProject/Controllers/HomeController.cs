using DemoProject.DAO;
using DemoProject.Entities;
using DemoProject.Models;
using DemoProject.Sessions;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class HomeController : BaseController
    {
        MyDbContext db = new MyDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            ViewBag.MaQuyen = new SelectList(db.tblPhanQuyens, "MaQuyen", "TenQuyen");
            ViewBag.MaGV = new SelectList(db.tblGiaoViens,"MaGV","HoTen");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Password,PasswordConfirm,MaGV,MaQuyen")] UserDTO user)
        {
            var dao = new UserDAO().getUserByUsername(user.Username);
            if(user.Password != user.PasswordConfirm)
            {
                ModelState.AddModelError("","Xác nhận mật khẩu không đúng!");
            }
            else if(dao != null)
            {
                ModelState.AddModelError("","Tên đăng nhập đã tồn tại!");
            }
            if (ModelState.IsValid)
            {
                tblUser tblUser = new tblUser();
                tblUser.Username = user.Username;
                tblUser.Password = user.Password;
                tblUser.MaGV = user.MaGV;
                tblUser.MaQuyen = user.MaQuyen;
                tblUser.tblPhanQuyen = user.tblPhanQuyen;

                db.tblUsers.Add(tblUser);
                db.SaveChanges();

                return RedirectToAction("index","home");
            }
            ViewBag.MaQuyen = new SelectList(db.tblPhanQuyens, "MaQuyen", "TenQuyen");
            ViewBag.MaGV = new SelectList(db.tblGiaoViens, "MaGV", "HoTen");
            return View();
        }
        [HttpGet]
        public ActionResult EditPass()
        {
            UserSession temp = (UserSession)Session["USER_SESSION"];
            ViewBag.Username = temp.username;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPass(UserChangePass user)
        {

            UserSession tmp = (UserSession)Session["USER_SESSION"];
            ViewBag.Username = tmp.username;
            user.username = tmp.username;

            var dao = new UserDAO();
            var oldUser = dao.getUserByUsername(user.username);
            if (!user.passwordOld.Equals(oldUser.Password))
            {
                ModelState.AddModelError("", "Mật khẩu cũ nhập chưa chính xác!");
            }
            else if (!user.passwordNew.Equals(user.passwordConfirm))
            {
                ModelState.AddModelError("", "Xác nhận mật không đúng!");
            }
            else
            {
                Object[] sqlPara =
                {
                        new SqlParameter("@Username", user.username),
                        new SqlParameter("@Password", user.passwordNew)
                    };
                var result = db.Database.SqlQuery<int>("PROC_USER_CHANGEPASS @Username, @Password", sqlPara).Single();
                if (result==0)
                    ModelState.AddModelError("", "Có lỗi xảy ra trong quá trình chỉnh sửa");
                else
                    return RedirectToAction("index", "home");
            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("USER_SESSION");
            return RedirectToAction("index","login");
        }
    }
}