using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.DL;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML.POCO;
using Birth_Certificate_Generator.Other;
using ServiceStack.OrmLite;
using System.Data;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Business logic handler for managing birth certificate requests, providing CRUD operations, validation, and related business tasks.
    /// </summary>
    public class BLBCR01Handler : IBCR01
    {

        #region Private Members
        /// <summary>
        /// ORM Lite connection factory for database operations.
        /// </summary>
        private readonly OrmLiteConnectionFactory _dbFactory;

        /// <summary>
        /// The current birth certificate request being handled.
        /// </summary>
        private BCR01 _currentRequest;

        /// <summary>
        /// Repository context for birth certificate request data operations.
        /// </summary>
        private readonly DBBCR01Context _objDbBCR01;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the BLBCR01Handler with the specified database factory and context.
        /// </summary>
        /// <param name="dbFactory">The ORM Lite connection factory for database operations.</param>
        /// <param name="obj">The repository context for birth certificate request data operations.</param>
        public BLBCR01Handler(OrmLiteConnectionFactory dbFactory, DBBCR01Context obj)
        {
            _dbFactory = dbFactory;
            _objDbBCR01 = obj;
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
            DataSet dtResult = _objDbBCR01.GetAllData();

            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
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
            DataSet dtResult = _objDbBCR01.GetPending();

            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
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
            DataSet dtResult = _objDbBCR01.GetDataByID(id);

            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = $"Birth certificate request with ID = {id} not found"; // Handle not found
                return response;
            }

            response.Data = dtResult; 
            return response;
        }

        /// <summary>
        /// Prepares a birth certificate request for saving to the database.
        /// </summary>
        /// <param name="objBCR01">Data transfer object representing the birth certificate request.</param>
        public void PreSave(DTOBCR01 objBCR01)
        {
            _currentRequest = objBCR01.CreatePOCO<BCR01>(); 
            _currentRequest.C01F03 = DateTime.Now; 
            _currentRequest.C01F04 = EnmStatus.P.ToString(); 
        }

        /// <summary>
        /// Validates the birth certificate request to ensure it doesn't duplicate existing records.
        /// </summary>
        /// <returns>A Response object indicating validation success or failure.</returns>
        public Response Validate()
        {
            Response response = new Response();
            int count;
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                count = (int)db.Count((BCR01 p) => p.C01F02 == _currentRequest.C01F02);

                if (count > 0) 
                {
                    response.IsSuccess = false;
                    response.Message = "Duplicate birth certificate request for this child"; // Handle duplicate case
                }
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

            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                db.Insert(_currentRequest); 
                response.IsSuccess = true;
                response.Message = EnmOperation.I.GetMessage(); 
            }
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

            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                int rowsAffected = db.DeleteById<BCR01>(id);

                if (rowsAffected == 0) 
                {
                    response.IsSuccess = false;
                    response.Message = $"Birth certificate request with ID = {id} does not exist";
                }
                else
                {
                    response.Message = EnmOperation.D.GetMessage(); 
                }
            }

            return response;
        }

        #endregion
    }
}
