using System;
using System.Windows.Forms;

namespace WindowsForms3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик кнопки для вычисления значений функции
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Получаем введенные значения
                double x0 = Convert.ToDouble(x0TextBox.Text);
                double xk = Convert.ToDouble(xkTextBox.Text);
                double dx = Convert.ToDouble(dxTextBox.Text);
                double b = Convert.ToDouble(bTextBox.Text);

                // Очистка ListBox перед новым выводом
                resultListBox.Items.Clear();

                // Табулирование функции
                for (double x = x0; x <= xk; x += dx)
                {
                    double y = CalculateY(x, b);  // Вычисление функции
                    resultListBox.Items.Add($"x = {x:F2}, y(x) = {y:F4}");  // Вывод в ListBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);  // Обработка ошибок
            }
        }

        // Метод для вычисления y(x)
        private double CalculateY(double x, double b)
        {
            // Формула для вычисления y
            double part1 = Math.Pow(Math.Abs(x - b), 0.5) * Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 1.5);
            double part2 = Math.Log(Math.Abs(x - b));
            return part1 + part2;
        }
    }
}
