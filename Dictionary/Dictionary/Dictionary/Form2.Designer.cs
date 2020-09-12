namespace Dictionary
{
    partial class Form2
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
            this.russian = new System.Windows.Forms.TextBox();
            this.english = new System.Windows.Forms.TextBox();
            this.lithuanian = new System.Windows.Forms.TextBox();
            this.Update = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // russian
            // 
            this.russian.Location = new System.Drawing.Point(78, 75);
            this.russian.Name = "russian";
            this.russian.Size = new System.Drawing.Size(100, 22);
            this.russian.TabIndex = 0;
            // 
            // english
            // 
            this.english.Location = new System.Drawing.Point(78, 122);
            this.english.Name = "english";
            this.english.Size = new System.Drawing.Size(100, 22);
            this.english.TabIndex = 1;
            this.english.TextChanged += new System.EventHandler(this.english_TextChanged);
            // 
            // lithuanian
            // 
            this.lithuanian.Location = new System.Drawing.Point(78, 174);
            this.lithuanian.Name = "lithuanian";
            this.lithuanian.Size = new System.Drawing.Size(100, 22);
            this.lithuanian.TabIndex = 2;
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(204, 202);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(75, 39);
            this.Update.TabIndex = 3;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(233, 38);
            this.label4.TabIndex = 9;
            this.label4.Text = "Update or delete";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(78, 213);
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Size = new System.Drawing.Size(58, 22);
            this.id.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 175);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Lietuvių";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "English";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Русский";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 213);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(19, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "id";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(204, 153);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 39);
            this.button1.TabIndex = 15;
            this.button1.Text = "delete";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.lithuanian);
            this.Controls.Add(this.english);
            this.Controls.Add(this.russian);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private new System.Windows.Forms.Button Update;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.TextBox russian;
        public System.Windows.Forms.TextBox english;
        public System.Windows.Forms.TextBox lithuanian;
        public System.Windows.Forms.TextBox id;
    }
}