using System;
using System.Windows.Forms;

namespace Практика_14_1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Настройка визуальных эффектов
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск формы
            Application.Run(new Form1());
        }
    }
}
