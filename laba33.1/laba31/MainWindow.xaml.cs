using System;
using System.Linq;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ProcessButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string input = InputTextBox.Text;
                if (string.IsNullOrWhiteSpace(input))
                    throw new Exception("Введите слова через пробел.");

                string[] words = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (!int.TryParse(LengthTextBox.Text, out int targetLength))
                    throw new Exception("Введите корректное целое число для длины слова.");

                string[] processed = words.Select(word =>
                {
                    if (word.Length == targetLength)
                    {
                        if (word.Length >= 3)
                            return word.Substring(0, word.Length - 3) + "$$$";
                        else
                            return "$$$";
                    }
                    return word;
                }).ToArray();

                ResultTextBlock.Text = "Результат: " + string.Join(" ", processed);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
