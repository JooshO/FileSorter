﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FileSorter.FileOperations;

namespace FileSorter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            ///default directory (downloads folder) in string form
            string downloadsFilePath = Microsoft.Win32.Registry.GetValue(@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Explorer\Shell Folders", "{374DE290-123F-4565-9164-39C4925E467B}", String.Empty).ToString();
            //Set text box on window to downloads folder
            folderInputText.Text = downloadsFilePath;
            //Set the Title of the Window
            this.Text = "File Sorter";

            sortSelector.Text = "File type";
        }

        /// <summary>
        /// Auto generated method that runs on file selection button click
        /// </summary>
        /// <param name="sender">unused parameter generated by autofill</param>
        /// <param name="e">unused parameter generated by autofill</param>
        private void fileSelectButton_Click(object sender, EventArgs e)
        {



            // open the folder selection dialog and record the result
            DialogResult result = folderSelector.ShowDialog();


            // if we get a valid result, set the folder selection text box to hold the path
            if (result == DialogResult.OK)
            {
                folderInputText.Text = folderSelector.SelectedPath;
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            string path = folderInputText.Text;
            System.IO.DirectoryInfo directory = new(path);
            string val = (string)sortSelector.SelectedItem;
            System.IO.FileInfo[] files = null;
            try
            {
                files = CollectFileInformation(directory);
            } catch (System.IO.DirectoryNotFoundException)
            {
                errorProvider.SetError(folderInputText, "Invalid Directory");
                return;
            }

            progressBar.Value = 10;

            switch (val)
            {
                case "File type":
                    try
                    {
                        //checks if the delete checkbox is checked or not
                        bool dBool = false;
                        if (checkBox1.Checked)
                        {
                            dBool = true;
                        }

                        CreateFolders(files);
                        sortTypes(files, safeTypeText.Text,dBool);
                        progressBar.Value = 100;
                    }
                    catch (System.IO.DirectoryNotFoundException)
                    {
                        // TODO let the user know there is an error
                    }
                    break;
                case "Similar name":
                    try
                    {
                        //If user has a specific name they want to search for
                        if (fileNameTextBox.Text.Length > 0)
                        {
                            string[] specNames = specificNames(fileNameTextBox.Text);
                            int progress = 80 / specNames.Length;
                            foreach ( string name in specNames )
                            {
                                if (name == null)
                                {
                                    break;
                                }
                                string folderPath = System.IO.Path.Combine(path, name);
                                System.IO.Directory.CreateDirectory(folderPath);
                                sortCommonNames(files, folderPath, name);
                                progressBar.Value += progress;
                            }
                            progressBar.Value = 100;
                        }
                        else
                        {
                            var longestSubstr = CommonFileName.LongestSubstring(files, 3, 4);
                            string folderPath = System.IO.Path.Combine(path, longestSubstr);
                            System.IO.Directory.CreateDirectory(folderPath);
                            sortCommonNames(files, folderPath, longestSubstr);
                            progressBar.Value = 100;
                        }

                    }
                    catch (System.IO.DirectoryNotFoundException)
                    {
                        // TODO let the user know there is an error
                    }
                    break;
                default:
                    
                    break;

            }

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void folderInputText_TextChanged(object sender, EventArgs e)
        {

        }

        private void folderSelector_HelpRequest(object sender, EventArgs e)
        {

        }

        private void safeTypesText_TextChanged(object sender, EventArgs e)
        {

        }

        private void sortSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fileNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void remove_delete_folder_Click(object sender, EventArgs e)
        {

        }
    }
}
