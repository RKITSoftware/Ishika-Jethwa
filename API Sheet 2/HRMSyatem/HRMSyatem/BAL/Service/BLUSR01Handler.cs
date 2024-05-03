using HRMSyatem.Auth;
using HRMSyatem.DAL;
using HRMSyatem.MAL.Dto;
using HRMSyatem.MAL.POCO;
using HRMSystem.BL;
using HRMSystem.Connection;
using HRMSystem.Helper;
using HRMSystem.MAL;
using HRMSystem.Models;
using ServiceStack.OrmLite;
using System;
using System.Data;

namespace HRMSyatem.BAL.Service
{
    /// <summary>
    /// Handles operations related to users and employees.
    /// </summary>
    public class BLUSR01Handler
    {
        #region Private members

        private USR01 _objUsr01;
        private DBUSR01Context _objDbUsr01;

        #endregion

        public BLUSR01Handler()
        {
            _objDbUsr01 = new DBUSR01Context();
        }
        #region Public Menebers

        /// <summary>
        /// Specifies the operation to be performed.
        /// </summary>
        public EnmOperation Operation;

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves a list of all Users from the database.
        /// </summary>
        /// <returns>An IEnumerable of Emp01 representing the list of Users.</returns>
        public Response GetUsers()
        {
            Response response = new Response();
            DataTable dtresult = _objDbUsr01.GetallUser();
            if (dtresult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "User Not Found";
            }
            response.Data = dtresult;
            return response;
        }

        /// <summary>
        /// Retrieves a specific User from the database based on the User ID.
        /// </summary>
        /// <param name="id">The ID of the User to retrieve.</param>
        /// <returns>An Emp01 object representing the User details.</returns>
        public Response GetById(int id)
        {
            Response response = new Response();

            DataTable dtresult = _objDbUsr01.GetUserById(id);
            if (dtresult.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "User not found";
            }

            // Convert the single user object to a DataTable using the extension method
            response.Data = dtresult;


            return response;
        }

        /// <summary>
        /// Adds a new User to the database.
        /// </summary>
        /// <param name="objUser">An Emp01 object representing the User to be added.</param>
        /// <returns>A string indicating the result of the operation.</returns>
        public Response Save()
        {
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {

                try
                {
                    if (Operation == EnmOperation.I)
                    {

                        db.Insert(_objUsr01);
                        response.Message = EnmOperation.I.GetMessage();
                    }
                    else if (Operation == EnmOperation.U)
                    {
                        int result = db.UpdateOnlyFields(
                                             _objUsr01, // Object with the field to update
                                             new[] { nameof(USR01.R01F03), nameof(USR01.R01F04), nameof(USR01.R01F05), }, // Fields to update
                                             x => x.R01F02 == _objUsr01.R01F02 && x.R01F01 == _objUsr01.R01F01 // Condition to select the record to update
                                             );
                        if (result == 0)
                        {
                            response.IsSuccess = false;
                            response.Message = "Updation failed";
                        }
                        else
                        {
                            response.Message = EnmOperation.U.GetMessage();
                        }
                    }
                }
                catch (Exception ex)
                {

                    response.IsSuccess = false;
                    response.Message = "Error saving user: " + ex.Message;
                }
            }

            return response;
        }

        /// <summary>
        /// Performs operations before saving the User data.
        /// </summary>
        /// <param name="objdtoUsr">The DTO representing the User data.</param>
        public void PreSave(DTOUSR01 objdtoUsr)
        {
            _objUsr01 = objdtoUsr.CreatePOCO<USR01>();


            if (Operation == EnmOperation.I)
            {
                // Assuming you have a property to store creation date/time in the USR01 class
                _objUsr01.R01F04 = BLEncryptDecrypt.Encrypt(objdtoUsr.R01F04);
                _objUsr01.R01F06 = DateTime.Now;

            }
            else if (Operation == EnmOperation.U)
            {
                // Assuming you have a property to store modification date/time in the USR01 class
                _objUsr01.R01F07 = DateTime.Now;

            }
        }

        /// <summary>
        /// Validates the User data.
        /// </summary>
        /// <returns>A response indicating the validation result.</returns>
        public Response Validate()
        {
            int count;
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    // Check if the table contains any records with the same values as the provided USR01 object
                    count = (int)db.Count((USR01 p) => p.R01F02 == _objUsr01.R01F02 || p.R01F03 == _objUsr01.R01F03);

                    // If no existing records match the provided object, it's considered valid
                    if (count > 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Duplicate entry found";
                        return response;
                    }
                    count = (int)db.Count((EMP01 e) => e.P01F01 == _objUsr01.R01F02); // Check for existing Employee ID
                }
                if (count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Employee ID does not exist";

                }
            }
            else
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    // Check if a record with the provided ID exists in the table
                    count = (int)db.Count((USR01 p) => p.R01F01 == _objUsr01.R01F01);

                    // If no record matches the provided ID, it's considered invalid
                    if (count <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = $"User with ID = {_objUsr01.R01F01} does not exist";
                        return response;
                    }
                    count = (int)db.Count((EMP01 e) => e.P01F01 == _objUsr01.R01F02); // Check for existing Employee ID
                }
                if (count == 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Employee ID does not exist";

                }
            }
            return response;
        }


        #endregion
    }
}
