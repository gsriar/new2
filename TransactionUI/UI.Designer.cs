namespace TransactionUI
{
    partial class UI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblConfigPath = new System.Windows.Forms.Label();
            this.txtConfigFilePath = new System.Windows.Forms.TextBox();
            this.txtClientDataFilePath = new System.Windows.Forms.TextBox();
            this.lblClientDataFile = new System.Windows.Forms.Label();
            this.txtOutputFileNamePrefix = new System.Windows.Forms.TextBox();
            this.lblOutFilePrefix = new System.Windows.Forms.Label();
            this.txtErrorOutputFolder = new System.Windows.Forms.TextBox();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.txtResultOutputFolder = new System.Windows.Forms.TextBox();
            this.lblResultOutput = new System.Windows.Forms.Label();
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblConfigPath
            // 
            this.lblConfigPath.AutoSize = true;
            this.lblConfigPath.Location = new System.Drawing.Point(21, 32);
            this.lblConfigPath.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfigPath.Name = "lblConfigPath";
            this.lblConfigPath.Size = new System.Drawing.Size(113, 13);
            this.lblConfigPath.TabIndex = 0;
            this.lblConfigPath.Text = "Configuration File Path";
            // 
            // txtConfigFilePath
            // 
            this.txtConfigFilePath.Location = new System.Drawing.Point(160, 28);
            this.txtConfigFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfigFilePath.Name = "txtConfigFilePath";
            this.txtConfigFilePath.Size = new System.Drawing.Size(338, 20);
            this.txtConfigFilePath.TabIndex = 1;
            // 
            // txtClientDataFilePath
            // 
            this.txtClientDataFilePath.Location = new System.Drawing.Point(160, 68);
            this.txtClientDataFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.txtClientDataFilePath.Name = "txtClientDataFilePath";
            this.txtClientDataFilePath.Size = new System.Drawing.Size(338, 20);
            this.txtClientDataFilePath.TabIndex = 3;
            // 
            // lblClientDataFile
            // 
            this.lblClientDataFile.AutoSize = true;
            this.lblClientDataFile.Location = new System.Drawing.Point(21, 72);
            this.lblClientDataFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClientDataFile.Name = "lblClientDataFile";
            this.lblClientDataFile.Size = new System.Drawing.Size(103, 13);
            this.lblClientDataFile.TabIndex = 2;
            this.lblClientDataFile.Text = "Client Data File Path";
            // 
            // txtOutputFileNamePrefix
            // 
            this.txtOutputFileNamePrefix.Location = new System.Drawing.Point(160, 111);
            this.txtOutputFileNamePrefix.Margin = new System.Windows.Forms.Padding(2);
            this.txtOutputFileNamePrefix.Name = "txtOutputFileNamePrefix";
            this.txtOutputFileNamePrefix.Size = new System.Drawing.Size(338, 20);
            this.txtOutputFileNamePrefix.TabIndex = 5;
            // 
            // lblOutFilePrefix
            // 
            this.lblOutFilePrefix.AutoSize = true;
            this.lblOutFilePrefix.Location = new System.Drawing.Point(21, 115);
            this.lblOutFilePrefix.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOutFilePrefix.Name = "lblOutFilePrefix";
            this.lblOutFilePrefix.Size = new System.Drawing.Size(118, 13);
            this.lblOutFilePrefix.TabIndex = 4;
            this.lblOutFilePrefix.Text = "Output File Name Prefix";
            // 
            // txtErrorOutputFolder
            // 
            this.txtErrorOutputFolder.Location = new System.Drawing.Point(160, 150);
            this.txtErrorOutputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtErrorOutputFolder.Name = "txtErrorOutputFolder";
            this.txtErrorOutputFolder.Size = new System.Drawing.Size(338, 20);
            this.txtErrorOutputFolder.TabIndex = 7;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.AutoSize = true;
            this.lblErrorOutput.Location = new System.Drawing.Point(21, 154);
            this.lblErrorOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(96, 13);
            this.lblErrorOutput.TabIndex = 6;
            this.lblErrorOutput.Text = "Error Outpur Folder";
            // 
            // txtResultOutputFolder
            // 
            this.txtResultOutputFolder.Location = new System.Drawing.Point(160, 193);
            this.txtResultOutputFolder.Margin = new System.Windows.Forms.Padding(2);
            this.txtResultOutputFolder.Name = "txtResultOutputFolder";
            this.txtResultOutputFolder.Size = new System.Drawing.Size(338, 20);
            this.txtResultOutputFolder.TabIndex = 9;
            // 
            // lblResultOutput
            // 
            this.lblResultOutput.AutoSize = true;
            this.lblResultOutput.Location = new System.Drawing.Point(21, 197);
            this.lblResultOutput.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblResultOutput.Name = "lblResultOutput";
            this.lblResultOutput.Size = new System.Drawing.Size(104, 13);
            this.lblResultOutput.TabIndex = 8;
            this.lblResultOutput.Text = "Result Output Folder";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(415, 229);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(83, 24);
            this.btnProcess.TabIndex = 10;
            this.btnProcess.Text = "Start Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(509, 27);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(74, 24);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Tag = "configFilePath";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(509, 68);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 24);
            this.button1.TabIndex = 12;
            this.button1.Tag = "clientDataFilePath";
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(509, 147);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(2);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(74, 24);
            this.btnBrowseFolder.TabIndex = 13;
            this.btnBrowseFolder.Tag = "errorOutputFolder";
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(509, 191);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 24);
            this.button3.TabIndex = 14;
            this.button3.Tag = "resultOutputFolder";
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 265);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(559, 168);
            this.textBox1.TabIndex = 15;
            // 
            // UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 445);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnBrowseFolder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.txtResultOutputFolder);
            this.Controls.Add(this.lblResultOutput);
            this.Controls.Add(this.txtErrorOutputFolder);
            this.Controls.Add(this.lblErrorOutput);
            this.Controls.Add(this.txtOutputFileNamePrefix);
            this.Controls.Add(this.lblOutFilePrefix);
            this.Controls.Add(this.txtClientDataFilePath);
            this.Controls.Add(this.lblClientDataFile);
            this.Controls.Add(this.txtConfigFilePath);
            this.Controls.Add(this.lblConfigPath);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "UI";
            this.Text = "UI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfigPath;
        private System.Windows.Forms.TextBox txtConfigFilePath;
        private System.Windows.Forms.TextBox txtClientDataFilePath;
        private System.Windows.Forms.Label lblClientDataFile;
        private System.Windows.Forms.TextBox txtOutputFileNamePrefix;
        private System.Windows.Forms.Label lblOutFilePrefix;
        private System.Windows.Forms.TextBox txtErrorOutputFolder;
        private System.Windows.Forms.Label lblErrorOutput;
        private System.Windows.Forms.TextBox txtResultOutputFolder;
        private System.Windows.Forms.Label lblResultOutput;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
    }
}