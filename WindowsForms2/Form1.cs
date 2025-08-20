using System;
using System.Windows.Forms;

namespace WindowsForms2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Ввод значений переменных x, y, z
                double x = Convert.ToDouble(xTextBox.Text);
                double y = Convert.ToDouble(yTextBox.Text);
                double z = Convert.ToDouble(zTextBox.Text);

                // Выбор функции f(x)
                double fx;
                if (functionComboBox.SelectedIndex == 0)
                {
                    // f(x) = sin(x)
                    fx = Math.Sin(x);
                }
                else if (functionComboBox.SelectedIndex == 1)
                {
                    // f(x) = x^2
                    fx = Math.Pow(x, 2);
                }
                else
                {
                    // f(x) = e^x
                    fx = Math.Exp(x);
                }

                // Вычисление p по формуле
                double p = (Math.Abs(Math.Min(fx, y) - Math.Max(y, z))) / 2;

                // Отображение результата
                resultLabel.Text = "Результат: " + p.ToString("F5");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
