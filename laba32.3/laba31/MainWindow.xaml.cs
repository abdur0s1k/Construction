using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;  // <-- нужно добавить

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        private Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void RunButton_MouseEnter(object sender, MouseEventArgs e)
        {
            double canvasWidth = MainCanvas.ActualWidth;
            double canvasHeight = MainCanvas.ActualHeight;

            double buttonWidth = RunButton.ActualWidth;
            double buttonHeight = RunButton.ActualHeight;

            double maxX = canvasWidth - buttonWidth;
            double maxY = canvasHeight - buttonHeight;

            double newX, newY;

            do
            {
                newX = Canvas.GetLeft(RunButton) + _random.Next(-100, 101);
                newY = Canvas.GetTop(RunButton) + _random.Next(-100, 101);
            }
            while (newX < 0 || newY < 0 || newX > maxX || newY > maxY);

            // Создаём анимацию для Canvas.Left
            DoubleAnimation animX = new DoubleAnimation
            {
                To = newX,
                Duration = TimeSpan.FromMilliseconds(300),
                AccelerationRatio = 0.2,
                DecelerationRatio = 0.8
            };
            // Создаём анимацию для Canvas.Top
            DoubleAnimation animY = new DoubleAnimation
            {
                To = newY,
                Duration = TimeSpan.FromMilliseconds(300),
                AccelerationRatio = 0.2,
                DecelerationRatio = 0.8
            };

            // Запускаем анимацию
            RunButton.BeginAnimation(Canvas.LeftProperty, animX);
            RunButton.BeginAnimation(Canvas.TopProperty, animY);
        }
    }
}
