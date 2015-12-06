using System;
using System.IO;
using System.Windows.Forms;
using Model;
using Service;

namespace QRTester
{
    public partial class MainForm : Form
    {
        private static TestMethodsForm testMethodsForm;
        private static SettingsForm settingsForm;

        public MainForm()
        {
            InitializeComponent();

            ImageService.Settings = new Settings();
            ofdUploadImage.Filter = "Portable Network Graphics (*.png)|*.png";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            testMethodsForm = new TestMethodsForm();
            settingsForm = new SettingsForm();
        }

        private void btnUploadQr_Click(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/cc221415%28v=vs.95%29.aspx
            if (ofdUploadImage.ShowDialog() == DialogResult.OK)
            {
                Image image;
                try
                {
                    image = ImageService.GetPicture(ofdUploadImage.OpenFile());
                    if (ImageService.CheckImage(image) == CheckImageResult.QrRecognitionSuccessful)
                    {
                        Refresh(image);
                        btnSabotage.Show();
                        btnTryDecode.Show();
                        btnRunTest.Show();
                    }
                    else
                    {
                        DisplayError("Not recognised");
                    }
                }
                catch (Exception exception)
                {
                    DisplayError(exception.Message); //TODO: Innermost message
                    return;
                }
            }
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

        private void DisplayError(string message)
        {
            // TODO: Log in the console as an error
            MessageBox.Show(message);
        }

        private void Refresh(Image image)
        {
            pbxQrImage.Image = image.Picture;

            Refresh();
        }
    }
}
