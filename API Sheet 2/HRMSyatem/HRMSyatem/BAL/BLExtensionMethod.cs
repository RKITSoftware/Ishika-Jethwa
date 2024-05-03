using HRMSystem.Helper;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System;
using System.Web;

namespace HRMSystem.BL
{
    /// <summary>
    /// Extension method for converting context to integer
    /// </summary>
    public static class BLExtensionMethod
    {
        /// <summary>
        /// Get an integer value from the form data in the HttpContext.
        /// </summary>
        /// <param name="context">The HttpContext containing the form data.</param>
        /// <param name="key">The key of the form field.</param>
        /// <returns>Returns the parsed integer value from the form data or 0 if parsing fails.</returns>
        public static int GetFormInt(this HttpContext context, string key)
        {
            string value = context.Request.Form[key];
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return 0; 
        }
   
        /// <summary>
        /// Gets the corresponding message for the enum value.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The message corresponding to the enum value.</returns>
        public static string GetMessage(this EnmOperation enumValue)
        {
            switch (enumValue)
            {
                case EnmOperation.I:
                    return "Record inserted successfully.";
                case EnmOperation.D:
                    return "Record deleted successfully.";
                case EnmOperation.U:
                    return "Record updated successfully.";
                default:
                    return "Unknown operation.";
            }
        }

        /// <summary>
        /// Converting List To Datatable
        /// </summary>
        /// <returns>Datatble</returns>
        public static DataTable ListToDataTable<T>(this List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties of the type T
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns in the DataTable based on the properties
            foreach (var prop in props)
            {
                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, propType);
            }

            // Add rows to the DataTable for each item in the list
            foreach (T item in items)
            {
                var row = dataTable.NewRow();

                foreach (var prop in props)
                {
                    object value = prop.GetValue(item, null);
                    row[prop.Name] = value ?? DBNull.Value;
                }

                dataTable.Rows.Add(row);
            }

            return dataTable;
        }

        /// <summary>
        /// Convert Object to Datatable
        /// </summary>
        /// <returns>Datatable</returns>
        public static DataTable ToDataTable<T>(this T item)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get properties from the object
            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns based on the properties
            foreach (var prop in props)
            {
                Type propType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, propType);
            }

            // Create a new row and populate with property values
            var row = dataTable.NewRow();
            foreach (var prop in props)
            {
                object value = prop.GetValue(item, null);
                row[prop.Name] = value ?? DBNull.Value;
            }

            dataTable.Rows.Add(row);

            return dataTable;
        }
    }
}