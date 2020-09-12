namespace Project_2
{
    partial class Prjct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.number = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.inUnicode = new System.Windows.Forms.RichTextBox();
            this.inUTF8 = new System.Windows.Forms.RichTextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.Convert_val = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // number
            // 
            this.number.Location = new System.Drawing.Point(12, 37);
            this.number.Name = "number";
            this.number.Size = new System.Drawing.Size(49, 26);
            this.number.TabIndex = 0;
            this.number.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(49, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Decimal";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(84, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(51, 20);
            this.textBox2.TabIndex = 2;
            this.textBox2.Text = "Unicode";
            // 
            // inUnicode
            // 
            this.inUnicode.Location = new System.Drawing.Point(84, 37);
            this.inUnicode.Name = "inUnicode";
            this.inUnicode.Size = new System.Drawing.Size(51, 26);
            this.inUnicode.TabIndex = 3;
            this.inUnicode.Text = "";
            // 
            // inUTF8
            // 
            this.inUTF8.Location = new System.Drawing.Point(156, 37);
            this.inUTF8.Name = "inUTF8";
            this.inUTF8.Size = new System.Drawing.Size(51, 26);
            this.inUTF8.TabIndex = 4;
            this.inUTF8.Text = "";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(156, 11);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(51, 20);
            this.textBox3.TabIndex = 5;
            this.textBox3.Text = "UTF-8";
            // 
            // Convert_val
            // 
            this.Convert_val.Location = new System.Drawing.Point(215, 12);
            this.Convert_val.Name = "Convert_val";
            this.Convert_val.Size = new System.Drawing.Size(53, 48);
            this.Convert_val.TabIndex = 6;
            this.Convert_val.Text = "Convert";
            this.Convert_val.UseVisualStyleBackColor = true;
            this.Convert_val.Click += new System.EventHandler(this.Convert_val_Click);
            // 
            // Prjct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 75);
            this.Controls.Add(this.Convert_val);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.inUTF8);
            this.Controls.Add(this.inUnicode);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.number);
            this.Name = "Prjct";
            this.Text = "Unicode/UTF-8";
            this.Load += new System.EventHandler(this.Unicode_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox number;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.RichTextBox inUnicode;
        private System.Windows.Forms.RichTextBox inUTF8;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button Convert_val;
    }
}

