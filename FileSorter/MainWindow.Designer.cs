
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.folderSelector = new System.Windows.Forms.FolderBrowserDialog();
            this.fileSelectButton = new System.Windows.Forms.Button();
            this.folderInputText = new System.Windows.Forms.TextBox();
            this.sortButton = new System.Windows.Forms.Button();
            this.safeTypeText = new System.Windows.Forms.TextBox();
            this.safeTypeLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.sortSelector = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // folderSelector
            // 
            this.folderSelector.HelpRequest += new System.EventHandler(this.folderSelector_HelpRequest);
            // 
            // fileSelectButton
            // 
            this.fileSelectButton.Location = new System.Drawing.Point(10, 367);
            this.fileSelectButton.Name = "fileSelectButton";
            this.fileSelectButton.Size = new System.Drawing.Size(110, 29);
            this.fileSelectButton.TabIndex = 0;
            this.fileSelectButton.Text = "select folder";
            this.fileSelectButton.UseVisualStyleBackColor = true;
            this.fileSelectButton.Click += new System.EventHandler(this.fileSelectButton_Click);
            // 
            // folderInputText
            // 
            this.folderInputText.Location = new System.Drawing.Point(135, 367);
            this.folderInputText.Name = "folderInputText";
            this.folderInputText.Size = new System.Drawing.Size(651, 27);
            this.folderInputText.TabIndex = 1;
            this.folderInputText.TextChanged += new System.EventHandler(this.folderInputText_TextChanged);
            // 
            // sortButton
            // 
            this.sortButton.Location = new System.Drawing.Point(695, 331);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(93, 29);
            this.sortButton.TabIndex = 2;
            this.sortButton.Text = "Sort";
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // safeTypeText
            // 
            this.safeTypeText.Location = new System.Drawing.Point(144, 257);
            this.safeTypeText.Name = "safeTypeText";
            this.safeTypeText.Size = new System.Drawing.Size(465, 27);
            this.safeTypeText.TabIndex = 3;
            this.safeTypeText.TextChanged += new System.EventHandler(this.safeTypesText_TextChanged);
            // 
            // safeTypeLabel
            // 
            this.safeTypeLabel.AutoSize = true;
            this.safeTypeLabel.Location = new System.Drawing.Point(10, 264);
            this.safeTypeLabel.Name = "safeTypeLabel";
            this.safeTypeLabel.Size = new System.Drawing.Size(117, 20);
            this.safeTypeLabel.TabIndex = 4;
            this.safeTypeLabel.Text = "Protected Types:";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(711, 13);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(75, 24);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "Delete";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // sortSelector
            // 
            this.sortSelector.FormattingEnabled = true;
            this.sortSelector.Items.AddRange(new object[] {
            "File type",
            "Similar name"});
            this.sortSelector.Location = new System.Drawing.Point(13, 13);
            this.sortSelector.Name = "sortSelector";
            this.sortSelector.Size = new System.Drawing.Size(151, 28);
            this.sortSelector.TabIndex = 6;
            this.sortSelector.SelectedIndexChanged += new System.EventHandler(this.sortSelector_SelectedIndexChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 412);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(773, 29);
            this.progressBar.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Names to Sort:";
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(144, 324);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.Size = new System.Drawing.Size(465, 27);
            this.fileNameTextBox.TabIndex = 9;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.fileNameTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 297);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "Protected Names:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(144, 291);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(465, 27);
            this.textBox1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 227);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "File Age Limit:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(584, 9);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 31);
            this.button1.TabIndex = 13;
            this.button1.Text = "Remove Files";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.sortSelector);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.safeTypeLabel);
            this.Controls.Add(this.safeTypeText);
            this.Controls.Add(this.sortButton);
            this.Controls.Add(this.folderInputText);
            this.Controls.Add(this.fileSelectButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
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
        private System.Windows.Forms.ComboBox sortSelector;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}

