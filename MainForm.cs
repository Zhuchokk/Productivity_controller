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

        

        private void button1_Click(object sender, EventArgs e)
        {
            AddForm form = new AddForm(ref dataGridView1);
            form.Show();
        }
    }
}
