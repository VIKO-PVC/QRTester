using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QRTester
{
    public partial class ActionLogForm : Form
    {
        public ActionLogForm()
        {
            InitializeComponent();
        }

        public void Initialize(Image picture, string message)
        {
            if (picture != null)
            {
                pbcActionLogImage.Image = picture;
            }
            else
            {

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
