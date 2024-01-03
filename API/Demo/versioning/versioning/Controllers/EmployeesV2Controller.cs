using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using versioning.Models;

namespace versioning.Controllers
{
    public class EmployeesV2Controller : ApiController
    {
        // GET: api/EmployeesV2
        public List<EmployeeV2> EmployeeList = new List<EmployeeV2>
        {
            new EmployeeV2 {ID = 1 , Name ="Ishika" ,Gender="Female", City= "Dwarka", IsActive = true},
            new EmployeeV2 {ID = 2 , Name ="Deven" ,Gender="Male", City= "Mumbai", IsActive = false},
            new EmployeeV2 {ID = 3 , Name ="Gopal" ,Gender="Male", City= "Rajkot", IsActive = false},
            new EmployeeV2 {ID = 4 , Name ="Ganesh" ,Gender="Male", City= "Surat", IsActive = true},
            new EmployeeV2 {ID = 5 , Name ="Madhav" ,Gender="Male", City= "Ahmedabad", IsActive = true}

        };
        // GET: api/Employees
        public List<EmployeeV2> Get()
        {
            return EmployeeList;
        }

     
    }
}
