using FileSystemDemo.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace FileSystemDemo.BL
{
    public  class BLFileRepo

    {   /// <summary>
        /// Handles file upload.
        /// </summary>
        /// <returns> success or failure.</returns>
        public  string Upload()
        {
            try
            {
                // Loop through each file in the request
                foreach (string filename in HttpContext.Current.Request.Files.AllKeys)
                {
                    // Get the current file
                    HttpPostedFile file = HttpContext.Current.Request.Files[filename];

                    // Check if the file is not null
                    if (file != null)
                    {
                        // Create a FileDetails object to store file information
                        fil01 objFile = new fil01();
                        objFile.l01f02 = file.FileName;
                        objFile.l01f04 = Path.GetExtension(file.FileName);
                        objFile.l01f03 = file.ContentType;

                        // Generate a unique name for the file
                        objFile.l01f01 = Guid.NewGuid().ToString();

                        // Get the server's root path for the "Upload" folder
                        string rootpath = HttpContext.Current.Server.MapPath("~/Upload");

                        // Combine the root path with the unique file name and extension
                        string fileSavePath = Path.Combine(rootpath, objFile.l01f02 + objFile.l01f04);

                        // Save the file to the specified path
                        file.SaveAs(fileSavePath);

                        // Save file information to the database
                        BLFile.SaveFile(objFile);
                    }
                }
                // Return a success response
                return "Success";
            }
            // Catch any exceptions that might occur during file processing
            catch (Exception ex)
            {
                // Return a bad request response with the exception message
                return $"BadRequest  {ex}";
            }
        }

        /// <summary>
        /// Handles file download.
        /// </summary>
        /// <param name="uniqueName">Unique identifier for the file to be downloaded.</param>
        /// <returns>HTTP response containing the file for download or an error response.</returns>
        public  HttpResponseMessage Download(string uniqueName)
        {
            // Get the server's root path for the "Upload" folder
            string rootPath = HttpContext.Current.Server.MapPath("~/Upload");

            // Get file information by unique ID
            fil01 objFile = BLFile.GetFileByUniqueID(uniqueName);

            if (objFile != null)
            {
                try
                {
                    // Combine the root path with the unique file name and extension
                    string fullpath = Path.Combine(rootPath, objFile.l01f01 + objFile.l01f04);

                    // Read the file content into a byte array
                    byte[] file = File.ReadAllBytes(fullpath);

                    // Create a memory stream from the byte array
                    using (MemoryStream ms = new MemoryStream(file))
                    {
                        // Create a new HTTP response message with OK status
                        HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);

                        // Set the response content as a byte array
                        response.Content = new ByteArrayContent(file);

                        // Set content disposition header for attachment
                        response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");

                        // Set content type header based on the file's content type
                        response.Content.Headers.ContentType = new MediaTypeHeaderValue(objFile.l01f03);

                        // Set the file name for content disposition header
                        response.Content.Headers.ContentDisposition.FileName = objFile.l01f02;

                        // Return the HTTP response message
                        return response;
                    }
                }
                catch (Exception ex)
                {
                    // Handle exceptions (log or return an error response)
                    HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    errorResponse.Content = new StringContent($"Error: {ex.Message}");
                    return errorResponse;
                }
            }
            else
            {
                // If file information is not found, create a not found HTTP response
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        /// Get the full file path based on the unique name.
        /// </summary>
        /// <param name="uniqueName">Unique identifier for the file.</param>
        /// <returns>Full file path or null if not found.</returns>
        public  string GetFilePath(string uniqueName)
        {
            string appDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");
            uniqueName += ".txt";
            string filePath = Path.Combine(appDataPath, uniqueName);
            return File.Exists(filePath) ? filePath : null;
        }

        /// <summary>
        /// Get File Related information
        /// </summary>
        /// <param name="filePath">path of the file</param>
        /// <returns></returns>
        public  dynamic FileInfo(string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);

            var fileInformation = new
            {
                FileName = fileInfo.Name,
                FilePath = fileInfo.FullName,
                SizeInBytes = fileInfo.Length,
                LastModified = fileInfo.LastWriteTime
            };

            return fileInformation;
        }

        /// <summary>
        /// Get The Directory Related information
        /// </summary>
        /// <param name="directoryPath">Pass Directory Path</param>
        /// <returns></returns>
        public  dynamic DirectoryInfo(string directoryPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directoryPath);

            var directoryInformation = new
            {
                DirectoryName = directoryInfo.Name,
                DirectoryPath = directoryInfo.FullName,
                LastModified = directoryInfo.LastWriteTime
            };

            return directoryInformation;
        }

        /// <summary>
        /// Creates a new directory.
        /// </summary>
        /// <param name="directoryName">Name of the new directory.</param>
        /// <returns>Path of the created directory or an error message if failed.</returns>
        public string CreateDirectory(string directoryName)
        {
            try
            {
                string rootPath = HttpContext.Current.Server.MapPath("~/Upload");
                string newDirectoryPath = Path.Combine(rootPath, directoryName);

                if (!Directory.Exists(newDirectoryPath))
                {
                    Directory.CreateDirectory(newDirectoryPath);
                    return newDirectoryPath;
                }
                else
                {
                    return "Directory already exists.";
                }
            }
            catch (Exception ex)
            {
                return $"Failed to create directory. Error: {ex.Message}";
            }
        }

        /// <summary>
        /// Renames an existing directory.
        /// </summary>
        /// <param name="currentDirectoryName">Current name of the directory to be renamed.</param>
        /// <param name="newDirectoryName">New name for the directory.</param>
        /// <returns>Success message or an error message if failed.</returns>
        public string RenameDirectory(string currentDirectoryName, string newDirectoryName)
        {
            try
            {
                string rootPath = HttpContext.Current.Server.MapPath("~/Upload");
                string currentDirectoryPath = Path.Combine(rootPath, currentDirectoryName);
                string newDirectoryPath = Path.Combine(rootPath, newDirectoryName);

                if (Directory.Exists(currentDirectoryPath))
                {
                    Directory.Move(currentDirectoryPath, newDirectoryPath);
                    return "Directory renamed successfully.";
                }
                else
                {
                    return "Directory not found.";
                }
            }
            catch (Exception ex)
            {
                return $"Failed to rename directory. Error: {ex.Message}";
            }
        }


        /// <summary>
        /// Deletes a directory.
        /// </summary>
        /// <param name="directoryName">Name of the directory to be deleted.</param>
        /// <returns>Success message or an error message if failed.</returns>
        public string DeleteDirectory(string directoryName)
        {
            try
            {
                string rootPath = HttpContext.Current.Server.MapPath("~/Upload");
                string directoryPath = Path.Combine(rootPath, directoryName);

               
                    Directory.Delete(directoryPath, true);
                    return "Directory deleted successfully.";
               
            }
            catch (Exception ex)
            {
                return $"Failed to delete directory. Error: {ex.Message}";
            }
        }
    }

}