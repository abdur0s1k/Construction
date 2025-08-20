using System.Windows;

namespace WpfApp
{
    public partial class NewWindow : Window
    {
        public string Title { get; set; }
        public string Message { get; set; }

        public NewWindow(string title)
        {
            InitializeComponent();
            Title = title;
            Message = $"Вы выбрали: {title}";
            DataContext = this;
        }
    }
}