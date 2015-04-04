using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
namespace DynamicRoutingExample
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapLocalizedRoute("SeoFriendlyUrl",
                                                 "{SeoFriendlyName}",
                                                 new { controller = "Company", action = "Index" },
                                                 new[] { "DynamicRoutingExample.Controllers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }


    }
    public static class LocalizedRouteExtensionMethod
    {
        public static Route MapLocalizedRoute(this RouteCollection routes, string name, string url, object defaults, string[] namespaces)
        {
            return MapLocalizedRoute(routes, name, url, defaults, null /* constraints */, namespaces);
        }
        public static Route MapLocalizedRoute(this RouteCollection routes, string name, string url, object defaults, object constraints, string[] namespaces)
        {
            if (routes == null)
            {
                throw new ArgumentNullException("routes");
            }
            if (url == null)
            {
                throw new ArgumentNullException("url");
            }

            var route = new clsRouteData(url, new MvcRouteHandler())
            {
                Defaults = new RouteValueDictionary(defaults),
                Constraints = new RouteValueDictionary(constraints),
                DataTokens = new RouteValueDictionary()
            };

            if ((namespaces != null) && (namespaces.Length > 0))
            {
                route.DataTokens["Namespaces"] = namespaces;
            }

            routes.Add(name, route);

            return route;
        }
    }
    public class clsRouteData : Route
    {
        public clsRouteData(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            RouteData data = base.GetRouteData(httpContext);
            if (data != null)
            {
                var SeoFriendliyName = data.Values["SeoFriendlyName"] as string;
                //get here from Database;
                var ObjDataRep = new DataAccess.Repository();
                var Resutls = ObjDataRep.GetComapnyDetailBySeoUrl(SeoFriendliyName);
                if (Resutls != null && Resutls.Id > 0)
                {
                    data.Values["controller"] = "Company";
                    data.Values["action"] = "Index";
                    data.Values["Id"] = Resutls.Id;
                }
                else
                {
                    // Add Error page here.
                }
            }
            return data;
        }

    }
}
