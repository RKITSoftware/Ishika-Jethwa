using Cryptography.Auth;
using System.Web.Http;

namespace Cryptography.Controllers
{
    public class CLAESEncryptionController : ApiController
    {
        /// <summary>
        /// Encrypts the provided plaintext using AES.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>The encrypted text.</returns>
        [HttpPost]
        [Route("api/encrypt")]
        public IHttpActionResult Encrypt(string plaintext)
        {
           return Ok(BLEncryptDecrypt.Encrypt(plaintext));
        }

        /// <summary>
        /// Decrypts the provided encrypted text using AES.
        /// </summary>
        /// <param name="encryptedText">The encrypted text to decrypt.</param>
        /// <returns>The decrypted plaintext.</returns>
        [HttpPost]
        [Route("api/decrypt")]
        public IHttpActionResult Decrypt([FromBody] string encryptedText)
        {
           return Ok(BLEncryptDecrypt.Decrypt(encryptedText));
        }
    }
}
