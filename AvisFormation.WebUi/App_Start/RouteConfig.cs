using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AvisFormation.WebUi
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "touteslesformations",
                url: "toutes-les-formations",
                defaults: new { controller = "Formation", action = "ToutesLesFormations"}
            );
            routes.MapRoute(
                name: "detailsformations",
                url: "formation/{nomSeo}",
                defaults: new { controller = "Formation", action = "DetailsFormations" }
            );

            routes.MapRoute(
                name: "ajouterunavis",
                url: "avisformation/{nomSeo}",
                defaults: new { controller = "Avis", action = "AjouterUnAvis" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Accueil", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
