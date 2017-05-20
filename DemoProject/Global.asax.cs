using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DemoProject
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //RouteTable.Routes.MapRoute(
            //    name: "GiangDay",                                              
            //    url: "{controller}/{action}/{id1}/{id2}",                        
            //    defaults: new { controller = "GiangDay", action = "Edit", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional }
            //);


            Application["APP_CONTROLLER"] = "Home";
            Application["APP_NAME"] = "Quản lý THPT";
            Application["STUDENT_NAME"] = "Phan Huy Dũng";
            Application["STUDENT_CLASS"] = "TH13B";
            Application["STUDENT_ROLL_NUMBER"] = "14150235";



        }
    }
}
