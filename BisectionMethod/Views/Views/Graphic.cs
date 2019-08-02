using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Views.Views
{
    public partial class Graphic : Form
    {
        private readonly List<double> _answerList;

        public Graphic(List<double> answerList)
        {
            try
            {
                InitializeComponent();
                _answerList = answerList;
            }
            catch (Exception e)
            {
                
            }
            
        }

        private void Graphic_Load(object sender, EventArgs e)
        {
            
        }

        private void Graphic_Load_1(object sender, EventArgs e)
        {
            try
            {
                chart1.ChartAreas.Add("load_area");
                chart1.ChartAreas["load_area"].AxisX.Minimum = 0;
                chart1.ChartAreas["load_area"].AxisX.Maximum = _answerList.Count;
                chart1.ChartAreas["load_area"].AxisX.Interval = 1;
                chart1.ChartAreas["load_area"].AxisY.Minimum = _answerList.Min();
                chart1.ChartAreas["load_area"].AxisY.Maximum = _answerList.Max();
                chart1.ChartAreas["load_area"].AxisY.Interval =
                    Math.Abs((_answerList[0] - _answerList[_answerList.Count - 1]) / _answerList.Count);

                chart1.Series.Add("Load");
                chart1.Series["Load"].Color = Color.Orange;
                chart1.Series[0].BorderWidth = 5;
                chart1.Series["Load"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                chart1.ChartAreas["load_area"].Visible = true;
                InitGraph();
            }
            catch (Exception exception)
            {
                MessageBox.Show("Значение найдено с одной итерации");
            }           

        }

        private void InitGraph()
        {
            for (var i = 0; i < _answerList.Count; i++)
            {
                chart1.Series[0].Points.AddXY(i, _answerList[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitGraph();
        }
    }
}
