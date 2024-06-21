namespace Cryptography.Models
{
    /// <summary>
    /// Represents a request for encryption.
    /// </summary>
    public class EncryptionRequest
    {
        /// <summary>
        /// Gets or sets the plaintext to encrypt.
        /// </summary>
        public string PlainText { get; set; }

        /// <summary>
        /// Gets or sets the encryption key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV).
        /// </summary>
        public string IV { get; set; }
    }

    /// <summary>
    /// Represents a request for decryption.
    /// </summary>
    public class DecryptionRequest
    {
        /// <summary>
        /// Gets or sets the encrypted text to decrypt.
        /// </summary>
        public string EncryptedText { get; set; }

        /// <summary>
        /// Gets or sets the encryption key.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the initialization vector (IV).
        /// </summary>
        public string IV { get; set; }
    }
}