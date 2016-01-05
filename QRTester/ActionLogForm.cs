using System;
using System.Windows.Forms;
using Model;

namespace QRTester
{
    public partial class ActionLogForm : Form
    {
        public ActionLogForm()
        {
            InitializeComponent();
        }

        public void Initialize(Image image, string message)
        {
            if (image != null)
            {
                pbcActionLogImage.Image = image.Picture;
                lblDecryptedValue.Text = image.EncodedValue;
            }
            else
            {
                lblDecryptedValue.Text = String.Empty;
                pbcActionLogImage.Image = pbcActionLogImage.InitialImage;
            }

            lblActionLogMessage.Text = message;
            Refresh();
            ShowDialog();
        }

        private void btnActionLogOk_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
