using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.ML;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML.POCO;
using Birth_Certificate_Generator.Other;
using ServiceStack.OrmLite;
using System.Data;
using Birth_Certificate_Generator.DL;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Business logic handler for managing child records, providing CRUD operations, validation, and other business-related tasks.
    /// </summary>
    public class BLCHD01Handler : ICHD01
    {
        #region Private Members
        /// <summary>
        /// ORM Lite connection factory for database operations.
        /// </summary>
        private readonly OrmLiteConnectionFactory _dbFactory;

        /// <summary>
        /// The child object used for pre-save operations and data handling.
        /// </summary>
        private CHD01 _objCHD01;

        /// <summary>
        /// Repository context for child-related data operations.
        /// </summary>
        private readonly DBCHD01Context _childRepository;
        #endregion

        #region Public Member
        /// <summary>
        /// Current operation type (Insert, Update, Delete).
        /// </summary>
        public static EnmOperation Operation;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the BLCHD01Handler class with the specified database factory and child repository.
        /// </summary>
        /// <param name="dbFactory">ORM Lite connection factory for database operations.</param>
        /// <param name="context">Repository context for child-related data operations.</param>
        public BLCHD01Handler(OrmLiteConnectionFactory dbFactory, DBCHD01Context context)
        {
            _dbFactory = dbFactory;
            _childRepository = context;
        }
        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves all child records.
        /// </summary>
        /// <returns>A Response object containing all child records.</returns>
        public Response GetAll()
        {
            Response response = new Response();
            DataSet dtResult = _childRepository.GetAllChildren();

            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "No child records found"; 
                return response;
            }
            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Retrieves a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child record to retrieve.</param>
        /// <returns>A Response object with the child record or a not found message.</returns>
        public Response GetById(int id)
        {
            Response response = new Response();
            DataSet dtResult = _childRepository.GetChildById(id);

            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = $"Child with ID = {id} not found";
                return response;
            }
            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Prepares a child record for saving to the database.
        /// </summary>
        /// <param name="childDto">Data transfer object representing the child to be saved.</param>
        public void PreSave(DTOCHD01 childDto)
        {
            _objCHD01 = childDto.CreatePOCO<CHD01>(); // Convert DTO to POCO
            if (Operation == EnmOperation.I) 
            {
                _objCHD01.D01F08 = DateTime.Now; 
            }
        }

        /// <summary>
        /// Validates the child record to ensure it's ready for saving.
        /// </summary>
        /// <returns>A Response object indicating whether validation passed or failed.</returns>
        public Response Validate()
        {
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    int count = (int)db.Count((CHD01 p) => p.D01F02 == _objCHD01.D01F02 && p.D01F03 == _objCHD01.D01F03);

                    if (count > 0) 
                    {
                        response.IsSuccess = false;
                        response.Message = "Duplicate entry found"; 
                    }
                }
            }

            return response;
        }

        /// <summary>
        /// Saves the child record to the database (Insert or Update).
        /// </summary>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        public Response Save()
        {
            Response response = new Response();

            if (Operation == EnmOperation.I) 
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    db.Insert(_objCHD01); 
                }

                response.Message = EnmOperation.I.GetMessage();
            }
            else if (Operation == EnmOperation.U) 
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    db.Update(_objCHD01); 
                }

                response.Message = EnmOperation.U.GetMessage();
            }

            return response;
        }

        /// <summary>
        /// Deletes a child record by its ID.
        /// </summary>
        /// <param name="id">The ID of the child record to delete.</param>
        /// <returns>A Response object indicating the success or failure of the deletion.</returns>
        public Response Delete(int id)
        {
            Response response = new Response();

            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                int rowsAffected = db.DeleteById<CHD01>(id);

                if (rowsAffected == 0) 
                {
                    response.IsSuccess = false;
                    response.Message = $"Child with ID = {id} does not exist"; 
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
