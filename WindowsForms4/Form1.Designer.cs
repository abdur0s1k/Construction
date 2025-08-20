namespace WindowsForms4
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.ListBox inputListBox;
        private System.Windows.Forms.Button processButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            this.inputListBox = new System.Windows.Forms.ListBox();
            this.processButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // Настройка ListBox для ввода строк
            this.inputListBox.FormattingEnabled = true;
            this.inputListBox.Location = new System.Drawing.Point(30, 30);
            this.inputListBox.Size = new System.Drawing.Size(400, 100);

            // Настройка кнопки для обработки текста
            this.processButton.Text = "Обработать";
            this.processButton.Location = new System.Drawing.Point(30, 150);
            this.processButton.Size = new System.Drawing.Size(100, 30);
            this.processButton.Click += new System.EventHandler(this.ProcessButton_Click);

            // Настройка Label для вывода результата
            this.resultLabel.Location = new System.Drawing.Point(30, 200);
            this.resultLabel.Size = new System.Drawing.Size(400, 30);

            // Настройка меток
            this.label1.Text = "Введите строки:";
            this.label1.Location = new System.Drawing.Point(30, 10);
            this.label2.Text = "Результат:";
            this.label2.Location = new System.Drawing.Point(30, 180);

            // Настройка формы
            this.ClientSize = new System.Drawing.Size(500, 300);
            this.Controls.Add(this.inputListBox);
            this.Controls.Add(this.processButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "Form1";
            this.Text = "Замена букв на +";
            this.ResumeLayout(false);
        }

        #endregion
    }
}
