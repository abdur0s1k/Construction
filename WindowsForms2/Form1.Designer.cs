namespace WindowsForms2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления для калькулятора
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox zTextBox;
        private System.Windows.Forms.ComboBox functionComboBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;

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
            this.functionComboBox = new System.Windows.Forms.ComboBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            // functionComboBox
            // 
            this.functionComboBox.Items.AddRange(new object[] {
            "sin(x)",
            "x^2",
            "e^x"});
            this.functionComboBox.Location = new System.Drawing.Point(296, 50);
            this.functionComboBox.Name = "functionComboBox";
            this.functionComboBox.Size = new System.Drawing.Size(121, 24);
            this.functionComboBox.TabIndex = 8;
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
            this.resultLabel.Location = new System.Drawing.Point(50, 250);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(210, 20);
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
            this.Controls.Add(this.functionComboBox);
            this.Name = "Form1";
            this.Text = "Калькулятор";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
