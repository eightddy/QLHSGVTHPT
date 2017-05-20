using DemoProject.DAO;
using DemoProject.Models;
using DemoProject.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var dao = new UserDAO();
            var res = dao.Login(model.username, model.password);

            if (res == true && ModelState.IsValid)
            {
                var userSession = new UserSession();
                var user = dao.getUserByUsername(model.username);
                userSession.username = user.Username;
                userSession.MaGV = user.MaGV;
                userSession.MaQuyen = user.MaQuyen;

                Session.Add(CommonConstant.USER_SESSION, userSession);
                return RedirectToAction("index","home");
            }
            else
            {
                ModelState.AddModelError("","Tên đăng nhập hoặc mật khẩu không chính xác!");
            }
            
            return View(model);
        }
    }
}