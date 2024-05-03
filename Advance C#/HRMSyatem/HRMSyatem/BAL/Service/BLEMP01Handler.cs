using HRMSyatem.MAL.POCO;
using HRMSystem.Connection;
using HRMSystem.DAL;
using HRMSystem.Dto;
using HRMSystem.Helper;
using HRMSystem.MAL;
using HRMSystem.Models;
using ServiceStack.OrmLite;
using System;
using System.Data;
using System.Transactions;

namespace HRMSystem.BL
{
    /// <summary>
    /// Class BLEmp01Handler for Handling Employee's operation
    /// </summary>
    public class BLEMP01Handler 
    {
        #region Private members
        private readonly DBEMP01Context _objDbEmp01;
        private EMP01 _objEmp01;

        #endregion

        #region Public Menebers
        public Helper.EnmOperation Operation;
        #endregion

        #region Constructor
        public BLEMP01Handler()
        {
            _objDbEmp01 = new DBEMP01Context();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>An IEnumerable of Emp01 representing the list of employees.</returns>
        public Response GetEmployees()
        {
            Response response = new Response();
            DataTable dtemp01 = _objDbEmp01.GetAllEmployee();
            if (dtemp01.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "Not Found";
            }
            response.Data = dtemp01;
            return response;
        }

        /// <summary>
        /// Retrieves a specific employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>An Emp01 object representing the employee details.</returns>
        public Response GetByID(int id)
        {
            Response response = new Response();
            DataTable dtemp01 = _objDbEmp01.GetEmployeeByID(id);
            if (dtemp01.Rows.Count == 0)
            {
                response.IsSuccess = false;
                response.Message = "Not Found";

            }
            response.Data = dtemp01;
            return response;
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="objEmployee">An Emp01 object representing the employee to be added.</param>
        /// <returns>A string indicating the result of the operation.</returns>
        public Response Save()
        {
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    db.Insert(_objEmp01);
                }
                response.Message = EnmOperation.I.GetMessage();
            }
            else
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    db.Update(_objEmp01);
                }
                response.Message = EnmOperation.U.GetMessage();
            }
            return response;
        }

        /// <summary>
        /// Removes an employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to be removed.</param>
        /// <returns>A string indicating the result of the operation.</returns>
        public Response RemoveEmployee(int employeeId)
        {
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                    using (IDbTransaction transaction = db.OpenTransaction())
                    {
                        int userRowsAffected = db.Delete<USR01>(x => x.R01F02 == employeeId);

                        int employeeRowsAffected = db.DeleteById<EMP01>(employeeId);

                        if (employeeRowsAffected == 0)
                        {
                            response.IsSuccess = false;
                            response.Message = $"Employee with ID {employeeId} does not exist";
                        }
                        else
                        {
                            response.Message = EnmOperation.D.GetMessage();
                        }

                        // Commit the transaction if everything is successful
                        transaction.Commit();
                    }
            }
            return response;
        }

        /// <summary>
        /// Presave on insert
        /// </summary>
        /// <param name="objdtoEmp"> Dto object</param>
        public void PreSave(DTOEMP01 objdtoEmp)
        {
            _objEmp01 = objdtoEmp.CreatePOCO<EMP01>();
            if (Operation == EnmOperation.I)
            {
                _objEmp01.P01F05 = DateTime.Now;
            }
            else if (Operation == EnmOperation.U)
            {
                _objEmp01.P01F06 = DateTime.Now;
            }

        }

        /// <summary>
        /// Validation that check duplicate entry and id Exist
        /// </summary>
        /// <returns>return true for duplication</returns>

        public Response validate()
        {
            int count;
            Response response = new Response();
            if (Operation == EnmOperation.I)
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {

                    // Check if the table contains any records with the same values as the provided per01 object
                    count = (int)db.Count((EMP01 p) => p.P01F02 == _objEmp01.P01F02 && p.P01F03 == _objEmp01.P01F03);
                }
                // If no existing records match the provided object, it's considered valid
                if (count <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Duplicate entry found";
                }

            }
            else
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {

                    // Check if the table contains any records with the same values as the provided per01 object
                    count = (int)db.Count((EMP01 p) => p.P01F01 == _objEmp01.P01F01);
                }
                // If no existing records match the provided object, it's considered valid
                if (count <= 0)
                {
                    response.IsSuccess = false;
                    response.Message = $"This Id = {_objEmp01.P01F01} not Exist";
                }
            }
            return response;
        }

        /// <summary>
        /// Validation id Exist
        /// </summary>
        /// <returns>return true for Exist</returns>
        public Response ValidateOnDelete(int id)
        {
            int count;
            Response response = new Response();
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                count = (int)db.Count<EMP01>(p => p.P01F01 == id);
            }
            if (count <= 0)
            {
                response.IsSuccess = false;
                response.Message = $"This Id = {id} not Exist";
            }
            return response;
        }

        #endregion
    }
}