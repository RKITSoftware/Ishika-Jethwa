using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.DL;
using Birth_Certificate_Generator.Filters;
using Birth_Certificate_Generator.Middleware;
using Microsoft.OpenApi.Models;
using NLog.Extensions.Logging;
using ServiceStack.OrmLite;

namespace Birth_Certificate_Generator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthCertificate", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header,
                    Description = "Basic Authorization header using the Bearer scheme."
                });
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
                        new string[] {}
                    }
                });

                //// Use Newtonsoft.Json for Swagger JSON serialization
                //c.CustomSchemaIds(type => type.FullName);
                ////c.UseNewtonsoftJson();
                //c.ToJson();
            });

            services.AddControllers(config =>
            {
                // Applies filter globally
                config.Filters.Add(new AuthenticationFilter());
            });
            services.AddSingleton(Configuration.GetConnectionString("Default"));

            // Register the DBUse01 repository
            services.AddScoped<DBUSR01Context>();

            // Register your service
            services.AddScoped<IUSR01, BLUSR01Handler>();
            services.AddScoped<IBCR01, BLBCR01Handler>();
            // Register OrmLite connection factory with SQL Server dialect
            string connectionString = Configuration.GetConnectionString("Default");

            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);

            services.AddSingleton(dbFactory);

           
            services.AddScoped<BLCHD01Handler>();
            services.AddScoped<BLBCT01Handler>();
            services.AddScoped<IBCT01, BLBCT01Handler>();
            services.AddScoped<ICHD01, BLCHD01Handler>();
            services.AddScoped<DBCHD01Context>(provider => new DBCHD01Context(Configuration.GetConnectionString("Default")));
            services.AddScoped<DBBCR01Context>(provider => new DBBCR01Context(Configuration.GetConnectionString("Default")));


            services.AddLogging(builder =>
            {
                builder.SetMinimumLevel(LogLevel.Trace);
                builder.AddNLog();

            });
            services.AddEndpointsApiExplorer();

            

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthorization();
            // app.UseAuthenticationMiddleware();
            //   app.UseMiddleware<BasicAuthenticationMiddleware>();
            app.UseMiddleware<RequestLoggingMiddleware>();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
