using System;
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

        private void fileSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderSelector.ShowDialog();
            if ( result == DialogResult.OK)
            {
                folderInputText.Text = folderSelector.SelectedPath;
            }
        }
    }
}
