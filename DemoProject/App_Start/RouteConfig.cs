﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DemoProject
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "GiangDay",                                              // Route name
                url: "{controller}/{action}/{id1}/{id2}/{id3}",                           // URL with parameters
                defaults: new { controller = "GiangDay", action = "Edit", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional, id3 = UrlParameter.Optional }  // Parameter defaults
            );

            routes.MapRoute(
                name: "GiangDay_Delete",                                              // Route name
                url: "{controller}/{action}/{id1}/{id2}/{id3}",                           // URL with parameters
                defaults: new { controller = "Delete", action = "Edit", id1 = UrlParameter.Optional, id2 = UrlParameter.Optional, id3 = UrlParameter.Optional }  // Parameter defaults
            );

        }
    }
}
