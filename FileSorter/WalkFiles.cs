using System.Collections.Generic;

namespace FileSorter
{
    class FileOperations
    {
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