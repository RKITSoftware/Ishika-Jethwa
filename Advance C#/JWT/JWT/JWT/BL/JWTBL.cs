using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;

namespace JWT.BL
{
    /// <summary>
    /// Business Logic class for handling JWT-related operations.
    /// </summary>
    public class JWTBL
    {
        Rijndeal objRijndeal = new Rijndeal();
        string  Key = "v9yUDgxQRxYKkVfBgiZ9BO0MAMIS7UBc2U+SCqRoxik=";
        string IV = "3X7fqYc9wZ9JCnSIFGOtuQ==";

        /// <summary>
        /// Generates a JWT token with specific claims.
        /// </summary>
        /// <returns>An object containing the generated JWT token.</returns>
        public object GenerateToken()
        {

            // Secret key used for token signing and validation

            var issuer = "http://localhost:58548/";

            // Creating a symmetric key for token signing using Rijndael algorithm
            using (var rijndael = new RijndaelManaged())
            {

                // Adding claims to the token payload
                var permClaims = new List<Claim>
                 {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("valid", "true"),
                        new Claim("userid", "1"),
                        new Claim("name", "Ishika")
                 };

                // Create a plain text representation of the claims
                var claimsText = string.Join(",", permClaims.Select(c => $"{c.Type}={c.Value}"));

                // Encrypt the plain text using Rijndael
                var encryptedClaims = objRijndeal.EncryptRijndael(claimsText, Key, IV);

                // Returning the encrypted claims in an object
                return new { data = encryptedClaims };
            }
        }

        /// <summary>
        /// Retrieves the name from the authenticated user's claims.
        /// </summary>
        /// <returns>The name of the authenticated user if available; otherwise, "Invalid".</returns>
        public string ValidateToken(string token)
        {
            try
            {
                // Decrypt the JWE token using your decryption logic
                string decryptedToken = objRijndeal.Decrypt(token, Key, IV);

                string[] decryptedTokenInfo = decryptedToken.Split(',');

                return decryptedTokenInfo[3];

            }
            catch (Exception ex)
            {
                // Handle decryption or parsing errors
                return $"Token validation failed: {ex.Message}";
            }
        }

        /// <summary>
        /// Checks if Token is Valid or not
        /// </summary>
        /// <param name="token">Generated Token</param>
        /// <returns>Bool Value that Token is Valid or not</returns>
        public bool IsTokenValid(string token)
        {
            try
            {
                // Decrypt the JWE token using your decryption logic
                string decryptedToken = objRijndeal.Decrypt(token, Key, IV);

                // Split the decrypted token into parts
                string[] decryptedTokenInfo = decryptedToken.Split(',');

                // Validate token properties based on your criteria
                // For example, check if the token has the expected structure or contains required claims
                if (decryptedTokenInfo.Length >= 3 && decryptedTokenInfo[3] == "name=Ishika") // Adjust the validation criteria as needed
                {
                    return true;
                }

                // Token is not valid based on the criteria
                return false;
            }
            catch (Exception ex)
            {
                // Handle decryption or validation errors
                // Log or throw an exception as needed
                return false;
            }
        }

        /// <summary>
        /// Checks if a token passed in the request headers is valid.
        /// </summary>
        /// <returns>True if the token is valid; otherwise, false.</returns>
        public bool IsTokenValidFromHeader()
        {
            try
            {
                // Retrieve the token from the request headers
                var tokenHeader = HttpContext.Current.Request.Headers["Authorization"];
                if (!string.IsNullOrEmpty(tokenHeader) && tokenHeader.StartsWith("Bearer "))
                {
                    string token = tokenHeader.Substring("Bearer ".Length).Trim();

                    // Use the existing IsTokenValid method to check the validity of the token
                    return IsTokenValid(token);
                }

                // Token is not present or in an invalid format
                return false;
            }
            catch (Exception ex)
            {
                // Handle errors, log, or throw an exception as needed
                return false;
            }
        }
    }
}
