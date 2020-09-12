using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();

        }

      
     

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dictionaryDataSet2.words". При необходимости она может быть перемещена или удалена.
            this.wordsTableAdapter.Fill(this.dictionaryDataSet2.words);
            // Methods methods = new Methods();
            // methods.display(dataGridView2);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "dictionaryDataSet1.Wordlist". При необходимости она может быть перемещена или удалена.
            //this.wordlistTableAdapter1.Fill(this.dictionaryDataSet1.Wordlist);

            // TODO: данная строка кода позволяет загрузить данные в таблицу "dictionaryDataSet.Wordlist". При необходимости она может быть перемещена или удалена.
            this.wordlistTableAdapter.Fill(this.dictionaryDataSet.Wordlist);

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing to see here", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void label2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing to see here", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void label6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nothing to see here", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private async void uploadFileButton_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            using (OpenFileDialog file = new OpenFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true, Multiselect = false })
            {
                if (file.ShowDialog() == DialogResult.OK)
                {

                    StreamReader sr = new StreamReader(file.FileName);

                    String line = await sr.ReadLineAsync();

                    while(line != null)
                    {
                        try
                        {
                            string[] array = line.Split(',');
                            methods.saveInsert(new Word(array[1],array[0], array[2]));
                            line = await sr.ReadLineAsync();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("File is not correct. Make sure it has form -ENGLISH, RUSSIAN,  LITHUANIAN.", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;

                        }
                    }
                    sr.Close();

                }

            }
            this.wordsTableAdapter.Fill(this.dictionaryDataSet2.words);

        }

        private void button1_Click(object sender, EventArgs e)
        {
           //check fields 
           if (russianField.Text =="" || englishField.Text=="" || lithuanianField.Text == "")
            {
                MessageBox.Show("Fill all areas", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                Word word = new Word((russianField.Text), englishField.Text, lithuanianField.Text);
                Methods methods = new Methods();
                int message = methods.saveInsert(word);

                if (message != 0)
                {
                    MessageBox.Show("New word saved", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Word is not saved. It already exists in the DB", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                this.wordsTableAdapter.Fill(this.dictionaryDataSet2.words);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
          Word word = methods.search(searchWord.Text.ToLower());

            if (word.russian1 ==null && word.english1 == null && word.lithuanian1 == null)
            {

                MessageBox.Show("Can't find it in the dictionary", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("Your word in \n Russian: "+word.russian1 + " \n English: " +word.english1+" \n Lithuanian: "+word.lithuanian1,
                     "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }



        private void dataGridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell.ColumnIndex == 4)  //example-'Column index=4'
            {
                dataGridView2.BeginEdit(true);
            }
        }


        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                MessageBox.Show("New word saved", "Dictionary", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();
            methods.deleteAll();
            this.wordsTableAdapter.Fill(this.dictionaryDataSet2.words);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Int32 selectedRowCount =
        dataGridView5.Rows.GetRowCount(DataGridViewElementStates.Selected);

            Form2 form2 = new Form2();
            form2.id.Text = dataGridView5.SelectedRows[0].Cells[0].Value.ToString();
            form2.russian.Text = dataGridView5.SelectedRows[0].Cells[1].Value.ToString();
            form2.english.Text = dataGridView5.SelectedRows[0].Cells[2].Value.ToString();
            form2.lithuanian.Text = dataGridView5.SelectedRows[0].Cells[3].Value.ToString();



            form2.Show();
            this.wordsTableAdapter.Fill(this.dictionaryDataSet2.words);


        }

        protected void dataGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
          //  DataGridViewRow row = dataGridView.SelectedRows;
        }


        //dataGridView1 RowHeaderMouseClick Event  
        private void selectedRowsButton_Click(object sender, DataGridViewCellMouseEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.id.Text = (dataGridView5.Rows[e.RowIndex].Cells[0].Value.ToString());
            form2.russian.Text = dataGridView5.Rows[e.RowIndex].Cells[1].Value.ToString();
            form2.english.Text = dataGridView5.Rows[e.RowIndex].Cells[2].Value.ToString();
            form2.lithuanian.Text = dataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString();

            this.dataGridView5.SelectionMode =
       DataGridViewSelectionMode.RowHeaderSelect;
            this.dataGridView5.Rows[e.RowIndex].Selected = true;

            form2.Show();

        }

        private void upd_Click(object sender, EventArgs e)
        {
            this.wordsTableAdapter.Fill(this.dictionaryDataSet2.words);

        }
    }
}
