using System;

class Program
{
    static void Main()
    {
        int[,] matrix = {
            {1, 2, 3},
            {4, 5, 6},
            {7, 8, 9}
        };

        int p = 4; // Количество сдвигов
        bool shiftRight = true; // true - сдвиг вправо, false - вниз

        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        if (shiftRight)
        {
            p = p % cols; // Учитываем количество столбцов
            if (p != 0)
            {
                for (int i = 0; i < rows; i++)
                {
                    int[] temp = new int[cols];
                    for (int j = 0; j < cols; j++)
                    {
                        temp[(j + p) % cols] = matrix[i, j];
                    }
                    for (int j = 0; j < cols; j++)
                    {
                        matrix[i, j] = temp[j];
                    }
                }
            }
        }
        else
        {
            p = p % rows; // Учитываем количество строк
            if (p != 0)
            {
                for (int j = 0; j < cols; j++)
                {
                    int[] temp = new int[rows];
                    for (int i = 0; i < rows; i++)
                    {
                        temp[(i + p) % rows] = matrix[i, j];
                    }
                    for (int i = 0; i < rows; i++)
                    {
                        matrix[i, j] = temp[i];
                    }
                }
            }
        }

        // Печать матрицы
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}