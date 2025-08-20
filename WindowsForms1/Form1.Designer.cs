namespace WindowsFormsApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления для первого калькулятора
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

        // Элементы управления для второго калькулятора
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button calculateButton2;
        private System.Windows.Forms.Label resultLabel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;

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
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.zTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.calculateButton2 = new System.Windows.Forms.Button();
            this.resultLabel2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(50, 50);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 22);
            this.xTextBox.TabIndex = 0;
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(50, 100);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 22);
            this.yTextBox.TabIndex = 1;
            // 
            // zTextBox
            // 
            this.zTextBox.Location = new System.Drawing.Point(50, 150);
            this.zTextBox.Name = "zTextBox";
            this.zTextBox.Size = new System.Drawing.Size(100, 22);
            this.zTextBox.TabIndex = 2;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(50, 200);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 30);
            this.calculateButton.TabIndex = 3;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(47, 242);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(103, 20);
            this.resultLabel.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(160, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Введите x:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(160, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите y:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(160, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Введите z:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(266, 50);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 22);
            this.textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(266, 100);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(84, 22);
            this.textBox2.TabIndex = 9;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(266, 150);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(84, 22);
            this.textBox3.TabIndex = 10;
            // 
            // calculateButton2
            // 
            this.calculateButton2.Location = new System.Drawing.Point(250, 200);
            this.calculateButton2.Name = "calculateButton2";
            this.calculateButton2.Size = new System.Drawing.Size(100, 30);
            this.calculateButton2.TabIndex = 11;
            this.calculateButton2.Text = "Рассчитать";
            this.calculateButton2.Click += new System.EventHandler(this.CalculateButton2_Click);
            // 
            // resultLabel2
            // 
            this.resultLabel2.Location = new System.Drawing.Point(247, 242);
            this.resultLabel2.Name = "resultLabel2";
            this.resultLabel2.Size = new System.Drawing.Size(213, 20);
            this.resultLabel2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(360, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Введите a:";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(360, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Введите b:";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(360, 150);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 23);
            this.label6.TabIndex = 15;
            this.label6.Text = "Введите z:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.xTextBox);
            this.Controls.Add(this.yTextBox);
            this.Controls.Add(this.zTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.calculateButton2);
            this.Controls.Add(this.resultLabel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Name = "Form1";
            this.Text = "Два калькулятора";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
