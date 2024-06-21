using FinalDemo.Connection;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Web.Http;

namespace FinalDemo
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

           
        }
    }
}
