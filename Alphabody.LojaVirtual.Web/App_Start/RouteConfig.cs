using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Alphabody.LojaVirtual.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                null,
                "",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null, pagina = 1 }

                );

            //meu
            routes.MapRoute(
                 name: null,
                 url: "{categoria}",
                 defaults: new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 }
             );

            //meu2
            routes.MapRoute(
                 null,
                 "{categoria}Pagina{pagina}",
                 new { controller = "Vitrine", action = "ListaProdutos", categoria = (string) null}, 
                 new { pagina = @"\d+" }
             );

            //meu3
            routes.MapRoute(null, "{controller}/{action}");

            routes.MapRoute(
               null,
               "Pagina{pagina}",
                new { controller = "Vitrine", action = "ListaProdutos", categoria = (string)null },
                new {pagina  = @"\d+"}
            );

            //meu
       /* routes.MapRoute(
            name: null,
            url: "Pagina{pagina}",
            defaults: new { controller = "Vitrine", action = "ListaProdutos", pagina = 1 }
        );*/

            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Vitrine", action = "ListaProdutos", id = UrlParameter.Optional }
            );

        }
    }
}
