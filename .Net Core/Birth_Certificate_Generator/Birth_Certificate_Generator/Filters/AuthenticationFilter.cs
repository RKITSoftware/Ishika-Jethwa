using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.ML.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics.Contracts;
using System.Security.Claims;

namespace Birth_Certificate_Generator.Filters
{
    /// <summary>
    /// Custom basic authentication filter
    /// </summary>
    public class AuthenticationFilter : Attribute, IAuthorizationFilter
    {
        #region Public Members

        /// <summary>
        /// Instance of BLTokenManager for managing token operations.
        /// </summary>
        public BLTokenManager objBLTokenManager = new BLTokenManager();

        /// <summary>
        /// Static user object to hold user details.
        /// </summary>
        public static USR01 objUSR01;

        /// <summary>
        /// Flag to check if token is generated.
        /// </summary>
        public static bool isTokenGenerated = false;

        #endregion

        /// <summary>
        /// Called to perform authorization.This method will validate the JWT token
        /// present in the Authorization header and set the current user principal.
        ///</summary>
        /// <param name="context">Authorization filter context.</param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (SkipAuthorization(context)) return;

            string authHeader = context.HttpContext.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Bearer "))
            {
                string token = authHeader.Substring("Bearer ".Length).Trim();

                if (objBLTokenManager.ValidateToken(token))
                {
                    var principal = objBLTokenManager.GetPrincipal(token);
                    if (principal != null)
                    {
                        context.HttpContext.User = principal;
                        Thread.CurrentPrincipal = principal;

                        var identity = (ClaimsIdentity)principal.Identity;
                        string username = identity.FindFirst(ClaimTypes.Name).Value;
                       

                       
                        BLLogin objLogin = new BLLogin();
                        USR01 user = objLogin.ValidateUserName(username);  // Assuming you have a method to get user details by username

                        if (user != null)
                        {
                            objUSR01 = user;

                            if (!isTokenGenerated)
                            {
                                objBLTokenManager.GenerateToken(objUSR01);
                                isTokenGenerated = true;
                                return;
                            }

                            string cachedToken = (string)BLTokenManager.cache.Get(BLTokenManager.CachePrefix + objUSR01.R01F02);
                            if (cachedToken != null)
                            {
                                string refreshedToken = objBLTokenManager.RefreshToken(objUSR01);
                                if (refreshedToken == null)
                                {
                                    context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                                }
                                return;
                            }
                            else
                            {
                                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
                                isTokenGenerated = false;
                            }
                        }
                        else
                        {
                            context.Result = new StatusCodeResult(StatusCodes.Status406NotAcceptable);
                        }
                    }
                    else
                    {
                        context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                    }
                }
                else
                {
                    context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
                }
            }
            else
            {
                context.Result = new StatusCodeResult(StatusCodes.Status400BadRequest);
            }
        }

        /// <summary>
        /// Determines if the current action should skip authorization.
        /// </summary>
        /// <param name="context">Authorization filter context.</param>
        /// <returns>True if the action has the AllowAnonymous attribute; otherwise, false.</returns>
        public static bool SkipAuthorization(AuthorizationFilterContext context)
        {
            Contract.Assert(context != null);
            if (context.ActionDescriptor is ControllerActionDescriptor descriptor)
            {
                var actionAttributes = descriptor.MethodInfo.GetCustomAttributes(inherit: true);
                if (actionAttributes.Any(a => a.GetType() == typeof(AllowAnonymousAttribute))) return true;
            }
            return false;
        }
    }
}
