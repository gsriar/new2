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
        public Test()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            InputParameter ip = new InputParameter();
            CalculationEngine engine = new CalculationEngine(ip, WriteLog);
            engine.Evaluate();
        }

        private void WriteLog(string logText)
        {
            txtResult.Text = txtResult.Text + Environment.NewLine + logText;
        }
    }
}
