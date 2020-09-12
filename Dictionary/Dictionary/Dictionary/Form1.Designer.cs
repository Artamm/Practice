namespace Dictionary
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.wordlistBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dictionaryDataSet = new Dictionary.DictionaryDataSet();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.searchWord = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uploadFileButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lithuanianField = new System.Windows.Forms.TextBox();
            this.englishField = new System.Windows.Forms.TextBox();
            this.russianField = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.wordlist = new Dictionary.wordlist();
            this.wordlistBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dictionaryDataSet1 = new Dictionary.DictionaryDataSet1();
            this.wordlistBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.wordlistTableAdapter1 = new Dictionary.DictionaryDataSet1TableAdapters.WordlistTableAdapter();
            this.wordlistTableAdapter = new Dictionary.DictionaryDataSetTableAdapters.WordlistTableAdapter();
            this.wordlistBindingSource3 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.wordlistBindingSource4 = new System.Windows.Forms.BindingSource(this.components);
            this.dictionaryDataSet2 = new Dictionary.DictionaryDataSet2();
            this.wordsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wordsTableAdapter = new Dictionary.DictionaryDataSet2TableAdapters.wordsTableAdapter();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.russianDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.englishDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lithuanianDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lithuanianDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.englishDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.russianDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.upd = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.upd);
            this.panel1.Controls.Add(this.dataGridView5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.searchWord);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.uploadFileButton);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lithuanianField);
            this.panel1.Controls.Add(this.englishField);
            this.panel1.Controls.Add(this.russianField);
            this.panel1.Location = new System.Drawing.Point(6, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 533);
            this.panel1.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(75, 426);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 38);
            this.label7.TabIndex = 18;
            this.label7.Text = "Additional:";
            // 
            // wordlistBindingSource1
            // 
            this.wordlistBindingSource1.DataMember = "Wordlist";
            this.wordlistBindingSource1.DataSource = this.dictionaryDataSet;
            // 
            // dictionaryDataSet
            // 
            this.dictionaryDataSet.DataSetName = "DictionaryDataSet";
            this.dictionaryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(222, 476);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 45);
            this.button4.TabIndex = 16;
            this.button4.Text = "Manage";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 476);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 45);
            this.button3.TabIndex = 15;
            this.button3.Text = "Delete everything";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 37);
            this.button2.TabIndex = 14;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // searchWord
            // 
            this.searchWord.ForeColor = System.Drawing.SystemColors.ScrollBar;
            this.searchWord.Location = new System.Drawing.Point(136, 334);
            this.searchWord.Multiline = true;
            this.searchWord.Name = "searchWord";
            this.searchWord.Size = new System.Drawing.Size(134, 26);
            this.searchWord.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(22, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 38);
            this.label6.TabIndex = 11;
            this.label6.Text = "Search:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // uploadFileButton
            // 
            this.uploadFileButton.Location = new System.Drawing.Point(171, 227);
            this.uploadFileButton.Name = "uploadFileButton";
            this.uploadFileButton.Size = new System.Drawing.Size(99, 29);
            this.uploadFileButton.TabIndex = 10;
            this.uploadFileButton.Text = "Upload File";
            this.uploadFileButton.UseVisualStyleBackColor = true;
            this.uploadFileButton.Click += new System.EventHandler(this.uploadFileButton_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(26, 233);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(125, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Or upload file (.txt)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(22, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(229, 38);
            this.label4.TabIndex = 8;
            this.label4.Text = "Insert new word:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(29, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 39);
            this.button1.TabIndex = 7;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Lietuvių";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "English";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Русский";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lithuanianField
            // 
            this.lithuanianField.Location = new System.Drawing.Point(110, 182);
            this.lithuanianField.Name = "lithuanianField";
            this.lithuanianField.Size = new System.Drawing.Size(160, 22);
            this.lithuanianField.TabIndex = 2;
            // 
            // englishField
            // 
            this.englishField.Location = new System.Drawing.Point(110, 132);
            this.englishField.Name = "englishField";
            this.englishField.Size = new System.Drawing.Size(160, 22);
            this.englishField.TabIndex = 1;
            // 
            // russianField
            // 
            this.russianField.Location = new System.Drawing.Point(110, 87);
            this.russianField.Name = "russianField";
            this.russianField.Size = new System.Drawing.Size(160, 22);
            this.russianField.TabIndex = 0;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // wordlist
            // 
            this.wordlist.DataSetName = "wordlist";
            this.wordlist.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wordlistBindingSource
            // 
            this.wordlistBindingSource.DataSource = this.wordlist;
            this.wordlistBindingSource.Position = 0;
            // 
            // dictionaryDataSet1
            // 
            this.dictionaryDataSet1.DataSetName = "DictionaryDataSet1";
            this.dictionaryDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wordlistBindingSource2
            // 
            this.wordlistBindingSource2.DataMember = "Wordlist";
            this.wordlistBindingSource2.DataSource = this.dictionaryDataSet1;
            // 
            // wordlistTableAdapter1
            // 
            this.wordlistTableAdapter1.ClearBeforeFill = true;
            // 
            // wordlistTableAdapter
            // 
            this.wordlistTableAdapter.ClearBeforeFill = true;
            // 
            // wordlistBindingSource3
            // 
            this.wordlistBindingSource3.DataSource = this.wordlist;
            this.wordlistBindingSource3.Position = 0;
            // 
            // dataGridView5
            // 
            this.dataGridView5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView5.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.russianDataGridViewTextBoxColumn1,
            this.englishDataGridViewTextBoxColumn1,
            this.lithuanianDataGridViewTextBoxColumn1});
            this.dataGridView5.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.dataGridView5.DataSource = this.wordsBindingSource;
            this.dataGridView5.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView5.Location = new System.Drawing.Point(309, 20);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowTemplate.Height = 24;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.ShowEditingIcon = false;
            this.dataGridView5.Size = new System.Drawing.Size(526, 501);
            this.dataGridView5.TabIndex = 19;
            // 
            // wordlistBindingSource4
            // 
            this.wordlistBindingSource4.DataSource = this.wordlist;
            this.wordlistBindingSource4.Position = 0;
            // 
            // dictionaryDataSet2
            // 
            this.dictionaryDataSet2.DataSetName = "DictionaryDataSet2";
            this.dictionaryDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // wordsBindingSource
            // 
            this.wordsBindingSource.DataMember = "words";
            this.wordsBindingSource.DataSource = this.dictionaryDataSet2;
            // 
            // wordsTableAdapter
            // 
            this.wordsTableAdapter.ClearBeforeFill = true;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.idDataGridViewTextBoxColumn.Width = 40;
            // 
            // russianDataGridViewTextBoxColumn1
            // 
            this.russianDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.russianDataGridViewTextBoxColumn1.DataPropertyName = "russian";
            this.russianDataGridViewTextBoxColumn1.HeaderText = "russian";
            this.russianDataGridViewTextBoxColumn1.Name = "russianDataGridViewTextBoxColumn1";
            this.russianDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // englishDataGridViewTextBoxColumn1
            // 
            this.englishDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.englishDataGridViewTextBoxColumn1.DataPropertyName = "english";
            this.englishDataGridViewTextBoxColumn1.HeaderText = "english";
            this.englishDataGridViewTextBoxColumn1.Name = "englishDataGridViewTextBoxColumn1";
            this.englishDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // lithuanianDataGridViewTextBoxColumn1
            // 
            this.lithuanianDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lithuanianDataGridViewTextBoxColumn1.DataPropertyName = "lithuanian";
            this.lithuanianDataGridViewTextBoxColumn1.HeaderText = "lithuanian";
            this.lithuanianDataGridViewTextBoxColumn1.Name = "lithuanianDataGridViewTextBoxColumn1";
            this.lithuanianDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "DataColumn1";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Width = 40;
            // 
            // lithuanianDataGridViewTextBoxColumn
            // 
            this.lithuanianDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.lithuanianDataGridViewTextBoxColumn.DataPropertyName = "lithuanian";
            this.lithuanianDataGridViewTextBoxColumn.HeaderText = "lithuanian";
            this.lithuanianDataGridViewTextBoxColumn.Name = "lithuanianDataGridViewTextBoxColumn";
            // 
            // englishDataGridViewTextBoxColumn
            // 
            this.englishDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.englishDataGridViewTextBoxColumn.DataPropertyName = "english";
            this.englishDataGridViewTextBoxColumn.HeaderText = "english";
            this.englishDataGridViewTextBoxColumn.Name = "englishDataGridViewTextBoxColumn";
            // 
            // russianDataGridViewTextBoxColumn
            // 
            this.russianDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.russianDataGridViewTextBoxColumn.DataPropertyName = "russian";
            this.russianDataGridViewTextBoxColumn.HeaderText = "russian";
            this.russianDataGridViewTextBoxColumn.Name = "russianDataGridViewTextBoxColumn";
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.russianDataGridViewTextBoxColumn,
            this.englishDataGridViewTextBoxColumn,
            this.lithuanianDataGridViewTextBoxColumn,
            this.id});
            this.dataGridView2.DataSource = this.wordlistBindingSource1;
            this.dataGridView2.Location = new System.Drawing.Point(309, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(526, 501);
            this.dataGridView2.TabIndex = 17;
            // 
            // upd
            // 
            this.upd.Location = new System.Drawing.Point(113, 476);
            this.upd.Name = "upd";
            this.upd.Size = new System.Drawing.Size(103, 45);
            this.upd.TabIndex = 20;
            this.upd.Text = "Update";
            this.upd.UseVisualStyleBackColor = true;
            this.upd.Click += new System.EventHandler(this.upd_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(885, 553);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Text = "Dictionary";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordlistBindingSource4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dictionaryDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wordsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox lithuanianField;
        private System.Windows.Forms.TextBox englishField;
        private System.Windows.Forms.TextBox russianField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button uploadFileButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox searchWord;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private wordlist wordlist;
        private System.Windows.Forms.BindingSource wordlistBindingSource;
        private DictionaryDataSet dictionaryDataSet;
        private System.Windows.Forms.BindingSource wordlistBindingSource1;
        private DictionaryDataSetTableAdapters.WordlistTableAdapter wordlistTableAdapter;
        private System.Windows.Forms.Label label7;
        private DictionaryDataSet1 dictionaryDataSet1;
        private System.Windows.Forms.BindingSource wordlistBindingSource2;
        private DictionaryDataSet1TableAdapters.WordlistTableAdapter wordlistTableAdapter1;
        private System.Windows.Forms.BindingSource wordlistBindingSource3;
        private System.Windows.Forms.DataGridView dataGridView5;
        private System.Windows.Forms.BindingSource wordlistBindingSource4;
        private DictionaryDataSet2 dictionaryDataSet2;
        private System.Windows.Forms.BindingSource wordsBindingSource;
        private DictionaryDataSet2TableAdapters.wordsTableAdapter wordsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn russianDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn englishDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lithuanianDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn russianDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn englishDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lithuanianDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.Button upd;
    }
}

