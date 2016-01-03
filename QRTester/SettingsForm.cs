using System;
using System.Linq;
using System.Windows.Forms;
using QRTester.Properties;
using Service;

namespace QRTester
{
    public partial class SettingsForm : Form
    {
        private HelpForm helpForm;

        public SettingsForm()
        {
            InitializeComponent();

            tbxSuccessfulResponseFragment.Text = ImageService.Settings.SuccessHtmlFragment;
            tbxUploadUrl.Text = ImageService.Settings.ImageUploadUrl;
            cbxCheckQrCode.Checked = ImageService.Settings.EnableQrReader;
            ddlRequestType.Text = ImageService.Settings.RequestType;

            helpForm = new HelpForm();
        }

        private void btnSettingsOk_Click(object sender, EventArgs e)
        {
            ImageService.Settings.ImageUploadUrl = tbxUploadUrl.Text;
            ImageService.Settings.RequestType = ddlRequestType.Text;
            ImageService.Settings.SuccessHtmlFragment = tbxSuccessfulResponseFragment.Text;
            ImageService.Settings.EnableQrReader = cbxCheckQrCode.Checked;

            Close();
        }

        private void btnSettingsCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSettingsHelp_Click(object sender, EventArgs e)
        {
            helpForm.Initialize(Resources.SettignsHelp);
        }
    }
}
