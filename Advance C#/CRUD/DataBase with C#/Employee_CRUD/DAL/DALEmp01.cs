using Dapper;
using Employee_CRUD.Connections_Strings;
using Employee_CRUD.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Employee_CRUD.DAL
{
    /// <summary>
    /// Data access layer for handling employee data operations.
    /// </summary>
    public class DALEmp01
    {
        #region Public Methods
        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        public List<Emp01> GetEmployees()
        {
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();
                string query = @"SELECT 
                                        p01f01, 
                                        p01f02, 
                                        p01f03, 
                                        p01f04, 
                                        p01f05 
                                FROM 
                                        emp01";
                return objConnection.Query<Emp01>(query).ToList();
            }
        }

        /// <summary>
        /// Retrieves an employee by ID from the database.
        /// </summary>
        public Emp01 GetByID(int id)
        {
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();
                string query = string.Format(@"SELECT 
                                                    p01f01, 
                                                    p01f02, 
                                                    p01f03, 
                                                    p01f04, 
                                                    p01f05 
                                                FROM 
                                                    emp01 
                                                WHERE 
                                                    p01f01 = {0}",
                                                    id);
                return objConnection.QueryFirstOrDefault<Emp01>(query);
            }
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        public string AddEmployee(Emp01 emp, DateTime created_at, DateTime updated_at)
        {
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();

                string query = string.Format(@"INSERT INTO emp01 
                                                                (p01f01, 
                                                                p01f02, 
                                                                p01f03, 
                                                                p01f04, 
                                                                p01f05,
                                                                p01f06,
                                                                p01f07) 
                                                        VALUES 
                                                                ({0}, '{1}', '{2}', '{3}', {4}, '{5}', '{6}')",
                                                            emp.p01f01, emp.p01f02, emp.p01f03, emp.p01f04, emp.p01f05, created_at, updated_at);

                try
                {
                    int rowsAffected = objConnection.Execute(query);

                    if (rowsAffected > 0)
                        return "Employee has been added successfully";
                    else
                        return "Failed to insert employee";
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                        return "Employee already exists";
                    else
                        return "Internal server error";
                }
            }
        }

        /// <summary>
        /// Updates an existing employee in the database.
        /// </summary>
        public string UpdateEmployee(Emp01 emp, DateTime updatedAt)
        {
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();

                string query = string.Format(@"UPDATE 
                                                        emp01 
                                                    SET 
                                                        p01f02 = '{0}', 
                                                        p01f03 = '{1}', 
                                                        p01f04 = '{2}', 
                                                        p01f05 = {3},
                                                        p01f07 = '{4}'
                                                    WHERE 
                                                        p01f01 = {5}",
                                                        emp.p01f02, emp.p01f03, emp.p01f04, emp.p01f05, updatedAt, emp.p01f01);

                try
                {
                    int rowsAffected = objConnection.Execute(query);

                    if (rowsAffected > 0)
                        return "Employee has been updated successfully";
                    else
                        return $"Employee with ID = {emp.p01f01} not found";
                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                        return "Employee already exists";
                    else
                        return "Internal server error";
                }
            }
        }

        /// <summary>
        /// Removes an employee from the database by ID.
        /// </summary>
        public string RemoveEmployee(int id)
        {
            using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
            {
                objConnection.Open();

                string query = string.Format(@"DELETE FROM 
                                                        emp01 
                                                    WHERE 
                                                        p01f01 = {0}",
                                                        id);

                try
                {
                    int rowsAffected = objConnection.Execute(query);

                    if (rowsAffected > 0)
                        return $"Employee with ID = {id} has been deleted";
                    else
                        return $"Employee with ID = {id} not found";
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }
        }

        #endregion
    }
}
