using ServiceStack.OrmLite;
using TimeTableGenerator.BL.Context;
using TimeTableGenerator.BL.Interface;
using TimeTableGenerator.ML.POCO;

namespace TimeTableGenerator
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(config =>
            {
                config.AddDefaultPolicy(options =>
                {
                    options.AllowAnyOrigin();
                    options.AllowAnyHeader();
                    options.AllowAnyMethod();
                });
            });
            services.AddControllers().AddNewtonsoftJson(); 
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // Register OrmLite connection factory with SQL Server dialect
            string connectionString = Configuration.GetConnectionString("Default");
            var dbFactory = new OrmLiteConnectionFactory(connectionString, MySqlDialect.Provider);

            services.AddSingleton(dbFactory);
            services.AddScoped<IGenInterface<DayTable>, BLImplementationHandler<DayTable>>();
            services.AddScoped<IGenInterface<CourseTable>, BLImplementationHandler<CourseTable>>();
            services.AddScoped<IGenInterface<SessionTable>, BLImplementationHandler<SessionTable>>();
            services.AddScoped<IGenInterface<SemesterTable>, BLImplementationHandler<SemesterTable>>();
            services.AddScoped<IGenInterface<ProgramTable>, BLImplementationHandler<ProgramTable>>();
            services.AddScoped<IGenInterface<RoomTable>, BLImplementationHandler<RoomTable>>();
            services.AddScoped<IGenInterface<LabTable>, BLImplementationHandler<LabTable>>();
            services.AddScoped<IGenInterface<LecturerTable>, BLImplementationHandler<LecturerTable>>();
            services.AddScoped<IGenInterface<DayTimeSlotTable>, BLImplementationHandler<DayTimeSlotTable>>();
            services.AddScoped<IGenInterface<LecturerSubjectTable>, BLImplementationHandler<LecturerSubjectTable>>();
            services.AddScoped<IGenInterface<ProgramSemesterTable>, BLImplementationHandler<ProgramSemesterTable>>();
            services.AddSwaggerGenNewtonsoftSupport();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseCors();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
