namespace Middleware
{
    /// <summary>
    /// Entry point class for the application.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method serving as the entry point for the application.
        /// </summary>
        /// <param name="args">Command-line arguments passed to the application.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup(builder.Configuration);
            startup.ConfigureServices(builder.Services); // calling ConfigureServices method
            var app = builder.Build();
            startup.Configure(app, builder.Environment);
            app.Run();// calling Configure method
           
        }
    }
}