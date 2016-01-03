namespace QRTester
{
    partial class ActionLogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionLogForm));
            this.pbcActionLogImage = new System.Windows.Forms.PictureBox();
            this.lblActionLogMessage = new System.Windows.Forms.Label();
            this.btnActionLogOk = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbcActionLogImage)).BeginInit();
            this.SuspendLayout();
            // 
            // pbcActionLogImage
            // 
            this.pbcActionLogImage.Image = ((System.Drawing.Image)(resources.GetObject("pbcActionLogImage.Image")));
            this.pbcActionLogImage.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbcActionLogImage.InitialImage")));
            this.pbcActionLogImage.Location = new System.Drawing.Point(13, 13);
            this.pbcActionLogImage.Name = "pbcActionLogImage";
            this.pbcActionLogImage.Size = new System.Drawing.Size(250, 250);
            this.pbcActionLogImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbcActionLogImage.TabIndex = 0;
            this.pbcActionLogImage.TabStop = false;
            // 
            // lblActionLogMessage
            // 
            this.lblActionLogMessage.AutoSize = true;
            this.lblActionLogMessage.Location = new System.Drawing.Point(277, 13);
            this.lblActionLogMessage.Name = "lblActionLogMessage";
            this.lblActionLogMessage.Size = new System.Drawing.Size(91, 17);
            this.lblActionLogMessage.TabIndex = 1;
            this.lblActionLogMessage.Text = "[Placeholder]";
            // 
            // btnActionLogOk
            // 
            this.btnActionLogOk.Location = new System.Drawing.Point(854, 237);
            this.btnActionLogOk.Name = "btnActionLogOk";
            this.btnActionLogOk.Size = new System.Drawing.Size(75, 23);
            this.btnActionLogOk.TabIndex = 2;
            this.btnActionLogOk.Text = "Ok";
            this.btnActionLogOk.UseVisualStyleBackColor = true;
            this.btnActionLogOk.Click += new System.EventHandler(this.btnActionLogOk_Click);
            // 
            // ActionLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 272);
            this.Controls.Add(this.btnActionLogOk);
            this.Controls.Add(this.lblActionLogMessage);
            this.Controls.Add(this.pbcActionLogImage);
            this.Name = "ActionLogForm";
            this.Text = "ActionLogForm";
            ((System.ComponentModel.ISupportInitialize)(this.pbcActionLogImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbcActionLogImage;
        private System.Windows.Forms.Label lblActionLogMessage;
        private System.Windows.Forms.Button btnActionLogOk;
    }
}