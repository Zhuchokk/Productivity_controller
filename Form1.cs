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
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}
