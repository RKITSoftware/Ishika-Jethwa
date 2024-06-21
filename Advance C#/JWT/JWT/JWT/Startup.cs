using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Text;

[assembly: OwinStartup(typeof(JWT.Startup))]

namespace JWT
{
    /// <summary>
    /// Configuration startup class for JWT authentication.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configures the application to use JWT Bearer Authentication.
        /// </summary>
        /// <param name="app">The OWIN application builder.</param>
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
            app.UseJwtBearerAuthentication(
                new JwtBearerAuthenticationOptions
                {
                    AuthenticationMode = AuthenticationMode.Active,
                    TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "http://localhost:58548/",
                        ValidAudience = "http://localhost:58548/",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("v9yUDgxQRxYKkVfBgiZ9BO0MAMIS7UBc2U+SCqRoxik="))
                    },


                });
        }
    }
}
