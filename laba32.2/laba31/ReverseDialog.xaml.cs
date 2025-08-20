using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace WpfApp
{
    public partial class ReverseDialog : Window, INotifyPropertyChanged
    {
        private string _inputText;
        public string InputText
        {
            get => _inputText;
            set
            {
                if (_inputText != value)
                {
                    _inputText = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isUpperCase;
        public bool IsUpperCase
        {
            get => _isUpperCase;
            set
            {
                if (_isUpperCase != value)
                {
                    _isUpperCase = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool _isReverse;
        public bool IsReverse
        {
            get => _isReverse;
            set
            {
                if (_isReverse != value)
                {
                    _isReverse = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand OkCommand { get; }

        public string ResultText { get; private set; } = "";

        public ReverseDialog(string initialText)
        {
            InitializeComponent();
            DataContext = this;
            InputText = initialText;

            OkCommand = new RelayCommand(_ => OnOk());
        }

        private void OnOk()
        {
            string result = InputText;

            if (IsReverse)
            {
                char[] arr = result.ToCharArray();
                System.Array.Reverse(arr);
                result = new string(arr);
            }

            if (IsUpperCase)
            {
                result = result.ToUpper();
            }

            ResultText = result;
            DialogResult = true;
            Close();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
