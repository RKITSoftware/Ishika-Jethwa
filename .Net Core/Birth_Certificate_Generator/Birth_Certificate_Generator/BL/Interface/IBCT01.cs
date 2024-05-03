using Birth_Certificate_Generator.ML;

namespace Birth_Certificate_Generator.BL.Interface
{
    /// <summary>
    /// Interface For Birth Certificatation
    /// </summary>
    public interface IBCT01
    {
        /// <summary>
        /// Generates Certificate's pdf
        /// </summary>
        /// <param name="id">Id of Request to be generate</param>
        Response FinalCertificate(int id);

        /// <summary>
        /// Validation that already generated or not
        /// </summary>
        /// <param name="requestID"></param>
        /// <returns></returns>
        Response Validation(int requestID);
    }
}
