using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Model;
using QRTester.Properties;
using Service;
using Settings = Model.Settings;

namespace QRTester
{
    public partial class MainForm : Form
    {
        private static TestMethodsForm testMethodsForm;
        private static SettingsForm settingsForm;
        private static ActionLogForm actionLogForm;
        private static HelpForm helpForm;

        public MainForm()
        {
            ImageService.Settings = new Settings();
            ImageService.PendingImageOperations = new Stack<ImageOperation>();
            ImageService.ExecutedImageOperations = new Stack<ImageOperation>();
            ImageService.ActionLog = new List<ActionLogEntry>();

            InitializeComponent();

            ofdUploadImage.Filter = "Paveiksliukai (*.png, *.jpg)|*.png;*.jpg";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            testMethodsForm = new TestMethodsForm();
            testMethodsForm.RefreshMainFormHandler += ProcessCurrentImage;
            testMethodsForm.RefreshMainFormHandler += HideActionButtons;

            settingsForm = new SettingsForm();
            actionLogForm = new ActionLogForm();
            helpForm = new HelpForm();
        }

        private void btnUploadQr_Click(object sender, EventArgs e)
        {
            // https://msdn.microsoft.com/en-us/library/cc221415%28v=vs.95%29.aspx
            if (ofdUploadImage.ShowDialog() == DialogResult.OK)
            {
                Image image = null;
                try
                {
                    image = ImageService.GetPicture(ofdUploadImage.OpenFile());

                    if (ImageService.Settings.EnableQrReader && ImageService.CheckImage(image) == CheckImageStatus.QrRecognitionSuccessful)
                    {
                        ImageService.Settings.UploadedImage = image;
                        ImageService.Settings.CurrentImage = image;
                        ImageService.ExecutedImageOperations.Clear();
                        
                        RefreshForm();
                        ShowActionButtons();
                        btnRevertSabotage.Show();

                        ImageService.ActionLog.Add(new ActionLogEntry()
                        {
                            Id = Guid.NewGuid(),
                            Description = "Sėkmingai įkeltas QR simbolis",
                            Image = image
                        });
                    }
                    else
                    {
                        ImageService.ActionLog.Add(new ActionLogEntry()
                        {
                            Id = Guid.NewGuid(),
                            Description = "Įkeltas paveiksliukas yra ne QR simbolis.",
                            Image = image
                        });
                    }
                }
                catch (Exception exception)
                {
                    ImageService.ActionLog.Add(new ActionLogEntry()
                    {
                        Id = Guid.NewGuid(),
                        Description = "Įkeliant paveiksliuką įvyko klaida: " + exception.Message,
                        Image = image
                    });
                }
            }

            RefreshActionLog();
        }

        private void btnRunTest_Click(object sender, EventArgs e)
        {
            ImageService.ActionLog.Add(new ActionLogEntry()
            {
                Id = Guid.NewGuid(),
                Description = "Pradėtas testų paketo vykdymas"
            });
            RefreshActionLog();

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

            ImageService.ActionLog.Add(new ActionLogEntry()
            {
                Id = Guid.NewGuid(),
                Description = "Testų paketo vykdymas baigtas"
            });
            RefreshActionLog();
        }

        private void btnSabotage_Click(object sender, EventArgs e)
        {
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

        private void RefreshForm()
        {
            pbxQrImage.Image = ImageService.Settings.CurrentImage.Picture;
            RefreshActionLog();
            Refresh();
        }

        private void ProcessCurrentImage()
        {
            var lastExecutedOperation = ImageService.ExecutedImageOperations.Peek();
            if (ImageService.Settings.EnableQrReader)
            {
                lastExecutedOperation.CheckStatus = ImageService.CheckImage(ImageService.Settings.CurrentImage);
            }

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
            var actionLogMessageIds = lsbActionLog.Items.Cast<ActionLogEntry>().Select(item => item.Id);
            var missingOperations = ImageService.ActionLog.Where(item => !actionLogMessageIds.Contains(item.Id));
            lsbActionLog.Items.AddRange(missingOperations.ToArray());
        }

        private void lsbActionLog_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = lsbActionLog.SelectedItem;
            var actionLogEntry = ImageService.ActionLog.Single(item => ((ActionLogEntry)selectedItem).Id == item.Id);
            actionLogForm.Initialize(actionLogEntry.Image.Picture, actionLogEntry.Description);
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            helpForm.Initialize(Resources.MainFormHelp);
        }
    }
}
