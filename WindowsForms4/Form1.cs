using System;
using System.Text;
using System.Windows.Forms;

namespace WindowsForms4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик кнопки для обработки текста
        private void ProcessButton_Click(object sender, EventArgs e)
        {
            // Получаем строки из ListBox
            StringBuilder result = new StringBuilder();
            foreach (string line in inputListBox.Items)
            {
                string processedLine = ReplaceLatinLettersWithPlus(line);
                result.AppendLine(processedLine);
            }

            // Отображаем результат в Label
            resultLabel.Text = result.ToString();
        }

        // Метод для замены латинских букв на '+'
        private string ReplaceLatinLettersWithPlus(string input)
        {
            StringBuilder output = new StringBuilder(input);

            // Проходим по всем символам строки и заменяем латинские буквы на '+'
            for (int i = 0; i < output.Length; i++)
            {
                char c = output[i];
                if (char.IsLetter(c) && (char.IsLower(c) || char.IsUpper(c)))
                {
                    output[i] = '+';
                }
            }

            return output.ToString();
        }
    }
}
