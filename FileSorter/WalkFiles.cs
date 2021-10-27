using System.Collections.Generic;
using System.Linq;

namespace FileSorter
{
    public class FileOperations
    {
        public enum FindOldFilesBy
        {
            kLastAccessed, kLastModified, kCreationTime
        }


        /// <summary>
        /// Collects an array of file information based on passed in directory
        /// </summary>
        /// <param name="root">The directory we want to look through</param>
        /// <returns>An array of FileInfo containing all files directly underneath root</returns>
        public static System.IO.FileInfo[] CollectFileInformation( System.IO.DirectoryInfo root )
        {
            System.IO.FileInfo[] files = null;

            try
            {
                // try to get an array of all file info under the root folder
                files = root.GetFiles("*.*");
            }
            catch (System.UnauthorizedAccessException e)
            {
                // catch if we don't have access to a file
                System.Console.WriteLine(e.Message);
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                // catch if does not exist
                System.Console.WriteLine(e.Message);
                throw;
            }


            return files;
        }

        /// <summary>
        /// Finds all files "older" than a certain date
        /// Defaults to last modified
        /// </summary>
        /// <param name="files">An array of FileInfos to compare to</param>
        /// <param name="time">The time to compare</param>
        public static List<System.IO.FileInfo> FindFilesOlderThan(System.IO.FileInfo[] files, System.DateTime time)
        {
            // query our array
            var queryOldFiles = from file in files
                                where file.LastWriteTime.CompareTo(time) < 0
                                select file;

            // convert to a list and return
            return queryOldFiles.ToList();

        }

        /// <summary>
        /// Finds all files "older" than a certain date
        /// </summary>
        /// <param name="files">An array of FileInfos to compare to</param>
        /// <param name="time">The time to compare</param>
        /// <param name="mode">How we want to compare - either by time last modified, last accessed, or time created</param>
        /// <returns></returns>
        public static List<System.IO.FileInfo> FindFilesOlderThan(System.IO.FileInfo[] files, System.DateTime time, FindOldFilesBy mode)
        {
            // declare the enumerable to store query results
            IEnumerable<System.IO.FileInfo> queryOldFiles;

            switch (mode)
            {
                case FindOldFilesBy.kLastModified:
                    queryOldFiles = from file in files
                                    where file.LastWriteTime.CompareTo(time) < 0
                                    select file;
                    break;
                case FindOldFilesBy.kLastAccessed:
                    queryOldFiles = from file in files
                                    where file.LastAccessTime.CompareTo(time) < 0
                                    select file;
                    break;
                case FindOldFilesBy.kCreationTime:
                    queryOldFiles = from file in files
                                    where file.CreationTime.CompareTo(time) < 0
                                    select file;
                    break;
                // default to time last modified
                default:
                    queryOldFiles = from file in files
                                    where file.LastWriteTime.CompareTo(time) < 0
                                    select file;
                    break;
            }

            // convert to a list and return
            return queryOldFiles.ToList();

        }

        /// <summary>
        /// Creates a folder for every file type present 
        /// </summary>
        /// <param name="files">All files in the main folder</param>
        public static void CreateFolders(System.IO.FileInfo[] files)
        {
            // grab the path to the root folder from the first file
            string pathToRoot = files[0].DirectoryName;

            // Create a HashSet for folder types so we only track one of each file type
            HashSet<string> extensions = new();

            // add file extensions to the set
            foreach(System.IO.FileInfo file in files)
            {
                extensions.Add(System.IO.Path.GetExtension(file.FullName));
            }
            
            // for each file extension / type create a folder
            foreach(string str in extensions)
            {
                string folderPath = System.IO.Path.Combine(pathToRoot, str);
                System.IO.Directory.CreateDirectory(folderPath);
            }
        }
    }
}