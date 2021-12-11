using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4_OOP
    {public partial class Form1 : Form
        {
            public static Bitmap bmp;
            public Form1()
            {
                InitializeComponent();
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Globals.arr_circles.add(new CCircle(e.X, e.Y));
            Globals.arr_circles.st[Globals.arr_circles.get_count()-1].Draw();
            pictureBox1.Image = bmp;
        }
    }


    public static class Globals
    {
        public static Pen circle = new Pen(Color.Blue, 20);
        public static Pen line = new Pen(Color.Blue);
        public static SolidBrush blueBrush = new SolidBrush(Color.Blue);
        public static Storage arr_circles = new Storage();
    }
}





