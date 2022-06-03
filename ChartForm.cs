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
        public int[] lmood;
        public int[] lproductivity;
        public DateTime[] dates;
        int dataset;
        SeriesChartType moodtype = SeriesChartType.Column;
        SeriesChartType producttype = SeriesChartType.Column;

        public ChartForm(int[] lm, int[] lp, DateTime[] d)
        {
            InitializeComponent();
            lmood = lm;
            lproductivity = lp;
            dates = d;
            /*//создаем элемент Chart
            Chart myChart = new Chart();
            //кладем его на форму и растягиваем на все окно.
            myChart.Parent = this;

            myChart.Dock = DockStyle.Fill;
            //добавляем в Chart область для рисования графиков, их может быть
            //много, поэтому даем ей имя.
            myChart.ChartAreas.Add(new ChartArea("Math functions"));
            //Создаем и настраиваем набор точек для рисования графика, в том
            //не забыв указать имя области на которой хотим отобразить этот
            //набор точек.
            Series mySeriesOfPoint = new Series("Sinus");
            mySeriesOfPoint.ChartType = SeriesChartType.Line;
            mySeriesOfPoint.ChartArea = "Math functions";
            for (double x = -Math.PI; x <= Math.PI; x += Math.PI / 10.0)
            {
                mySeriesOfPoint.Points.AddXY(x, Math.Sin(x));
            }
            //Добавляем созданный набор точек в Chart
            myChart.Series.Add(mySeriesOfPoint);*/
            int num = 7;
            if(lmood.Length < num) { num = lmood.Length; }
            dataset = num;
            Series mySeriesOfPoint = new Series("Mood");
            mySeriesOfPoint.ChartType = SeriesChartType.Column;
            mySeriesOfPoint.ChartArea = "ChartArea1";
            for (int i=0; i < num; i++)
            {
                mySeriesOfPoint.Points.AddXY(dates[i], lmood[i]);
            }
            chart1.Series.Add(mySeriesOfPoint);

            Series mySeriesOfPoint2 = new Series("Productivity");
            mySeriesOfPoint2.ChartType = SeriesChartType.Column;
            mySeriesOfPoint2.ChartArea = "ChartArea1";
            for (int i = 0; i < num; i++)
            {
                mySeriesOfPoint2.Points.AddXY(dates[i], lproductivity[i]);
            }
            chart1.Series.Add(mySeriesOfPoint2);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Contains("7"))
            {
                if(lmood.Length < 7)
                {
                    dataset = lmood.Length;
                }
                else
                {
                    dataset = 7;
                }
            } else if (comboBox3.Text.Contains("30"))
            {
                if(lmood.Length < 30)
                {
                    dataset = lmood.Length;
                }
                else
                {
                    dataset = 30;
                }
            }
            else
            {
                dataset = lmood.Length;
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
                mySeriesOfPoint.Points.AddXY(dates[i], lmood[i]);
            }
            chart1.Series.Add(mySeriesOfPoint);

            Series mySeriesOfPoint2 = new Series("Productivity");
            mySeriesOfPoint2.ChartType = producttype;
            mySeriesOfPoint2.ChartArea = "ChartArea1";
            for (int i = 0; i < dataset; i++)
            {
                mySeriesOfPoint2.Points.AddXY(dates[i], lproductivity[i]);
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
