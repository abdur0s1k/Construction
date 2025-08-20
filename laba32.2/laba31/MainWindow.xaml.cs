using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WpfApp
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _resultText = string.Empty;
        public string ResultText
        {
            get => _resultText;
            set
            {
                if (_resultText != value)
                {
                    _resultText = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand AboutCommand { get; }
        public ICommand ReverseCommand { get; }
        public ICommand ExitCommand { get; }

        public MainWindowViewModel()
        {
            AboutCommand = new RelayCommand(_ => ShowAbout());
            ReverseCommand = new RelayCommand(_ => ShowReverseDialog());
            ExitCommand = new RelayCommand(_ => Application.Current.Shutdown());
        }

        private void ShowAbout()
        {
            MessageBox.Show("Разработчик: Алексей", "О программе", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ShowReverseDialog()
        {
            var dialog = new ReverseDialog(ResultText);
            if (dialog.ShowDialog() == true)
            {
                ResultText = dialog.ResultText;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
