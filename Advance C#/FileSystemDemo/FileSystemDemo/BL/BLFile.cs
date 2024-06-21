using System;
using System.Collections.Generic;
using System.Linq;

namespace FileSystemDemo.Models
{
    public static class BLFile
    {
        private static List<fil01> lstFiles = new List<fil01>();

        /// <summary>
        /// Saves a file to the file list.
        /// </summary>
        /// <param name="file">The file to be saved.</param>
        public static void SaveFile(fil01 file)
        {
            lstFiles.Add(file);
        }

        /// <summary>
        /// Retrieves a file by its unique ID.
        /// </summary>
        /// <param name="uniqueName">The unique ID of the file.</param>
        /// <returns>The file matching the unique ID, or null if not found.</returns>
        public static fil01 GetFileByUniqueID(string uniqueName)
        {
            if (lstFiles != null)
            {
                // Case-insensitive comparison
                return lstFiles.FirstOrDefault(p => p.l01f01.Equals(uniqueName, StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Retrieves all files in the file list.
        /// </summary>
        /// <returns>A list of all files.</returns>
        public static List<fil01> GetAllFiles()
        {
            return lstFiles;
        }
    }
}
