using System;
using System.Windows.Forms;

namespace QRTester
{
    public partial class MainForm : Form
    {
        private static TestMethodsForm testMethodsForm;
        private static SettingsForm settingsForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            testMethodsForm = new TestMethodsForm();
            settingsForm = new SettingsForm();
        }

        private void btnUploadQr_Click(object sender, EventArgs e)
        {
            btnSabotage.Show();
            btnTryDecode.Show();
            btnRunTest.Show();
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {

            testMethodsForm.ShowDialog();
        }

        private void btnSabotage_Click(object sender, EventArgs e)
        {
            testMethodsForm.ShowDialog();
        }

        private void btnTryDecode_Click(object sender, EventArgs e)
        {
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            settingsForm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
