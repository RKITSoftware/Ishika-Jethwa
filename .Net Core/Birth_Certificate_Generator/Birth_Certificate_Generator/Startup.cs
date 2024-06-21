using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.DL.Context;
using Birth_Certificate_Generator.DL.Interface;
using Birth_Certificate_Generator.Filters;
using Birth_Certificate_Generator.Middleware;
using Birth_Certificate_Generator.Other;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ServiceStack;
using ServiceStack.OrmLite;
using System.Reflection;
using System.Text;

namespace Birth_Certificate_Generator
{
    /// <summary>
    /// The Startup class configures services and the app's request pipeline.
    /// </summary>
    public class Startup
    {
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Constructor to initialize the Startup class with configuration settings.
        /// </summary>
        /// <param name="configuration">The configuration settings for the application.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configures services and dependencies for the application.
        /// </summary>
        /// <param name="services">The service collection to which dependencies are added.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            // Add controllers with a global authentication filter
            services.AddControllers(config =>
            {
                config.Filters.Add(new AuthenticationFilter());
            })
            .AddNewtonsoftJson();

            // Configure Swagger for API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BirthCertificate", Version = "v1" });
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            services.AddSwaggerGenNewtonsoftSupport();

            services.MyServices(Configuration);



            // Configure JWT authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = false,
                       ValidateAudience = false,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(BLTokenManager.Secret)),
                       ClockSkew = TimeSpan.Zero
                   };
               });

            services.AddEndpointsApiExplorer();
        }

        /// <summary>
        /// Configures the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The web hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseMiddleware<RequestLoggingMiddleware>();

                app.ConfigureExceptionHandler();
                // UseDeveloperExceptionPage Middleware Component for detailed exception information and source code snippets
                //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                //{
                //    SourceCodeLineCount = 10
                //};
                //app.UseDeveloperExceptionPage(developerExceptionPageOptions);
            }

            else
            {
            }


            app.UseRouting();
            app.UseAuthorization();

            // Configure endpoint routing
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
