using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dictionary
{
    public partial class Form2 : Form
    {

      
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
        }

            private void english_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Update_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();

            methods.update(new Word(id.Text, russian.Text,lithuanian.Text, english.Text ));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Methods methods = new Methods();

            methods.deleteOne(id.Text);
        }
    }
}
