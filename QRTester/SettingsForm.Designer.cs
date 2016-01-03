namespace QRTester
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.tbxUploadUrl = new System.Windows.Forms.TextBox();
            this.lblSettingsUploadUrl = new System.Windows.Forms.Label();
            this.btnSettingsOk = new System.Windows.Forms.Button();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ddlRequestType = new System.Windows.Forms.ComboBox();
            this.tbxSuccessfulResponseFragment = new System.Windows.Forms.TextBox();
            this.cbxCheckQrCode = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSettingsHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxUploadUrl
            // 
            this.tbxUploadUrl.Location = new System.Drawing.Point(281, 10);
            this.tbxUploadUrl.Name = "tbxUploadUrl";
            this.tbxUploadUrl.Size = new System.Drawing.Size(589, 22);
            this.tbxUploadUrl.TabIndex = 0;
            // 
            // lblSettingsUploadUrl
            // 
            this.lblSettingsUploadUrl.AutoSize = true;
            this.lblSettingsUploadUrl.Location = new System.Drawing.Point(13, 13);
            this.lblSettingsUploadUrl.Name = "lblSettingsUploadUrl";
            this.lblSettingsUploadUrl.Size = new System.Drawing.Size(117, 17);
            this.lblSettingsUploadUrl.TabIndex = 1;
            this.lblSettingsUploadUrl.Text = "QR tikrinimo URL";
            // 
            // btnSettingsOk
            // 
            this.btnSettingsOk.Location = new System.Drawing.Point(16, 218);
            this.btnSettingsOk.Name = "btnSettingsOk";
            this.btnSettingsOk.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsOk.TabIndex = 2;
            this.btnSettingsOk.Text = "Ok";
            this.btnSettingsOk.UseVisualStyleBackColor = true;
            this.btnSettingsOk.Click += new System.EventHandler(this.btnSettingsOk_Click);
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.Location = new System.Drawing.Point(795, 218);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 3;
            this.btnSettingsCancel.Text = "Atšaukti";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            this.btnSettingsCancel.Click += new System.EventHandler(this.btnSettingsCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Užklausos tipas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sėkmingo nuskaitymo HTML fragmentas";
            // 
            // ddlRequestType
            // 
            this.ddlRequestType.FormattingEnabled = true;
            this.ddlRequestType.Items.AddRange(new object[] {
            "GET",
            "POST"});
            this.ddlRequestType.Location = new System.Drawing.Point(281, 40);
            this.ddlRequestType.Name = "ddlRequestType";
            this.ddlRequestType.Size = new System.Drawing.Size(121, 24);
            this.ddlRequestType.TabIndex = 6;
            // 
            // tbxSuccessfulResponseFragment
            // 
            this.tbxSuccessfulResponseFragment.Location = new System.Drawing.Point(281, 70);
            this.tbxSuccessfulResponseFragment.Name = "tbxSuccessfulResponseFragment";
            this.tbxSuccessfulResponseFragment.Size = new System.Drawing.Size(589, 22);
            this.tbxSuccessfulResponseFragment.TabIndex = 7;
            // 
            // cbxCheckQrCode
            // 
            this.cbxCheckQrCode.AutoSize = true;
            this.cbxCheckQrCode.Location = new System.Drawing.Point(281, 103);
            this.cbxCheckQrCode.Name = "cbxCheckQrCode";
            this.cbxCheckQrCode.Size = new System.Drawing.Size(18, 17);
            this.cbxCheckQrCode.TabIndex = 8;
            this.cbxCheckQrCode.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Įjungti QR skaitytuvą";
            // 
            // btnSettingsHelp
            // 
            this.btnSettingsHelp.Location = new System.Drawing.Point(98, 218);
            this.btnSettingsHelp.Name = "btnSettingsHelp";
            this.btnSettingsHelp.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsHelp.TabIndex = 10;
            this.btnSettingsHelp.Text = "Pagalba";
            this.btnSettingsHelp.UseVisualStyleBackColor = true;
            this.btnSettingsHelp.Click += new System.EventHandler(this.btnSettingsHelp_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 253);
            this.Controls.Add(this.btnSettingsHelp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCheckQrCode);
            this.Controls.Add(this.tbxSuccessfulResponseFragment);
            this.Controls.Add(this.ddlRequestType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSettingsCancel);
            this.Controls.Add(this.btnSettingsOk);
            this.Controls.Add(this.lblSettingsUploadUrl);
            this.Controls.Add(this.tbxUploadUrl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsForm";
            this.Text = "Nustatymai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxUploadUrl;
        private System.Windows.Forms.Label lblSettingsUploadUrl;
        private System.Windows.Forms.Button btnSettingsOk;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox ddlRequestType;
        private System.Windows.Forms.TextBox tbxSuccessfulResponseFragment;
        private System.Windows.Forms.CheckBox cbxCheckQrCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSettingsHelp;
    }
}