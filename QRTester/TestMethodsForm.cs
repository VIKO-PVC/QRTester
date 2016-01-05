using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model;
using QRTester.Properties;
using Service;

namespace QRTester
{
    public partial class TestMethodsForm : Form
    {
        private static HelpForm helpForm;

        public delegate void RefreshMainFormDelegate();
        public RefreshMainFormDelegate RefreshMainFormHandler { get; set; }


        public TestMethodsForm()
        {
            helpForm = new HelpForm();
            InitializeComponent();
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

            if (cbxBrightness.Checked)
            {
                operations.Push(new BrightnessOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    Intensity = trbBrightness.Value
                });
            }

            if (cbxBlur.Checked)
            {
                operations.Push(new BlurOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    Intensity = Int32.Parse(tbxBlurIntensity.Text)
                });
            }

            if (cbxNoise.Checked)
            {
                operations.Push(new NoiseOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    Intensity = Int32.Parse(tbxNoiseIntensity.Text)
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

            if (operations.Any())
            {
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
            else
            {
                MessageBox.Show("Pasirinkite bent vieną operaciją!");
            }
        }

        private void btnSabotageCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tbxRotateAngle_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxRotateAngle.Text) && (!Int32.TryParse(tbxRotateAngle.Text, out parsedNumber) || parsedNumber > 360 || parsedNumber < 0))
            {
                tbxRotateAngle.Text = tbxRotateAngle.Tag.ToString();
                if (String.IsNullOrEmpty(tbxRotateAngle.Text))
                {
                    cbxRotate.Checked = false;
                }
            }
            else
            {
                tbxRotateAngle.Tag = tbxRotateAngle.Text;
                tbxRotateAngle.SelectionStart = tbxRotateAngle.Text.Length;
                cbxRotate.Checked = true;
            }
        }

        private void tbxTopMarkerPosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxTopMarkerPosition.Text) && (!Int32.TryParse(tbxTopMarkerPosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0))
            {
                tbxTopMarkerPosition.Text = tbxTopMarkerPosition.Tag.ToString();

                if (String.IsNullOrEmpty(tbxTopMarkerPosition.Text))
                {
                    cbxMarker.Checked = false;
                }
            }
            else
            {
                tbxTopMarkerPosition.Tag = tbxTopMarkerPosition.Text;
                tbxTopMarkerPosition.SelectionStart = tbxTopMarkerPosition.Text.Length;

                if (!String.IsNullOrEmpty(tbxBottomMarkerPosition.Text))
                {
                    cbxMarker.Checked = true;
                }
            }
        }

        private void tbxBottomMarkerPosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxBottomMarkerPosition.Text) && (!Int32.TryParse(tbxBottomMarkerPosition.Text, out parsedNumber) || parsedNumber > 100 ||
                parsedNumber < 0))
            {
                tbxBottomMarkerPosition.Text = tbxBottomMarkerPosition.Tag.ToString();
                if (String.IsNullOrEmpty(tbxBottomMarkerPosition.Text))
                {
                    cbxMarker.Checked = false;
                }
            }
            else
            {
                tbxBottomMarkerPosition.Tag = tbxBottomMarkerPosition.Text;
                tbxBottomMarkerPosition.SelectionStart = tbxBottomMarkerPosition.Text.Length;

                if (!String.IsNullOrEmpty(tbxTopMarkerPosition.Text))
                {
                    cbxMarker.Checked = true;
                }
            }
        }

        private void tbxTopCornerPosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxTopCornerPosition.Text) && (!Int32.TryParse(tbxTopCornerPosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0))
            {
                tbxTopCornerPosition.Text = tbxTopCornerPosition.Tag.ToString();
                if (String.IsNullOrEmpty(tbxTopCornerPosition.Text))
                {
                    cbxCorner.Checked = false;
                }
            }
            else
            {
                tbxTopCornerPosition.Tag = tbxTopCornerPosition.Text;
                tbxTopCornerPosition.SelectionStart = tbxTopCornerPosition.Text.Length;

                if (!String.IsNullOrEmpty(tbxCornerSidePosition.Text))
                {
                    cbxCorner.Checked = true;
                }
            }
        }

        private void tbxCornerSidePosition_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxCornerSidePosition.Text) && (!Int32.TryParse(tbxCornerSidePosition.Text, out parsedNumber) || parsedNumber > 100 || parsedNumber < 0))
            {
                tbxCornerSidePosition.Text = tbxCornerSidePosition.Tag.ToString();
                if (String.IsNullOrEmpty(tbxCornerSidePosition.Text))
                {
                    cbxCorner.Checked = false;
                }
            }
            else
            {
                tbxCornerSidePosition.Tag = tbxCornerSidePosition.Text;
                tbxCornerSidePosition.SelectionStart = tbxCornerSidePosition.Text.Length;

                if (!String.IsNullOrEmpty(tbxTopCornerPosition.Text))
                {
                    cbxCorner.Checked = true;
                }
            }
        }

        private void tbxNoiseIntensity_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxNoiseIntensity.Text) && (!Int32.TryParse(tbxNoiseIntensity.Text, out parsedNumber) || parsedNumber > 1000 || parsedNumber < 0))
            {
                tbxNoiseIntensity.Text = tbxNoiseIntensity.Tag.ToString();
                if (String.IsNullOrEmpty(tbxNoiseIntensity.Text))
                {
                    cbxNoise.Checked = false;
                }
            }
            else
            {
                tbxNoiseIntensity.Tag = tbxNoiseIntensity.Text;
                tbxNoiseIntensity.SelectionStart = tbxNoiseIntensity.Text.Length;
                cbxNoise.Checked = true;
            }
        }

        private void tbxBlurIntensity_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!String.IsNullOrEmpty(tbxBlurIntensity.Text) && (!Int32.TryParse(tbxBlurIntensity.Text, out parsedNumber) || parsedNumber > 1000 || parsedNumber < 0))
            {
                tbxBlurIntensity.Text = tbxBlurIntensity.Tag.ToString();
                if (String.IsNullOrEmpty(tbxBlurIntensity.Text))
                {
                    cbxBlur.Checked = false;
                }
            }
            else
            {
                tbxBlurIntensity.Tag = tbxBlurIntensity.Text;
                tbxBlurIntensity.SelectionStart = tbxBlurIntensity.Text.Length;
                cbxBlur.Checked = true;
            }
        }

        private void btnSabotageHelp_Click(object sender, EventArgs e)
        {
            helpForm.Initialize(Resources.SabotageFormHelp);
        }

        private void cbxRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRotate.Checked)
            {
                tbxRotateAngle.Text = String.IsNullOrEmpty(tbxRotateAngle.Text) ? 0.ToString() : tbxRotateAngle.Text;
            }
        }

        private void cbxMarker_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxMarker.Checked)
            {
                tbxTopMarkerPosition.Text = String.IsNullOrEmpty(tbxTopMarkerPosition.Text) ? 0.ToString() : tbxTopMarkerPosition.Text;
                tbxBottomMarkerPosition.Text = String.IsNullOrEmpty(tbxBottomMarkerPosition.Text) ? 0.ToString() : tbxBottomMarkerPosition.Text;
            }
        }

        private void cbxCorner_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxCorner.Checked)
            {
                tbxCornerSidePosition.Text = String.IsNullOrEmpty(tbxCornerSidePosition.Text) ? 0.ToString() : tbxCornerSidePosition.Text;
                tbxTopCornerPosition.Text = String.IsNullOrEmpty(tbxTopCornerPosition.Text) ? 0.ToString() : tbxTopCornerPosition.Text;
            }
        }

        private void cbxNoise_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxNoise.Checked)
            {
                tbxNoiseIntensity.Text = String.IsNullOrEmpty(tbxNoiseIntensity.Text) ? 0.ToString() : tbxNoiseIntensity.Text;
            }
        }

        private void cbxBlur_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxBlur.Checked)
            {
                tbxBlurIntensity.Text = String.IsNullOrEmpty(tbxBlurIntensity.Text) ? 0.ToString() : tbxBlurIntensity.Text;
            }
        }

        private void trbBrightness_Scroll(object sender, EventArgs e)
        {
            cbxBrightness.Checked = true;
        }
    }
}
