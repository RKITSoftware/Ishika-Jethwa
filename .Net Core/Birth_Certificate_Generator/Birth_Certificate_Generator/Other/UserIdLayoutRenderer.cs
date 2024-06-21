using NLog;
using NLog.LayoutRenderers;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Birth_Certificate_Generator.Other 
{
    /// <summary>
    /// Custom layout renderer for extracting username from JWT token and rendering it.
    /// </summary>
    [LayoutRenderer("username")]
    public class UsernameLayoutRenderer : LayoutRenderer 
    {
        /// <summary>
        /// Appends the username extracted from JWT token to the log message.
        /// </summary>
        /// <param name="builder">StringBuilder to build the log message.</param>
        /// <param name="logEvent">LogEventInfo containing log event information.</param>
        protected override void Append(StringBuilder builder, LogEventInfo logEvent) 
        {
            if (logEvent.Properties.ContainsKey("jwt")) 
            {
                string jwtToken = logEvent.Properties["jwt"].ToString();
                string username = GetUsernameFromJwt(jwtToken); 

                if (!string.IsNullOrEmpty(username)) 
                {
                    builder.Append(username); 
                }
                else
                {
                    builder.Append("UnknownUser"); 
                }
            }
            else
            {
                builder.Append("UnknownUser");
            }
        }

        /// <summary>
        /// Extracts the username from the JWT token.
        /// </summary>
        /// <param name="jwtToken">JWT token string.</param>
        /// <returns>The username extracted from the JWT token.</returns>
        private string GetUsernameFromJwt(string jwtToken) 
        {
            try
            {
                var handler = new JwtSecurityTokenHandler(); 
                var jsonToken = handler.ReadToken(jwtToken) as JwtSecurityToken; 
                var usernameClaim = jsonToken?.Claims.FirstOrDefault(claim => claim.Type == "unique_name"); 

                return usernameClaim?.Value; 
            }
            catch (Exception)
            {
                return null; 
            }
        }
    }
}


