using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Productivity_controller
{
    public partial class ChartForm : Form
    {
        public Row[] rows;
        int dataset;
        SeriesChartType moodtype = SeriesChartType.Column;
        SeriesChartType producttype = SeriesChartType.Column;

        public ChartForm(Row[] r)
        {
            InitializeComponent();
            rows = r;
            int num = 7;
            if(rows.Length < num) { num = rows.Length; }
            dataset = num;
            Series mySeriesOfPoint = new Series("Mood");
            mySeriesOfPoint.ChartType = SeriesChartType.Column;
            mySeriesOfPoint.ChartArea = "ChartArea1";
            for (int i=0; i < num; i++)
            {
                mySeriesOfPoint.Points.AddXY(rows[i].date, rows[i].mood);
            }
            chart1.Series.Add(mySeriesOfPoint);

            Series mySeriesOfPoint2 = new Series("Productivity");
            mySeriesOfPoint2.ChartType = SeriesChartType.Column;
            mySeriesOfPoint2.ChartArea = "ChartArea1";
            for (int i = 0; i < num; i++)
            {
                mySeriesOfPoint2.Points.AddXY(rows[i].date, rows[i].productivity);
            }
            chart1.Series.Add(mySeriesOfPoint2);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Contains("7"))
            {
                if(rows.Length < 7)
                {
                    dataset = rows.Length;
                }
                else
                {
                    dataset = 7;
                }
            } else if (comboBox3.Text.Contains("30"))
            {
                if(rows.Length < 30)
                {
                    dataset = rows.Length;
                }
                else
                {
                    dataset = 30;
                }
            }
            else
            {
                dataset = rows.Length;
            }
            update();
        }

        public void update()
        {
            chart1.Series.Clear();
            Series mySeriesOfPoint = new Series("Mood");
            mySeriesOfPoint.ChartType = moodtype;
            mySeriesOfPoint.ChartArea = "ChartArea1";
            for (int i = 0; i < dataset; i++)
            {
                mySeriesOfPoint.Points.AddXY(rows[i].date, rows[i].mood);
            }
            chart1.Series.Add(mySeriesOfPoint);

            Series mySeriesOfPoint2 = new Series("Productivity");
            mySeriesOfPoint2.ChartType = producttype;
            mySeriesOfPoint2.ChartArea = "ChartArea1";
            for (int i = 0; i < dataset; i++)
            {
                mySeriesOfPoint2.Points.AddXY(rows[i].date, rows[i].productivity);
            }
            chart1.Series.Add(mySeriesOfPoint2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //mood
            
            if(comboBox2.Text == "Line")
            {
                moodtype = SeriesChartType.Line;
            } else if(comboBox2.Text == "FastLine")
            {
                moodtype = SeriesChartType.FastLine;
            } else if (comboBox2.Text == "SpLine")
            {
                moodtype = SeriesChartType.Spline;
            } else if(comboBox2.Text == "Column")
            {
                moodtype = SeriesChartType.Column;
            } else if(comboBox2.Text == "Area")
            {
                moodtype = SeriesChartType.Area;
            } else if(comboBox2.Text == "Bubble")
            {
                moodtype = SeriesChartType.Bubble;
            }
            else
            {
                moodtype = SeriesChartType.Point;
            }
            chart1.Series[0].ChartType = moodtype;
            chart1.Update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //productivity
            if(comboBox1.Text == "Line")
            {
                producttype = SeriesChartType.Line;
            } else if(comboBox1.Text == "FastLine")
            {
                producttype = SeriesChartType.FastLine;
            } else if (comboBox1.Text == "SpLine")
            {
                producttype = SeriesChartType.Spline;
            } else if(comboBox1.Text == "Column")
            {
                producttype = SeriesChartType.Column;
            } else if(comboBox1.Text == "Area")
            {
                producttype = SeriesChartType.Area;
            } else if(comboBox1.Text == "Bubble")
            {
                producttype = SeriesChartType.Bubble;
            }
            else
            {
                producttype = SeriesChartType.Point;
            }
            chart1.Series[1].ChartType = producttype;
            chart1.Update();
        }
    }
}
