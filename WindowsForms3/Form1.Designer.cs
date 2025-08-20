namespace WindowsForms3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Элементы управления
        private System.Windows.Forms.TextBox x0TextBox;
        private System.Windows.Forms.TextBox xkTextBox;
        private System.Windows.Forms.TextBox dxTextBox;
        private System.Windows.Forms.TextBox bTextBox;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.ListBox resultListBox;
        private System.Windows.Forms.Label labelX0;
        private System.Windows.Forms.Label labelXk;
        private System.Windows.Forms.Label labelDx;
        private System.Windows.Forms.Label labelB;
        private System.Windows.Forms.Label labelResults;

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
            this.x0TextBox = new System.Windows.Forms.TextBox();
            this.xkTextBox = new System.Windows.Forms.TextBox();
            this.dxTextBox = new System.Windows.Forms.TextBox();
            this.bTextBox = new System.Windows.Forms.TextBox();
            this.calculateButton = new System.Windows.Forms.Button();
            this.resultListBox = new System.Windows.Forms.ListBox();
            this.labelX0 = new System.Windows.Forms.Label();
            this.labelXk = new System.Windows.Forms.Label();
            this.labelDx = new System.Windows.Forms.Label();
            this.labelB = new System.Windows.Forms.Label();
            this.labelResults = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // x0TextBox
            // 
            this.x0TextBox.Location = new System.Drawing.Point(80, 30);
            this.x0TextBox.Name = "x0TextBox";
            this.x0TextBox.Size = new System.Drawing.Size(100, 22);
            this.x0TextBox.TabIndex = 0;
            // 
            // xkTextBox
            // 
            this.xkTextBox.Location = new System.Drawing.Point(80, 70);
            this.xkTextBox.Name = "xkTextBox";
            this.xkTextBox.Size = new System.Drawing.Size(100, 22);
            this.xkTextBox.TabIndex = 1;
            // 
            // dxTextBox
            // 
            this.dxTextBox.Location = new System.Drawing.Point(80, 110);
            this.dxTextBox.Name = "dxTextBox";
            this.dxTextBox.Size = new System.Drawing.Size(100, 22);
            this.dxTextBox.TabIndex = 2;
            // 
            // bTextBox
            // 
            this.bTextBox.Location = new System.Drawing.Point(80, 150);
            this.bTextBox.Name = "bTextBox";
            this.bTextBox.Size = new System.Drawing.Size(100, 22);
            this.bTextBox.TabIndex = 3;
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(80, 190);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(100, 30);
            this.calculateButton.TabIndex = 4;
            this.calculateButton.Text = "Рассчитать";
            this.calculateButton.Click += new System.EventHandler(this.CalculateButton_Click);
            // 
            // resultListBox
            // 
            this.resultListBox.ItemHeight = 16;
            this.resultListBox.Location = new System.Drawing.Point(107, 230);
            this.resultListBox.Name = "resultListBox";
            this.resultListBox.Size = new System.Drawing.Size(300, 148);
            this.resultListBox.TabIndex = 5;
            // 
            // labelX0
            // 
            this.labelX0.Location = new System.Drawing.Point(30, 30);
            this.labelX0.Name = "labelX0";
            this.labelX0.Size = new System.Drawing.Size(100, 23);
            this.labelX0.TabIndex = 6;
            this.labelX0.Text = "x0:";
            // 
            // labelXk
            // 
            this.labelXk.Location = new System.Drawing.Point(30, 70);
            this.labelXk.Name = "labelXk";
            this.labelXk.Size = new System.Drawing.Size(100, 23);
            this.labelXk.TabIndex = 7;
            this.labelXk.Text = "xk:";
            // 
            // labelDx
            // 
            this.labelDx.Location = new System.Drawing.Point(30, 110);
            this.labelDx.Name = "labelDx";
            this.labelDx.Size = new System.Drawing.Size(100, 23);
            this.labelDx.TabIndex = 8;
            this.labelDx.Text = "dx:";
            // 
            // labelB
            // 
            this.labelB.Location = new System.Drawing.Point(30, 150);
            this.labelB.Name = "labelB";
            this.labelB.Size = new System.Drawing.Size(100, 23);
            this.labelB.TabIndex = 9;
            this.labelB.Text = "b:";
            // 
            // labelResults
            // 
            this.labelResults.Location = new System.Drawing.Point(1, 230);
            this.labelResults.Name = "labelResults";
            this.labelResults.Size = new System.Drawing.Size(100, 23);
            this.labelResults.TabIndex = 10;
            this.labelResults.Text = "Результаты:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.Controls.Add(this.x0TextBox);
            this.Controls.Add(this.xkTextBox);
            this.Controls.Add(this.dxTextBox);
            this.Controls.Add(this.bTextBox);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.resultListBox);
            this.Controls.Add(this.labelX0);
            this.Controls.Add(this.labelXk);
            this.Controls.Add(this.labelDx);
            this.Controls.Add(this.labelB);
            this.Controls.Add(this.labelResults);
            this.Name = "Form1";
            this.Text = "Табулирование функции";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
