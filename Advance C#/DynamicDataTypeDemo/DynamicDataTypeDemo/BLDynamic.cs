using DynamicDataTypeDemo.Models;
using Newtonsoft.Json.Linq;
using System;

namespace DynamicDataTypeDemo
{
    public class BLDynamic
    {
        /// <summary>
        /// Retrieves information about properties and values from a dynamic data model.
        /// </summary>
        /// <param name="model">The DynamicDataModel containing dynamic data.</param>
        /// <returns>A string containing property names, values, and types.</returns>
        public string Get(DynamicDataModel model)
        {
            try
            {
                // Access dynamic data properties as JObject
                JObject data = (JObject)model.Data;

                // Check if there are any properties
                if (data.Count == 0)
                {
                    return "No properties found in dynamic data.";
                }

                // Build a string with the properties and their values
                string result = "Properties: ";
                foreach (dynamic property in data)
                {
                    string propertyName = property.Key;
                    JToken propertyValue = property.Value;

                    // Convert the value to string
                    string propertyValueString = propertyValue.ToString();

                    // Get the type of the value
                    string propertyType = propertyValue.Type.ToString();

                    result += $"{propertyName}: {propertyValueString} (Type: {propertyType})\n";
                }

                // Remove the trailing comma and space
                result = result.TrimEnd(',', ' ');

                return result;
            }
            catch (Exception ex)
            {
                return $"Error processing dynamic data: {ex.Message}";
            }
        }
    }
}