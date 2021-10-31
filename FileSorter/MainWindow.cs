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
            if ( result == DialogResult.OK)
            {
                folderInputText.Text = folderSelector.SelectedPath;
            }
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            string path = folderInputText.Text;
            System.IO.DirectoryInfo directory = new(path);
            try
            {
                CreateFolders(CollectFileInformation(directory));
                sortTypes(CollectFileInformation(directory), safeTypeText.Text);
            } catch (System.IO.DirectoryNotFoundException)
            {
                // TODO let the user know there is an error
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
