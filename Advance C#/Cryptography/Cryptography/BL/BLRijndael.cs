using Cryptography.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Security.Cryptography;

namespace Cryptography.Auth
{
    public static class BLRijndael
    {
        /// <summary>
        /// Generates a new Rijndael key and initialization vector (IV).
        /// </summary>
        /// <returns> containing the generated key and IV.</returns>
        public static HttpResponseMessage GetKey()
        {
            try
            {
                // Create a new instance of the Rijndael class.
                using (Rijndael rijAlg = Rijndael.Create())
                {
                    // Generate a new key and IV.
                    rijAlg.GenerateKey();
                    rijAlg.GenerateIV();

                    // Convert key and IV to base64 strings for easier handling.
                    string base64Key = Convert.ToBase64String(rijAlg.Key);
                    string base64IV = Convert.ToBase64String(rijAlg.IV);

                    // Create an HttpResponseMessage and set its content
                    HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new ObjectContent<object>(new { Key = base64Key, IV = base64IV }, new JsonMediaTypeFormatter());

                    return response;
                }
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Internal Server Error")
                };
            }
        }

        /// <summary>
        /// Encrypts the provided plaintext using Rijndael algorithm.
        /// </summary>
        /// <param name="request">The encryption request containing plaintext, key, and IV.</param>
        /// <returns> containing the encrypted text.</returns>
        public static HttpResponseMessage Encrypt(EncryptionRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.PlainText) || string.IsNullOrEmpty(request.Key) || string.IsNullOrEmpty(request.IV))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Invalid request data.")
                    };
                }

                byte[] key = Convert.FromBase64String(request.Key);
                byte[] iv = Convert.FromBase64String(request.IV);

                // Encrypt the string to an array of bytes.
                byte[] encrypted = BLRijndael.EncryptStringToBytes(request.PlainText, key, iv);

                // Convert the encrypted bytes to a base64 string for easier handling.
                string base64Encrypted = Convert.ToBase64String(encrypted);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(base64Encrypted)
                };
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Error during decryption.")
                };
            }
        }

        /// <summary>
        /// Decrypts the provided encrypted text using Rijndael algorithm.
        /// </summary>
        /// <param name="request">The decryption request containing encrypted text, key, and IV.</param>
        /// <returns> containing the decrypted plaintext.</returns>
        public static HttpResponseMessage Decrypt(DecryptionRequest request)
        {
            try
            {
                if (request == null || string.IsNullOrEmpty(request.EncryptedText) || string.IsNullOrEmpty(request.Key) || string.IsNullOrEmpty(request.IV))
                {
                    return new HttpResponseMessage(HttpStatusCode.BadRequest)
                    {
                        Content = new StringContent("Invalid request data.")
                    };
                }

                byte[] key = Convert.FromBase64String(request.Key);
                byte[] iv = Convert.FromBase64String(request.IV);
                byte[] encryptedText = Convert.FromBase64String(request.EncryptedText);

                // Decrypt the bytes to a string.
                string decryptedText = DecryptStringFromBytes(encryptedText, key, iv);

                return new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent(decryptedText)
                };
            }
            catch (Exception)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("Error during decryption.")
                };
            }
        }

        /// <summary>
        /// Encrypts the provided plaintext using the Rijndael algorithm.
        /// </summary>
        /// <param name="plainText">The plaintext to encrypt.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <returns>The encrypted bytes.</returns>
        public static byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts the provided encrypted bytes using the Rijndael algorithm.
        /// </summary>
        /// <param name="cipherText">The encrypted bytes to decrypt.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <returns>The decrypted plaintext.</returns>
        public static string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}