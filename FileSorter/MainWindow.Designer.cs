
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
            this.safeTypeText = new System.Windows.Forms.TextBox();
            this.safeTypeLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // folderSelector
            // 
            this.folderSelector.HelpRequest += new System.EventHandler(this.folderSelector_HelpRequest);
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(11, 10);
            this.fileSelectButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(135, 22);
            this.fileSelectButton.TabIndex = 0;
            this.fileSelectButton.Text = "select folder";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // folderInputText
            // 
            this.folderInputText.Location = new System.Drawing.Point(162, 10);
            this.folderInputText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.folderInputText.Name = "folderInputText";
            this.folderInputText.Size = new System.Drawing.Size(154, 23);
            this.folderInputText.TabIndex = 1;
            this.folderInputText.TextChanged += new System.EventHandler(this.folderInputText_TextChanged);
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(464, 10);
            this.sortButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(226, 22);
            this.sortButton.TabIndex = 2;
            this.sortButton.Text = "Generate folders";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // safeTypeText
            // 
            this.safeTypeText.Location = new System.Drawing.Point(119, 50);
            this.safeTypeText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.safeTypeText.Name = "safeTypeText";
            this.safeTypeText.Size = new System.Drawing.Size(305, 23);
            this.safeTypeText.TabIndex = 3;
            this.safeTypeText.TextChanged += new System.EventHandler(this.safeTypesText_TextChanged);
            // 
            // safeTypeLabel
            // 
            this.safeTypeLabel.AutoSize = true;
            this.safeTypeLabel.Location = new System.Drawing.Point(11, 52);
            this.safeTypeLabel.Name = "safeTypeLabel";
            this.safeTypeLabel.Size = new System.Drawing.Size(93, 15);
            this.safeTypeLabel.TabIndex = 4;
            this.safeTypeLabel.Text = "Protected Types:";
            this.safeTypeLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(322, 10);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(59, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Delete";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.safeTypeLabel);
            this.Controls.Add(this.safeTypeText);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.folderInputText);
            this.Controls.Add(this.fileSelectButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderSelector;
        private System.Windows.Forms.Button fileSelectButton;
        private System.Windows.Forms.TextBox folderInputText;
        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.TextBox safeTypeText;
        private System.Windows.Forms.Label safeTypeLabel;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

