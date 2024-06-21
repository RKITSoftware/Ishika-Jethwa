using ORMDemo.Models;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ORMDemo.BL
{
    /// <summary>
    /// BL Class for representing demo of ormservice
    /// </summary>
    public class BLPeople
    {
        /// <summary>
        /// Retrieves all 'per01' records from the database.
        /// </summary>
        /// <returns>A list of 'per01' records.</returns>
        public List<per01> GetAll()
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    List<per01> lstPeople = db.Select<per01>();
                    return lstPeople;
                }
                else
                {
                    throw new InvalidOperationException("'per01' table does not exist.");
                }
            }
        }

        /// <summary>
        /// Adds a new 'per01' record to the database.
        /// </summary>
        /// <param name="person">The 'per01' record to be added.</param>
        /// <returns>The added 'per01' record.</returns>
        public per01 AddPeople(per01 objPerson)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    db.Insert(objPerson);
                    return objPerson;
                }
                else
                {
                    throw new InvalidOperationException("'per01' table does not exist.");
                }

            }
        }

        /// <summary>
        /// Retrieves a 'per01' record by its ID.
        /// </summary>
        /// <param name="id">The ID of the 'per01' record to retrieve.</param>
        /// <returns>The 'per01' record with the specified ID, or a NotFound response if not found.</returns>
        public per01 GetID(int id)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    per01 objPerson = db.SingleById<per01>(id);
                    if (objPerson != null)
                    {
                        return objPerson;
                    }
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.NotFound); ;
                    }
                }
                throw new InvalidOperationException("'per01' table does not exist.");
            }
        }

        /// <summary>
        /// Updates the information of a 'per01' record with the specified ID.
        /// </summary>  
        /// <param name="objPerson">The updated person information.</param>
        /// <returns>The updated 'per01' record, or a NotFound response if the record with the specified ID is not found.</returns>
        public string UpdatePerson(per01 updatedPerson)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {

                    db.Update(updatedPerson);
                    return $"Person with ID {updatedPerson.r01f01} has been updated.";

                }
                return "per01 table does not exist.";
            }
        }

        /// <summary>
        /// Removes a 'per01' record from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the 'per01' record to remove.</param>
        /// <returns>A message indicating the result of the removal operation.</returns>
        public string RemovePerson(int id)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    //int rowsAffected = db.DeleteById<per01>(id);
                    int rowsAffected = db.Delete<per01>(p => p.r01f01 == id);
                    if (rowsAffected > 0)
                    {
                        return $"Person with ID {id} has been deleted.";
                    }
                    else
                    {
                        return "Not Found";
                    }
                }
                return "per01 not exist...";
            }
        }
        /// <summary>
        /// Insert mane person 
        /// </summary>
        /// <param name="persons">List of persons</param>
        public void InsertPersons(List<per01> persons)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    db.InsertAll(persons);
                }
            }
        }
        /// <summary>
        /// update many person 
        /// </summary>
        /// <param name="persons">list of updated person</param>
        public void UpdatePersons(List<per01> persons)
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    db.UpdateAll(persons);
                }
            }
        }

        /// <summary>
        /// Orders 'per01' records by a specified column.
        /// </summary>
        /// <returns>The ordered result.</returns>
        public List<per01> OrderByColumn()
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    // Order by a specified column using LINQ
                    List<per01> result = db.Select<per01>().OrderByDescending(p => p.r01f01).ToList();
                    return result;
                }
                throw new InvalidOperationException("'per01' table does not exist.");
            }
        }

        /// <summary>
        /// Selects distinct 'per01' records from the database.
        /// </summary>
        /// <returns>The distinct 'per01' records.</returns>
        public List<per01> SelectDistinct()
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>())
                {
                    // Select distinct records using LINQ
                    List<per01> allRecords = db.Select<per01>(); // Retrieve all records from the per01 table
                    List<per01> distinctRecords = allRecords.GroupBy(r => new { r.r01f02 }).Select(g => g.First()).ToList(); // Extract distinct records
                    return distinctRecords;
                }
                throw new InvalidOperationException("'per01' table does not exist.");
            }
        }
        /// <summary>
        /// Performs a join operation between 'per01' and 'Emp01'.
        /// </summary>
        /// <returns>The result of the join operation.</returns>
        public List<Tuple<per01, Emp01>> JoinWithOtherTable()
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>() && db.TableExists<Emp01>())
                {
                    // Retrieve all records from per01 and Emp01 tables
                    List<per01> lstper01 = db.Select<per01>();
                    List<Emp01> lstemp01 = db.Select<Emp01>();

                    var result = lstper01.Join(
                                                lstemp01,
                                                per => per.r01f01,
                                                emp => emp.p01f01,
                                                (per, emp) => new Tuple<per01, Emp01>(per, emp)
                                               ).ToList();

                    return result.ToList();
                }
                throw new InvalidOperationException("Tables do not exist.");
            }
        }

        /// <summary>
        /// Retrieves records from 'per01' that do not exist in 'Emp01'.
        /// </summary>
        /// <returns>The result of the except operation.</returns>
        public List<per01> ExceptWithEmp01()
        {
            using (IDbConnection db = Connections.dbFactory.OpenDbConnection())
            {
                if (db.TableExists<per01>() && db.TableExists<Emp01>())
                {
                    // Retrieve all records from per01 and Emp01 tables
                    var lstper01 = db.Select<per01>();
                    var lstemp01 = db.Select<Emp01>();

                    // Perform the except operation to get records in lstper01 that do not exist in lstemp01
                    //var result = lstper01.Where(per => !lstemp01.Any(emp => emp.p01f01 == per.r01f01)).ToList();

                    var per01Ids = lstper01.Select(per => per.r01f01);
                    var emp01Ids = lstemp01.Select(emp => emp.p01f01);

                  
                    var resultIds = per01Ids.Except(emp01Ids);

                    // Filter lstper01 to contain only records with IDs present in resultIds
                    var result = lstper01.Where(per => resultIds.Contains(per.r01f01)).ToList();

                    return result;
                }
                throw new InvalidOperationException("Tables do not exist.");
            }
        }
    }
}