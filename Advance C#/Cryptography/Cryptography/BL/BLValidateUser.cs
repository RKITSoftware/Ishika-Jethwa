using Cryptography.Models;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.Linq;
using Dapper;

namespace Cryptography.Auth
{
    public class BLValidateUSer
    {
        /// <summary>
        /// Validates user login credentials.
        /// </summary>
        /// <param name="username">The username to be validated.</param>
        /// <param name="password">The password to be validated.</param>
        /// <returns>True if the username and password are valid, otherwise false.</returns>
        public static bool isLogin(string username, string password)
        {
            return GetUser().Any(user => user.e01f02.Equals(username) && BLEncryptDecrypt.Decrypt(user.e01f03) == password);
        }
        /// <summary>
        /// Get Role of th user
        /// </summary>
        /// <param name="encryptData"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static use01 GetUserRoles(string username, string encryptData)
        {
            return GetUser().FirstOrDefault(user => user.e01f02.Equals(username) && user.e01f03 == encryptData);
        }
        /// <summary>
        /// Gets a list of sample users.
        /// </summary>
        /// <returns>A list of user objects.</returns>
        public static List<use01> GetUser() 
        {
            try
            {
                using (MySqlConnection objConnection = new MySqlConnection(Connections.connection))
                {
                    objConnection.Open();
                    string query = "SELECT " +
                                        "e01f01," +
                                        "e01f02," +
                                        "e01f03," +
                                        "e01f04 " +
                                 "FROM " +
                                        "use01";
                    List<use01> lstEmployees = objConnection.Query<use01>(query).ToList();


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