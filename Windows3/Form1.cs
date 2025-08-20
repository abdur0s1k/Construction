using System;
using System.Drawing;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        private Timer animationTimer;
        private PointF[] polygonPoints;
        private int numVertices;
        private int currentSegment = 0;
        private float t = 0f; // Параметр интерполяции
        private float circleRadius = 10f;

        public Form1()
        {
            // Настройка формы
            this.Text = "Движение окружности вдоль многоугольника";
            this.Width = 800;
            this.Height = 600;

            // Настройка таймера
            animationTimer = new Timer();
            animationTimer.Interval = 60; // Интервал таймера для анимации
            animationTimer.Tick += AnimationTimer_Tick;

            // Ввод количества вершин
            Label label = new Label();
            label.Text = "Введите количество вершин:";
            label.Location = new Point(10, 10);
            this.Controls.Add(label);

            TextBox vertexInput = new TextBox();
            vertexInput.Location = new Point(150, 10);
            this.Controls.Add(vertexInput);

            Button startButton = new Button();
            startButton.Text = "Начать анимацию";
            startButton.Location = new Point(300, 10);
            startButton.Click += (sender, e) =>
            {
                if (int.TryParse(vertexInput.Text, out numVertices) && numVertices >= 3)
                {
                    GeneratePolygon(numVertices);
                    t = 0f;
                    currentSegment = 0;
                    animationTimer.Start();
                }
                else
                {
                    MessageBox.Show("Введите корректное число вершин (не менее 3).");
                }
            };
            this.Controls.Add(startButton);

            // Подписываемся на событие загрузки формы
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
        }

        // Метод для генерации многоугольника с заданным количеством вершин
        private void GeneratePolygon(int vertices)
        {
            polygonPoints = new PointF[vertices];
            float centerX = this.ClientSize.Width / 2;
            float centerY = this.ClientSize.Height / 2;
            float radius = Math.Min(this.ClientSize.Width, this.ClientSize.Height) / 3;

            for (int i = 0; i < vertices; i++)
            {
                float angle = (float)(2 * Math.PI * i / vertices);
                polygonPoints[i] = new PointF(
                    centerX + radius * (float)Math.Cos(angle),
                    centerY + radius * (float)Math.Sin(angle)
                );
            }
        }

        // Метод для обработки событий таймера и анимации
        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            t += 0.01f; // Увеличиваем параметр интерполяции
            if (t >= 1f)
            {
                t = 0f;
                currentSegment = (currentSegment + 1) % polygonPoints.Length;
            }
            this.Invalidate(); // Перерисовываем форму
        }

        // Метод, который вызывается при перерисовке формы
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if (polygonPoints != null && polygonPoints.Length > 1)
            {
                // Рисуем многоугольник
                g.DrawPolygon(Pens.Black, polygonPoints);

                // Расчет текущей позиции окружности
                PointF start = polygonPoints[currentSegment];
                PointF end = polygonPoints[(currentSegment + 1) % polygonPoints.Length];
                float x = (1 - t) * start.X + t * end.X;
                float y = (1 - t) * start.Y + t * end.Y; 

                // Рисуем окружность
                g.FillEllipse(Brushes.Red, x - circleRadius, y - circleRadius, circleRadius * 2, circleRadius * 2);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Установим начальные значения для анимации
            t = 0f; // Параметр интерполяции (начальное значение)
            currentSegment = 0; // Начальный сегмент многоугольника
            animationTimer.Start(); // Запуск таймера анимации

            // Генерация многоугольника с количеством вершин по умолчанию (например, 5)
            numVertices = 5; // Начальное количество вершин (по умолчанию 5)
            GeneratePolygon(numVertices); // Генерация многоугольника

            // Дополнительная настройка формы
            this.BackColor = Color.White; // Устанавливаем фон формы белым
            this.CenterToScreen(); // Центрируем окно на экране
        }

        // Метод для обработки изменения размера формы
        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();   
        }
    }
}
