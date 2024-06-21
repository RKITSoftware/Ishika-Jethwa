using Dapper;
using Employee_CRUD.Connections_Strings;
using Employee_CRUD.DAL;
using Employee_CRUD.Mapper;
using Employee_CRUD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Employee_CRUD.BL
{
    /// <summary>
    /// Business logic layer for managing employees.
    /// </summary>
    public class BLEmp01
    {
        #region variables

        private readonly DALEmp01 _dalEmp01;
        private DateTime _createdAt;
        private DateTime _updatedAt;

        #endregion

        #region Constructors
        /// <summary>
        /// Constructor initializing DALEmp01 instance.
        /// </summary>
        public BLEmp01()
        {
            _dalEmp01 = new DALEmp01();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Retrieves all employees from the data source.
        /// </summary>
        public List<DtoEmp01> GetAllEmployees()
        {
            List<Emp01> lstEmp01 = _dalEmp01.GetEmployees();
            List<DtoEmp01> lstDtoEmp01 = new List<DtoEmp01>();

            foreach (Emp01 emp in lstEmp01)
            {
                lstDtoEmp01.Add(Emp01Mapper.ToDtoEmp01(emp));
            }

            return lstDtoEmp01;
        }

        /// <summary>
        /// Retrieves an employee by ID from the data source.
        /// </summary>
        public DtoEmp01 GetEmployeeById(int id)
        {
            Emp01 emp = _dalEmp01.GetByID(id);
            if (emp != null)
            {
                return Emp01Mapper.ToDtoEmp01(emp);
            }
            return null;
        }

        /// <summary>
        /// Adds a new employee to the data source.
        /// </summary>
        public DtoEmp01 AddEmployee(DtoEmp01 objDtoEmp)
        {
            Emp01 objEmp = PreSaveOnInsert(objDtoEmp);

            // Validate before saving
            string validationMessage = Validate(objEmp);
            if (validationMessage == "Validation passed.")
            {
                SaveInsert(objEmp, _createdAt, _updatedAt);
                return objDtoEmp;
            }
            return null;
        }

        /// <summary>
        /// Updates an existing employee in the data source.
        /// </summary>
        public DtoEmp01 UpdateEmployee(DtoEmp01 objDtoEmp)
        {
            Emp01 objEmp = PreSaveOnUpdate(objDtoEmp);

            // Validate before saving
            string validationMessage = Validate(objEmp);
            if (validationMessage == "Validation passed.")
            {
                SaveUpdate(objEmp, _updatedAt);
                return objDtoEmp;
            }
            return null;

        }

        /// <summary>
        /// Removes an employee from the data source by ID.
        /// </summary>
        public string RemoveEmployee(int id)
        {
            return _dalEmp01.RemoveEmployee(id);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Preprocessing tasks before saving new employee record.
        /// </summary>
        private Emp01 PreSaveOnInsert(DtoEmp01 objDtoEmp)
        {
            _createdAt = DateTime.Now;
            _updatedAt = DateTime.Now;
            // Convert DTO to POCO
            return Emp01Mapper.ToEmp01(objDtoEmp);
        }

        /// <summary>
        /// Preprocessing tasks before updating employee record.
        /// </summary>
        private Emp01 PreSaveOnUpdate(DtoEmp01 objDtoEmp)
        {
            _updatedAt = DateTime.Now;
            // Convert DTO to POCO
            return Emp01Mapper.ToEmp01(objDtoEmp);
        }

        /// <summary>
        /// Validates the employee data before saving.
        /// </summary>
        private string Validate(Emp01 objEmp)
        {
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                try
                {
                    objConnection.Open();
                    // Check if a duplicate record exists
                    string duplicateCheckQuery = string.Format(@"SELECT COUNT(*) FROM emp01 WHERE p01f02 = '{0}' AND p01f03 = '{1}' AND p01f04 = '{2}'", objEmp.p01f02, objEmp.p01f03, objEmp.p01f04);
                    int duplicateCount = objConnection.ExecuteScalar<int>(duplicateCheckQuery);

                    if (duplicateCount > 0)
                    {
                        // Duplicate record found
                        return "Duplicate record found.";
                    }

                    // Validation passed
                    return "Validation passed.";
                }
                catch (MySqlException)
                {
                    // Connection to the database failed
                    return "Connection to the database failed.";
                }

            }
        }

        /// <summary>
        /// Saves a new employee record to the data source.
        /// </summary>
        private void SaveInsert(Emp01 objEmp, DateTime created_at, DateTime updated_at)
        {
            _dalEmp01.AddEmployee(objEmp, created_at, updated_at);
        }

        /// <summary>
        /// Updates an existing employee record in the data source.
        /// </summary>
        private void SaveUpdate(Emp01 objEmp, DateTime updatedAt)
        {
            _dalEmp01.UpdateEmployee(objEmp, updatedAt);
        }
        #endregion
    }
}
