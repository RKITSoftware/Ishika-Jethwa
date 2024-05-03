using HRMSyatem.Auth;
using HRMSyatem.BAL.Service;
using HRMSyatem.MAL.Dto;
using HRMSystem.Helper;
using HRMSystem.MAL;
using System.Web.Http;

namespace HRMSyatem.Controllers
{
    /// <summary>
    /// USer Controller
    /// </summary>
    [RoutePrefix("api/User")]
   // [BLBasicAuthentication]
    //[BLBasicAuthorization(Roles = "HR")]
    public class CLUSR01Controller : ApiController
    {
        #region public members
        //Instance of BLEmp01Handler 
        BLUSR01Handler objUser = new BLUSR01Handler();
        //Instance of Response
        public Response response;

        #endregion

        /// <summary>
        /// Gets the list of all Users.
        /// </summary>
        /// <returns>The list of Users or an error response if the operation fails.</returns>

        [HttpGet]
        [Route("GetUsers")]
        public IHttpActionResult GetUser()
        {
            return Ok(objUser.GetUsers());
        }
        /// <summary>
        /// Gets a specific User by ID.
        /// </summary>
        /// <param name="id">The ID of the User to retrieve.</param>
        /// <returns>The User with the specified ID or an error response if the User is not found.</returns>
        
        [HttpGet]
        [Route("GetUser-by-id/{id}")]
        public IHttpActionResult GetUserByID(int id)
        {
            return Ok(objUser.GetById(id));
        }
        /// <summary>
        /// Adds a new User.
        /// </summary>
        /// <param name="User">The User to add.</param>
        /// <returns>The added User or an error response if the operation fails.</returns>

        [HttpPost]
        [Route("AddUser")]
        public IHttpActionResult AddUser(DTOUSR01 objUsr)
        {
            objUser.Operation = EnmOperation.I;
            objUser.PreSave(objUsr);
            response = objUser.Validate();
            if (response.IsSuccess)
            {
                return Ok(objUser.Save());
            }
            return Ok(response);
        }

        /// <summary>
        /// Updates an existing User.
        /// </summary>
        /// <param name="id">The ID of the User to update.</param>
        /// <param name="User">The updated User data.</param>
        /// <returns>The updated User or an error response if the operation fails.</returns>

        [HttpPut]
        [Route("updateUser")]
        public IHttpActionResult UpdateUser(DTOUSR01 objUsr)
        {
            objUser.Operation = EnmOperation.U;
            objUser.PreSave(objUsr);
            response = objUser.Validate();
            if (response.IsSuccess)
            {
                return Ok(objUser.Save());
            }
            return Ok(response);
        }
    }
}
