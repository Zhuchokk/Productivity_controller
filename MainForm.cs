using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productivity_controller
{
    
    public partial class MainForm : Form
    {
        public DataTable table = new DataTable();
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
            dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Ascending);
            int[] lmood = new int[dataGridView1.RowCount];
            int[] lproductivity = new int[dataGridView1.RowCount];
            DateTime[] dates = new DateTime[dataGridView1.RowCount];
            Row[] rows = new Row[ dataGridView1.RowCount ];

            for(int i=0; i < dataGridView1.RowCount; i++)
            {
                lmood[i] = Convert.ToInt32( dataGridView1[2, i].Value.ToString().Substring(0, dataGridView1[2, i].Value.ToString().Length -1));
                lproductivity[i] = Convert.ToInt32(dataGridView1[1, i].Value.ToString().Substring(0, dataGridView1[1, i].Value.ToString().Length - 1));
                dates[i] = DateTime.Parse(dataGridView1[0, i].Value.ToString());
                rows[i] = new Row(dates[i], lproductivity[i], lmood[i]);
            }
            
            rows = rows.OrderByDescending(x => x.date.Date).ToArray();
            foreach(Row row in rows)
            {
                Console.WriteLine(row.date);
            }
            ChartForm form = new ChartForm(rows);
            form.Show();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Do you want to clear all data in table?", "Question", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question,MessageBoxDefaultButton.Button3);
            if(res == DialogResult.Yes)
            {
                dataGridView1.Rows.Clear();
            }
            
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if(e.ColumnIndex != 1 && e.ColumnIndex != 2)
            {
                return;
            }
            string str = e.FormattedValue.ToString();
            Console.WriteLine(str.Substring(0, str.Length - 1));
            if (!(str[str.Length - 1] == '%' && IsDigitsOnly(str.Substring(0, str.Length - 1)) && Convert.ToInt32(str.Substring(0, str.Length - 1)) <=100))
            {
                ((DataGridView)sender).CancelEdit();
                MessageBox.Show("The 'Productivity' and 'Mood' fields should only consist of numbers and a % at the end. Also, these fields should not exceed 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
                
        }
    }
}
