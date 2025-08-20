using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsForms5
{
    public partial class Form1 : Form
    {
        private int[] arrayA = new int[30];

        public Form1()
        {
            InitializeComponent();
        }

        // Заполнение массива случайными числами
        private void FillButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            listBoxOriginal.Items.Clear(); // Очистка ListBox перед добавлением новых элементов

            for (int i = 0; i < arrayA.Length; i++)
            {
                arrayA[i] = rand.Next(-50, 50); // Заполняем массив случайными числами от -50 до 50
                listBoxOriginal.Items.Add($"Mas[{i}] = {arrayA[i]}"); // Добавляем элементы в ListBox
            }
        }

        // Вычисление суммы отрицательных нечетных чисел
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            int sum = 0;
            listBoxResult.Items.Clear(); // Очистка ListBox перед выводом результатов

            // Фильтруем массив для нахождения отрицательных нечетных чисел
            var oddNegativeNumbers = arrayA.Where(x => x < 0 && x % 2 != 0).ToArray();

            foreach (var num in oddNegativeNumbers)
            {
                sum += num; // Суммируем отрицательные нечетные числа
                listBoxResult.Items.Add($"Mas[{Array.IndexOf(arrayA, num)}] = {num}"); // Выводим результат в ListBox
            }

            // Вывод суммы в Label
            MessageBox.Show($"Сумма отрицательных нечетных чисел: {sum}", "Результат");
        }
    }
}
