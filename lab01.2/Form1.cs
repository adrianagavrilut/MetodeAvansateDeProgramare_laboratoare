using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01d2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics graphics;
        Bitmap bitmap;

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bitmap = new Bitmap(mainDisplay.Width, mainDisplay.Height);
            graphics = Graphics.FromImage(bitmap);

            Brush brush = new SolidBrush(Color.Black);

            graphics.Clear(Color.PeachPuff);
            graphics.DrawString("Hello World", new Font("Arial", 20), brush, NewPoint(-100, 10));

            mainDisplay.Image = bitmap;
        }

        Point NewPoint(int x, int y)
        {
            return new Point(mainDisplay.Width / 2 + x, mainDisplay.Height / 2 - y);
        }
    }
}
