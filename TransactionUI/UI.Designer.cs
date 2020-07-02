namespace TransactionUI
{
    partial class Transaction
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblConfigPath
            // 
            this.lblConfigPath.AutoSize = true;
            this.lblConfigPath.Location = new System.Drawing.Point(28, 44);
            this.lblConfigPath.Name = "lblConfigPath";
            this.lblConfigPath.Size = new System.Drawing.Size(192, 18);
            this.lblConfigPath.TabIndex = 0;
            this.lblConfigPath.Text = "Configuration File Path";
            // 
            // txtConfigFilePath
            // 
            this.txtConfigFilePath.BackColor = System.Drawing.Color.Beige;
            this.txtConfigFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigFilePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigFilePath.Location = new System.Drawing.Point(227, 38);
            this.txtConfigFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfigFilePath.Multiline = true;
            this.txtConfigFilePath.Name = "txtConfigFilePath";
            this.txtConfigFilePath.Size = new System.Drawing.Size(457, 41);
            this.txtConfigFilePath.TabIndex = 1;
            // 
            // txtClientDataFilePath
            // 
            this.txtClientDataFilePath.BackColor = System.Drawing.Color.Beige;
            this.txtClientDataFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientDataFilePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientDataFilePath.Location = new System.Drawing.Point(227, 94);
            this.txtClientDataFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClientDataFilePath.Multiline = true;
            this.txtClientDataFilePath.Name = "txtClientDataFilePath";
            this.txtClientDataFilePath.Size = new System.Drawing.Size(457, 41);
            this.txtClientDataFilePath.TabIndex = 3;
            // 
            // lblClientDataFile
            // 
            this.lblClientDataFile.AutoSize = true;
            this.lblClientDataFile.Location = new System.Drawing.Point(28, 100);
            this.lblClientDataFile.Name = "lblClientDataFile";
            this.lblClientDataFile.Size = new System.Drawing.Size(176, 18);
            this.lblClientDataFile.TabIndex = 2;
            this.lblClientDataFile.Text = "Client Data File Path";
            // 
            // txtOutputFileNamePrefix
            // 
            this.txtOutputFileNamePrefix.BackColor = System.Drawing.Color.Beige;
            this.txtOutputFileNamePrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFileNamePrefix.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFileNamePrefix.Location = new System.Drawing.Point(227, 154);
            this.txtOutputFileNamePrefix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOutputFileNamePrefix.Multiline = true;
            this.txtOutputFileNamePrefix.Name = "txtOutputFileNamePrefix";
            this.txtOutputFileNamePrefix.Size = new System.Drawing.Size(457, 41);
            this.txtOutputFileNamePrefix.TabIndex = 5;
            // 
            // lblOutFilePrefix
            // 
            this.lblOutFilePrefix.AutoSize = true;
            this.lblOutFilePrefix.Location = new System.Drawing.Point(28, 160);
            this.lblOutFilePrefix.Name = "lblOutFilePrefix";
            this.lblOutFilePrefix.Size = new System.Drawing.Size(192, 18);
            this.lblOutFilePrefix.TabIndex = 4;
            this.lblOutFilePrefix.Text = "Output File Name Prefix";
            // 
            // txtErrorOutputFolder
            // 
            this.txtErrorOutputFolder.BackColor = System.Drawing.Color.Beige;
            this.txtErrorOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtErrorOutputFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorOutputFolder.Location = new System.Drawing.Point(227, 208);
            this.txtErrorOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtErrorOutputFolder.Multiline = true;
            this.txtErrorOutputFolder.Name = "txtErrorOutputFolder";
            this.txtErrorOutputFolder.Size = new System.Drawing.Size(457, 41);
            this.txtErrorOutputFolder.TabIndex = 7;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.AutoSize = true;
            this.lblErrorOutput.Location = new System.Drawing.Point(28, 214);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(160, 18);
            this.lblErrorOutput.TabIndex = 6;
            this.lblErrorOutput.Text = "Error Outpur Folder";
            // 
            // txtResultOutputFolder
            // 
            this.txtResultOutputFolder.BackColor = System.Drawing.Color.Beige;
            this.txtResultOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResultOutputFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultOutputFolder.Location = new System.Drawing.Point(227, 268);
            this.txtResultOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtResultOutputFolder.Multiline = true;
            this.txtResultOutputFolder.Name = "txtResultOutputFolder";
            this.txtResultOutputFolder.Size = new System.Drawing.Size(457, 41);
            this.txtResultOutputFolder.TabIndex = 9;
            // 
            // lblResultOutput
            // 
            this.lblResultOutput.AutoSize = true;
            this.lblResultOutput.Location = new System.Drawing.Point(28, 272);
            this.lblResultOutput.Name = "lblResultOutput";
            this.lblResultOutput.Size = new System.Drawing.Size(168, 18);
            this.lblResultOutput.TabIndex = 8;
            this.lblResultOutput.Text = "Result Output Folder";
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(538, 317);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(144, 34);
            this.btnProcess.TabIndex = 10;
            this.btnProcess.Text = "Start Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(690, 48);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(76, 30);
            this.btnBrowse.TabIndex = 11;
            this.btnBrowse.Tag = "configFilePath";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(690, 104);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 30);
            this.button1.TabIndex = 12;
            this.button1.Tag = "clientDataFilePath";
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(693, 218);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(76, 30);
            this.btnBrowseFolder.TabIndex = 13;
            this.btnBrowseFolder.Tag = "errorOutputFolder";
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(690, 278);
            this.button3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 30);
            this.button3.TabIndex = 14;
            this.button3.Tag = "resultOutputFolder";
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.Color.Beige;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(46, 367);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(725, 232);
            this.txtResult.TabIndex = 15;
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 616);
            this.Controls.Add(this.txtResult);
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
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Transaction";
            this.Text = "Transaction Utility";
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
        private System.Windows.Forms.TextBox txtResult;
    }
}