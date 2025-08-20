using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsForms6
{
    public partial class Form1 : Form
    {
        private int[,] matrix = new int[15, 15];

        public Form1()
        {
            InitializeComponent();
        }

        // Заполнение матрицы случайными числами
        private void FillMatrixButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            matrixListBox.Items.Clear(); // Очистка ListBox перед добавлением новой матрицы

            for (int i = 0; i < 15; i++)
            {
                string row = "";
                for (int j = 0; j < 15; j++)
                {
                    matrix[i, j] = rand.Next(-100, 101); // Заполнение случайными числами от -100 до 100
                    row += matrix[i, j] + "\t";
                }
                matrixListBox.Items.Add(row); // Добавляем строку в ListBox
            }
        }

        // Поиск наибольшего элемента на главной диагонали и вывод строки
        private void FindMaxButton_Click(object sender, EventArgs e)
        {
            int maxElement = matrix[0, 0]; // Начинаем с первого элемента на диагонали
            int maxRow = 0; // Строка, где находится максимальный элемент

            // Проходим по главной диагонали
            for (int i = 1; i < 15; i++)
            {
                if (matrix[i, i] > maxElement)
                {
                    maxElement = matrix[i, i];
                    maxRow = i;
                }
            }

            // Вывод строки с максимальным элементом
            string resultRow = "Строка с максимальным элементом на диагонали: ";
            for (int j = 0; j < 15; j++)
            {
                resultRow += matrix[maxRow, j] + "\t";
            }

            resultLabel.Text = $"Максимум на главной диагонали: {maxElement}. {resultRow}";
        }
    }
}
