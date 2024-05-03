using HRMSyatem.MAL.POCO;
using HRMSystem.Connection;
using MySql.Data.MySqlClient;
using ServiceStack.OrmLite.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HRMSyatem.Auth
{
    /// <summary>
    /// Validate User
    /// </summary>
    public class ValidateUser
    {

        /// <summary>
        /// Validates user login credentials.
        /// </summary>
        /// <param name="username">The username to be validated.</param>
        /// <param name="password">The password to be validated.</param>
        /// <returns>True if the username and password are valid, otherwise false.</returns>
        public static bool isLogin(string username, string password)
        {
            return GetUser().Any(user => user.R01F03.Equals(username) && BLEncryptDecrypt.Decrypt(user.R01F04) == password);
        }

        /// <summary>
        /// Get User Role.
        /// </summary>
        /// <param name="username">The username to be validated.</param>
        /// <param name="password">The password to be validated.</param>
        /// <returns>True if the username and password are valid, otherwise false.</returns>
        public static USR01 GetUserRoles(string username, string encryptData)
        {
            return GetUser().FirstOrDefault(user => user.R01F03.Equals(username) && user.R01F04 == encryptData);
        }

        /// <summary>
        /// Gets a list of sample users.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        public static List<USR01> GetUser()
        {
            try
            {
                using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
                {
                    objConnection.Open();
                    string query = string.Format(@"SELECT 
                                                        r01f01,
                                                        r01f02,
                                                        r01f03,
                                                        r01f04,
                                                        r01f05
                                                FROM 
                                                        usr01");
                    List<USR01> lstEmployees = objConnection.Query<USR01>(query).ToList();
                    return lstEmployees;
                }
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}