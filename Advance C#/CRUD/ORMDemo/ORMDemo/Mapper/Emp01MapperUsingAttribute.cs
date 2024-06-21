using ORMDemo.Custom_Attributes;
using ORMDemo.Models;
using System;
using System.Reflection;

namespace ORMDemo.Mapper
{
    /// <summary>
    /// Provides methods to map between DTO (Data Transfer Object) and POCO (Plain Old CLR Object) classes using attributes for property mapping.
    /// </summary>
    public class Emp01MapperUsingAttribute
    {
        /// <summary>
        /// Converts a DTO object to a POCO object using attribute-based mapping.
        /// </summary>
        /// <param name="dtoEmp">The DTO object to convert.</param>
        /// <returns>A POCO object converted from the DTO object.</returns>
        public static Emp01 ToEmp01(DtoEmp01UsingAttribute dtoEmp)
        {
            Emp01 emp = new Emp01();
            PropertyInfo[] dtoProps = typeof(DtoEmp01UsingAttribute).GetProperties();
            PropertyInfo[] empProps = typeof(Emp01).GetProperties();

            foreach (PropertyInfo dtoProp in dtoProps)
            {
                MappingAttribute mappingAttr = dtoProp.GetCustomAttribute<MappingAttribute>();
                if (mappingAttr != null)
                {
                    PropertyInfo empProp = Array.Find(empProps, p => p.Name.Equals(mappingAttr.PropertyName, StringComparison.OrdinalIgnoreCase));
                    if (empProp != null && empProp.PropertyType == dtoProp.PropertyType)
                    {
                        empProp.SetValue(emp, dtoProp.GetValue(dtoEmp));
                    }
                }
            }

            return emp;
        }

        /// <summary>
        /// Converts a POCO object to a DTO object using attribute-based mapping.
        /// </summary>
        /// <param name="emp">The POCO object to convert.</param>
        /// <returns>A DTO object converted from the POCO object.</returns>
        public static DtoEmp01UsingAttribute ToDtoEmp01(Emp01 emp)
        {
            DtoEmp01UsingAttribute dtoEmp = new DtoEmp01UsingAttribute();
            PropertyInfo[] dtoProps = typeof(DtoEmp01UsingAttribute).GetProperties();
            PropertyInfo[] empProps = typeof(Emp01).GetProperties();

            foreach (PropertyInfo empProp in empProps)
            {
                MappingAttribute mappingAttr = empProp.GetCustomAttribute<MappingAttribute>();
                if (mappingAttr != null)
                {
                    PropertyInfo dtoProp = Array.Find(dtoProps, p => p.Name.Equals(mappingAttr.PropertyName, StringComparison.OrdinalIgnoreCase));
                    if (dtoProp != null && dtoProp.PropertyType == empProp.PropertyType)
                    {
                        dtoProp.SetValue(dtoEmp, empProp.GetValue(emp));
                    }
                }
            }

            return dtoEmp;
        }
    }
}
