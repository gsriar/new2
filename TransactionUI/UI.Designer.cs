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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageMain = new System.Windows.Forms.TabPage();
            this.linkCSV = new System.Windows.Forms.LinkLabel();
            this.linkLog = new System.Windows.Forms.LinkLabel();
            this.button2 = new System.Windows.Forms.Button();
            this.txtLogOutputFolder = new System.Windows.Forms.TextBox();
            this.lblLog = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtCompletedOutputFolder = new System.Windows.Forms.TextBox();
            this.lblResultOutput = new System.Windows.Forms.Label();
            this.txtErrorOutputFolder = new System.Windows.Forms.TextBox();
            this.lblErrorOutput = new System.Windows.Forms.Label();
            this.txtOutputFileNameSuffix = new System.Windows.Forms.TextBox();
            this.lblOutFilePrefix = new System.Windows.Forms.Label();
            this.txtClientDataFilePath = new System.Windows.Forms.TextBox();
            this.lblClientDataFile = new System.Windows.Forms.Label();
            this.txtConfigFilePath = new System.Windows.Forms.TextBox();
            this.lblConfigPath = new System.Windows.Forms.Label();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.txtClientFile = new System.Windows.Forms.TextBox();
            this.btnBrowseClientFile = new System.Windows.Forms.Button();
            this.btnGetClientFileConfig = new System.Windows.Forms.Button();
            this.tabMain.SuspendLayout();
            this.tabPageMain.SuspendLayout();
            this.tabPageTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageMain);
            this.tabMain.Controls.Add(this.tabPageTest);
            this.tabMain.Location = new System.Drawing.Point(3, 1);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(784, 592);
            this.tabMain.TabIndex = 0;
            // 
            // tabPageMain
            // 
            this.tabPageMain.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageMain.Controls.Add(this.linkCSV);
            this.tabPageMain.Controls.Add(this.linkLog);
            this.tabPageMain.Controls.Add(this.button2);
            this.tabPageMain.Controls.Add(this.txtLogOutputFolder);
            this.tabPageMain.Controls.Add(this.lblLog);
            this.tabPageMain.Controls.Add(this.txtResult);
            this.tabPageMain.Controls.Add(this.button3);
            this.tabPageMain.Controls.Add(this.btnBrowseFolder);
            this.tabPageMain.Controls.Add(this.button1);
            this.tabPageMain.Controls.Add(this.btnBrowse);
            this.tabPageMain.Controls.Add(this.btnProcess);
            this.tabPageMain.Controls.Add(this.txtCompletedOutputFolder);
            this.tabPageMain.Controls.Add(this.lblResultOutput);
            this.tabPageMain.Controls.Add(this.txtErrorOutputFolder);
            this.tabPageMain.Controls.Add(this.lblErrorOutput);
            this.tabPageMain.Controls.Add(this.txtOutputFileNameSuffix);
            this.tabPageMain.Controls.Add(this.lblOutFilePrefix);
            this.tabPageMain.Controls.Add(this.txtClientDataFilePath);
            this.tabPageMain.Controls.Add(this.lblClientDataFile);
            this.tabPageMain.Controls.Add(this.txtConfigFilePath);
            this.tabPageMain.Controls.Add(this.lblConfigPath);
            this.tabPageMain.Location = new System.Drawing.Point(4, 23);
            this.tabPageMain.Name = "tabPageMain";
            this.tabPageMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMain.Size = new System.Drawing.Size(776, 565);
            this.tabPageMain.TabIndex = 0;
            this.tabPageMain.Text = "Main";
            // 
            // linkCSV
            // 
            this.linkCSV.AutoSize = true;
            this.linkCSV.Location = new System.Drawing.Point(260, 255);
            this.linkCSV.Name = "linkCSV";
            this.linkCSV.Size = new System.Drawing.Size(147, 14);
            this.linkCSV.TabIndex = 36;
            this.linkCSV.TabStop = true;
            this.linkCSV.Text = "Open Last CSV Output";
            this.linkCSV.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkCSV_LinkClicked);
            // 
            // linkLog
            // 
            this.linkLog.AutoSize = true;
            this.linkLog.Location = new System.Drawing.Point(104, 255);
            this.linkLog.Name = "linkLog";
            this.linkLog.Size = new System.Drawing.Size(133, 14);
            this.linkLog.TabIndex = 35;
            this.linkLog.TabStop = true;
            this.linkLog.Text = "Open Last Log File";
            this.linkLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLog_LinkClicked);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(679, 196);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 26);
            this.button2.TabIndex = 34;
            this.button2.Tag = "logOutputFolder";
            this.button2.Text = "Browse";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // txtLogOutputFolder
            // 
            this.txtLogOutputFolder.BackColor = System.Drawing.Color.Beige;
            this.txtLogOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLogOutputFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogOutputFolder.Location = new System.Drawing.Point(216, 198);
            this.txtLogOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogOutputFolder.Name = "txtLogOutputFolder";
            this.txtLogOutputFolder.Size = new System.Drawing.Size(457, 22);
            this.txtLogOutputFolder.TabIndex = 33;
            // 
            // lblLog
            // 
            this.lblLog.AutoSize = true;
            this.lblLog.Location = new System.Drawing.Point(17, 202);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(126, 14);
            this.lblLog.TabIndex = 32;
            this.lblLog.Text = "Log Output Folder";
            // 
            // txtResult
            // 
            this.txtResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResult.BackColor = System.Drawing.Color.Beige;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResult.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.HideSelection = false;
            this.txtResult.Location = new System.Drawing.Point(15, 275);
            this.txtResult.Margin = new System.Windows.Forms.Padding(4);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResult.Size = new System.Drawing.Size(740, 282);
            this.txtResult.TabIndex = 31;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(679, 161);
            this.button3.Margin = new System.Windows.Forms.Padding(1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(76, 26);
            this.button3.TabIndex = 30;
            this.button3.Tag = "resultOutputFolder";
            this.button3.Text = "Browse";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseFolder.Location = new System.Drawing.Point(679, 129);
            this.btnBrowseFolder.Margin = new System.Windows.Forms.Padding(1);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(76, 22);
            this.btnBrowseFolder.TabIndex = 29;
            this.btnBrowseFolder.Tag = "errorOutputFolder";
            this.btnBrowseFolder.Text = "Browse";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(679, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 22);
            this.button1.TabIndex = 28;
            this.button1.Tag = "clientDataFilePath";
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowse.Location = new System.Drawing.Point(679, 13);
            this.btnBrowse.Margin = new System.Windows.Forms.Padding(1);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(76, 22);
            this.btnBrowse.TabIndex = 27;
            this.btnBrowse.Tag = "configFilePath";
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.Location = new System.Drawing.Point(529, 235);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(144, 34);
            this.btnProcess.TabIndex = 26;
            this.btnProcess.Text = "Start Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtCompletedOutputFolder
            // 
            this.txtCompletedOutputFolder.BackColor = System.Drawing.Color.Beige;
            this.txtCompletedOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCompletedOutputFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompletedOutputFolder.Location = new System.Drawing.Point(216, 163);
            this.txtCompletedOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCompletedOutputFolder.Name = "txtCompletedOutputFolder";
            this.txtCompletedOutputFolder.Size = new System.Drawing.Size(457, 22);
            this.txtCompletedOutputFolder.TabIndex = 25;
            // 
            // lblResultOutput
            // 
            this.lblResultOutput.AutoSize = true;
            this.lblResultOutput.Location = new System.Drawing.Point(17, 167);
            this.lblResultOutput.Name = "lblResultOutput";
            this.lblResultOutput.Size = new System.Drawing.Size(147, 14);
            this.lblResultOutput.TabIndex = 24;
            this.lblResultOutput.Text = "Result Output Folder";
            // 
            // txtErrorOutputFolder
            // 
            this.txtErrorOutputFolder.BackColor = System.Drawing.Color.Beige;
            this.txtErrorOutputFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtErrorOutputFolder.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtErrorOutputFolder.Location = new System.Drawing.Point(216, 129);
            this.txtErrorOutputFolder.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtErrorOutputFolder.Name = "txtErrorOutputFolder";
            this.txtErrorOutputFolder.Size = new System.Drawing.Size(457, 22);
            this.txtErrorOutputFolder.TabIndex = 23;
            // 
            // lblErrorOutput
            // 
            this.lblErrorOutput.AutoSize = true;
            this.lblErrorOutput.Location = new System.Drawing.Point(17, 135);
            this.lblErrorOutput.Name = "lblErrorOutput";
            this.lblErrorOutput.Size = new System.Drawing.Size(140, 14);
            this.lblErrorOutput.TabIndex = 22;
            this.lblErrorOutput.Text = "Error Outpur Folder";
            // 
            // txtOutputFileNameSuffix
            // 
            this.txtOutputFileNameSuffix.BackColor = System.Drawing.Color.Beige;
            this.txtOutputFileNameSuffix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutputFileNameSuffix.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutputFileNameSuffix.Location = new System.Drawing.Point(216, 96);
            this.txtOutputFileNameSuffix.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOutputFileNameSuffix.Name = "txtOutputFileNameSuffix";
            this.txtOutputFileNameSuffix.Size = new System.Drawing.Size(457, 22);
            this.txtOutputFileNameSuffix.TabIndex = 21;
            // 
            // lblOutFilePrefix
            // 
            this.lblOutFilePrefix.AutoSize = true;
            this.lblOutFilePrefix.Location = new System.Drawing.Point(17, 102);
            this.lblOutFilePrefix.Name = "lblOutFilePrefix";
            this.lblOutFilePrefix.Size = new System.Drawing.Size(168, 14);
            this.lblOutFilePrefix.TabIndex = 20;
            this.lblOutFilePrefix.Text = "Output File Name Suffix";
            // 
            // txtClientDataFilePath
            // 
            this.txtClientDataFilePath.BackColor = System.Drawing.Color.Beige;
            this.txtClientDataFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtClientDataFilePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClientDataFilePath.Location = new System.Drawing.Point(216, 51);
            this.txtClientDataFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtClientDataFilePath.Multiline = true;
            this.txtClientDataFilePath.Name = "txtClientDataFilePath";
            this.txtClientDataFilePath.Size = new System.Drawing.Size(457, 33);
            this.txtClientDataFilePath.TabIndex = 19;
            // 
            // lblClientDataFile
            // 
            this.lblClientDataFile.AutoSize = true;
            this.lblClientDataFile.Location = new System.Drawing.Point(17, 57);
            this.lblClientDataFile.Name = "lblClientDataFile";
            this.lblClientDataFile.Size = new System.Drawing.Size(154, 14);
            this.lblClientDataFile.TabIndex = 18;
            this.lblClientDataFile.Text = "Client Data File Path";
            // 
            // txtConfigFilePath
            // 
            this.txtConfigFilePath.BackColor = System.Drawing.Color.Beige;
            this.txtConfigFilePath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfigFilePath.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfigFilePath.Location = new System.Drawing.Point(216, 8);
            this.txtConfigFilePath.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtConfigFilePath.Multiline = true;
            this.txtConfigFilePath.Name = "txtConfigFilePath";
            this.txtConfigFilePath.Size = new System.Drawing.Size(457, 33);
            this.txtConfigFilePath.TabIndex = 17;
            // 
            // lblConfigPath
            // 
            this.lblConfigPath.AutoSize = true;
            this.lblConfigPath.Location = new System.Drawing.Point(17, 14);
            this.lblConfigPath.Name = "lblConfigPath";
            this.lblConfigPath.Size = new System.Drawing.Size(168, 14);
            this.lblConfigPath.TabIndex = 16;
            this.lblConfigPath.Text = "Configuration File Path";
            // 
            // tabPageTest
            // 
            this.tabPageTest.BackColor = System.Drawing.Color.LightGray;
            this.tabPageTest.Controls.Add(this.btnGetClientFileConfig);
            this.tabPageTest.Controls.Add(this.btnBrowseClientFile);
            this.tabPageTest.Controls.Add(this.txtClientFile);
            this.tabPageTest.Location = new System.Drawing.Point(4, 23);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(776, 565);
            this.tabPageTest.TabIndex = 1;
            this.tabPageTest.Text = "Test";
            // 
            // txtClientFile
            // 
            this.txtClientFile.Location = new System.Drawing.Point(21, 25);
            this.txtClientFile.Multiline = true;
            this.txtClientFile.Name = "txtClientFile";
            this.txtClientFile.Size = new System.Drawing.Size(659, 39);
            this.txtClientFile.TabIndex = 0;
            // 
            // btnBrowseClientFile
            // 
            this.btnBrowseClientFile.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseClientFile.Location = new System.Drawing.Point(684, 42);
            this.btnBrowseClientFile.Margin = new System.Windows.Forms.Padding(1);
            this.btnBrowseClientFile.Name = "btnBrowseClientFile";
            this.btnBrowseClientFile.Size = new System.Drawing.Size(76, 22);
            this.btnBrowseClientFile.TabIndex = 28;
            this.btnBrowseClientFile.Tag = "rawClientDataFile";
            this.btnBrowseClientFile.Text = "Browse";
            this.btnBrowseClientFile.UseVisualStyleBackColor = true;
            this.btnBrowseClientFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // btnGetClientFileConfig
            // 
            this.btnGetClientFileConfig.Location = new System.Drawing.Point(21, 115);
            this.btnGetClientFileConfig.Name = "btnGetClientFileConfig";
            this.btnGetClientFileConfig.Size = new System.Drawing.Size(75, 23);
            this.btnGetClientFileConfig.TabIndex = 29;
            this.btnGetClientFileConfig.Text = "Get";
            this.btnGetClientFileConfig.UseVisualStyleBackColor = true;
            this.btnGetClientFileConfig.Click += new System.EventHandler(this.btnGetClientFileConfig_Click);
            // 
            // Transaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 616);
            this.Controls.Add(this.tabMain);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Transaction";
            this.Text = "Open Last CSV Output";
            this.tabMain.ResumeLayout(false);
            this.tabPageMain.ResumeLayout(false);
            this.tabPageMain.PerformLayout();
            this.tabPageTest.ResumeLayout(false);
            this.tabPageTest.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageMain;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtCompletedOutputFolder;
        private System.Windows.Forms.Label lblResultOutput;
        private System.Windows.Forms.TextBox txtErrorOutputFolder;
        private System.Windows.Forms.Label lblErrorOutput;
        private System.Windows.Forms.TextBox txtOutputFileNameSuffix;
        private System.Windows.Forms.Label lblOutFilePrefix;
        private System.Windows.Forms.TextBox txtClientDataFilePath;
        private System.Windows.Forms.Label lblClientDataFile;
        private System.Windows.Forms.TextBox txtConfigFilePath;
        private System.Windows.Forms.Label lblConfigPath;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtLogOutputFolder;
        private System.Windows.Forms.Label lblLog;
        private System.Windows.Forms.LinkLabel linkLog;
        private System.Windows.Forms.LinkLabel linkCSV;
        private System.Windows.Forms.Button btnBrowseClientFile;
        private System.Windows.Forms.TextBox txtClientFile;
        private System.Windows.Forms.Button btnGetClientFileConfig;
    }
}