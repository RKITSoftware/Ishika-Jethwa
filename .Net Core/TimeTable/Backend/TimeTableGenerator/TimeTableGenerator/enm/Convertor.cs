using System.Data;
using System.Reflection;

namespace TimeTableGenerator.enm
{
    public static class Convertor
    {
        public static DataSet ConvertToDataSet<T>(this List<T> list)
        {
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable(typeof(T).Name);

            // Get all the properties of the class T
            PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Create columns for each property
            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
            }

            // Populate the datatable with data from the list
            foreach (T item in list)
            {
                DataRow row = dataTable.NewRow();
                foreach (PropertyInfo property in properties)
                {
                    row[property.Name] = property.GetValue(item) ?? DBNull.Value;
                }
                dataTable.Rows.Add(row);
            }

            // Add the datatable to the dataset
            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        /// <summary>
        /// Gets the corresponding message for the enum value.
        /// </summary>
        /// <param name="enumValue">The enum value.</param>
        /// <returns>The message corresponding to the enum value.</returns>
        public static string GetMessage(this enmOperation enumValue)
        {
            switch (enumValue)
            {
                case enmOperation.I:
                    return "Record inserted successfully.";
                case enmOperation.D:
                    return "Record deleted successfully.";
                case enmOperation.U:
                    return "Record updated successfully.";
                default:
                    return "Unknown operation.";
            }
        }
    }
}
