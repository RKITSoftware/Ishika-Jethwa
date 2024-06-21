using Employee_CRUD.Models;

namespace Employee_CRUD.Mapper
{
    /// <summary>
    /// Mapper class for converting between DTOs and entity objects related to employees.
    /// </summary>
    public class Emp01Mapper
    {
        #region Public Methods
     
        /// <summary>
        /// Converts a DTO object to an entity object.
        /// </summary>
        public static Emp01 ToEmp01(DtoEmp01 dtoEmp)
        {
            return new Emp01
            {
                p01f01 = dtoEmp.p01101,
                p01f02 = dtoEmp.p01102,
                p01f03 = dtoEmp.p01103,
                p01f04 = dtoEmp.p01104,
                p01f05 = dtoEmp.p01105
            };
        }

        /// <summary>
        /// Converts an entity object to a DTO object.
        /// </summary>
        public static DtoEmp01 ToDtoEmp01(Emp01 emp)
        {
            return new DtoEmp01
            {
                p01101 = emp.p01f01,
                p01102 = emp.p01f02,
                p01103 = emp.p01f03,
                p01104 = emp.p01f04,
                p01105 = emp.p01f05
            };
        }

        #endregion
    }
}
