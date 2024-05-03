using FiltersDemo.Filters;
using Microsoft.OpenApi.Models;

namespace FiltersDemo
{
    /// <summary>
    /// Configures the application's services and request pipeline.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the services used by the application.
        /// </summary>
        /// <param name="services">The collection of services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<ActionFilter>();
            services.AddTransient<StandardAuthorizationFilter>();
            services.AddTransient<ExceptionFilter>();
            services.AddTransient<ResourceFilter>();
            services.AddTransient<ResultFilter>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                // Add security definition for basic authentication
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Scheme = "basic",
                    Type = SecuritySchemeType.Http,
                    Description = "Basic Authentication using the basic scheme"
                });

                // Add security requirement for basic authentication
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "basic"
                            }
                        },
                        new string[] { }
                    }
                });
            });
        }

        /// <summary>
        /// Configures the application's request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

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
