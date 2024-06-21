using System;
using System.IO;
using System.Security.Cryptography;

namespace JWT.BL
{
    /// <summary>
    /// Class for Rijndael encryption and decryption operations.
    /// </summary>
    public class Rijndeal
    {
        /// <summary>
        /// Encrypts the provided text using Rijndael algorithm.
        /// </summary>
        /// <param name="claimsText">The text to be encrypted.</param>
        /// <param name="key">The encryption key in base64 format.</param>
        /// <param name="iv">The initialization vector (IV) in base64 format.</param>
        /// <returns>The encrypted text in base64 format.</returns>
        public string EncryptRijndael(string claimsText, string key, string iv)
        {
            try
            {
                if (string.IsNullOrEmpty(claimsText))
                {
                    return "Invalid Data";
                }

                // Convert base64 strings to byte arrays
                byte[] Key = Convert.FromBase64String(key);
                byte[] IV = Convert.FromBase64String(iv);

                // Encrypt the string to an array of bytes.
                byte[] encrypted = EncryptStringToBytes(claimsText, Key, IV);

                // Convert the encrypted bytes to a base64 string for easier handling.
                string base64Encrypted = Convert.ToBase64String(encrypted);

                return base64Encrypted;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Encrypts a plain text to bytes using Rijndael algorithm.
        /// </summary>
        /// <param name="plainText">The plain text to be encrypted.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <returns>The encrypted bytes.</returns>
        public byte[] EncryptStringToBytes(string plainText, byte[] key, byte[] iv)
        {
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Write the data to the stream.
                            swEncrypt.Write(plainText);
                        }

                        // Return the encrypted bytes.
                        return msEncrypt.ToArray();
                    }
                }
            }
        }

        /// <summary>
        /// Decrypts the provided encrypted text using Rijndael algorithm.
        /// </summary>
        /// <param name="claimsText">The encrypted text in base64 format.</param>
        /// <param name="key">The encryption key in base64 format.</param>
        /// <param name="iv">The initialization vector (IV) in base64 format.</param>
        /// <returns>The decrypted text.</returns>
        public string Decrypt(string claimsText, string key, string iv)
        {
            try
            {
                if (string.IsNullOrEmpty(claimsText))
                {
                    return "Invalid";
                }

                // Convert base64 strings to byte arrays
                byte[] Key = Convert.FromBase64String(key);
                byte[] IV = Convert.FromBase64String(iv);
                byte[] encryptedText = Convert.FromBase64String(claimsText);

                // Decrypt the bytes to a string.
                string decryptedText = DecryptStringFromBytes(encryptedText, Key, IV);

                return decryptedText;
            }
            catch (Exception)
            {
                return "Error";
            }
        }

        /// <summary>
        /// Decrypts the provided encrypted bytes using the Rijndael algorithm.
        /// </summary>
        /// <param name="cipherText">The encrypted bytes.</param>
        /// <param name="key">The encryption key.</param>
        /// <param name="iv">The initialization vector (IV).</param>
        /// <returns>The decrypted plaintext.</returns>
        public string DecryptStringFromBytes(byte[] cipherText, byte[] key, byte[] iv)
        {
            using (Rijndael rijAlg = Rijndael.Create())
            {
                rijAlg.Key = key;
                rijAlg.IV = iv;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // Read the decrypted bytes from the decrypting stream and convert them to a string.
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}
