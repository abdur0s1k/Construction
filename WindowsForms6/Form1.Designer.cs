namespace WindowsForms6
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Button fillMatrixButton;
        private System.Windows.Forms.Button findMaxButton;
        private System.Windows.Forms.ListBox matrixListBox;
        private System.Windows.Forms.Label resultLabel;

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
            this.fillMatrixButton = new System.Windows.Forms.Button();
            this.findMaxButton = new System.Windows.Forms.Button();
            this.matrixListBox = new System.Windows.Forms.ListBox();
            this.resultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fillMatrixButton
            // 
            this.fillMatrixButton.Location = new System.Drawing.Point(30, 30);
            this.fillMatrixButton.Name = "fillMatrixButton";
            this.fillMatrixButton.Size = new System.Drawing.Size(150, 30);
            this.fillMatrixButton.TabIndex = 0;
            this.fillMatrixButton.Text = "Заполнить матрицу";
            this.fillMatrixButton.Click += new System.EventHandler(this.FillMatrixButton_Click);
            // 
            // findMaxButton
            // 
            this.findMaxButton.Location = new System.Drawing.Point(30, 70);
            this.findMaxButton.Name = "findMaxButton";
            this.findMaxButton.Size = new System.Drawing.Size(150, 30);
            this.findMaxButton.TabIndex = 1;
            this.findMaxButton.Text = "Найти максимум";
            this.findMaxButton.Click += new System.EventHandler(this.FindMaxButton_Click);
            // 
            // matrixListBox
            // 
            this.matrixListBox.ItemHeight = 16;
            this.matrixListBox.Location = new System.Drawing.Point(200, 30);
            this.matrixListBox.Name = "matrixListBox";
            this.matrixListBox.Size = new System.Drawing.Size(300, 196);
            this.matrixListBox.TabIndex = 2;
            // 
            // resultLabel
            // 
            this.resultLabel.Location = new System.Drawing.Point(30, 120);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(164, 92);
            this.resultLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(600, 300);
            this.Controls.Add(this.fillMatrixButton);
            this.Controls.Add(this.findMaxButton);
            this.Controls.Add(this.matrixListBox);
            this.Controls.Add(this.resultLabel);
            this.Name = "Form1";
            this.Text = "Поиск максимума в матрице";
            this.ResumeLayout(false);

        }

        #endregion
    }
}
