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
            int num = 0;
            using (StreamReader reader = new StreamReader(Application.StartupPath + @"\data.txt"))
            {
                while (line != null)
                {
                    line = reader.ReadLine();
                    if (line != null)
                    {
                        dataGridView1.Rows.Add(line.Replace("$n", "\n").Split('|'));
                        num += 1;
                        
                    }

                }

            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(ref dataGridView1);
            form.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            string line = "";
            using (StreamWriter writer = new StreamWriter(Application.StartupPath + @"\data.txt"))
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        if(j != dataGridView1.ColumnCount - 1)
                        {
                            line += (string)dataGridView1[j, i].Value + "|";
                        }
                        else
                        {
                            line += (string)dataGridView1[j, i].Value;
                        }
                    }
                    writer.WriteLine(line.Replace("\n", "$n"));
                    line = "";
                }
                
            }
        }
    }
}
