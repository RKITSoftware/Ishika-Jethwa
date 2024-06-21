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
    /// Business logic handler for user-related operations.
    /// </summary>
    public class BLUSR01Handler : IUSR01
    {
        #region Private Members
        /// <summary>
        /// Interface Repository for user data operations.
        /// </summary>
        private readonly IUSR01Repository _objUSR01Service;

        /// <summary>
        /// The current user object.
        /// </summary>
        private USR01 objUSR01;

        /// <summary>
        /// ORM Lite connection factory for database connections.
        /// </summary>
        private readonly IOrmLiteContext _dbFactory;


        #endregion

        #region Public Members
        /// <summary>
        /// Represents the current operation type (Insert, Update, Delete).
        /// </summary>
        public static EnmOperation Operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for BLUSR01Handler for connection factory and userRepository.
        /// </summary>
        /// <param name="dbFactory">ORM Lite connection factory.</param>
        /// <param name="userrepository">Interface For User Related Data operation</param>
        public BLUSR01Handler(IOrmLiteContext dbFactory, IUSR01Repository userrepository)
        {
            _objUSR01Service = userrepository;
            _dbFactory = dbFactory;
        }

        #endregion

        #region Public Method
        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>A Response object with all user data.</returns>
        public Response GetAll()
        {
            Response response = new Response();
            DataTable dtResult = _objUSR01Service.GetAllUser();
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "User Not Found";
            }
            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Retrieves a user by their username.
        /// </summary>
        /// <param name="username">The username to search for.</param>
        /// <returns>A Response object with the user data or a not found message.</returns>
        public Response GetUserByusername(string username)
        {
            Response response = new Response();
            DataTable dtResult = _objUSR01Service.GetUserByUserName(username);
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "User Not Found";
            }
            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Saves a user to the database (insert or update based on the Enmoperation).
        /// </summary>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        public Response Save()
        {
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
                {
                    db.Insert(objUSR01);
                }
                response.Message = EnmOperation.I.GetMessage();
            }
            else
            {
                using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
                {
                    db.Update(objUSR01);
                }
                response.Message = EnmOperation.U.GetMessage();
            }
            return response;
        }

        /// <summary>
        /// Delete a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A Response object indicating the success or failure of the deletion.</returns>
        public Response Delete(int id)
        {
            int rowsAffected;
            Response response = new Response();
            using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
            {
                rowsAffected = db.DeleteById<USR01>(id);
            }
            if (rowsAffected == 0)
            {
                response.IsSuccess = false;
                response.Message = $"User {id} does not exist";
            }
            else
            {
                response.Message = EnmOperation.D.GetMessage();
            }

            return response;
        }

        /// <summary>
        /// Presave a user object for Converting Dto to Poco and set other feild.
        /// </summary>
        /// <param name="objUSR01Dto">The DTO representing the user.</param>
        public void PreSave(DTOUSR01 objUSR01Dto)
        {
            objUSR01 = objUSR01Dto.CreatePOCO<USR01>();
           
            if (Operation == EnmOperation.I)
            {
                objUSR01.R01F06 = DateTime.Now;
            }
            else if (Operation == EnmOperation.U)
            {
                objUSR01.R01F07 = DateTime.Now;
            }
        }

        /// <summary>
        /// Validates the user object.
        /// </summary>
        /// <returns>A Response object indicating whether the validation passed or failed.</returns>
        public Response Validate()
        {
            int count;
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
                {
                    count = (int)db.Count((USR01 p) => p.R01F03 == objUSR01.R01F03);
                }
                if (count > 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Duplicate entry found";
                }
            }
            else
            {
                using (IDbConnection db = _dbFactory.DbFactory.OpenDbConnection())
                {
                    count = (int)db.Count((USR01 p) => p.R01F01 == objUSR01.R01F01);
                }
                if (count <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = $"User with ID = {objUSR01.R01F01} does not exist";
                }
            }
            return response;
        }

        #endregion
    }
}
