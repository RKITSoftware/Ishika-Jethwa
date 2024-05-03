using NLog.Web;
using Serilog;
using System.Diagnostics;

namespace Logging
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            string SourceName = "MySource";
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).ConfigureLogging(logging =>
            {
               // logging.AddSerilog();
                //logging.AddEventSourceLogger();
                //logging.AddEventLog(opt =>
                //{
                //    opt.SourceName = SourceName;
                //    opt.LogName = "Apllication";

                //});
                logging.SetMinimumLevel(LogLevel.Trace);
                
            }).UseNLog().Build().Run();

            //if(!EventLog.SourceExists(SourceName))
            //{
            //    EventLog.CreateEventSource(new EventSourceCreationData(SourceName, "Application"));
            //}
        }

        
    }
}
