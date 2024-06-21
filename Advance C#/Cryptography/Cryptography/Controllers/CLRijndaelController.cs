using Cryptography.Auth;
using Cryptography.Models;
using System.Net.Http;
using System.Web.Http;

namespace Cryptography.Controllers
{
 
    public class CLRijndaelController : ApiController
    {
        /// <summary>
        /// Generates a new Rijndael key and initialization vector (IV).
        /// </summary>
        /// <returns> containing the generated key and IV.</returns>
        [HttpGet]
        [Route("api/rijndael/key")]
        public HttpResponseMessage GetKey()
        {
            return BLRijndael.GetKey();
        }

        /// <summary>
        /// Encrypts the provided plaintext using Rijndael algorithm.
        /// </summary>
        /// <param name="request">The encryption request containing plaintext, key, and IV.</param>
        /// <returns> containing the encrypted text.</returns>
        [HttpPost]
        [Route("api/rijndael/encrypt")]
        public HttpResponseMessage Encrypt([FromBody] EncryptionRequest request)
        {
            return BLRijndael.Encrypt(request);
        }

        /// <summary>
        /// Decrypts the provided encrypted text using Rijndael algorithm.
        /// </summary>
        /// <param name="request">The decryption request containing encrypted text, key, and IV.</param>
        /// <returns> containing the decrypted plaintext.</returns>
        [HttpPost]
        [Route("api/rijndael/decrypt")]
        public HttpResponseMessage Decrypt([FromBody] DecryptionRequest request)
        {
            return BLRijndael.Decrypt(request);
        } 
    }
}
