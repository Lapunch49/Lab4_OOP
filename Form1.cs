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
            public Form1()
            {
                InitializeComponent();
                //Storage arr_circles = new Storage();

            }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Globals.arr_circles.st[Globals.n++] = new CCircle(e.X, e.Y);

        }
    }


    public static class Globals
    {
        public static Pen circle = new Pen(Color.Blue, 20);
        public static Pen line = new Pen(Color.Blue);
        public static Storage arr_circles = new Storage();
        public static int n = 0;
        public static int versh = -1;
    }
}





