using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Model;
using Service;

namespace QRTester
{
    public partial class MainForm : Form
    {
        private static TestMethodsForm testMethodsForm;
        private static SettingsForm settingsForm;
        private static ActionLogForm actionLogForm;

        public MainForm()
        {
            InitializeComponent();

            ImageService.Settings = new Settings();
            ImageService.PendingImageOperations = new Stack<ImageOperation>();
            ImageService.ExecutedImageOperations = new Stack<ImageOperation>();
            ImageService.ActionLog = new List<ActionLogEntry>();
            ofdUploadImage.Filter = "Portable Network Graphics (*.png)|*.png";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            testMethodsForm = new TestMethodsForm();
            testMethodsForm.RefreshMainFormHandler += ProcessCurrentImage;
            testMethodsForm.RefreshMainFormHandler += HideActionButtons;

            settingsForm = new SettingsForm();
            actionLogForm = new ActionLogForm();
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

                    if (ImageService.CheckImage(image) == CheckImageStatus.QrRecognitionSuccessful)
                    {
                        ImageService.Settings.UploadedImage = image;
                        ImageService.Settings.CurrentImage = image;
                        ImageService.ExecutedImageOperations.Clear();
                        
                        RefreshForm();
                        ShowActionButtons();
                        btnRevertSabotage.Show();
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
            ImageService.SetUpTestPacket();

            pgbImageOperations.Value = 0;
            pgbImageOperations.Maximum = ImageService.PendingImageOperations.Count;
            pgbImageOperations.Step = 1;

            while (ImageService.PendingImageOperations.Any())
            {
                ImageService.ExecuteTopmostImageOperation();
                ProcessCurrentImage();
                pgbImageOperations.Value++;
                Thread.Sleep(6000);
            }
        }

        private void btnSabotage_Click(object sender, EventArgs e)
        {
            testMethodsForm.Initialize();
            testMethodsForm.ShowDialog();
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
            RefreshActionLog();
            Refresh();
        }

        private void ProcessCurrentImage()
        {
            var lastExecutedOperation = ImageService.ExecutedImageOperations.Peek();
            lastExecutedOperation.CheckStatus = ImageService.CheckImage(ImageService.Settings.CurrentImage);
            ImageService.LogLastOperation();
            RefreshForm();
        }

        private void btnRevertSabotage_Click(object sender, EventArgs e)
        {
            ImageService.Settings.CurrentImage = ImageService.Settings.UploadedImage;

            RefreshForm();
            ShowActionButtons();
            pgbImageOperations.Value = 0;
        }

        private void HideActionButtons()
        {
            btnSabotage.Hide();
            btnRunTest.Hide();
        }

        private void ShowActionButtons()
        {
            btnSabotage.Show();
            btnRunTest.Show();
        }

        private void RefreshActionLog()
        {
            var actionLogMessageIds = lsbActionLog.Items.Cast<ListViewItem>().Select(item => item.Name);
            var missingOperations = ImageService.ActionLog.Where(item => !actionLogMessageIds.Contains(item.Id.ToString()));
            var missingOperationListItems = missingOperations.Select(item => new ListViewItem() {Name = item.Id.ToString(), Text = item.Description});
            lsbActionLog.Items.AddRange(missingOperationListItems.ToArray());
        }

        private void lsbActionLog_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = lsbActionLog.SelectedItem;
            var actionLogEntry = ImageService.ActionLog.Single(item => ((ListViewItem)selectedItem).Name == item.Id.ToString());
            actionLogForm.Initialize(actionLogEntry.Image.Picture, actionLogEntry.Description);
        }
    }
}
