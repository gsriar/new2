using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TransactionUtility;

namespace TransactionUI
{
    public partial class Transaction : Form
    {
        private string logFile;
        private string csvFile;
       static string bp = @"C:\Gurbhej\TransactionUtilityTest";

        public Transaction()
        {
            InitializeComponent();
            txtClientDataFilePath.Text = @"..\..\..\TransactionUtility\Excel\Data.xlsx";
            txtConfigFilePath.Text = @"..\..\..\TransactionUtility\Excel\Mapping.xlsx";
            txtOutputFileNameSuffix.Text = "-source-measures.csv";


            txtCompletedOutputFolder.Text = $@"{bp}\Completed";
            txtErrorOutputFolder.Text = $@"{bp}\Error";
            txtLogOutputFolder.Text = $@"{bp}\Log";
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            OutAttrubute outputAttribute;
            InputParameter inputParam = new InputParameter()
            {
                InputExcelFilePath = txtClientDataFilePath.Text,
                ConfigExcelFilePath = txtConfigFilePath.Text,
                OutputFileName = txtOutputFileNameSuffix.Text,
                CompletedFolder = txtCompletedOutputFolder.Text,
                ErrorFolder = txtErrorOutputFolder.Text,
                LogFolder = txtLogOutputFolder.Text
            };

            using (CalculationEngine engine = new CalculationEngine(inputParam, WriteLog))
            {
                engine.Evaluate(out outputAttribute);

                logFile = outputAttribute.GetAttrib("log");
                csvFile = outputAttribute.GetAttrib("csv");
            }
        }

        private void WriteLog(string logText)
        {
            txtResult.Text = txtResult.Text + logText + Environment.NewLine;
            txtResult.SelectionStart = txtResult.TextLength;
            txtResult.ScrollToCaret();
        }

        private void linkLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Open(logFile);
        }

        void Open(string fileName)
        {
            if (!string.IsNullOrEmpty(fileName))
                System.Diagnostics.Process.Start(fileName);
        }
        private void linkCSV_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Open(csvFile);
        }

        OpenFileDialog openFileDialog1 = new OpenFileDialog
        {
            InitialDirectory = bp,
            Title = "Browse XLSX Files",

            CheckFileExists = true,
            CheckPathExists = true,

            DefaultExt = "txt",
            Filter = "excel files (*.xlsx)|*.xlsx",
            FilterIndex = 2,
            RestoreDirectory = true,

            ReadOnlyChecked = true,
            ShowReadOnly = true
        };

        FolderBrowserDialog folderDlg = new FolderBrowserDialog()
        {
            ShowNewFolderButton = true,
            RootFolder = Environment.SpecialFolder.Desktop,
            SelectedPath = bp

        };
        private string outSchemaFile;

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {
            TextBox tb = getTB((sender as Button).Tag.ToString());
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                tb.Text = openFileDialog1.FileName;
            }
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {
            TextBox tb = getTB((sender as Button).Tag.ToString());

            DialogResult result = folderDlg.ShowDialog();
            if (result == DialogResult.OK)
            {
                tb.Text = folderDlg.SelectedPath;
                Environment.SpecialFolder root = folderDlg.RootFolder;
            }
        }


        const string errorOutputFolder = "errorOutputFolder";
        const string resultOutputFolder = "resultOutputFolder";
        const string logOutputFolder = "logOutputFolder";
        const string configFilePath = "configFilePath";
        const string clientDataFilePath = "clientDataFilePath";
        const string rawClientDataFile = "rawClientDataFile";

        private TextBox getTB(string tag)
        {
            TextBox result = null;
            switch (tag)
            {
                case errorOutputFolder:
                    result = txtErrorOutputFolder;
                    break;
                case resultOutputFolder:
                    result = txtCompletedOutputFolder;
                    break;
                case logOutputFolder:
                    result = txtLogOutputFolder;
                    break;
                case configFilePath:
                    result = txtConfigFilePath;
                    break;
                case clientDataFilePath:
                    result = txtClientDataFilePath;
                    break;
                case rawClientDataFile:
                    result = txtClientFile;
                    break;

            }
            return result;
        }

        private void btnGetClientFileConfig_Click(object sender, EventArgs e)
        {
            DataHelper h = new DataHelper();
            try
            {
                lblStatus.Text = "";
                linkSchema.Visible = false;
                FileInfo fi = new FileInfo(txtClientFile.Text);
                var str = h.getClientConfigData(fi.FullName);
                outSchemaFile = fi.FullName + ".schema.xlsx";
                File.WriteAllText(outSchemaFile, str);
                lblStatus.Text = $"Done.. [{outSchemaFile}]";

                linkSchema.Visible = true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lblSchema_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Open(outSchemaFile); 
        }
    }
}
