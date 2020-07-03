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
    public partial class Test : Form
    {
        int count = 0;

        public Test()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            OutAttrubute outputAttribute;
            InputParameter inputParam = new InputParameter()
            {
                InputExcelFilePath = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Data.xlsx",
                
                ConfigExcelFilePath = @"C:\Gurbhej\EXL\FinalCodeBase\TransactionUtility\Excel\Mapping.xlsx",
                OutputFileName = "Result.xlsx",
                CompletedFolder = @"C:\backup\TransactionUtilityTest\Completed",
                ErrorFolder = @"C:\backup\TransactionUtilityTest\Error",
                LogFolder= @"C:\backup\TransactionUtilityTest\Log"
            };

            using (CalculationEngine engine = new CalculationEngine(inputParam, WriteLog))
            {
                engine.Evaluate(out outputAttribute);
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
