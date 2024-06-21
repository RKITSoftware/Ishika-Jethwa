using ORMDemo.Models;
using System;
using System.Linq;
using System.Reflection;

namespace ORMDemo.Mapper
{
    /// <summary>
    /// Provides methods to map objects between a DTO (Data Transfer Object) and a POCO (Plain Old CLR Object) using reflection.
    /// </summary>
    public class Emp01Mapper
    {
        /// <summary>
        /// Converts a DTO object of type <see cref="DtoEmp01"/> to a POCO object of type <see cref="Emp01"/>.
        /// </summary>
        /// <param name="dtoEmp">The DTO object to be converted.</param>
        /// <returns>A POCO object converted from the provided DTO object.</returns>
        public static Emp01 ToEmp01(DtoEmp01 dtoEmp)
        {
            Emp01 emp = new Emp01();
            PropertyInfo[] dtoProps = typeof(DtoEmp01).GetProperties();
            PropertyInfo[] empProps = typeof(Emp01).GetProperties();

            foreach (PropertyInfo dtoProp in dtoProps)
            {
                // Generate the corresponding property name in the POCO model
                string empPropName = "p01f" + dtoProp.Name.Substring(4);

                // Find the corresponding property in the POCO model based on the generated name
                PropertyInfo empProp = empProps.FirstOrDefault(p => string.Equals(p.Name, empPropName, StringComparison.OrdinalIgnoreCase));

                if (empProp != null && empProp.PropertyType == dtoProp.PropertyType)
                {
                    empProp.SetValue(emp, dtoProp.GetValue(dtoEmp));
                }
            }

            return emp;
        }

        /// <summary>
        /// Converts a POCO object of type <see cref="Emp01"/> to a DTO object of type <see cref="DtoEmp01"/>.
        /// </summary>
        /// <param name="emp">The POCO object to be converted.</param>
        /// <returns>A DTO object converted from the provided POCO object.</returns>
        public static DtoEmp01 ToDtoEmp01(Emp01 emp)
        {
            DtoEmp01 dtoEmp = new DtoEmp01();
            PropertyInfo[] empProps = typeof(Emp01).GetProperties();
            PropertyInfo[] dtoProps = typeof(DtoEmp01).GetProperties();

            foreach (PropertyInfo empProp in empProps)
            {
                // Generate the corresponding property name in the DTO model
                string dtoPropName = "p011" + empProp.Name.Substring(4);

                // Find the corresponding property in the DTO model based on the generated name
                PropertyInfo dtoProp = dtoProps.FirstOrDefault(p => string.Equals(p.Name, dtoPropName, StringComparison.OrdinalIgnoreCase));

                if (dtoProp != null && dtoProp.PropertyType == empProp.PropertyType)
                {
                    dtoProp.SetValue(dtoEmp, empProp.GetValue(emp));
                }
            }
            return dtoEmp;
        }
    }
}
