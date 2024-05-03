using Exception.ExceptionHandler;
using Microsoft.AspNetCore.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace Exception
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
           services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {

                app.UseSwagger();
                app.UseSwaggerUI();
                    // UseDeveloperExceptionPage Middleware Component for detailed exception information and source code snippets
                    DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                    {
                        SourceCodeLineCount = 10
                    };
                    app.UseDeveloperExceptionPage(developerExceptionPageOptions); 
            }

            //app.UseExceptionHandler(a => a.Run(async context =>
            //{
            //    await CustomExceptionHandler.HandleExceptionAsync(context);
            //}));

            //Using UseDeveloperExceptionPage Middleware to Show Exception Details
            app.UseExceptionHandler(a => a.Run(async context =>
            {
                var exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
                var exception = exceptionHandlerPathFeature.Error;

                // Custom logic for handling the exception
                // ...

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync("<html><body>\r\n");
                await context.Response.WriteAsync("Custom Error Page<br><br>\r\n");

                // Display custom error details
                await context.Response.WriteAsync($"<strong>Error:</strong> {exception.Message}<br>\r\n");
                await context.Response.WriteAsync("</body></html>\r\n");
            }));
            app.UseHttpsRedirection();
            

            app.UseAuthorization();
            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
