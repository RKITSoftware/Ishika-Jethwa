using DBCrudFrmaework.BAL.Interface;
using DBCrudFrmaework.Connection;
using DBCrudFrmaework.DAL;
using DBCrudFrmaework.Dto;
using DBCrudFrmaework.Helper;
using DBCrudFrmaework.Models;
using ServiceStack.OrmLite;
using System;
using System.Data;

namespace DBCrudFrmaework.BAL.Services
{
    /// <summary>
    /// BLEmployeeService Class
    /// </summary>
    public class BLEmp01Handler : IEmp01
    {
        #region Private members
        //intance of DBEmp01Context
        private readonly DBEmp01Context objDbEmp01;

        //instance of Emp01
        private Emp01 objEmp01;

        #endregion

        #region Public Menebers
        //instance for handling insertion-updatation
        public EnumMessage Operation;
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
            DataTable dtemp01 = objDbEmp01.GetAllEmployee();
            if (dtemp01.Rows.Count == 0)
            {
                return new Response()
                {
                    IsSuccess = false,
                    Message = "Not Found"
                };
            }

            return new Response()
            {
                IsSuccess = true,
                Data = dtemp01,
            };
        }

        /// <summary>
        /// Retrieves a specific employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to retrieve.</param>
        /// <returns>An Emp01 object representing the employee details.</returns>
        public Response GetByID(int id)
        {
            DataTable dtemp01 = objDbEmp01.GetEmployeeByID(id);
            if (dtemp01.Rows.Count == 0)
            {
                return new Response()
                {
                    IsSuccess = false,
                    Message = "Not Found"
                };
            }

            return new Response()
            {
                IsSuccess = true,
                Data = dtemp01,
            };
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
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    db.Insert(objEmp01);
                    return new Response()
                    {
                        IsSuccess = true,
                        Message = EnumMessage.I.GetMessage()

                    };

                }
            }
            else
            {
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    db.Update(objEmp01);
                    return new Response()
                    {
                        IsSuccess = true,
                        Message = EnumMessage.U.GetMessage()

                    };
                }
            }
        }

        /// <summary>
        /// Removes an employee from the database based on the employee ID.
        /// </summary>
        /// <param name="id">The ID of the employee to be removed.</param>
        /// <returns>A string indicating the result of the operation.</returns>
        public Response Delete(int id)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                int rowsAffected = db.DeleteById<Emp01>(id);
                if (rowsAffected == 0)
                {
                    return new Response()
                    {
                        IsSuccess = false,
                        Message = $"Employe {id} not exist"
                    };
                }
                else
                {
                    return new Response()
                    {
                        Message = EnumMessage.D.GetMessage()

                    };

                }
            }
        }

        /// <summary>
        /// Presave on insert and update
        /// </summary>
        /// <param name="objdtoEmp"> Dto object</param>
        public void PreSave(DtoEmp01 objdtoEmp)
        {
            objEmp01 = objdtoEmp.CreatePOCO<Emp01>();

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

        public Response validate()
        {
            Response response = new Response();
            if (Operation == EnumMessage.I)
            {
                int count;
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {
                    // Check if the table contains any records with the same values as the provided per01 object
                    count = (int)db.Count<Emp01>(p => p.p01f02 == objEmp01.p01f02 && p.p01f03 == objEmp01.p01f03);
                }
                // If no existing records match the provided object, it's considered valid

                if (count > 0)
                {
                    response.IsSuccess = false;
                    response.Message = "Duplicate entry found";
                }

            }
            else
            {
                int count;
                using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
                {

                    // Check if the table contains any records with the same values as the provided per01 object
                    count = (int)db.Count<Emp01>(p => p.p01f01 == objEmp01.p01f01);
                }

                if (count <= 0)
                { 
                    response.IsSuccess = false;
                    response.Message = $"This Id = {objEmp01.p01f01} not Exist";
                }
            }

            return response;
    }

    /// <summary>
    /// Validation id Exist
    /// </summary>
    /// <returns>return true for Exist</returns>
    public Response ValidationOnDelete(int id)
    {
        using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
        {

            int objEmp01Exist = (int)db.Count<Emp01>(p => p.p01f01 == id);

            // If no existing records match the provided object, it's considered valid
            if (objEmp01Exist > 0)
            {
                return new Response()
                {
                    IsSuccess = true
                };
            }
            else
            {
                return new Response()
                {
                    IsSuccess = false,
                    Message = $"This Id = {id} not Exist"
                };
            }

        }
    }

    #endregion
}
}