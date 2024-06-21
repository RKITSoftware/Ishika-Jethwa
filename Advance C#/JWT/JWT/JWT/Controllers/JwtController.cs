using JWT.BL;
using System;
using System.Web.Http;

namespace JWT
{




    /// <summary>
    /// Controller for handling JWT token generation and user information retrieval.
    /// </summary>
    public class JwtController : ApiController
    {
        private readonly JWTBL _jwtBL;

        public JwtController()
        {
            _jwtBL = new JWTBL();
        }

        /// <summary>
        /// Generates a JWT token with specific claims.
        /// </summary>
        /// <returns>An object containing the generated JWT token.</returns>
        [HttpGet]
        [Route("api/token")]
        public Object GetToken()
        {
            return _jwtBL.GenerateToken();
        }

        /// <summary>
        /// Retrieves the name from the authenticated user's claims.
        /// </summary>
        /// <returns>The name of the authenticated user if available; otherwise, "Invalid".</returns>
        [HttpGet]
        [Route("api/getname")]
        public String GetName()
        {
            if (Request.Headers.Authorization != null && Request.Headers.Authorization.Scheme.Equals("Bearer", StringComparison.OrdinalIgnoreCase))
            {
                string token = Request.Headers.Authorization.Parameter;
                // Validate or process the token as needed

                // Example: If you need to validate the token using your JWTBL class
                string decryptedName = _jwtBL.ValidateToken(token);
                if (decryptedName != null)
                {
                    return decryptedName;
                }
                else
                {
                    return "Invalid token";
                }
            }
            else
            {
                return "Unauthorized";
            }
        }

        /// <summary>
        /// Retrives that the passed Token is Valid or not.
        /// </summary>
        /// <returns>TOken passed is Valid or not.</returns>
        [HttpGet]
        [Route("api/isValid")]
        public string isValid()
        {
            try
            {
                // Check if the token passed in the request headers is valid
                bool isTokenValid = _jwtBL.IsTokenValidFromHeader();

                if (isTokenValid)
                {
                    // Token is valid, no need to check specific claims
                    return "Valid token.";
                }
                else
                {
                    return "Invalid token";
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions, log, or return an error message as needed
                return $"Error: {ex.Message}";
            }
        }
    }
}