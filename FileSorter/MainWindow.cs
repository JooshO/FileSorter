﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorter
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
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
    }
}
