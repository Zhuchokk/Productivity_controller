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
        DataGridView dataGrid;
        public AddForm(ref DataGridView data)
        {
            InitializeComponent();
            trackBar1.Value = 50;
            trackBar2.Value = 50;
            dataGrid = data;
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

        private bool find(string value)
        {
            for (int i = 0; i < dataGrid.RowCount; i++)
            {
                for (int j = 0; j < dataGrid.ColumnCount; j++)
                    if (dataGrid.Rows[i].Cells[j].Value != null)
                        if (dataGrid.Rows[i].Cells[j].Value.ToString().Contains(value))
                        {
                            return true;
                        }
            }
            return false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (find(dateTimePicker1.Value.ToShortDateString()))
            {
                MessageBox.Show("Row with date " + dateTimePicker1.Value.ToShortDateString() + " is already exist!. You can change this row in the table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ( dateTimePicker1.Value > DateTime.Now)
            {
                MessageBox.Show("You can't add data about a future date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (richTextBox1.Text.Contains('|'))
            {
                MessageBox.Show("Your Comment contains '|', please remove this character", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            dataGrid.Rows.Add(dateTimePicker1.Value.ToShortDateString(), label4.Text, label5.Text, richTextBox1.Text);
            MessageBox.Show("Adding was successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();

        }
    }
}
