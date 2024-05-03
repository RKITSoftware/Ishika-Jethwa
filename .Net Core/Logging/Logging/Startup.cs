
using Microsoft.OpenApi.Models;

namespace Logging
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //string sourceName = "MySource";
            var _logger = services.BuildServiceProvider().GetService<ILogger<Startup>>();
            services.AddSingleton(typeof(ILogger), _logger);
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            //services.AddLogging(builder => builder.ClearProviders());

            //services.AddLogging(builder => builder.AddConsole());
            //services.AddLogging(builder => builder.AddSimpleConsole(options =>
            //{
            //    options.SingleLine = true;
            //    options.TimestampFormat = "[HH:mm:ss]";
            //    options.ColorBehavior = LoggerColorBehavior.Disabled;
            //}));

            //services.AddLogging(builder => builder.AddSystemdConsole(options =>
            //{
            //    options.TimestampFormat = "[HH:mm:ss]";
            //}));

            //services.AddLogging(builder => builder.AddJsonConsole(options =>
            //{
            //    options.TimestampFormat = "[HH:mm:ss]";
            //    options.JsonWriterOptions = new System.Text.Json.JsonWriterOptions()
            //    {
            //        Indented = true
            //    };
            //}));

            //services.AddLogging(opt => opt.AddEventSourceLogger());

            //services.AddLogging(builder => builder.AddEventLog(options =>
            //{
            //    options.LogName = "Ishika";
            //    options.SourceName = sourceName;
            //}));

            //if (!EventLog.SourceExists(sourceName))
            //{
            //    EventLog.CreateEventSource(sourceName, "Ishika");
            //}

            //Log.Logger = new LoggerConfiguration()
            //    .WriteTo.Console()
            //    .MinimumLevel.Information()
            //    .WriteTo.File(path: "serilogs\\seri.json",
            //    formatter: new JsonFormatter(),
            //    rollingInterval: RollingInterval.Day,
            //    rollOnFileSizeLimit: true,
            //    fileSizeLimitBytes: 10*1024*1024, //10MB
            //    retainedFileTimeLimit: TimeSpan.FromDays(7)
            //    )  
            //    .CreateLogger();


        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
            }



            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
