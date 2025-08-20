using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media;

namespace WpfAppGradient
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            UpdateCloseButtonState();
        }

        private void UpdateCloseButtonState()
        {
            // Закрыть доступна, если оба поля пустые
            CloseButton.IsEnabled = string.IsNullOrEmpty(TextBox1.Text) && string.IsNullOrEmpty(TextBox2.Text);
        }

        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            UpdateCloseButtonState();
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                try
                {
                    string text = System.IO.File.ReadAllText(dlg.FileName);
                    if (string.IsNullOrEmpty(TextBox1.Text))
                        TextBox1.Text = text;
                    else
                        TextBox2.Text = text;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
                }
            }
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            TextBox1.Clear();
            TextBox2.Clear();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void StyleSelector_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string selected = (StyleSelector.SelectedItem as System.Windows.Controls.ComboBoxItem)?.Content as string;
            switch (selected)
            {
                case "Стандартный":
                    SetTheme(new FontFamily("Segoe UI"), 14, Colors.Black);
                    break;
                case "Тема 1":
                    SetTheme(new FontFamily("Consolas"), 16, Colors.DarkBlue);
                    break;
                case "Тема 2":
                    SetTheme(new FontFamily("Arial"), 18, Colors.DarkRed);
                    break;
                case "Тема 3":
                    SetTheme(new FontFamily("Courier New"), 12, Colors.DarkGreen);
                    break;
            }
        }

        private void SetTheme(FontFamily fontFamily, double fontSize, Color fontColor)
        {
            Resources["SelectedFontFamily"] = fontFamily;
            Resources["SelectedFontSize"] = fontSize;
            Resources["SelectedFontColor"] = new SolidColorBrush(fontColor);
        }
    }
}
