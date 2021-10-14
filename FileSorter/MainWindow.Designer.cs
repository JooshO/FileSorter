
namespace FileSorter
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.folderInputText = new System.Windows.Forms.TextBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(13, 13);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(154, 29);
            this.fileSelectButton.TabIndex = 0;
            this.fileSelectButton.Text = "select folder";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // folderInputText
            // 
            this.folderInputText.Location = new System.Drawing.Point(185, 13);
            this.folderInputText.Name = "folderInputText";
            this.folderInputText.Size = new System.Drawing.Size(176, 27);
            this.folderInputText.TabIndex = 1;
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(530, 13);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(258, 29);
            this.sortButton.TabIndex = 2;
            this.sortButton.Text = "Generate folders";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.folderInputText);
            this.Controls.Add(this.fileSelectButton);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderSelector;
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.TextBox folderInputText;
        private System.Windows.Forms.Button sortButton;
    }
}

