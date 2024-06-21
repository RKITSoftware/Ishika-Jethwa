using Birth_Certificate_Generator.BL.Handler;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Birth_Certificate_Generator.Controllers
{
    /// <summary>
    ///  Controller Class For Login
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CLLogin : ControllerBase
    {
        #region Private Member
        //instance of BLLogin Class
        private readonly BLLogin _blLogin;
        //instance of BLTokenManager Class
        private readonly BLTokenManager _blTokenManager;
        #endregion

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public CLLogin()
        {
            _blLogin = new BLLogin();
            _blTokenManager = new BLTokenManager();
        }

        /// <summary>
        /// Authenticates the user and generates a JWT token.
        /// </summary>
        /// <param name="objLogin">The username and Password.</param>
        /// <returns>A JWT token if the user is authenticated, otherwise a 401 Unauthorized status.</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login(Login objLogin)
        {
           
            USR01 user = _blLogin.ValidateUser(objLogin);
            if (user != null)
            {
                _blTokenManager.GenerateToken(user);
                string token = BLTokenManager.cache.Get(BLTokenManager.CachePrefix + user.R01F02) as string;
                return Ok(new { Token = token });
            }
            return Unauthorized();
        }

        [HttpGet("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            int a = 0;
            int b = 2;
            b = b / a;
            return Ok();
        }

    }
}
