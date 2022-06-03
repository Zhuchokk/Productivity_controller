using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_controller
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            trackBar1.Value = 50;
            trackBar2.Value = 50;
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = trackBar2.Value.ToString() + "%";
            if (trackBar2.Value * 5 > 255)
            {
                int r = Math.Abs(255 - trackBar2.Value * 5);
                label3.ForeColor = Color.FromArgb(255 - r, 255, 0);
            }
            else
            {
                label3.ForeColor = Color.FromArgb(255, trackBar2.Value * 5, 0);
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label4.Text = trackBar1.Value.ToString() + "%";
            if(trackBar1.Value * 5 > 255)
            {
                int r = Math.Abs(255 - trackBar1.Value * 5);
                label2.ForeColor = Color.FromArgb(255 - r, 255, 0);
            }
            else
            {
                label2.ForeColor = Color.FromArgb(255, trackBar1.Value * 5, 0);
            }
            
        }
    }
}
