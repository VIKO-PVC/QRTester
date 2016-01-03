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
            this.SuspendLayout();
            // 
            // cbxRotate
            // 
            this.cbxRotate.AutoSize = true;
            this.cbxRotate.Location = new System.Drawing.Point(13, 13);
            this.cbxRotate.Name = "cbxRotate";
            this.cbxRotate.Size = new System.Drawing.Size(98, 21);
            this.cbxRotate.TabIndex = 0;
            this.cbxRotate.Text = "Pasukimas";
            this.cbxRotate.UseVisualStyleBackColor = true;
            // 
            // tbxRotateAngle
            // 
            this.tbxRotateAngle.Location = new System.Drawing.Point(118, 13);
            this.tbxRotateAngle.Name = "tbxRotateAngle";
            this.tbxRotateAngle.Size = new System.Drawing.Size(56, 22);
            this.tbxRotateAngle.TabIndex = 1;
            this.tbxRotateAngle.Text = "0";
            this.tbxRotateAngle.TextChanged += new System.EventHandler(this.tbxRotateAngle_TextChanged);
            // 
            // lblRotateAnglePercent
            // 
            this.lblRotateAnglePercent.AutoSize = true;
            this.lblRotateAnglePercent.Location = new System.Drawing.Point(181, 17);
            this.lblRotateAnglePercent.Name = "lblRotateAnglePercent";
            this.lblRotateAnglePercent.Size = new System.Drawing.Size(20, 17);
            this.lblRotateAnglePercent.TabIndex = 2;
            this.lblRotateAnglePercent.Text = "%";
            // 
            // cbxMarker
            // 
            this.cbxMarker.AutoSize = true;
            this.cbxMarker.Location = new System.Drawing.Point(13, 41);
            this.cbxMarker.Name = "cbxMarker";
            this.cbxMarker.Size = new System.Drawing.Size(84, 21);
            this.cbxMarker.TabIndex = 3;
            this.cbxMarker.Text = "Markeris";
            this.cbxMarker.UseVisualStyleBackColor = true;
            // 
            // cbxCorner
            // 
            this.cbxCorner.AutoSize = true;
            this.cbxCorner.Location = new System.Drawing.Point(13, 69);
            this.cbxCorner.Name = "cbxCorner";
            this.cbxCorner.Size = new System.Drawing.Size(81, 21);
            this.cbxCorner.TabIndex = 4;
            this.cbxCorner.Text = "Kampas";
            this.cbxCorner.UseVisualStyleBackColor = true;
            // 
            // btnSabotageOk
            // 
            this.btnSabotageOk.Location = new System.Drawing.Point(12, 111);
            this.btnSabotageOk.Name = "btnSabotageOk";
            this.btnSabotageOk.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageOk.TabIndex = 5;
            this.btnSabotageOk.Text = "Ok";
            this.btnSabotageOk.UseVisualStyleBackColor = true;
            this.btnSabotageOk.Click += new System.EventHandler(this.btnSabotageOk_Click);
            // 
            // btnSabotageCancel
            // 
            this.btnSabotageCancel.Location = new System.Drawing.Point(325, 111);
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
            this.tbxTopMarkerPosition.Name = "tbxTopMarkerPosition";
            this.tbxTopMarkerPosition.Size = new System.Drawing.Size(56, 22);
            this.tbxTopMarkerPosition.TabIndex = 7;
            this.tbxTopMarkerPosition.TextChanged += new System.EventHandler(this.tbxTopMarkerPosition_TextChanged);
            // 
            // tbxBottomMarkerPosition
            // 
            this.tbxBottomMarkerPosition.Location = new System.Drawing.Point(317, 42);
            this.tbxBottomMarkerPosition.Name = "tbxBottomMarkerPosition";
            this.tbxBottomMarkerPosition.Size = new System.Drawing.Size(56, 22);
            this.tbxBottomMarkerPosition.TabIndex = 8;
            this.tbxBottomMarkerPosition.TextChanged += new System.EventHandler(this.tbxBottomMarkerPosition_TextChanged);
            // 
            // lblTopMarkerPosition
            // 
            this.lblTopMarkerPosition.AutoSize = true;
            this.lblTopMarkerPosition.Location = new System.Drawing.Point(118, 46);
            this.lblTopMarkerPosition.Name = "lblTopMarkerPosition";
            this.lblTopMarkerPosition.Size = new System.Drawing.Size(47, 17);
            this.lblTopMarkerPosition.TabIndex = 9;
            this.lblTopMarkerPosition.Text = "Viršus";
            // 
            // lblTopMarkerPositionPercent
            // 
            this.lblTopMarkerPositionPercent.AutoSize = true;
            this.lblTopMarkerPositionPercent.Location = new System.Drawing.Point(234, 46);
            this.lblTopMarkerPositionPercent.Name = "lblTopMarkerPositionPercent";
            this.lblTopMarkerPositionPercent.Size = new System.Drawing.Size(20, 17);
            this.lblTopMarkerPositionPercent.TabIndex = 10;
            this.lblTopMarkerPositionPercent.Text = "%";
            // 
            // lblBottomMarkerPosition
            // 
            this.lblBottomMarkerPosition.AutoSize = true;
            this.lblBottomMarkerPosition.Location = new System.Drawing.Point(260, 45);
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
            this.lblTopCornerPosition.Location = new System.Drawing.Point(118, 69);
            this.lblTopCornerPosition.Name = "lblTopCornerPosition";
            this.lblTopCornerPosition.Size = new System.Drawing.Size(47, 17);
            this.lblTopCornerPosition.TabIndex = 13;
            this.lblTopCornerPosition.Text = "Viršus";
            // 
            // tbxTopCornerPosition
            // 
            this.tbxTopCornerPosition.Location = new System.Drawing.Point(172, 69);
            this.tbxTopCornerPosition.Name = "tbxTopCornerPosition";
            this.tbxTopCornerPosition.Size = new System.Drawing.Size(55, 22);
            this.tbxTopCornerPosition.TabIndex = 14;
            this.tbxTopCornerPosition.TextChanged += new System.EventHandler(this.tbxTopCornerPosition_TextChanged);
            // 
            // lblTopCornerPercentage
            // 
            this.lblTopCornerPercentage.AutoSize = true;
            this.lblTopCornerPercentage.Location = new System.Drawing.Point(234, 72);
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
            this.tbxCornerSidePosition.Name = "tbxCornerSidePosition";
            this.tbxCornerSidePosition.Size = new System.Drawing.Size(56, 22);
            this.tbxCornerSidePosition.TabIndex = 17;
            this.tbxCornerSidePosition.TextChanged += new System.EventHandler(this.tbxCornerSidePosition_TextChanged);
            // 
            // lblCornerSidePositionPercentage
            // 
            this.lblCornerSidePositionPercentage.AutoSize = true;
            this.lblCornerSidePositionPercentage.Location = new System.Drawing.Point(380, 72);
            this.lblCornerSidePositionPercentage.Name = "lblCornerSidePositionPercentage";
            this.lblCornerSidePositionPercentage.Size = new System.Drawing.Size(20, 17);
            this.lblCornerSidePositionPercentage.TabIndex = 18;
            this.lblCornerSidePositionPercentage.Text = "%";
            // 
            // btnSabotageHelp
            // 
            this.btnSabotageHelp.Location = new System.Drawing.Point(93, 111);
            this.btnSabotageHelp.Name = "btnSabotageHelp";
            this.btnSabotageHelp.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageHelp.TabIndex = 19;
            this.btnSabotageHelp.Text = "Pagalba";
            this.btnSabotageHelp.UseVisualStyleBackColor = true;
            this.btnSabotageHelp.Click += new System.EventHandler(this.btnSabotageHelp_Click);
            // 
            // TestMethodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 145);
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
            this.Name = "TestMethodsForm";
            this.Text = "Iškraipymai";
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
    }
}