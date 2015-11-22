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
            this.btnSabotageOk.Location = new System.Drawing.Point(13, 111);
            this.btnSabotageOk.Name = "btnSabotageOk";
            this.btnSabotageOk.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageOk.TabIndex = 5;
            this.btnSabotageOk.Text = "Ok";
            this.btnSabotageOk.UseVisualStyleBackColor = true;
            this.btnSabotageOk.Click += new System.EventHandler(this.btnSabotageOk_Click);
            // 
            // btnSabotageCancel
            // 
            this.btnSabotageCancel.Location = new System.Drawing.Point(195, 111);
            this.btnSabotageCancel.Name = "btnSabotageCancel";
            this.btnSabotageCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSabotageCancel.TabIndex = 6;
            this.btnSabotageCancel.Text = "Atšaukti";
            this.btnSabotageCancel.UseVisualStyleBackColor = true;
            this.btnSabotageCancel.Click += new System.EventHandler(this.btnSabotageCancel_Click);
            // 
            // TestMethodsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 146);
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
    }
}