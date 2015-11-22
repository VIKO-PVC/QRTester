using System;
using System.Windows.Forms;

namespace QRTester
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void btnSettingsOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
