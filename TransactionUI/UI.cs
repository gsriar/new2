using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TransactionUI
{
    public partial class UI : Form
    {
        string configFilePath = "configFilePath";
        string clientDataFilePath = "clientDataFilePath";
        string errorOutputFolder = "errorOutputFolder";
        string resultOutputFolder = "resultOutputFolder";


        public UI()
        {
            InitializeComponent();
        }

        private void btnBrowseFile_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseFolder_Click(object sender, EventArgs e)
        {

        }
    }
}
