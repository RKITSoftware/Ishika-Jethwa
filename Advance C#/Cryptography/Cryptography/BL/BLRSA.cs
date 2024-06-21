using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography;
using System.Text;

namespace Cryptography.Auth
{
    public static class BLRSA
    {
        /// <summary>
        /// The RSA provider for encryption and decryption.
        /// </summary>
        public static RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();

        /// <summary>
        /// Encrypts the specified plaintext using RSA.
        /// </summary>
        /// <param name="plaintext">The plaintext to encrypt.</param>
        /// <returns>HttpResponseMessage containing the encrypted text and public key.</returns>
        public static HttpResponseMessage Encrypt(string plaintext)
        {
            try
            {
                if (string.IsNullOrEmpty(plaintext))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Plaintext cannot be null or empty.")
                    };
                }

                // Get the public key
                RSAParameters publicKeyParams = rsaProvider.ExportParameters(false);
                string publicKey = Convert.ToBase64String(publicKeyParams.Modulus);

                // Encrypt the plaintext
                byte[] encryptedBytes = rsaProvider.Encrypt(Encoding.UTF8.GetBytes(plaintext), false);
                string encryptedText = Convert.ToBase64String(encryptedBytes);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(new { PublicKey = publicKey, EncryptedText = encryptedText }, new JsonMediaTypeFormatter())
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Error: {ex.Message}")
                };
            }
        }

        /// <summary>
        /// Decrypts the specified encrypted text using RSA.
        /// </summary>
        /// <param name="encryptedText">The encrypted text to decrypt.</param>
        /// <returns>HttpResponseMessage containing the decrypted text.</returns>
        public static HttpResponseMessage Decrypt(string encryptedText)
        {
            try
            {
                if (string.IsNullOrEmpty(encryptedText))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Encrypted text cannot be null or empty.")
                    };
                }

                // Get the private key
                RSAParameters privateKeyParams = rsaProvider.ExportParameters(true);

                // Create a new RSA provider with the private key
                RSACryptoServiceProvider rsaDecryptor = new RSACryptoServiceProvider();
                rsaDecryptor.ImportParameters(privateKeyParams);

                // Decrypt the encrypted text
                byte[] encryptedBytes = Convert.FromBase64String(encryptedText);
                byte[] decryptedBytes = rsaDecryptor.Decrypt(encryptedBytes, false);
                string decryptedText = Encoding.UTF8.GetString(decryptedBytes);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new ObjectContent<object>(new { DecryptedText = decryptedText }, new JsonMediaTypeFormatter())
                };
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent($"Error: {ex.Message}")
                };
            }
        }
    }
}
