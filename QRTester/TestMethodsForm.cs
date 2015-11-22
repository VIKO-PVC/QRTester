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
    public partial class TestMethodsForm : Form
    {
        public TestMethodsForm()
        {
            InitializeComponent();
        }

        private void btnSabotageOk_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSabotageCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
