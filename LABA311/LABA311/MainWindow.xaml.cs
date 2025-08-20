using System.Windows;

namespace EmployeeCardApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OpenEmployeeCard_Click(object sender, RoutedEventArgs e)
        {
            var cardWindow = new EmployeeCardWindow();
            cardWindow.Show();
        }
    }
}