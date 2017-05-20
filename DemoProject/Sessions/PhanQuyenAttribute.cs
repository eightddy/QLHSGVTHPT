using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Sessions
{
    public class PhanQuyenAttribute : AuthorizeAttribute
    {
        public string MaQuyen { get; set; }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var session = (UserSession)HttpContext.Current.Session[CommonConstant.USER_SESSION];
            if (session == null)
            {
                return false;
            }
            string[] dsQuyen = MaQuyen.Split(',');
            foreach (var item in dsQuyen)
            {
                if (session.MaQuyen == int.Parse(item))
                {
                    return true;
                }
            }

            return base.AuthorizeCore(httpContext);
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //filterContext.Result = new RedirectResult("/Login/Index");
            filterContext.Result = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
        }
    }
}