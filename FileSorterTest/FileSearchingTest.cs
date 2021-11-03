using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSorter;
using System.Linq;
using System.Collections.Generic;

namespace FileSorterTest
{
    [TestClass]
    public class FileSearchingTest
    {
        // TODO: Find better way for getting to testMaster's relative path
        System.IO.DirectoryInfo testMaster;         // directory info for master test folder
        System.IO.DirectoryInfo testTarget;         // directory info for testing folder

        [TestInitialize]
        public void Init()
        {
            // grab source path and instantiate testMaster
            testMaster = new("../../../../TestFolderMaster");
            string sourcePath = testMaster.FullName;

            // create our test folder and get path/info
            System.IO.Directory.CreateDirectory("../../../../TestFolder");
            string targetPath = "../../../../TestFolder";
            testTarget = new(targetPath);

            // reused string for current file and target file
            string fileName;
            string destFile;

            // Copy all files from test master to new testing directory
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                System.Console.WriteLine("Source path does not exist!");
            }
        }

        [TestMethod]
        public void TestCollectFileInfo1()
        {
            // run method that we are testing
            System.IO.FileInfo[] files = FileOperations.CollectFileInformation(testTarget);

            // expected output
            string[] actualFiles = {"EmptyText - Copy (2).txt", "EmptyText - Copy.txt", "EmptyText.txt",
                                    "RandomBMP.bmp", "RTFFile.rtf", "testImage.png"};

            // make sure length matches
            Assert.AreEqual(actualFiles.Length, files.Length, string.Format("Number of files {0} does not match expected {1}", files.Length, actualFiles.Length));

            // make sure every returned file is expected and collect names
            List<string> returnedFileNames = new(files.Length);

            foreach (System.IO.FileInfo file in files)
            {
                returnedFileNames.Add(file.Name);
                Assert.IsTrue(actualFiles.Contains(file.Name), string.Format("Unexpected file {0}", file.Name));
            }

            // make sure every expected file is present
            foreach (string file in actualFiles)
            {
                Assert.IsTrue(returnedFileNames.Contains(file), string.Format("File {0} not present", file));
            }
        }

        [TestMethod]
        public void TestCreateFolders()
        {
            // run method targeting our test folder
            FileOperations.CreateFolders(FileOperations.CollectFileInformation(testTarget));

            // get array of all subdirectories
            System.IO.DirectoryInfo[] subDirs = testTarget.GetDirectories();

            // folders that we expect it to create
            string[] expectedFolders = { ".bmp", ".png", ".txt", ".rtf" };
            HashSet<string> subdirNames = new();

            // create a set of directory names
            foreach(System.IO.DirectoryInfo dir in subDirs)
            {
                subdirNames.Add(dir.Name);
            }

            // test if all expected folders are present among the sub directories
            Assert.IsTrue(subdirNames.IsSupersetOf(expectedFolders), "Not all expected folders are present");
        }

        [TestMethod]
        public void TestLongestSubstring1()
        {
            List<string> l1 = new() {"City: New York", "City: Los Vegas", "Town: Milan"};
            Assert.AreEqual("City: ", CommonFileName.LongestSubstring(l1, 2, 2));       // largest substring in two strings of length at least 2
            Assert.AreEqual(": ", CommonFileName.LongestSubstring(l1, 3, 2));           // in all 3 strings, length at least 3
            Assert.AreEqual(string.Empty, CommonFileName.LongestSubstring(l1, 3, 3));   // all 3, length at least 3
        }

        [TestMethod]
        public void TestFindDuplicates()
        {
            List<string> output = FileOperations.FindDuplicates(FileOperations.CollectFileInformation(testTarget));
            var expected = new List<string>() { "EmptyText - Copy (2).txt" };
            foreach (string s in output)
            {
                System.Console.WriteLine(s);
            }
            Assert.IsTrue(!expected.Except(output).Any());
        }

        [TestMethod]
        public void TestLongestSubstring2()
        {
            List<string> l1 = new() { 
                "CS3141 Homework 1.txt",
                "CS3141 Notes 1.txt", 
                "CS3141 Notes 2.txt", 
                "CS3141 Notes 3.txt", 
                "CS3141Exam.txt", 
                "CS2321 Exam.txt", 
                "CS2321 Exam2.txt", 
                "CS2321 Exam3.txt", 
            };

            // find largest substring in at least 4 elements
            Assert.AreEqual("CS3141", CommonFileName.LongestSubstring(l1, 4, 4).Trim());

            // find largest substring minus elements containing the previous substring
            Assert.AreEqual("CS2321 Exam", CommonFileName.LongestSubstring(l1.Where(s => !s.Contains("CS3141")).ToList(), 3, 4).Trim());

        }

        [TestCleanup]
        public void CleanUp()
        {
            // delete our testing folder and all files in it
            // comment me out for debugging if need be
            try
            {
                System.IO.Directory.Delete(testTarget.FullName, true);
            }
            catch (System.IO.IOException e)
            {
                System.Console.WriteLine(e.Message);
            }
        }
    }
}
