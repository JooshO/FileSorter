using Microsoft.VisualStudio.TestTools.UnitTesting;
using FileSorter;
using System.Linq;
using System.Collections.Generic;

namespace FileSorterTest
{
    [TestClass]
    public class FileSearchingTest
    {
        [TestMethod]
        public void TestCollectFileInfo1()
        {
            // TODO: Find better way for getting to testMaster's relative path
            System.IO.DirectoryInfo testMaster = new("../../../../TestFolderMaster");
            System.IO.FileInfo[] files = FileOperations.CollectFileInformation(testMaster);


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
    }
}
