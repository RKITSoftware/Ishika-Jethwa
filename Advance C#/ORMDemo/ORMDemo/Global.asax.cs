using Newtonsoft.Json;
using System;
using System.IO;
using System.Web;
using System.Web.Http;

namespace ORMDemo
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            
        }
    }
}
