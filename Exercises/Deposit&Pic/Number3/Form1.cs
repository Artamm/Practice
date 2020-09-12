using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number3
{
    public partial class Form1 : Form
    {
        Graphics drawArea;
        public Form1()
        {
            InitializeComponent();
            drawArea = drawingArea.CreateGraphics();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawArea.Clear(Color.White);

            SolidBrush y = new SolidBrush(Color.Yellow);
            SolidBrush b = new SolidBrush(Color.Blue);
            SolidBrush z = new SolidBrush(Color.Beige);
            SolidBrush g = new SolidBrush(Color.Green);


            Point[] UP = new Point[] { new Point(120, 120), new Point(180, 120), new Point(150, 80) };

            //l.DrawEllipse(p, 100, 300, 200, 200);
            drawArea.FillEllipse(y, 2, 2, 60, 60);
            
            drawArea.FillRectangle(z, 120, 120, 60, 60);
            drawArea.FillRectangle(b, 140, 140, 20, 20);
            drawArea.FillPolygon(b, UP);
            drawArea.FillRectangle(g, 0, 180, 500,500);





            if (deposit_number.Text != String.Empty & percent_field.Text != String.Empty & years_field.Text != String.Empty) { 
            double deposit = double.Parse(deposit_number.Text);
            double percent = double.Parse(percent_field.Text);
            double years = double.Parse(years_field.Text);
            double result = deposit+(deposit*years*percent)/100;
            result_field.Text = result.ToString();
}
            else
            {
                string msg = "Write numbers in all all three areas ";
                MessageBox.Show(msg);

            }
        }
       

    }
}
