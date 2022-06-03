using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_controller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string line = "";
            using(StreamReader reader = new StreamReader(Application.StartupPath + @"\data.txt")){
                while (line != null)
                {
                    line = reader.ReadLine();
                    if(line != null)
                    {
                        dataGridView1.Rows.Add(line.Split('|'));
                    }
                    
                }
                
            }
            

        }

        private bool find(string value)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString().Contains(value))
                        {
                            return true;
                        }
            }
            return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine();
            if (find(DateTime.Now.ToShortDateString()))
            {
                MessageBox.Show("Row with date " + DateTime.Now.ToShortDateString() + " is already exist!. You can change this row in the table.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AddForm form = new AddForm();
            form.Show();
        }
    }
}
