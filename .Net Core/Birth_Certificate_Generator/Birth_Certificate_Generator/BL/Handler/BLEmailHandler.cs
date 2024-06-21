using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.ML;
using System.Net;
using System.Net.Mail;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Email Service which implements ISender
    /// </summary>
    public class BLEmailHandler : IEmailService
    {
        #region Private Members

        /// <summary>
        /// Configuration for Email Setting
        /// </summary>
        private readonly IConfiguration _config;
        #endregion

        #region Constructor

        /// <summary>
        /// BLEmailHandler for handling Email
        /// </summary>
        /// <param name="config"></param>
        public BLEmailHandler(IConfiguration config)
        {
            
            _config = config;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// for Sending and email
        /// </summary>
        /// <param name="email">Receiver's Email</param>
        /// <param name="body">Email Body</param>
        /// <param name="attachmentBytes">Cerificate Pdf As Byte[]</param>
        public void Send(string email, string body, byte[] attachmentBytes)
        {
            Response response = new Response();
            try
            {
                string senderEmail = _config["EmailSettings:SenderEmail"];
                string senderPassword = _config["EmailSettings:SenderPassword"];

                MailMessage mail = new MailMessage(senderEmail, email);
                mail.Subject = "Birth Certificate generated";
                mail.Body = body;

                if (attachmentBytes != null)
                {
                    mail.Attachments.Add(new Attachment(new MemoryStream(attachmentBytes), "BirthCertificate.pdf", "application/pdf"));
                }
                else
                {
                    mail.Attachments.Clear();
                }

                SmtpClient smtpClient = new SmtpClient(_config["EmailSettings:SmtpClient"]);
                smtpClient.Port = Convert.ToInt32(_config["EmailSettings:Port"]);
                smtpClient.Credentials = new NetworkCredential(senderEmail, senderPassword);
                smtpClient.EnableSsl = true;

                smtpClient.Send(mail);
                response.Message = "Successfully Sent";

              
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
        }

        #endregion
    }
}
