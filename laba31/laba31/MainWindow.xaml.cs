using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenNewWindow(string windowTitle)
        {
            var newWindow = new NewWindow(windowTitle);
            newWindow.Show();

            this.Close();
        }

        private void OpenButton1_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow("Кнопка 1");
        }

        private void OpenButton2_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow("Кнопка 2");
        }

        private void OpenButton3_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow("Кнопка 3");
        }

        private void OpenButton4_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow("Кнопка 4");
        }

        private void OpenButton5_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow("Кнопка 5");
        }

        private void OpenButton6_Click(object sender, RoutedEventArgs e)
        {
            OpenNewWindow("Кнопка 6");
        }
    }
}