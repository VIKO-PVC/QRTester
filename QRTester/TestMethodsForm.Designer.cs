namespace QRTester
{
    partial class TestMethodsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TestMethodsForm));
            this.cbxRotate = new System.Windows.Forms.CheckBox();
            this.tbxRotateAngle = new System.Windows.Forms.TextBox();
            this.lblRotateAnglePercent = new System.Windows.Forms.Label();
            this.cbxMarker = new System.Windows.Forms.CheckBox();
            this.cbxCorner = new System.Windows.Forms.CheckBox();
            this.btnSabotageOk = new System.Windows.Forms.Button();
            this.btnSabotageCancel = new System.Windows.Forms.Button();
            this.tbxTopMarkerPosition = new System.Windows.Forms.TextBox();
            this.tbxBottomMarkerPosition = new System.Windows.Forms.TextBox();
            this.lblTopMarkerPosition = new System.Windows.Forms.Label();
            this.lblTopMarkerPositionPercent = new System.Windows.Forms.Label();
            this.lblBottomMarkerPosition = new System.Windows.Forms.Label();
            this.lblBottomMarkerPositionPercent = new System.Windows.Forms.Label();
            this.lblTopCornerPosition = new System.Windows.Forms.Label();
            this.tbxTopCornerPosition = new System.Windows.Forms.TextBox();
            this.lblTopCornerPercentage = new System.Windows.Forms.Label();
            this.lblCornerSidePosition = new System.Windows.Forms.Label();
            this.tbxCornerSidePosition = new System.Windows.Forms.TextBox();
            this.lblCornerSidePositionPercentage = new System.Windows.Forms.Label();
            this.btnSabotageHelp = new System.Windows.Forms.Button();
            this.cbxNoise = new System.Windows.Forms.CheckBox();
            this.lblNoiseIntensityPercent = new System.Windows.Forms.Label();
            this.tbxNoiseIntensity = new System.Windows.Forms.TextBox();
            this.cbxBlur = new System.Windows.Forms.CheckBox();
            this.tbxBlurIntensity = new System.Windows.Forms.TextBox();
            this.lblBlurIntensityPercent = new System.Windows.Forms.Label();
            this.cbxBrightness = new System.Windows.Forms.CheckBox();
            this.lblBrightnessDarker = new System.Windows.Forms.Label();
            this.lblBrightnessBrighter = new System.Windows.Forms.Label();
            this.trbBrightness = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxRotate
            // 
            this.cbxRotate.AutoSize = true;
            this.cbxRotate.Location = new System.Drawing.Point(13, 14);
            this.cbxRotate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxRotate.Name = "cbxRotate";
            this.cbxRotate.Size = new System.Drawing.Size(98, 21);
            this.cbxRotate.TabIndex = 0;
            this.cbxRotate.Text = "Pasukimas";
            this.cbxRotate.UseVisualStyleBackColor = true;
            this.cbxRotate.CheckedChanged += new System.EventHandler(this.cbxRotate_CheckedChanged);
            // 
            // tbxRotateAngle
            // 
            this.tbxRotateAngle.Location = new System.Drawing.Point(117, 14);
            this.tbxRotateAngle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxRotateAngle.Name = "tbxRotateAngle";
            this.tbxRotateAngle.Size = new System.Drawing.Size(56, 22);
            this.tbxRotateAngle.TabIndex = 1;
            this.tbxRotateAngle.TextChanged += new System.EventHandler(this.tbxRotateAngle_TextChanged);
            // 
            // lblRotateAnglePercent
            // 
            this.lblRotateAnglePercent.AutoSize = true;
            this.lblRotateAnglePercent.Location = new System.Drawing.Point(181, 17);
            this.lblRotateAnglePercent.Name = "lblRotateAnglePercent";
            this.lblRotateAnglePercent.Size = new System.Drawing.Size(14, 17);
            this.lblRotateAnglePercent.TabIndex = 2;
            this.lblRotateAnglePercent.Text = "°";
            // 
            // cbxMarker
            // 
            this.cbxMarker.AutoSize = true;
            this.cbxMarker.Location = new System.Drawing.Point(13, 41);
            this.cbxMarker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxMarker.Name = "cbxMarker";
            this.cbxMarker.Size = new System.Drawing.Size(84, 21);
            this.cbxMarker.TabIndex = 3;
            this.cbxMarker.Text = "Markeris";
            this.cbxMarker.UseVisualStyleBackColor = true;
            this.cbxMarker.CheckedChanged += new System.EventHandler(this.cbxMarker_CheckedChanged);
            // 
            // cbxCorner
            // 
            this.cbxCorner.AutoSize = true;
            this.cbxCorner.Location = new System.Drawing.Point(13, 69);
            this.cbxCorner.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxCorner.Name = "cbxCorner";
            this.cbxCorner.Size = new System.Drawing.Size(81, 21);
            this.cbxCorner.TabIndex = 4;
            this.cbxCorner.Text = "Kampas";
            this.cbxCorner.UseVisualStyleBackColor = true;
            this.cbxCorner.CheckedChanged += new System.EventHandler(this.cbxCorner_CheckedChanged);
            // 
            // btnSabotageOk
            // 
            this.btnSabotageOk.Location = new System.Drawing.Point(12, 190);
            this.btnSabotageOk.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSabotageOk.Name = "btnSabotageOk";
            this.btnSabotageOk.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageOk.TabIndex = 5;
            this.btnSabotageOk.Text = "Ok";
            this.btnSabotageOk.UseVisualStyleBackColor = true;
            this.btnSabotageOk.Click += new System.EventHandler(this.btnSabotageOk_Click);
            // 
            // btnSabotageCancel
            // 
            this.btnSabotageCancel.Location = new System.Drawing.Point(325, 190);
            this.btnSabotageCancel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSabotageCancel.Name = "btnSabotageCancel";
            this.btnSabotageCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageCancel.TabIndex = 6;
            this.btnSabotageCancel.Text = "Atšaukti";
            this.btnSabotageCancel.UseVisualStyleBackColor = true;
            this.btnSabotageCancel.Click += new System.EventHandler(this.btnSabotageCancel_Click);
            // 
            // tbxTopMarkerPosition
            // 
            this.tbxTopMarkerPosition.Location = new System.Drawing.Point(171, 42);
            this.tbxTopMarkerPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTopMarkerPosition.Name = "tbxTopMarkerPosition";
            this.tbxTopMarkerPosition.Size = new System.Drawing.Size(56, 22);
            this.tbxTopMarkerPosition.TabIndex = 7;
            this.tbxTopMarkerPosition.TextChanged += new System.EventHandler(this.tbxTopMarkerPosition_TextChanged);
            // 
            // tbxBottomMarkerPosition
            // 
            this.tbxBottomMarkerPosition.Location = new System.Drawing.Point(317, 42);
            this.tbxBottomMarkerPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxBottomMarkerPosition.Name = "tbxBottomMarkerPosition";
            this.tbxBottomMarkerPosition.Size = new System.Drawing.Size(56, 22);
            this.tbxBottomMarkerPosition.TabIndex = 8;
            this.tbxBottomMarkerPosition.TextChanged += new System.EventHandler(this.tbxBottomMarkerPosition_TextChanged);
            // 
            // lblTopMarkerPosition
            // 
            this.lblTopMarkerPosition.AutoSize = true;
            this.lblTopMarkerPosition.Location = new System.Drawing.Point(117, 46);
            this.lblTopMarkerPosition.Name = "lblTopMarkerPosition";
            this.lblTopMarkerPosition.Size = new System.Drawing.Size(47, 17);
            this.lblTopMarkerPosition.TabIndex = 9;
            this.lblTopMarkerPosition.Text = "Viršus";
            // 
            // lblTopMarkerPositionPercent
            // 
            this.lblTopMarkerPositionPercent.AutoSize = true;
            this.lblTopMarkerPositionPercent.Location = new System.Drawing.Point(235, 46);
            this.lblTopMarkerPositionPercent.Name = "lblTopMarkerPositionPercent";
            this.lblTopMarkerPositionPercent.Size = new System.Drawing.Size(20, 17);
            this.lblTopMarkerPositionPercent.TabIndex = 10;
            this.lblTopMarkerPositionPercent.Text = "%";
            // 
            // lblBottomMarkerPosition
            // 
            this.lblBottomMarkerPosition.AutoSize = true;
            this.lblBottomMarkerPosition.Location = new System.Drawing.Point(260, 46);
            this.lblBottomMarkerPosition.Name = "lblBottomMarkerPosition";
            this.lblBottomMarkerPosition.Size = new System.Drawing.Size(51, 17);
            this.lblBottomMarkerPosition.TabIndex = 11;
            this.lblBottomMarkerPosition.Text = "Apačia";
            // 
            // lblBottomMarkerPositionPercent
            // 
            this.lblBottomMarkerPositionPercent.AutoSize = true;
            this.lblBottomMarkerPositionPercent.Location = new System.Drawing.Point(380, 46);
            this.lblBottomMarkerPositionPercent.Name = "lblBottomMarkerPositionPercent";
            this.lblBottomMarkerPositionPercent.Size = new System.Drawing.Size(20, 17);
            this.lblBottomMarkerPositionPercent.TabIndex = 12;
            this.lblBottomMarkerPositionPercent.Text = "%";
            // 
            // lblTopCornerPosition
            // 
            this.lblTopCornerPosition.AutoSize = true;
            this.lblTopCornerPosition.Location = new System.Drawing.Point(117, 69);
            this.lblTopCornerPosition.Name = "lblTopCornerPosition";
            this.lblTopCornerPosition.Size = new System.Drawing.Size(47, 17);
            this.lblTopCornerPosition.TabIndex = 13;
            this.lblTopCornerPosition.Text = "Viršus";
            // 
            // tbxTopCornerPosition
            // 
            this.tbxTopCornerPosition.Location = new System.Drawing.Point(172, 69);
            this.tbxTopCornerPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxTopCornerPosition.Name = "tbxTopCornerPosition";
            this.tbxTopCornerPosition.Size = new System.Drawing.Size(55, 22);
            this.tbxTopCornerPosition.TabIndex = 14;
            this.tbxTopCornerPosition.TextChanged += new System.EventHandler(this.tbxTopCornerPosition_TextChanged);
            // 
            // lblTopCornerPercentage
            // 
            this.lblTopCornerPercentage.AutoSize = true;
            this.lblTopCornerPercentage.Location = new System.Drawing.Point(235, 71);
            this.lblTopCornerPercentage.Name = "lblTopCornerPercentage";
            this.lblTopCornerPercentage.Size = new System.Drawing.Size(20, 17);
            this.lblTopCornerPercentage.TabIndex = 15;
            this.lblTopCornerPercentage.Text = "%";
            // 
            // lblCornerSidePosition
            // 
            this.lblCornerSidePosition.AutoSize = true;
            this.lblCornerSidePosition.Location = new System.Drawing.Point(261, 71);
            this.lblCornerSidePosition.Name = "lblCornerSidePosition";
            this.lblCornerSidePosition.Size = new System.Drawing.Size(48, 17);
            this.lblCornerSidePosition.TabIndex = 16;
            this.lblCornerSidePosition.Text = "Šonas";
            // 
            // tbxCornerSidePosition
            // 
            this.tbxCornerSidePosition.Location = new System.Drawing.Point(317, 69);
            this.tbxCornerSidePosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxCornerSidePosition.Name = "tbxCornerSidePosition";
            this.tbxCornerSidePosition.Size = new System.Drawing.Size(56, 22);
            this.tbxCornerSidePosition.TabIndex = 17;
            this.tbxCornerSidePosition.TextChanged += new System.EventHandler(this.tbxCornerSidePosition_TextChanged);
            // 
            // lblCornerSidePositionPercentage
            // 
            this.lblCornerSidePositionPercentage.AutoSize = true;
            this.lblCornerSidePositionPercentage.Location = new System.Drawing.Point(380, 71);
            this.lblCornerSidePositionPercentage.Name = "lblCornerSidePositionPercentage";
            this.lblCornerSidePositionPercentage.Size = new System.Drawing.Size(20, 17);
            this.lblCornerSidePositionPercentage.TabIndex = 18;
            this.lblCornerSidePositionPercentage.Text = "%";
            // 
            // btnSabotageHelp
            // 
            this.btnSabotageHelp.Location = new System.Drawing.Point(93, 190);
            this.btnSabotageHelp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSabotageHelp.Name = "btnSabotageHelp";
            this.btnSabotageHelp.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageHelp.TabIndex = 19;
            this.btnSabotageHelp.Text = "Pagalba";
            this.btnSabotageHelp.UseVisualStyleBackColor = true;
            this.btnSabotageHelp.Click += new System.EventHandler(this.btnSabotageHelp_Click);
            // 
            // cbxNoise
            // 
            this.cbxNoise.AutoSize = true;
            this.cbxNoise.Location = new System.Drawing.Point(12, 96);
            this.cbxNoise.Name = "cbxNoise";
            this.cbxNoise.Size = new System.Drawing.Size(95, 21);
            this.cbxNoise.TabIndex = 20;
            this.cbxNoise.Text = "Triukšmas";
            this.cbxNoise.UseVisualStyleBackColor = true;
            this.cbxNoise.CheckedChanged += new System.EventHandler(this.cbxNoise_CheckedChanged);
            // 
            // lblNoiseIntensityPercent
            // 
            this.lblNoiseIntensityPercent.AutoSize = true;
            this.lblNoiseIntensityPercent.Location = new System.Drawing.Point(235, 100);
            this.lblNoiseIntensityPercent.Name = "lblNoiseIntensityPercent";
            this.lblNoiseIntensityPercent.Size = new System.Drawing.Size(22, 17);
            this.lblNoiseIntensityPercent.TabIndex = 23;
            this.lblNoiseIntensityPercent.Text = "‰";
            // 
            // tbxNoiseIntensity
            // 
            this.tbxNoiseIntensity.Location = new System.Drawing.Point(172, 96);
            this.tbxNoiseIntensity.Name = "tbxNoiseIntensity";
            this.tbxNoiseIntensity.Size = new System.Drawing.Size(56, 22);
            this.tbxNoiseIntensity.TabIndex = 22;
            this.tbxNoiseIntensity.TextChanged += new System.EventHandler(this.tbxNoiseIntensity_TextChanged);
            // 
            // cbxBlur
            // 
            this.cbxBlur.AutoSize = true;
            this.cbxBlur.Location = new System.Drawing.Point(12, 124);
            this.cbxBlur.Name = "cbxBlur";
            this.cbxBlur.Size = new System.Drawing.Size(95, 21);
            this.cbxBlur.TabIndex = 24;
            this.cbxBlur.Text = "Išblukimas";
            this.cbxBlur.UseVisualStyleBackColor = true;
            this.cbxBlur.CheckedChanged += new System.EventHandler(this.cbxBlur_CheckedChanged);
            // 
            // tbxBlurIntensity
            // 
            this.tbxBlurIntensity.Location = new System.Drawing.Point(171, 124);
            this.tbxBlurIntensity.Name = "tbxBlurIntensity";
            this.tbxBlurIntensity.Size = new System.Drawing.Size(57, 22);
            this.tbxBlurIntensity.TabIndex = 25;
            this.tbxBlurIntensity.TextChanged += new System.EventHandler(this.tbxBlurIntensity_TextChanged);
            // 
            // lblBlurIntensityPercent
            // 
            this.lblBlurIntensityPercent.AutoSize = true;
            this.lblBlurIntensityPercent.Location = new System.Drawing.Point(238, 128);
            this.lblBlurIntensityPercent.Name = "lblBlurIntensityPercent";
            this.lblBlurIntensityPercent.Size = new System.Drawing.Size(20, 17);
            this.lblBlurIntensityPercent.TabIndex = 26;
            this.lblBlurIntensityPercent.Text = "%";
            // 
            // cbxBrightness
            // 
            this.cbxBrightness.AutoSize = true;
            this.cbxBrightness.Location = new System.Drawing.Point(12, 151);
            this.cbxBrightness.Name = "cbxBrightness";
            this.cbxBrightness.Size = new System.Drawing.Size(105, 21);
            this.cbxBrightness.TabIndex = 27;
            this.cbxBrightness.Text = "Apšvietimas";
            this.cbxBrightness.UseVisualStyleBackColor = true;
            // 
            // lblBrightnessDarker
            // 
            this.lblBrightnessDarker.AutoSize = true;
            this.lblBrightnessDarker.Location = new System.Drawing.Point(114, 152);
            this.lblBrightnessDarker.Name = "lblBrightnessDarker";
            this.lblBrightnessDarker.Size = new System.Drawing.Size(62, 17);
            this.lblBrightnessDarker.TabIndex = 28;
            this.lblBrightnessDarker.Text = "Tamsiau";
            // 
            // lblBrightnessBrighter
            // 
            this.lblBrightnessBrighter.AutoSize = true;
            this.lblBrightnessBrighter.Location = new System.Drawing.Point(322, 152);
            this.lblBrightnessBrighter.Name = "lblBrightnessBrighter";
            this.lblBrightnessBrighter.Size = new System.Drawing.Size(61, 17);
            this.lblBrightnessBrighter.TabIndex = 29;
            this.lblBrightnessBrighter.Text = "Šviesiau";
            // 
            // trbBrightness
            // 
            this.trbBrightness.LargeChange = 90;
            this.trbBrightness.Location = new System.Drawing.Point(181, 154);
            this.trbBrightness.Maximum = 255;
            this.trbBrightness.Minimum = -255;
            this.trbBrightness.Name = "trbBrightness";
            this.trbBrightness.Size = new System.Drawing.Size(135, 56);
            this.trbBrightness.SmallChange = 30;
            this.trbBrightness.TabIndex = 30;
            this.trbBrightness.TickFrequency = 30;
            this.trbBrightness.Scroll += new System.EventHandler(this.trbBrightness_Scroll);
            // 
            // TestMethodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 224);
            this.Controls.Add(this.trbBrightness);
            this.Controls.Add(this.lblBrightnessBrighter);
            this.Controls.Add(this.lblBrightnessDarker);
            this.Controls.Add(this.cbxBrightness);
            this.Controls.Add(this.lblBlurIntensityPercent);
            this.Controls.Add(this.tbxBlurIntensity);
            this.Controls.Add(this.cbxBlur);
            this.Controls.Add(this.lblNoiseIntensityPercent);
            this.Controls.Add(this.tbxNoiseIntensity);
            this.Controls.Add(this.cbxNoise);
            this.Controls.Add(this.btnSabotageHelp);
            this.Controls.Add(this.lblCornerSidePositionPercentage);
            this.Controls.Add(this.tbxCornerSidePosition);
            this.Controls.Add(this.lblCornerSidePosition);
            this.Controls.Add(this.lblTopCornerPercentage);
            this.Controls.Add(this.tbxTopCornerPosition);
            this.Controls.Add(this.lblTopCornerPosition);
            this.Controls.Add(this.lblBottomMarkerPositionPercent);
            this.Controls.Add(this.lblBottomMarkerPosition);
            this.Controls.Add(this.lblTopMarkerPositionPercent);
            this.Controls.Add(this.lblTopMarkerPosition);
            this.Controls.Add(this.tbxBottomMarkerPosition);
            this.Controls.Add(this.tbxTopMarkerPosition);
            this.Controls.Add(this.btnSabotageCancel);
            this.Controls.Add(this.btnSabotageOk);
            this.Controls.Add(this.cbxCorner);
            this.Controls.Add(this.cbxMarker);
            this.Controls.Add(this.lblRotateAnglePercent);
            this.Controls.Add(this.tbxRotateAngle);
            this.Controls.Add(this.cbxRotate);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TestMethodsForm";
            this.Text = "Iškraipymai";
            ((System.ComponentModel.ISupportInitialize)(this.trbBrightness)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbxRotate;
        private System.Windows.Forms.TextBox tbxRotateAngle;
        private System.Windows.Forms.Label lblRotateAnglePercent;
        private System.Windows.Forms.CheckBox cbxMarker;
        private System.Windows.Forms.CheckBox cbxCorner;
        private System.Windows.Forms.Button btnSabotageOk;
        private System.Windows.Forms.Button btnSabotageCancel;
        private System.Windows.Forms.TextBox tbxTopMarkerPosition;
        private System.Windows.Forms.TextBox tbxBottomMarkerPosition;
        private System.Windows.Forms.Label lblTopMarkerPosition;
        private System.Windows.Forms.Label lblTopMarkerPositionPercent;
        private System.Windows.Forms.Label lblBottomMarkerPosition;
        private System.Windows.Forms.Label lblBottomMarkerPositionPercent;
        private System.Windows.Forms.Label lblTopCornerPosition;
        private System.Windows.Forms.TextBox tbxTopCornerPosition;
        private System.Windows.Forms.Label lblTopCornerPercentage;
        private System.Windows.Forms.Label lblCornerSidePosition;
        private System.Windows.Forms.TextBox tbxCornerSidePosition;
        private System.Windows.Forms.Label lblCornerSidePositionPercentage;
        private System.Windows.Forms.Button btnSabotageHelp;
        private System.Windows.Forms.CheckBox cbxNoise;
        private System.Windows.Forms.Label lblNoiseIntensityPercent;
        private System.Windows.Forms.TextBox tbxNoiseIntensity;
        private System.Windows.Forms.CheckBox cbxBlur;
        private System.Windows.Forms.TextBox tbxBlurIntensity;
        private System.Windows.Forms.Label lblBlurIntensityPercent;
        private System.Windows.Forms.CheckBox cbxBrightness;
        private System.Windows.Forms.Label lblBrightnessDarker;
        private System.Windows.Forms.Label lblBrightnessBrighter;
        private System.Windows.Forms.TrackBar trbBrightness;
    }
}