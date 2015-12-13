using System;
using System.Collections.Generic;
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
            ImageService.PendingImageOperations = new Stack<ImageOperation>();
            ImageService.ExecutedImageOperations = new Stack<ImageOperation>();
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

                    if (/*ImageService.CheckImage(image) == CheckImageStatus.QrRecognitionSuccessful*/ true)
                    {
                        ImageService.Settings.UploadedImage = image;
                        ImageService.Settings.CurrentImage = image;

                        RefreshForm();
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
                }
            }
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            testMethodsForm.MultipleChoises = true;
            testMethodsForm.Initialize();
            testMethodsForm.ShowDialog();
        }

        private void btnSabotage_Click(object sender, EventArgs e)
        {
            testMethodsForm.MultipleChoises = false;
            testMethodsForm.Initialize();
            testMethodsForm.ShowDialog();
        }

        private void btnTryDecode_Click(object sender, EventArgs e)
        {
            ImageService.ExecuteTopmostImageOperation();
            RefreshForm();
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

        private void RefreshForm()
        {
            pbxQrImage.Image = ImageService.Settings.CurrentImage.Picture;

            Refresh();
        }
    }
}
