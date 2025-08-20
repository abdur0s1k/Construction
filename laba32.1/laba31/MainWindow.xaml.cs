using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BlockButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.IsEnabled = false;
        }

        private void UnblockButton_Click(object sender, RoutedEventArgs e)
        {
            InputTextBox.IsEnabled = true;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Устанавливаем случайный цвет фона формы
            this.Background = new SolidColorBrush(Colors.LightBlue);

            // Скрываем все элементы на форме
            foreach (UIElement element in MainGrid.Children)
            {
                element.Visibility = Visibility.Collapsed;
            }
        }
    }
}
