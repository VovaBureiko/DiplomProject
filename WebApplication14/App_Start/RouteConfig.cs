using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebApplication14.Models.DataBaseModel;
namespace WebApplication14
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
                null,
                url : "{controller}/{action}",
                defaults : new {controler = "Test", action = "FirstSpisok"}
                );
            routes.MapRoute(
                name : "ToEnd",
                url: "{controller}/{action}",
                defaults : new {controller = "EndTest", action = "EndTest"}
                );
            routes.MapRoute(
                name: "Start",
                url: "{controller}/{action}/{number}",
                defaults: new { controller = "Test", action = "Index", number = UrlParameter.Optional });
            routes.MapRoute(
              null,
              url: "{Test}/{action}",
              defaults: new { action = "Search", name = 2 }
              );

        }
    }
}
