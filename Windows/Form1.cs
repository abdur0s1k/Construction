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

namespace Практика_14_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Создаём объект Chart
            Chart chart = new Chart
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(chart);

            // Создаём область графика
            ChartArea chartArea = new ChartArea("MainArea");
            chart.ChartAreas.Add(chartArea);

            // Создаём серию данных
            Series series = new Series("y =2tg^2x-1/((1/2)*sin^2*(x/2))")
            {
                ChartType = SeriesChartType.Spline,
                BorderWidth = 2
            };
            chart.Series.Add(series);

            // Параметры для осей
            double xMin = 2.4;
            double xMax = 3.5;
            double step = 0.1;

            // Добавляем данные на график
            for (double x = xMin; x <= xMax; x += step)
            {
                // Вычисляем значение функции
                double y = 2 * Math.Pow(Math.Tan(x), 2) - 1 / (0.5 * Math.Pow(Math.Sin(x / 2), 2));
                series.Points.AddXY(x, y);
            }

            // Настройки осей
            chartArea.AxisX.Title = "x";
            chartArea.AxisY.Title = "y";
            chartArea.AxisX.Minimum = xMin;
            chartArea.AxisX.Maximum = xMax;
        }
    }
}

