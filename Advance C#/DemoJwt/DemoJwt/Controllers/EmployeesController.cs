using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Http;

namespace DemoJwt.Controllers
{
    public class EmployeesController : ApiController
    {
        [HttpPost]
        [Route ("token-gen")]
        public IHttpActionResult TokenGenerate([FromBody] string data)
        {
            var requestData = JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
            //Checks Username and password
            bool isValidated = ValidateUSer.Login(requestData["username"].ToString(), requestData["password"].ToString());

            if (isValidated)
            {
                //Generates a JWT Token
                string key = "secretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKeysecretKey";
                string issuer = "http://localhost:44363";

                SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)); //key converted into UTF8 format
                SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); // UTF > hashing

                List<Claim> lstClaims = new List<Claim>(); //~A list of key value pair
                lstClaims.Add(new Claim("username", requestData["username"].ToString()));

                JwtSecurityToken token = new JwtSecurityToken(issuer,
                                issuer,
                                lstClaims,
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

    }
}
