using System;
using System.Drawing;
using System.Windows.Forms;

namespace Form1
{
    public partial class Form1 : Form
    {
        private bool shouldDraw = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            shouldDraw = true; // Разрешаем рисование
            this.Invalidate(); // Вызываем перерисовку формы
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!shouldDraw) return;

            Graphics g = e.Graphics;

            // Получаем размеры окна
            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            // Коэффициенты масштабирования
            float scaleX = width / 800f;
            float scaleY = height / 600f;

            // Создаем кисти и перья
            SolidBrush spaceBrush = new SolidBrush(Color.Black);  // Космический фон
            SolidBrush astronautBrush = new SolidBrush(Color.LightBlue); // Космонавт
            SolidBrush eyeBrush = new SolidBrush(Color.Black);  // Глаза космонавта
            SolidBrush planetBrush = new SolidBrush(Color.Orange);  // Планета
            SolidBrush starBrush = new SolidBrush(Color.White);  // Звезды

            // Космический фон
            g.FillRectangle(spaceBrush, 0, 0, width, height);

            // Звезды
            Random rand = new Random();
            for (int i = 0; i < 100; i++)
            {
                int starX = rand.Next(0, width);
                int starY = rand.Next(0, height);
                g.FillEllipse(starBrush, starX, starY, 2, 2);
            }

            // Планеты
            g.FillEllipse(planetBrush, (int)(width / 3), (int)(height / 4), (int)(100 * scaleX), (int)(100 * scaleY));
            g.FillEllipse(planetBrush, (int)(2 * width / 3), (int)(height / 2), (int)(150 * scaleX), (int)(150 * scaleY));

            // Космонавт (вместо колобка)
            int astronautSize = (int)(80 * scaleX);
            int astronautX = (int)(width / 2 - astronautSize / 2);
            int astronautY = (int)(height / 2 - astronautSize / 2);
            g.FillEllipse(astronautBrush, astronautX, astronautY, astronautSize, astronautSize); // Тело космонавта

            // Глаза космонавта
            int eyeSize = (int)(15 * scaleX);
            int leftEyeX = astronautX + (int)(20 * scaleX);
            int rightEyeX = astronautX + (int)(45 * scaleX);
            int eyeY = astronautY + (int)(25 * scaleY);
            g.FillEllipse(eyeBrush, leftEyeX, eyeY, eyeSize, eyeSize);
            g.FillEllipse(eyeBrush, rightEyeX, eyeY, eyeSize, eyeSize);

            // Добавим астероиды
            SolidBrush asteroidBrush = new SolidBrush(Color.Gray);
            g.FillEllipse(asteroidBrush, (int)(width / 2 + 150 * scaleX), (int)(height / 4 + 50 * scaleY), (int)(30 * scaleX), (int)(30 * scaleY));
            g.FillEllipse(asteroidBrush, (int)(width / 3 - 100 * scaleX), (int)(height / 2 - 100 * scaleY), (int)(40 * scaleX), (int)(40 * scaleY));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Добавляем кнопку для запуска рисования
            Button btnDraw = new Button();
            btnDraw.Text = "Нарисовать Космонавта";
            btnDraw.Location = new Point(10, 10);
            btnDraw.Click += btnDraw_Click;
            this.Controls.Add(btnDraw);

            // Подключаем событие Paint
            this.Paint += Form1_Paint;
        }
    }
}
