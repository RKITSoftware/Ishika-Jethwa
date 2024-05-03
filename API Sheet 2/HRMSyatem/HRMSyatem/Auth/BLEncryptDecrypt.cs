using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HRMSyatem.Auth
{
    /// <summary>
    /// Encryption Decyption
    /// </summary>
    public class BLEncryptDecrypt
    {
        #region private members
        private const string Key = "0123456789abcdef"; // 128-bit key
        private static readonly string Iv = "abcdef0123456789"; // 128-bit IV
        #endregion

        #region public method
        /// <summary>
        /// Encrypts the provided plain text using AES encryption.
        /// </summary>
        /// <param name="plainText">The plain text to encrypt.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <returns>The base64-encoded encrypted text.</returns>
        public static string Encrypt(string plainText)
        {
            using (AesManaged aes = new AesManaged())
            {
                // Set the encryption key and IV
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(Iv);

                // Create an encryptor based on the key and IV
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter sw = new StreamWriter(cs))
                        {
                            // Write the plain text to the CryptoStream
                            sw.Write(plainText);
                        }
                    }
                    // Convert the encrypted bytes to a base64-encoded string
                    return Convert.ToBase64String(ms.ToArray());
                }
            }
        }
        /// <summary>
        /// Decrypts the provided cipher text using AES decryption.
        /// </summary>
        /// <param name="cipherText">The base64-encoded encrypted text.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <returns>The decrypted plain text.</returns>
        public static string Decrypt(string cipherText)
        {
            using (AesManaged aes = new AesManaged())
            {

                // Set the encryption key and IV
                aes.Key = Encoding.UTF8.GetBytes(Key);
                aes.IV = Encoding.UTF8.GetBytes(Iv);

                // Create a decryptor based on the key and IV
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader sr = new StreamReader(cs))
                        {
                            // Read the decrypted plain text from the CryptoStream
                            return sr.ReadToEnd();
                        }
                    }
                }
            }
        }
        #endregion
    }
}