using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_2
{
    public partial class Prjct : Form
    {
        public Prjct()
        {
            InitializeComponent();
        }

        private void Unicode_Load(object sender, EventArgs e)
        {


        }

        private void Convert_val_Click(object sender, EventArgs e)
        {
            if (number.Text == null)
            {
                MessageBox.Show("Write Some values in First Box");
            }
            else
            {
                string your_number = number.Text;
                int num = int.Parse(your_number);
                string hexValue = num.ToString("X4");
              //  int num2 = int.Parse(hexValue);
                string[] hex = hexValue.Split();
               List <string> temp= new List<string>();
                //foreach (string element in hex)
                 //   temp.Add(Convert.ToString(Convert.ToInt32(element, 16), 2));
               
                //hexValue=string.Join("",temp);
                //int[] list = { 350, 290, 10 };

                
                System.Text.Encoding encoding = System.Text.Encoding.Unicode;
                byte []bytes=BitConverter.GetBytes(num);
                var result = encoding.GetString(BitConverter.GetBytes(num));
                inUnicode.Text = string.Join("", result);

                //var utf_result = Convert.ToUInt16(result).ToString("X4");
                string convertedUtf8 = Encoding.UTF8.GetString(bytes);




                char ch = (char)num;
                byte[] bytes_2 = Encoding.UTF8.GetBytes(new[] { ch });

                foreach (byte c in bytes_2)
                  temp.Add( c.ToString("X2"));

                inUTF8.Text = string.Join(" ", temp);




            }
        }
    }
}
