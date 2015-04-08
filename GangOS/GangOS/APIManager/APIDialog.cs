using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GangOS.Common;

namespace GangOS.APIManager
{
    public partial class APIDialog : Form
    {
        public APIDialog()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            var code = textBox1.Text;

            if (code.Length != 64)
            {
                MessageBox.Show("Error: Invalid API Auth Code, please try again.", "Invalid Code", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            GangOSClient.AddPlayer(code);

            DialogResult = DialogResult.OK;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.gangsofspace.com/en/account/tokens");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
