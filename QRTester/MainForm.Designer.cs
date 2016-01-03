namespace QRTester
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pbxQrImage = new System.Windows.Forms.PictureBox();
            this.btnUploadQr = new System.Windows.Forms.Button();
            this.btnSabotage = new System.Windows.Forms.Button();
            this.btnRunTest = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.tbxConsole = new System.Windows.Forms.TextBox();
            this.ofdUploadImage = new System.Windows.Forms.OpenFileDialog();
            this.btnRevertSabotage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxQrImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxQrImage
            // 
            this.pbxQrImage.Image = ((System.Drawing.Image)(resources.GetObject("pbxQrImage.Image")));
            this.pbxQrImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbxQrImage.InitialImage")));
            this.pbxQrImage.Location = new System.Drawing.Point(12, 12);
            this.pbxQrImage.Name = "pbxQrImage";
            this.pbxQrImage.Size = new System.Drawing.Size(250, 250);
            this.pbxQrImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxQrImage.TabIndex = 0;
            this.pbxQrImage.TabStop = false;
            // 
            // btnUploadQr
            // 
            this.btnUploadQr.Location = new System.Drawing.Point(269, 13);
            this.btnUploadQr.Name = "btnUploadQr";
            this.btnUploadQr.Size = new System.Drawing.Size(123, 23);
            this.btnUploadQr.TabIndex = 1;
            this.btnUploadQr.Text = "Įkelti...";
            this.btnUploadQr.UseVisualStyleBackColor = true;
            this.btnUploadQr.Click += new System.EventHandler(this.btnUploadQr_Click);
            // 
            // btnSabotage
            // 
            this.btnSabotage.Location = new System.Drawing.Point(270, 100);
            this.btnSabotage.Name = "btnSabotage";
            this.btnSabotage.Size = new System.Drawing.Size(123, 23);
            this.btnSabotage.TabIndex = 2;
            this.btnSabotage.Text = "Iškraipyti";
            this.btnSabotage.UseVisualStyleBackColor = true;
            this.btnSabotage.Visible = false;
            this.btnSabotage.Click += new System.EventHandler(this.btnSabotage_Click);
            // 
            // btnRunTest
            // 
            this.btnRunTest.Location = new System.Drawing.Point(270, 71);
            this.btnRunTest.Name = "btnRunTest";
            this.btnRunTest.Size = new System.Drawing.Size(123, 23);
            this.btnRunTest.TabIndex = 4;
            this.btnRunTest.Text = "Testų paketas";
            this.btnRunTest.UseVisualStyleBackColor = true;
            this.btnRunTest.Visible = false;
            this.btnRunTest.Click += new System.EventHandler(this.btnRunTest_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(269, 238);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(123, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Išeiti";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(269, 209);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(123, 23);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Nustatymai";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // tbxConsole
            // 
            this.tbxConsole.Location = new System.Drawing.Point(399, 13);
            this.tbxConsole.Multiline = true;
            this.tbxConsole.Name = "tbxConsole";
            this.tbxConsole.Size = new System.Drawing.Size(595, 249);
            this.tbxConsole.TabIndex = 7;
            // 
            // ofdUploadImage
            // 
            this.ofdUploadImage.FileName = "imageUpload";
            // 
            // btnRevertSabotage
            // 
            this.btnRevertSabotage.Location = new System.Drawing.Point(270, 42);
            this.btnRevertSabotage.Name = "btnRevertSabotage";
            this.btnRevertSabotage.Size = new System.Drawing.Size(123, 23);
            this.btnRevertSabotage.TabIndex = 8;
            this.btnRevertSabotage.Text = "Atstatyti";
            this.btnRevertSabotage.UseVisualStyleBackColor = true;
            this.btnRevertSabotage.Visible = false;
            this.btnRevertSabotage.Click += new System.EventHandler(this.btnRevertSabotage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 281);
            this.Controls.Add(this.btnRevertSabotage);
            this.Controls.Add(this.tbxConsole);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRunTest);
            this.Controls.Add(this.btnSabotage);
            this.Controls.Add(this.btnUploadQr);
            this.Controls.Add(this.pbxQrImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "QR Tester 0.6";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbxQrImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxQrImage;
        private System.Windows.Forms.Button btnUploadQr;
        private System.Windows.Forms.Button btnSabotage;
        private System.Windows.Forms.Button btnRunTest;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.TextBox tbxConsole;
        private System.Windows.Forms.OpenFileDialog ofdUploadImage;
        private System.Windows.Forms.Button btnRevertSabotage;
    }
}

