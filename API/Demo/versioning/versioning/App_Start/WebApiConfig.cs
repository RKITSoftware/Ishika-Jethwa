using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace versioning
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "Version1",
                routeTemplate: "api/v1/employees/{id}",
                defaults: new { id = RouteParameter.Optional , Controller = "EmployeesV1" }
            );
            config.Routes.MapHttpRoute(
              name: "Version2",
              routeTemplate: "api/v2/employees/{id}",
              defaults: new { id = RouteParameter.Optional, Controller = "EmployeesV2" }
          );
        }
    }
}
