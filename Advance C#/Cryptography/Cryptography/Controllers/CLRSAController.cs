using Cryptography.Auth;
using System.Net.Http;
using System.Web.Http;

namespace Cryptography.Controllers
{
    public class CLRSAController : ApiController
    {   

        /// <summary>
        /// Encrypts the provided plaintext using RSA.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>An HttpResponseMessage containing the public key and encrypted text.</returns>
        [HttpPost]
        [Route("api/rsa/encrypt")]
        public HttpResponseMessage Encrypt([FromBody] string plaintext)
        {
           return BLRSA.Encrypt(plaintext); 
        }

        /// <summary>
        /// Decrypts the provided encrypted data using RSA.
        /// </summary>
        /// <param name="encryptedData">The encrypted data to decrypt.</param>
        /// <returns>An HttpResponseMessage containing the decrypted plaintext.</returns>
        [HttpPost]
        [Route("api/rsa/decrypt")]
        public HttpResponseMessage Decrypt([FromBody] string encryptedData)
        {
            return BLRSA.Decrypt(encryptedData);
        }
    }
}
