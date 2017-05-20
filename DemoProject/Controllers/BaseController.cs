using DemoProject.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoProject.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var userSession = (UserSession)Session[CommonConstant.USER_SESSION];
            if(userSession == null)
            {
                filterContext.Result = new RedirectResult("/Login/Index");
            }

            base.OnActionExecuting(filterContext);
        }
    }
}