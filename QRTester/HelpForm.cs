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
    public partial class HelpForm : Form
    {
        public HelpForm()
        {
            InitializeComponent();
        }

        public void Initialize(Image image)
        {
            Width = image.Width + 50;
            Height = image.Height + 50;

            pbxHelpImage.Width = image.Width;
            pbxHelpImage.Height = image.Height;
            pbxHelpImage.Image = image;
            Refresh();
            ShowDialog();
        }
    }
}
