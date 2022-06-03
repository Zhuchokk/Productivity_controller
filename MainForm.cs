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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
            int[] lmood = new int[dataGridView1.RowCount];
            int[] lproductivity = new int[dataGridView1.RowCount];
            DateTime[] dates = new DateTime[dataGridView1.RowCount];
            

            for(int i=0; i < dataGridView1.RowCount; i++)
            {
                lmood[i] = Convert.ToInt32( dataGridView1[2, i].Value.ToString().Substring(0, dataGridView1[2, i].Value.ToString().Length -1));
                lproductivity[i] = Convert.ToInt32(dataGridView1[1, i].Value.ToString().Substring(0, dataGridView1[1, i].Value.ToString().Length - 1));
                dates[i] = DateTime.Parse(dataGridView1[0, i].Value.ToString());
            }
            ChartForm form = new ChartForm(lmood, lproductivity, dates);
            form.Show();
            
        }
    }
}
