using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.Connection;
using Birth_Certificate_Generator.DL.Interface;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML.POCO;
using Birth_Certificate_Generator.Other;
using ServiceStack.OrmLite;
using System.Data;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// BirthCertificate For Requesting and Validation Handler
    /// </summary>
    public class BLBCR01Handler : IBCR01
    {
        #region Private Members
        /// <summary>
        /// ORM Lite connection factory for database operations.
        /// </summary>
        private readonly IOrmLiteContext _dbFactory;

        /// <summary>
        /// instance current birth certificate request.
        /// </summary>
        private BCR01 _objBCR01;

        /// <summary>
        /// interface Repository for birth certificate request.
        /// </summary>
        private readonly IBCR01Repository _objBCR01Service;

        #endregion

        #region Constructor
        /// <summary>
        /// instance of the BLBCR01Handler with the specified database factory and Interface Repository.
        /// </summary>
        /// <param name="dbFactory">The ORM Lite connection factory for database operations.</param>
        /// <param name="objBCR01Service">The interface Repository for birth certificate request data operations.</param>
        public BLBCR01Handler(IOrmLiteContext dbFactory, IBCR01Repository objBCR01Service)
        {
            _dbFactory = dbFactory;
            _objBCR01Service = objBCR01Service;
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Retrieves all birth certificate requests.
        /// </summary>
        /// <returns>A Response object containing all birth certificate requests.</returns>
        public Response GetAll()
        {
            Response response = new Response();
            DataTable dtResult = _objBCR01Service.GetAllData();

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "No birth certificate requests found";
                return response;
            }

            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Retrieves all pending birth certificate requests.
        /// </summary>
        /// <returns>A Response object containing all pending birth certificate requests.</returns>
        public Response GetPending()
        {
            Response response = new Response();
            DataTable dtResult = _objBCR01Service.GetPending();

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "No pending birth certificate requests found";
                return response;
            }

            response.Data = dtResult; // Return pending data
            return response;
        }

        /// <summary>
        /// Retrieves a birth certificate request by its ID.
        /// </summary>
        /// <param name="id">The ID of the birth certificate request to retrieve.</param>
        /// <returns>A Response object containing the request data or an error message.</returns>
        public Response GetById(int id)
        {
            Response response = new Response();
            DataTable dtResult = _objBCR01Service.GetDataByID(id);

            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = $"Birth certificate request with ID = {id} not found"; // Handle not found
                return response;
            }

            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Presave For converting dto to poco and set other feilds
        /// </summary>
        /// <param name="objdtoBCR01">DTO representing the birth certificate request.</param>
        public void PreSave(DTOBCR01 objdtoBCR01)
        {
            _objBCR01 = objdtoBCR01.CreatePOCO<BCR01>();
            _objBCR01.C01F03 = DateTime.Now;
            _objBCR01.C01F04 = EnmStatus.P.ToString();
        }

        /// <summary>
        /// Validates the birth certificate request for it doesn't duplicate existing records.
        /// </summary>
        /// <returns>A Response object indicating validation success or failure.</returns>
        public Response Validate()
        {
            Response response = new Response();
            int count;
            using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
            {
                count = (int)db.Count((BCR01 p) => p.C01F02 == _objBCR01.C01F02);
            }
            if (count > 0 || _objBCR01.C01F02 == 0)
            {
                response.IsSuccess = false;
                response.Message = "Duplicate birth certificate request for this child"; // Handle duplicate case
            }
            return response;
        }

        /// <summary>
        /// Saves the birth certificate request to the database.
        /// </summary>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        public Response Save()
        {
            Response response = new Response();

            using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
            {
                db.Insert(_objBCR01);
            }
            response.IsSuccess = true;
            response.Message = EnmOperation.I.GetMessage();

            return response;
        }

        /// <summary>
        /// Deletes a birth certificate request by its ID.
        /// </summary>
        /// <param name="id">The ID of the birth certificate request to delete.</param>
        /// <returns>A Response object indicating success or failure of the operation.</returns>
        public Response Delete(int id)
        {
            Response response = new Response();
            int rowsAffected;
            using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
            {
                rowsAffected = db.DeleteById<BCR01>(id);
            }
            if (rowsAffected == 0)
            {
                response.IsSuccess = false;
                response.Message = $"Birth certificate request with ID = {id} does not exist";
            }
            else
            {
                response.Message = EnmOperation.D.GetMessage();
            }


            return response;
        }

        #endregion
    }
}
