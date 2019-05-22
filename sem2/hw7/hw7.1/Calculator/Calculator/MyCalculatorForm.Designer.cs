namespace homework
{
    partial class MyCalculatorForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox = new System.Windows.Forms.TextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.backspaceButton = new System.Windows.Forms.Button();
            this.divideButton = new System.Windows.Forms.Button();
            this.sevenButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.eightButton = new System.Windows.Forms.Button();
            this.nineButton = new System.Windows.Forms.Button();
            this.multiplyButton = new System.Windows.Forms.Button();
            this.fourButton = new System.Windows.Forms.Button();
            this.fiveButton = new System.Windows.Forms.Button();
            this.sixButton = new System.Windows.Forms.Button();
            this.minusButton = new System.Windows.Forms.Button();
            this.oneButton = new System.Windows.Forms.Button();
            this.twoButton = new System.Windows.Forms.Button();
            this.threeButton = new System.Windows.Forms.Button();
            this.plusButton = new System.Windows.Forms.Button();
            this.plusMinusButton = new System.Windows.Forms.Button();
            this.zeroButton = new System.Windows.Forms.Button();
            this.commaButton = new System.Windows.Forms.Button();
            this.resultButton = new System.Windows.Forms.Button();
            this.label = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.tableLayoutPanel1.SetColumnSpan(this.textBox, 4);
            this.textBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(3, 50);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox.Size = new System.Drawing.Size(396, 41);
            this.textBox.TabIndex = 0;
            this.textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnTextBoxKeyPress);
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.clearButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.clearButton.Location = new System.Drawing.Point(3, 97);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(94, 76);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "C";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.OnClearButtonClick);
            // 
            // backspaceButton
            // 
            this.backspaceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.backspaceButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backspaceButton.Location = new System.Drawing.Point(103, 97);
            this.backspaceButton.Name = "backspaceButton";
            this.backspaceButton.Size = new System.Drawing.Size(94, 76);
            this.backspaceButton.TabIndex = 7;
            this.backspaceButton.Text = "<-";
            this.backspaceButton.UseVisualStyleBackColor = true;
            this.backspaceButton.Click += new System.EventHandler(this.OnBackspaceButtonClick);
            // 
            // divideButton
            // 
            this.divideButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.divideButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.divideButton.Location = new System.Drawing.Point(303, 343);
            this.divideButton.Name = "divideButton";
            this.divideButton.Size = new System.Drawing.Size(96, 76);
            this.divideButton.TabIndex = 8;
            this.divideButton.Text = "/";
            this.divideButton.UseVisualStyleBackColor = true;
            this.divideButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // sevenButton
            // 
            this.sevenButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sevenButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sevenButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sevenButton.Location = new System.Drawing.Point(3, 179);
            this.sevenButton.Name = "sevenButton";
            this.sevenButton.Size = new System.Drawing.Size(94, 76);
            this.sevenButton.TabIndex = 9;
            this.sevenButton.Text = "7";
            this.sevenButton.UseVisualStyleBackColor = false;
            this.sevenButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.textBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.sevenButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.divideButton, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.backspaceButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.clearButton, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.eightButton, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.nineButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.multiplyButton, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.fourButton, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.fiveButton, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.sixButton, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.minusButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.oneButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.twoButton, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.threeButton, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.plusButton, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.plusMinusButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.zeroButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.commaButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.resultButton, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.label, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.456393F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.456393F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.21744F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.21744F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.21744F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.21744F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.21744F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(402, 507);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // eightButton
            // 
            this.eightButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.eightButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.eightButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.eightButton.Location = new System.Drawing.Point(103, 179);
            this.eightButton.Name = "eightButton";
            this.eightButton.Size = new System.Drawing.Size(94, 76);
            this.eightButton.TabIndex = 10;
            this.eightButton.Text = "8";
            this.eightButton.UseVisualStyleBackColor = false;
            this.eightButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // nineButton
            // 
            this.nineButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.nineButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nineButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nineButton.Location = new System.Drawing.Point(203, 179);
            this.nineButton.Name = "nineButton";
            this.nineButton.Size = new System.Drawing.Size(94, 76);
            this.nineButton.TabIndex = 11;
            this.nineButton.Text = "9";
            this.nineButton.UseVisualStyleBackColor = false;
            this.nineButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // multiplyButton
            // 
            this.multiplyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiplyButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.multiplyButton.Location = new System.Drawing.Point(303, 261);
            this.multiplyButton.Name = "multiplyButton";
            this.multiplyButton.Size = new System.Drawing.Size(96, 76);
            this.multiplyButton.TabIndex = 12;
            this.multiplyButton.Text = "*";
            this.multiplyButton.UseVisualStyleBackColor = true;
            this.multiplyButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // fourButton
            // 
            this.fourButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fourButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fourButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fourButton.Location = new System.Drawing.Point(3, 261);
            this.fourButton.Name = "fourButton";
            this.fourButton.Size = new System.Drawing.Size(94, 76);
            this.fourButton.TabIndex = 13;
            this.fourButton.Text = "4";
            this.fourButton.UseVisualStyleBackColor = false;
            this.fourButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // fiveButton
            // 
            this.fiveButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fiveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fiveButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fiveButton.Location = new System.Drawing.Point(103, 261);
            this.fiveButton.Name = "fiveButton";
            this.fiveButton.Size = new System.Drawing.Size(94, 76);
            this.fiveButton.TabIndex = 14;
            this.fiveButton.Text = "5";
            this.fiveButton.UseVisualStyleBackColor = false;
            this.fiveButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // sixButton
            // 
            this.sixButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.sixButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sixButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sixButton.Location = new System.Drawing.Point(203, 261);
            this.sixButton.Name = "sixButton";
            this.sixButton.Size = new System.Drawing.Size(94, 76);
            this.sixButton.TabIndex = 15;
            this.sixButton.Text = "6";
            this.sixButton.UseVisualStyleBackColor = false;
            this.sixButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // minusButton
            // 
            this.minusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minusButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.minusButton.Location = new System.Drawing.Point(303, 179);
            this.minusButton.Name = "minusButton";
            this.minusButton.Size = new System.Drawing.Size(96, 76);
            this.minusButton.TabIndex = 16;
            this.minusButton.Text = "-";
            this.minusButton.UseVisualStyleBackColor = true;
            this.minusButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // oneButton
            // 
            this.oneButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.oneButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oneButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.oneButton.Location = new System.Drawing.Point(3, 343);
            this.oneButton.Name = "oneButton";
            this.oneButton.Size = new System.Drawing.Size(94, 76);
            this.oneButton.TabIndex = 17;
            this.oneButton.Text = "1";
            this.oneButton.UseVisualStyleBackColor = false;
            this.oneButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // twoButton
            // 
            this.twoButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.twoButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twoButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.twoButton.Location = new System.Drawing.Point(103, 343);
            this.twoButton.Name = "twoButton";
            this.twoButton.Size = new System.Drawing.Size(94, 76);
            this.twoButton.TabIndex = 18;
            this.twoButton.Text = "2";
            this.twoButton.UseVisualStyleBackColor = false;
            this.twoButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // threeButton
            // 
            this.threeButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.threeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.threeButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.threeButton.Location = new System.Drawing.Point(203, 343);
            this.threeButton.Name = "threeButton";
            this.threeButton.Size = new System.Drawing.Size(94, 76);
            this.threeButton.TabIndex = 19;
            this.threeButton.Text = "3";
            this.threeButton.UseVisualStyleBackColor = false;
            this.threeButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // plusButton
            // 
            this.plusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusButton.Location = new System.Drawing.Point(303, 97);
            this.plusButton.Name = "plusButton";
            this.plusButton.Size = new System.Drawing.Size(96, 76);
            this.plusButton.TabIndex = 20;
            this.plusButton.Text = "+";
            this.plusButton.UseVisualStyleBackColor = true;
            this.plusButton.Click += new System.EventHandler(this.OnOperationButtonClick);
            // 
            // plusMinusButton
            // 
            this.plusMinusButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.plusMinusButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.plusMinusButton.Location = new System.Drawing.Point(203, 97);
            this.plusMinusButton.Name = "plusMinusButton";
            this.plusMinusButton.Size = new System.Drawing.Size(94, 76);
            this.plusMinusButton.TabIndex = 21;
            this.plusMinusButton.Text = "±";
            this.plusMinusButton.UseVisualStyleBackColor = true;
            this.plusMinusButton.Click += new System.EventHandler(this.OnPlusMinusButtonClick);
            // 
            // zeroButton
            // 
            this.zeroButton.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.zeroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zeroButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.zeroButton.Location = new System.Drawing.Point(103, 425);
            this.zeroButton.Name = "zeroButton";
            this.zeroButton.Size = new System.Drawing.Size(94, 79);
            this.zeroButton.TabIndex = 22;
            this.zeroButton.Text = "0";
            this.zeroButton.UseVisualStyleBackColor = false;
            this.zeroButton.Click += new System.EventHandler(this.OnNumberButtonClick);
            // 
            // commaButton
            // 
            this.commaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commaButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.commaButton.Location = new System.Drawing.Point(3, 425);
            this.commaButton.Name = "commaButton";
            this.commaButton.Size = new System.Drawing.Size(94, 79);
            this.commaButton.TabIndex = 23;
            this.commaButton.Text = ",";
            this.commaButton.UseVisualStyleBackColor = true;
            this.commaButton.Click += new System.EventHandler(this.OnCommaButtonClick);
            // 
            // resultButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.resultButton, 2);
            this.resultButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultButton.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.resultButton.Location = new System.Drawing.Point(203, 425);
            this.resultButton.Name = "resultButton";
            this.resultButton.Size = new System.Drawing.Size(196, 79);
            this.resultButton.TabIndex = 24;
            this.resultButton.Text = "=";
            this.resultButton.UseVisualStyleBackColor = true;
            this.resultButton.Click += new System.EventHandler(this.OnResultButtonClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.SetColumnSpan(this.label, 4);
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Font = new System.Drawing.Font("Verdana", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label.ForeColor = System.Drawing.SystemColors.GrayText;
            this.label.Location = new System.Drawing.Point(3, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(396, 47);
            this.label.TabIndex = 25;
            // 
            // MyCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(402, 507);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(420, 550);
            this.Name = "MyCalculatorForm";
            this.Text = "MyCalculator";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button sevenButton;
        private System.Windows.Forms.Button divideButton;
        private System.Windows.Forms.Button backspaceButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button eightButton;
        private System.Windows.Forms.Button nineButton;
        private System.Windows.Forms.Button multiplyButton;
        private System.Windows.Forms.Button fourButton;
        private System.Windows.Forms.Button fiveButton;
        private System.Windows.Forms.Button sixButton;
        private System.Windows.Forms.Button minusButton;
        private System.Windows.Forms.Button oneButton;
        private System.Windows.Forms.Button twoButton;
        private System.Windows.Forms.Button threeButton;
        private System.Windows.Forms.Button plusButton;
        private System.Windows.Forms.Button plusMinusButton;
        private System.Windows.Forms.Button zeroButton;
        private System.Windows.Forms.Button commaButton;
        private System.Windows.Forms.Button resultButton;
        private System.Windows.Forms.Label label;
    }
}

