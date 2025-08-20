using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();  // Инициализация компонентов формы
        }

        // Обработчик события для кнопки
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Ввод значений переменных x, y, z для первого калькулятора
                double x = Convert.ToDouble(xTextBox.Text);
                double y = Convert.ToDouble(yTextBox.Text);
                double z = Convert.ToDouble(zTextBox.Text);

                // Выполнение расчета
                double numerator = Math.Pow(y + Math.Pow(x - 1, 1.0 / 3), 1.0 / 4);
                double denominator = Math.Abs(x - y) * (Math.Pow(Math.Sin(z), 2) + Math.Tan(z));
                double result = numerator / denominator;

                // Отображение результата
                resultLabel.Text = "Результат: " + result.ToString("F5");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


        private void CalculateButton2_Click(object sender, EventArgs e)
        {
            try
            {
                // Ввод значений переменных x, y, z для второго калькулятора
                double x = Convert.ToDouble(textBox1.Text);
                double y = Convert.ToDouble(textBox2.Text);
                double z = Convert.ToDouble(textBox3.Text);

                // Вычисление результата по формуле
                double u = Math.Pow(Math.Tan(x + y), 2) - Math.Exp(y - z) * Math.Sqrt(Math.Cos(Math.Pow(x, 2)) + Math.Sin(Math.Pow(z, 2)));

                // Отображение результата
                resultLabel2.Text = "Результат: " + u.ToString("F5");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }


        private void xTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
