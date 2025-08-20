using System;
using System.Windows.Forms;
using WindowsFormsApp;

namespace WindowsForms1
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Запуск формы MainForm
            Application.Run(new Form1());
        }
    }
}
