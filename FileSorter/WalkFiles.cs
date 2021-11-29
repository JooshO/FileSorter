using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;


namespace FileSorter
{
    public static class FileOperations
    {
        /// <summary>
        /// Enum for methods of locating old files
        /// </summary>
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

        /************************************************************************************************************************************
         *  Find "old files". This can only be tested by hand because generated testing folders will have identical time created, mod, etc. *
         ************************************************************************************************************************************/

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

            // Creates the to folder that will eventually be deleted
            string path = System.IO.Path.Combine(pathToRoot, "to be deleted");
            System.IO.Directory.CreateDirectory(path);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="folders"></param>
        /// <param name="pathToRoot"></param>
        public static void CreateFolders(string[] folders, string pathToRoot)
        {
            foreach(string str in folders)
            {
                string folderPath = System.IO.Path.Combine(pathToRoot, str);
                System.IO.Directory.CreateDirectory(folderPath);
            }
        }

        /// <summary>
        /// Returns a list of all duplicate files filename
        /// </summary>
        /// <param name="files">All files in the main folder</param>
        public static List<string> FindDuplicates(System.IO.FileInfo[] files)
        {

            //instantiate duplicate file list
            List<string> duplicates = new();

            //search through each file in directory
            foreach (System.IO.FileInfo file in files)
            {
                //if the file has a duplicate file name EX: text(1).txt
                if ( file.Name.Contains("(") && file.Name.Contains(")") )
                {
                    //add filename to the duplicates list
                    duplicates.Add(file.Name);
                
                }
            }
            return duplicates;
        }

        public static int sortCommonNames(System.IO.FileInfo[] files, string folderPath, string commonStr)
        {
            int i = 0;
            //sort through files
            foreach (System.IO.FileInfo file in files)
            {
                if (!file.Name.Contains(commonStr)) continue;

                //new path
                string newPath = System.IO.Path.Combine(folderPath, file.Name);
                file.MoveTo(newPath);
                i++;
            }

            return i;
        }

        /// <summary>
        /// Iterate through specific names text box and return a list of all there
        /// </summary>
        /// <param name="rawNames">Textbox data</param>
        /// <returns></returns>
        public static string[] specificNames(string rawNames)
        {
            string[] names = new string[rawNames.Length / 2];
            char current = ' ';
            int j = 0;
            for (int i = 0; i < rawNames.Length; i++)
            {
                current = (char)rawNames[i];
                //if not space
                if (current != 32)
                {
                    //if needs to be initialized
                    if (i == 0)
                    {
                        names[j] = char.ToString(current);
                    }
                    else
                    {
                        //add character to string
                        names[j] += char.ToString(current);
                    }
                }
                else
                {
                    j++;
                }
            }
            return names;
        }

        /// <summary>
        /// Reutnrs array of strings with types to be left untouched
        /// </summary>
        /// <param name="files">All files in the main folder</param>
        /// <param name="protTypes">Files that are not to be touched</param>
        /// <returns> Array of string to be left untouched by file sorter </returns>
        public static string[] protTypes(System.IO.FileInfo[] files, string protTypes) 
        {
            //Sort through protected types
            string[] prot = new string[protTypes.Length / 2];
            char current = ' ';
            int j = 0;
            for (int i = 0; i < protTypes.Length; i++)
            {
                current = (char)protTypes[i];
                //if it is a letter
                if (current < 123 && current > 64 || current == 46)
                {
                    //if needs to be initialized
                    if (i == 0)
                    {
                        prot[j] = char.ToString(current);
                    }
                    else
                    {
                        //add character to string
                        prot[j] += char.ToString(current);
                    }
                }
                else if (current == 32)//if space move to next element for new type
                {
                    j++;
                }
            }
            return prot;
        }

        /// <summary>
        /// Pushes files to folder organized by type
        /// </summary>
        /// <param name="files">All files in the main folder</param>
        /// <param name="protectedTypes">Files that are not to be touched</param>
        /// <param name="deleteFiles">Moves files into the delete folder if True</param>
        public static void sortTypes(System.IO.FileInfo[] files, string protectedTypes, bool deleteFiles)
        {
            string[] prot = protTypes(files, protectedTypes);
            // grab the path to the root folder from the first file
            string pathToRoot = files[0].DirectoryName;
            //sort through files
            foreach (System.IO.FileInfo file in files)
            {
                //if not a protected type move to file
                bool canMove = true;
                //new path
                string newPath = System.IO.Path.Combine(pathToRoot, System.IO.Path.GetExtension(file.FullName));
                newPath = System.IO.Path.Combine(newPath, file.Name);
                int i = 0;

                // block movement of .ini files which are often system files
                if (file.Extension.Equals(".ini")) continue;

                //check against protected types
                while (i < protectedTypes.Length / 2 && prot[i] != null)
                {
                    if (System.IO.Path.GetExtension(file.FullName).CompareTo(prot[i]) == 0)
                    {
                        canMove = false;
                        break;
                    }
                    i++;
                }
                if (canMove)
                {

                    // Checks if the file is to be deleted
                    if (deleteFiles)
                    {

                        // Compares the duplicate files and moves them to the deleted folder
                        foreach (string dFile in FindDuplicates(files))
                        {
                            if (string.Equals(dFile,file.Name))
                            {
                                string path = System.IO.Path.Combine(pathToRoot, "to be deleted");
                                file.MoveTo(path);
                            }
                            else
                            {
                                file.MoveTo(newPath);
                            }
                            
                        }
                    }

                    //move file
                    file.MoveTo(newPath);
                }

            }

            

        }

        
    }
}