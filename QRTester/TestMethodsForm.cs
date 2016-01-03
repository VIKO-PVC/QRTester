using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Service;

namespace QRTester
{
    public partial class TestMethodsForm : Form
    {
        public delegate void RefreshMainFormDelegate();
        public RefreshMainFormDelegate RefreshMainFormHandler { get; set; }


        public TestMethodsForm()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            tbxRotateAngle.Text = 0.ToString();
        }

        private void btnSabotageOk_Click(object sender, EventArgs e)
        {
            var checkStatus = CheckImageStatus.NotCheckYet;
            var image = ImageService.Settings.CurrentImage;

            Stack<ImageOperation> operations = new Stack<ImageOperation>();
            
            if (cbxRotate.Checked)
            {
                operations.Push(new RotateOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    RotateAngle = Int32.Parse(tbxRotateAngle.Text)
                });
            }

            if (cbxCorner.Checked)
            {
                operations.Push(new CornerOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    TopPositionPercent = Int32.Parse(tbxTopCornerPosition.Text),
                    SidePositionPercent = Int32.Parse(tbxCornerSidePosition.Text)
                });
            }

            if (cbxMarker.Checked)
            {
                operations.Push(new MarkerOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    TopPositionPercent = Int32.Parse(tbxTopMarkerPosition.Text),
                    BottomPositionPercent = Int32.Parse(tbxBottomMarkerPosition.Text)
                });
            }

            var operation = operations.Pop();
            var currentOperation = operation;

            while (operations.Count > 0)
            {
                currentOperation.InnerOperation = operations.Pop();
                currentOperation = operation.InnerOperation;
            }

            ImageService.PendingImageOperations.Push(operation);

            Close();

            ImageService.ExecuteTopmostImageOperation();
            RefreshMainFormHandler();
        }

        private void btnSabotageCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbxRotateAngle_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!Int32.TryParse(tbxRotateAngle.Text, out parsedNumber) || parsedNumber > 360 || parsedNumber < 0)
            {
                tbxRotateAngle.Text = 0.ToString();
            }
        }

        private void tbxTopMarkerPosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!Int32.TryParse(tbxTopMarkerPosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0)
            {
                tbxTopMarkerPosition.Text = 0.ToString();
            }
        }

        private void tbxBottomMarkerPosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!Int32.TryParse(tbxBottomMarkerPosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0)
            {
                tbxBottomMarkerPosition.Text = 0.ToString();
            }
        }

        private void tbxTopCornerPosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!Int32.TryParse(tbxTopCornerPosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0)
            {
                tbxTopCornerPosition.Text = 0.ToString();
            }
        }

        private void tbxCornerSidePosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!Int32.TryParse(tbxCornerSidePosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0)
            {
                tbxCornerSidePosition.Text = 0.ToString();
            }

        }
    }
}
