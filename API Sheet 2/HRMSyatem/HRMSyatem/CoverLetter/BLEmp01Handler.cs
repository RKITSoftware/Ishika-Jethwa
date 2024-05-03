using DBCrudFrmaework.BAL.Interface;
using DBCrudFrmaework.DAL;
using DBCrudFrmaework.Dto;
using DBCrudFrmaework.Helper;
using DBCrudFrmaework.Models;

using System;

namespace DBCrudFrmaework.BAL.Services
{
    /// <summary>
    /// BLEmployeeService Class
    /// </summary>
    public class BLEmp01Handler : IEmp01
    {
        #region Private members
        private readonly DBEmp01Context objDbEmp01;
        private Emp01 objEmp01;
        #endregion

        #region Public Menebers
        public EnumMessage Operation;
        public Response response = new Response();

        #endregion

        #region Constructor
        public BLEmp01Handler()
        {
            objDbEmp01 = new DBEmp01Context();
        }

        #endregion

        #region Public Method

        /// <summary>
        /// Retrieves a list of all employees from the database.
        /// </summary>
        /// <returns>An IEnumerable of Emp01 representing the list of employees.</returns>
        public Response GetEmployees()
        {
            return objDbEmp01.GetAllEmployee();
        }

        /// <summary>
        /// Retrieves a specific employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>An Emp01 object representing the employee details.</returns>
        public Response GetByID(int id)
        {
            return objDbEmp01.GetEmployeeByID(id);
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="objEmployee">An Emp01 object representing the employee to be added.</param>
        /// <returns>A string indicating the result of the operation.</returns>
        public Response Save()
        {
            if (Operation == EnumMessage.I)
            {
                return objDbEmp01.AddEmployee(objEmp01);
            }
            else
            {
                return objDbEmp01.UpdateEmployee(objEmp01);
            }
        }


        /// <summary>
        /// Removes an employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to be removed.</param>
        /// <returns>A string indicating the result of the operation.</returns>
        public Response RemoveEmployee(int id)
        {
            return objDbEmp01.RemoveEmployee(id);
        }

        /// <summary>
        /// Presave on insert
        /// </summary>
        /// <param name="objdtoEmp"> Dto object</param>
        public void PreSave(DtoEmp01 objdtoEmp)
        {
            objEmp01 = new Emp01
            {
                p01f01 = objdtoEmp.p01f01,
                p01f02 = objdtoEmp.p01f02,
                p01f03 = objdtoEmp.p01f03,
                p01f04 = objdtoEmp.p01f04
            };
            if (Operation == EnumMessage.I)
            {
                objEmp01.p01f05 = DateTime.Now;
            }
            else if (Operation == EnumMessage.U)
            {
                objEmp01.p01f06 = DateTime.Now;
            }

        }

        /// <summary>
        /// Validation that check duplicate entry and id Exist
        /// </summary>
        /// <returns>return true for duplication</returns>
        
        public bool validate()
        {
            if (Operation == EnumMessage.I)
            {
                try
                {
                    response.IsSuccess = objDbEmp01.isExistRecord(objEmp01.p01f02, objEmp01.p01f03);
                    response.Message = response.IsSuccess ? "Duplicate entry found." : "No duplicate entry found.";

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error during validation: " + ex.Message;
                }

                return response.IsSuccess;
            }
            else
            {
                try
                {
                    response.IsSuccess = objDbEmp01.isExistId(objEmp01.p01f01);
                    response.Message = response.IsSuccess ? "Already Exist." : $"This Id = {objEmp01.p01f01} not Exist";
                    //if (response.IsSuccess) { 
                    //response.IsSuccess = objDbEmp01.isExistRecord(objEmp01.p01f02, objEmp01.p01f03);
                    //}

                }
                catch (Exception ex)
                {
                    response.IsSuccess = false;
                    response.Message = "Error during validation: " + ex.Message;
                }

                return response.IsSuccess;
            }

        }

        /// <summary>
        /// Validation id Exist
        /// </summary>
        /// <returns>return true for Exist</returns>
        public bool isExist(int id)
        {
            try
            {
                response.IsSuccess = objDbEmp01.isExistId(id);
                response.Message = response.IsSuccess ? "Already Exist." : $"This Id = {id} not Exist";

            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Error during validation: " + ex.Message;
            }

            return response.IsSuccess;
        }

        #endregion
    }
}