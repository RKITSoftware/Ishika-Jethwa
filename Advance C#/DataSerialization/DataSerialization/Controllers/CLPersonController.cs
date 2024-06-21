using DataSerialization.BL;
using DataSerialization.Models;
using System.Web.Http;
using System.Xml.Linq;

namespace DataSerialization.Controllers
{
    public class CLPersonController : ApiController
    {
        #region Public
        /// <summary>
        /// Converts a Person object to a JSON string.
        /// </summary>
        [HttpGet]
        [Route("api/JsonToString")]
        public IHttpActionResult JsonToString()
        {
            per01 objPerson = new per01 { r01f01 = "Ishika", r01f02 = 21 };
            string strjson = BLSerialization.JsonToString(objPerson);
            return Ok(strjson);
        }

        /// <summary>
        /// Converts a JSON string to a Person object.
        /// </summary>
        [HttpPost]
        [Route("api/StringToJson")]
        public IHttpActionResult StringToJson([FromBody] string strjson)
        {
            per01 objPerson = BLSerialization.StringToJson(strjson);
            return Ok(objPerson);
        }
        /// <summary>
        /// Converts an XML element to a JSON string.
        /// </summary>
        [HttpPost]
        [Route("api/XmlToString")]
        public IHttpActionResult XmlToString([FromBody] XElement root)
        {
            string strXML = BLSerialization.XMLToString(root) ;
            return Ok(strXML);
        }

        /// <summary>
        /// Converts a string to an XML element.
        /// </summary>
        [HttpPost]
        [Route("api/StringToXml")]
        public IHttpActionResult StringToXml([FromBody] string strjson)
        {
            XElement xmlOutput = BLSerialization.StringToXML(strjson);
            return Ok(xmlOutput);
        }

        /// <summary>
        /// Converts a Person object to an XML element.
        /// </summary>
        [HttpPost]
        [Route("api/JsonToXml")]
        public XElement JsonToXml([FromBody] per01 objPerson)
        {
            XElement rootElement = BLSerialization.JsonToXML(objPerson) ;
            return rootElement;
        }

        /// <summary>
        /// Converts an XML element to a Person object.
        /// </summary>
        [HttpPost]
        [Route("api/XmlToJson")]
        public IHttpActionResult XmlToJson([FromBody] XElement root)
        {
            per01 objPerson = BLSerialization.XMLToJson(root) ;
            return Ok(objPerson);
        }

        /// <summary>
        /// Converts a regular string to a binary string representation.
        /// </summary>
        /// <param name="input">The regular string to be converted.</param>
        /// <returns>Binary string representation of the input string.</returns>
        [HttpPost]
        [Route("api/StringToBinary")]
        public IHttpActionResult StringToBinary([FromBody] string input)
        {
           
            string binaryRepresentation = BLSerialization.StringToBinary(input);
            return Ok(binaryRepresentation);

        }

        /// <summary>
        /// Converts a binary string representation to a regular string.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>String representation of the binary data.</returns>

        [HttpPost]
        [Route("api/BinaryToString")]
        public IHttpActionResult BinaryToString([FromBody] string binaryString)
        {
            string strOutput = BLSerialization.BinaryToString(binaryString);
            return Ok(strOutput);
        }

        /// <summary>
        /// Converts a JSON object to a binary string representation.
        /// </summary>
        /// <param name="json">The JSON object to be converted.</param>
        /// <returns>Binary string representation of the JSON object.</returns>

        [HttpPost]
        [Route("api/JsonToBinary")]
        public IHttpActionResult JsonToBinary([FromBody] per01 objPerson)
        {
            return Ok(BLSerialization.JsonToBinary(objPerson));
        }

        /// <summary>
        /// Converts a binary string representation to a JSON object.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>JSON object representation of the binary string.</returns>
        [HttpPost]
        [Route("api/BinaryToJson")]
        public IHttpActionResult BinaryToJson([FromBody] string binaryString)
        {
           per01 objPerson = BLSerialization.BinaryToJson(binaryString);    
            return Ok(objPerson);

        }

        /// <summary>
        /// Converts a binary string representation to an XML element.
        /// </summary>
        /// <param name="binaryString">The binary string to be converted.</param>
        /// <returns>XML element representation of the binary string.</returns>
        [HttpPost]
        [Route("api/BinaryToXMl")]
        public XElement BinaryToXML([FromBody] string binaryString)
        {
            return BLSerialization.BinaryToXML(binaryString);
        }

        /// <summary>
        /// Converts an XML element to a binary string representation.
        /// </summary>
        /// <param name="xmlData">The XML element to be converted.</param>
        /// <returns>Binary string representation of the XML element.</returns>
        [HttpPost]
        [Route("api/XmlToBinary")]
        public IHttpActionResult XmlToBinary([FromBody] XElement xmlData)
        {
           return Ok(BLSerialization.XMLToBinary(xmlData));
        }
        #endregion

     
    }

}

