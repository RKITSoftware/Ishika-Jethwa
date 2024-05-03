using HRMSyatem.MAL.POCO;
using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace HRMSyatem.Auth
{
    /// <summary>
    /// Basic Authorization
    /// </summary>
    public class BLBasicAuthentication : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Overrides the default authorization to perform basic authentication.
        /// </summary>
        /// <param name="actionContext">The context for the HTTP action.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (SkipAuthorization(actionContext)) return;
            // Check if Authorization header is present
            if (actionContext.Request.Headers.Authorization == null)
            {
                // Set Unauthorized response if no Authorization header is found
                actionContext.Response = actionContext.Request
                    .CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
            }
            else
            {
                try
                {
                    // Extract username and password from the Authorization header
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;

                    // Decode the Authorization header
                    string decodedAuthToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                    // Split the decoded token into username and password
                    string[] usernamepassword = decodedAuthToken.Split(':');

                    string username = usernamepassword[0];
                    string password = usernamepassword[1];

                    string encryptedData = BLEncryptDecrypt.Encrypt(password);

                    // Validate user credentials
                    if (ValidateUser.isLogin(username, password))
                    {
                        //  string encryptedData = BLEncryptDecrypt.Encrypt(password);
                        // If credentials are valid, create identity and principal
                        USR01 userDetails = ValidateUser.GetUserRoles(username, encryptedData);
                        GenericIdentity identity = new GenericIdentity(username);
                        identity.AddClaim(new Claim(ClaimTypes.Name, userDetails.R01F05.ToString()));

                        // Create a principal with user roles
                        // Assuming userDetails.R01F04 is an enmUserRole enum value

                        // Now you can create the GenericPrincipal
                        IPrincipal principal = new GenericPrincipal(identity, (userDetails.R01F05).ToString().Split(','));


                        // Set the current thread's principal
                        Thread.CurrentPrincipal = principal;

                        // Set the current HttpContext's User
                        if (HttpContext.Current != null)
                        {
                            HttpContext.Current.User = principal;
                        }
                        else
                        {
                            // Set Unauthorized response if HttpContext is null
                            actionContext.Response = actionContext.Request
                            .CreateErrorResponse(HttpStatusCode.Unauthorized, "Authorization Denied.");
                        }
                    }
                    else
                    {
                        // Set Unauthorized response if HttpContext is null
                        actionContext.Response = actionContext.Request
                       .CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
                    }
                }
                catch (Exception)
                {
                    actionContext.Response = actionContext.Request
                       .CreateErrorResponse(HttpStatusCode.InternalServerError, "Server error - Login Failed");
                }

            }
        }
        /// <summary>
        /// To allow anonymous users to access endpoint
        /// </summary>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        public static bool SkipAuthorization(HttpActionContext actionContext)
        {
            // Use Contract.Assert to ensure that the actionContext is not null.
            Contract.Assert(actionContext != null);

            // Check if the action or controller has the AllowAnonymousAttribute.
            return actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any()
                       || actionContext.ControllerContext.ControllerDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any();
        }
    }
}