﻿using System;
using System.Windows.Forms;
using Model;
using Service;

namespace QRTester
{
    public partial class TestMethodsForm : Form
    {
        public bool MultipleChoises { get; set; }
        private bool IsMultipleChoisesEventsActive { get; set; }

        public TestMethodsForm()
        {
            IsMultipleChoisesEventsActive = true;
            InitializeComponent();
        }

        public void Initialize()
        {
            IsMultipleChoisesEventsActive = false;
            cbxRotate.Checked = false;
            cbxMarker.Checked = false;
            cbxCorner.Checked = false;
            tbxRotateAngle.Text = 0.ToString();
            IsMultipleChoisesEventsActive = true;
        }

        private void btnSabotageOk_Click(object sender, EventArgs e)
        {
            var checkStatus = CheckImageStatus.NotCheckYet;
            var image = ImageService.Settings.UploadedImage;
            ImageOperation operation;

            if (cbxRotate.Checked)
            {
                operation = new RotateOperation()
                {
                    CheckStatus = checkStatus,
                    Image = image,
                    RotateAngle = ImageService.GetRotationAngle(Int32.Parse(tbxRotateAngle.Text))
                };
            }
            else
            {
                operation = null;
            }

            ImageService.PendingImageOperations.Push(operation);
            Close();
        }

        private void btnSabotageCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cbxRotate_CheckedChanged(object sender, EventArgs e)
        {
            if (!MultipleChoises && IsMultipleChoisesEventsActive)
            {
                IsMultipleChoisesEventsActive = false;
                cbxMarker.Checked = false;
                cbxCorner.Checked = false;
                IsMultipleChoisesEventsActive = true;
            }
        }

        private void cbxMarker_CheckedChanged(object sender, EventArgs e)
        {
            if (!MultipleChoises && IsMultipleChoisesEventsActive)
            {
                IsMultipleChoisesEventsActive = false;
                cbxRotate.Checked = false;
                cbxCorner.Checked = false;
                IsMultipleChoisesEventsActive = true;
            }
        }

        private void cbxCorner_CheckedChanged(object sender, EventArgs e)
        {
            if (!MultipleChoises && IsMultipleChoisesEventsActive)
            {
                IsMultipleChoisesEventsActive = false;
                cbxMarker.Checked = false;
                cbxRotate.Checked = false;
                IsMultipleChoisesEventsActive = true;
            }
        }

        private void tbxRotateAngle_TextChanged(object sender, EventArgs e)
        {
            int parsedNumber;
            if (!Int32.TryParse(tbxRotateAngle.Text, out parsedNumber) || parsedNumber > 360 || parsedNumber < 0)
            {
                tbxRotateAngle.Text = 0.ToString();
            }
        }
    }
}
