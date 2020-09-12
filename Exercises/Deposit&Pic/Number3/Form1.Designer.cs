namespace Number3
{
    partial class Form1
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
            this.deposit_number = new System.Windows.Forms.RichTextBox();
            this.percent_field = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.result_field = new System.Windows.Forms.RichTextBox();
            this.years_field = new System.Windows.Forms.RichTextBox();
            this.drawingArea = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).BeginInit();
            this.SuspendLayout();
            // 
            // deposit_number
            // 
            this.deposit_number.Location = new System.Drawing.Point(82, 12);
            this.deposit_number.Name = "deposit_number";
            this.deposit_number.Size = new System.Drawing.Size(123, 41);
            this.deposit_number.TabIndex = 0;
            this.deposit_number.Text = "";
            // 
            // percent_field
            // 
            this.percent_field.Location = new System.Drawing.Point(82, 59);
            this.percent_field.Name = "percent_field";
            this.percent_field.Size = new System.Drawing.Size(123, 41);
            this.percent_field.TabIndex = 1;
            this.percent_field.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(211, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 76);
            this.button1.TabIndex = 8;
            this.button1.Text = "Calculate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Deposit:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Years";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Percent";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Result";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // result_field
            // 
            this.result_field.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.result_field.Location = new System.Drawing.Point(63, 174);
            this.result_field.Name = "result_field";
            this.result_field.ReadOnly = true;
            this.result_field.Size = new System.Drawing.Size(242, 50);
            this.result_field.TabIndex = 7;
            this.result_field.Text = "";
            // 
            // years_field
            // 
            this.years_field.Location = new System.Drawing.Point(82, 106);
            this.years_field.Name = "years_field";
            this.years_field.Size = new System.Drawing.Size(123, 41);
            this.years_field.TabIndex = 2;
            this.years_field.Text = "";
            // 
            // drawingArea
            // 
            this.drawingArea.Location = new System.Drawing.Point(12, 254);
            this.drawingArea.Name = "drawingArea";
            this.drawingArea.Size = new System.Drawing.Size(293, 255);
            this.drawingArea.TabIndex = 9;
            this.drawingArea.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 521);
            this.Controls.Add(this.drawingArea);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.result_field);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.years_field);
            this.Controls.Add(this.percent_field);
            this.Controls.Add(this.deposit_number);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "3 and 4";
            ((System.ComponentModel.ISupportInitialize)(this.drawingArea)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox deposit_number;
        private System.Windows.Forms.RichTextBox percent_field;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox result_field;
        private System.Windows.Forms.RichTextBox years_field;
        private System.Windows.Forms.PictureBox drawingArea;
    }
}

