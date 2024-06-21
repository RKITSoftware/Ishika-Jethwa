using FileSystemDemo.BL;
using FileSystemDemo.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Web.Http;

namespace FileSystemDemo.Controllers
{
    public class CLFileController : ApiController
    {
        private readonly BLFileRepo _objFileRepo = new BLFileRepo();
      
        /// <summary>
        /// Handles file upload.
        /// </summary>
        /// <returns>HTTP response indicating success or failure.</returns>
        [HttpPost]
        [Route("api/upload")]    
        public IHttpActionResult UploadFiles()
        {
          return Ok(_objFileRepo.Upload());
        }

        /// <summary>
        /// Handles file download.
        /// </summary>
        /// <param name="uniqueName">Unique identifier for the file to be downloaded.</param>
        /// <returns>HTTP response containing the file for download or an error response.</returns>
        [HttpGet]
        [Route("api/download/{uniqueName}")]
        public HttpResponseMessage DownloadFile(string uniqueName)
        {
            return _objFileRepo.Download(uniqueName);
        }

        /// <summary>
        /// Get All Files that has uploaded
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetAllFiles")]
        public List<fil01> GetAllFiles()
        {
            return BLFile.GetAllFiles();
        }

        /// <summary>
        /// Get information about a specific file.
        /// </summary>
        /// <param name="uniqueName">Unique identifier for the file.</param>
        /// <returns>File information or an error response.</returns>
        [HttpGet]
        [Route("api/fileinfo/{uniqueName}")]
        public IHttpActionResult GetFileInfo(string uniqueName)   
        {
            string filePath = _objFileRepo.GetFilePath(uniqueName);

            if (File.Exists(filePath))
            {
                return Ok(_objFileRepo.FileInfo(filePath));
            }
            else
            {
                return NotFound(); 
            }
        }

        /// <summary>
        /// Get information about a specific directory.
        /// </summary>
        /// <param name="directoryPath">Path of the directory.</param>
        /// <returns>Directory information or an error response.</returns>
        [HttpPost]
        [Route("api/directoryinfo")]
        public IHttpActionResult GetDirectoryInfo([FromBody] string directoryPath)
        {
            if (Directory.Exists(directoryPath))
            {
              return Ok(_objFileRepo.DirectoryInfo(directoryPath));
            }
            else
            {
                return NotFound(); 
            }
        }

        [HttpPost]
        [Route("api/createDirectory")]
        public IHttpActionResult AddDirectory([FromBody] string directoryPath)
        {
           
                return Ok(_objFileRepo.CreateDirectory(directoryPath));
           
        }


    }
}
