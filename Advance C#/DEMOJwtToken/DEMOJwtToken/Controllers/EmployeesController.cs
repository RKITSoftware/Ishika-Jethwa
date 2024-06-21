using DEMOJwtToken.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace DEMOJwtToken.Controllers
{
    public class EmployeesController : ApiController
    {
      
      
        [HttpPost]
        [Route("token-gen")]
        public IHttpActionResult TokenGenerate([FromBody] Credentials  data)
        {
            
            //Checks Username and password
            bool isValidated = ValidateUSer.IsLogin(data.username, data.password);

            if (isValidated)
            {
                //Generates a JWT Token
                string key = "secretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKey";
                string issuer = "http://localhost:55271";

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); //key converted into UTF8 format
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // UTF > hashing

                List<Claim> permClaims = new List<Claim>(); //~A list of key value pair
                permClaims.Add(new Claim("username", data.username));

                JwtSecurityToken token = new JwtSecurityToken(issuer,
                                issuer,
                                permClaims,
                                expires: DateTime.Now.AddDays(1),
                                signingCredentials: credentials);
                var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
                return Ok(new { JwtToken = jwt_token });
            }
            else
            {
                return Unauthorized();
            }


        }

        [HttpPost]
        [Route("api/getname")]
        public String GetName()
        {
            if (User.Identity.IsAuthenticated)
            {
                var identity = User.Identity as ClaimsIdentity;
                if (identity != null)
                {
                    IEnumerable<Claim> permClaims = identity.Claims;
                }
                return "Valid";
            }
            else
            {
                return "Invalid";
            }
        }

       // [Authorize]
        [HttpPost]
        [Route("api/getname2")]
        public Object GetName2()
        {
            var identity = User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                IEnumerable<Claim> claims = identity.Claims;
                var name = claims.Where(p => p.Type == "name").FirstOrDefault()?.Value;
                return new
                {
                    data = name
                };
            }
            return null;
        }
    }
}