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
        string configFilePath = "configFilePath";
        string clientDataFilePath = "clientDataFilePath";
        string errorOutputFolder = "errorOutputFolder";
        string resultOutputFolder = "resultOutputFolder";


        public Transaction()
        {
            InitializeComponent();


            txtClientDataFilePath.Text = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Data.xlsx";
            txtConfigFilePath.Text = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Mapping.xlsx";
            txtOutputFileNamePrefix.Text = "Result.xlsx";
            txtResultOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Completed";
            txtErrorOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Error";
            txtErrorOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Log";

        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            InputParameter inputParam = new InputParameter()
            {
                /*   txtClientDataFilePath.Text = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Data.xlsx";
            txtConfigFilePath.Text = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Mapping.xlsx";
            txtResult.Text = "Result.xlsx";
            txtResultOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Completed";
            txtErrorOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Error";
            txtErrorOutputFolder.Text = @"C:\backup\TransactionUtilityTest\Log";*/
                InputExcelFilePath = txtClientDataFilePath.Text,

                ConfigExcelFilePath = txtConfigFilePath.Text,
                OutputFileName = txtResult.Text,
                OuptputFolder = txtResultOutputFolder.Text,
                ErrorFolder = txtErrorOutputFolder.Text ,
                LogFolder = txtErrorOutputFolder.Text
            };

            using (CalculationEngine engine = new CalculationEngine(inputParam, WriteLog))
            {
                engine.Evaluate();
            }
        }

        private void WriteLog(string logText)
        {
            txtResult.Text = txtResult.Text + logText + Environment.NewLine;
            txtResult.SelectionStart = txtResult.TextLength;
            txtResult.ScrollToCaret();
        }
    }
}
