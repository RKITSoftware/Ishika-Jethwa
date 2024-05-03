using System.Data;
using System.Reflection;

namespace Birth_Certificate_Generator.Other
{
    /// <summary>
    /// Convertor for Dto-Poco
    /// </summary>
    public static class Convertor
    {
        #region Public Methods

        /// <summary>
        /// Creates an instance of the target type and maps properties from the source object to the target object.
        /// </summary>
        /// <typeparam name="T">The type of object to create.</typeparam>
        /// <param name="objSource">The source object from which property values will be retrieved.</param>
        /// <returns>An instance of the target type with properties mapped from the source object.</returns>
        public static T CreatePOCO<T>(this object objSource)
        {
            Type sourceType = objSource.GetType();
            Type targetType = typeof(T);

            T objTarget = (T)Activator.CreateInstance(targetType);

            PropertyInfo[] lstSourceProp = sourceType.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (PropertyInfo sourceProp in lstSourceProp)
            {
                string propName = sourceProp.Name;
                PropertyInfo targetProp = targetType.GetProperty(propName);
                if (targetProp != null)
                {
                    object propValue = sourceProp.GetValue(objSource);
                    targetProp.SetValue(objTarget, propValue);
                }
            }
            return objTarget;
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
        /// Convert DataSet To List
        /// </summary>
        /// <param name="dataSet">Dataset that you want to convert</param>
        /// <returns> returns List<T></returns>

        public static List<T> DatasetToList<T>(this DataSet dataSet) where T : new()
        {
            if (dataSet == null || dataSet.Tables.Count == 0)
            {
                return new List<T>();
            }

            DataTable dataTable = dataSet.Tables[0];
            List<T> resultList = new List<T>();

            foreach (DataRow row in dataTable.Rows)
            {
                T instance = new T();
                foreach (var property in typeof(T).GetProperties())
                {
                    if (dataTable.Columns.Contains(property.Name) && property.CanWrite)
                    {
                        object value = row[property.Name];

                        if (value != DBNull.Value)
                        {
                            property.SetValue(instance, Convert.ChangeType(value, property.PropertyType));
                        }
                    }
                }
                resultList.Add(instance);
            }

            return resultList;
        }
        #endregion
    }
}
