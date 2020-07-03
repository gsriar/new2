using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        public Transaction()
        {
            InitializeComponent();
            txtClientDataFilePath.Text = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Data.xlsx";
            txtConfigFilePath.Text = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Mapping.xlsx";
            txtOutputFileNameSuffix.Text = "-source-measures.csv";
            txtCompletedOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Completed";
            txtErrorOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Error";
            txtLogOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Log";
        }
        private void btnBrowseFile_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {

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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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
    }
}
