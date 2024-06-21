using DataSerialization.Models;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Xml.Linq;

namespace DataSerialization.BL
{
    public static  class BLSerialization
    {
        #region Private Method
        /// <summary>
        /// Converts a byte array to a binary string representation.
        /// </summary>
        /// <param name="data">The byte array to be converted.</param>
        /// <returns>Binary string representation of the byte array.</returns>
        private static string ConvertByteToBinary(byte[] data)
        {
            // Create a StringBuilder to efficiently build the binary string
            StringBuilder binaryStringBuilder = new StringBuilder();

            // Iterate through each byte in the data array
            foreach (byte b in data)
            {
                // Convert the byte to its binary representation, pad left with zeros to ensure 8 bits
                // and append a space after each binary representation
                binaryStringBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0') + " ");
            }

            // Convert the StringBuilder to a string and trim any leading or trailing whitespace
            return binaryStringBuilder.ToString().Trim();
        }

        /// <summary>
        /// Converts a binary string representation to a byte array.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>Byte array representation of the binary string.</returns>
        private static byte[] ConvertBinaryToBytes(string binaryString)
        {
            // Split the binary string into an array of binary values using space as the delimiter
            string[] binaryValues = binaryString.Split(' ');

            // Create a byte array with the same length as the binaryValues array
            byte[] binaryData = new byte[binaryValues.Length];

            // Iterate through each binary value in the array
            for (int i = 0; i < binaryValues.Length; i++)
            {
                // Convert each binary value back to a byte using base 2
                binaryData[i] = Convert.ToByte(binaryValues[i], 2);
            }

            // Return the resulting byte array
            return binaryData;
        }
        #endregion

        #region Public Method
        /// <summary>
        /// Converts a Person object to a JSON string.
        /// </summary>
        public static string JsonToString(per01 objPerson)
        {
            return JsonConvert.SerializeObject(objPerson);
        }

        /// <summary>
        /// Converts a JSON string to a Person object.
        /// </summary>
        public static per01 StringToJson(string strjson)
        {
            return JsonConvert.DeserializeObject<per01>(strjson);
        }

        /// <summary>
        /// Converts an XML element to a JSON string.
        /// </summary>       
        public static string XMLToString(XElement root)
        {
            return JsonConvert.SerializeXNode(root);
        }

        /// <summary>
        /// Converts a string to an XML element.
        /// </summary>
        public static XElement StringToXML(string strjson)
        {
            return JsonConvert.DeserializeXNode($"{{\"Root\":{strjson}}}").Root;
        }

        /// <summary>
        /// Converts a Person object to an XML element.
        /// </summary>    
        public static XElement JsonToXML(per01 objPerson)
        {
            return new XElement("root",
                   new XElement("Name", objPerson.r01f01),
                   new XElement("Age", objPerson.r01f02)
               );
        }

        /// <summary>
        /// Converts an XML element to a Person object.
        /// </summary>
        public static per01 XMLToJson(XElement root)
        {
            // Extract values from XML elements
            string r01f01Value = root.Element("r01f01")?.Value;
            int r01f02Value = int.Parse(root.Element("r01f02")?.Value);

            // Create per01 object
            per01 objPerson = new per01
            {
                r01f01 = r01f01Value,
                r01f02 = r01f02Value
            };
            return objPerson;
        }

        /// <summary>
        /// Converts a regular string to a binary string representation.
        /// </summary>
        /// <param name="input">The regular string to be converted.</param>
        /// <returns>Binary string representation of the input string.</returns>  
        public static string StringToBinary(string input)
        {
            byte[] binaryData = Encoding.UTF8.GetBytes(input);
            string binaryRepresentation = ConvertByteToBinary(binaryData);

            return binaryRepresentation;
        }

        /// <summary>
        /// Converts a binary string representation to a regular string.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>String representation of the binary data.</returns> 
        public static string BinaryToString(string binaryString)
        {
            byte[] binaryData = ConvertBinaryToBytes(binaryString);
            string strOutput = Encoding.UTF8.GetString(binaryData);
            return strOutput;
        }

        /// <summary>
        /// Converts a JSON object to a binary string representation.
        /// </summary>
        /// <param name="json">The JSON object to be converted.</param>
        /// <returns>Binary string representation of the JSON object.</returns>
         
        public static string JsonToBinary(per01 objPerson)
        {
            string strjson = JsonConvert.SerializeObject(objPerson);
            byte[] binaryData = Encoding.UTF8.GetBytes(strjson);
            return ConvertByteToBinary(binaryData);
        }

        /// <summary>
        /// Converts a binary string representation to a JSON object.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>JSON object representation of the binary string.</returns>
        
        public static per01 BinaryToJson(string binaryString)
        {
            byte[] binaryData = ConvertBinaryToBytes(binaryString);
            string strjson = Encoding.UTF8.GetString(binaryData);
            per01 objPerson = JsonConvert.DeserializeObject<per01>(strjson);
            return objPerson;
        }

        /// <summary>
        /// Converts a binary string representation to an XML element.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>XML element representation of the binary string.</returns>
        
        public static XElement BinaryToXML(string binaryString)
        {
            byte[] binaryData = ConvertBinaryToBytes(binaryString);
            string jsonString = Encoding.UTF8.GetString(binaryData);
            per01 objPerson = JsonConvert.DeserializeObject<per01>(jsonString);
            XElement rootElement = new XElement("root",
                   new XElement("Name", objPerson.r01f01),
                   new XElement("Age", objPerson.r01f02)
               );
            return rootElement;
        }

        /// <summary>
        /// Converts an XML element to a binary string representation.
        /// </summary>
        /// <param name="xmlData">The XML element to be converted.</param>
        /// <returns>Binary string representation of the XML element.</returns>
        public static string XMLToBinary(XElement xmlData)
        {
            string xmlString = xmlData.ToString();
            byte[] binaryData = Encoding.UTF8.GetBytes(xmlString);

            return ConvertByteToBinary(binaryData);
        }

        #endregion
    }
}