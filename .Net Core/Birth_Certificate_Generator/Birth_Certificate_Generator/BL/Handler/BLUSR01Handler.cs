using Birth_Certificate_Generator.BL.Interface;
using Birth_Certificate_Generator.ML.DTO;
using Birth_Certificate_Generator.ML;
using ServiceStack.OrmLite;
using System.Data;
using Birth_Certificate_Generator.ML.POCO;
using Birth_Certificate_Generator.Other;
using Birth_Certificate_Generator.DL;

namespace Birth_Certificate_Generator.BL.Handler
{
    /// <summary>
    /// Business logic handler for user-related operations, including CRUD and validation.
    /// </summary>
    public class BLUSR01Handler : IUSR01
    {
        #region Private Members
        /// <summary>
        /// Repository context for user data operations.
        /// </summary>
        private readonly DBUSR01Context _userRepository;

        /// <summary>
        /// The current user object for pre-save and validation operations.
        /// </summary>
        private USR01? objUSR01;

        /// <summary>
        /// ORM Lite connection factory for database connections.
        /// </summary>
        private readonly OrmLiteConnectionFactory _dbFactory;

        /// <summary>
        /// Database connection string for connecting to MySQL.
        /// </summary>
        private readonly string _connectionString;

        #endregion

        #region Public Members
        /// <summary>
        /// Represents the current operation type (Insert, Update, Delete).
        /// </summary>
        public static EnmOperation Operation;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor for BLUSR01Handler with injected configuration and connection factory.
        /// </summary>
        /// <param name="configuration">Configuration object for accessing connection strings.</param>
        /// <param name="dbFactory">ORM Lite connection factory.</param>
        public BLUSR01Handler(IConfiguration configuration, OrmLiteConnectionFactory dbFactory)
        {
            _connectionString = configuration.GetConnectionString("Default");
            _userRepository = new DBUSR01Context(_connectionString);
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
            DataSet dtResult = _userRepository.GetAllUser();
            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
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
            DataSet dtResult = _userRepository.GetUserByUserName(username);
            if (dtResult.Tables.Count == 0 || dtResult.Tables[0].Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "User Not Found"; 
            }
            response.Data = dtResult;
            return response;
        }

        /// <summary>
        /// Saves a user to the database (insert or update based on the operation).
        /// </summary>
        /// <returns>A Response object indicating the success or failure of the operation.</returns>
        public Response Save()
        {
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    db.Insert(objUSR01); 
                }
                response.Message = EnmOperation.I.GetMessage();
            }
            else
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
                {
                    db.Update(objUSR01); 
                }
                response.Message = EnmOperation.U.GetMessage();
            }
            return response;
        }

        /// <summary>
        /// Deletes a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>A Response object indicating the success or failure of the deletion.</returns>
        public Response Delete(int id)
        {
            Response response = new Response();
            using (IDbConnection db = _dbFactory.OpenDbConnection())
            {
                int rowsAffected = db.DeleteById<USR01>(id); 
                if (rowsAffected == 0)
                {
                    response.IsSuccess = false;
                    response.Message = $"User {id} does not exist";
                }
                else
                {
                    response.Message = EnmOperation.D.GetMessage();
                }
            }
            return response;
        }

        /// <summary>
        /// Prepares a user object for saving to the database.
        /// </summary>
        /// <param name="objUSR01Dto">The data transfer object representing the user.</param>
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
        /// Validates the user object to ensure it's ready for saving.
        /// </summary>
        /// <returns>A Response object indicating whether the validation passed or failed.</returns>
        public Response Validate()
        {
            int count;
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = _dbFactory.OpenDbConnection())
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
                using (IDbConnection db = _dbFactory.OpenDbConnection())
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
