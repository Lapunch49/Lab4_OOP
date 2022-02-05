using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace Lab4_OOP
    {public partial class Form1 : Form
        {
            public static Bitmap bmp;
            public bool ctrlPress = false;
            public Form1()
            {
                InitializeComponent();
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) ctrlPress = true;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) ctrlPress = false;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            int k = -1;
            int flag = 0;
            //проверяем попадание курсора по какому-либо кругу
            for (int i = 0; i < Globals.arr_circles.get_count() - 1; ++i)
                if (Globals.arr_circles.st[i].mouseClick_on_Object(e.X,e.Y))
                {
                    k = i;//курсор попал по кругу с индексом k
                }
            if (k > -1) {//курсор попал по существующему кругу
                //выделяем круг, по которому попал курсор
                if (!Globals.arr_circles.st[k].get_highlighted())//если объект не был выделен - выделяем
                {
                    Globals.arr_circles.st[k].highlight();
                    Globals.arr_circles.st[k].change_highlight();
                }
                //проверяем были ли уже выделены какие-то круги
                for (int i = 0; i < Globals.arr_circles.get_count() - 1; ++i)
                    if (Globals.arr_circles.st[i].get_highlighted())
                        flag = 1;//какие-то круг/круги уже выделены

                if (flag == 1)//круги уже выделены

                    if (ctrlPress)//если при этом зажата ctrl - выделяем и этот круг
                    {
                        Globals.arr_circles.st[k].highlight();
                        Globals.arr_circles.st[k].change_highlight();
                    }
                    else //если ctrl не зажата - убираем все выделения у кругов
                    if (!ctrlPress)
                        //if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Ctrl) == true)
                        {
                    for (int i = 0; i < Globals.arr_circles.get_count(); ++i)
                    {
                        if (Globals.arr_circles.st[i].get_highlighted())
                            Globals.arr_circles.st[i].change_highlight();
                        Globals.arr_circles.st[i].draw();
                    }
                    Globals.arr_circles.st[k].change_highlight();
                    Globals.arr_circles.st[k].highlight();
                }
                
                //else // если ни один круг не выделен
                //{
                //    Globals.arr_circles.st[k].highlight();//выделяем круг, на который попали курсором
                //    Globals.arr_circles.st[k].change_highlight();
                //} 
            }
            else //if (k==-1) - курсор попал в пустое место
            {
                Globals.arr_circles.add(new CCircle(e.X, e.Y));//создаем новый круг
                //выделяем только этот новый круг
                Globals.arr_circles.st[Globals.arr_circles.get_count() - 1].highlight();
                for (int i = 0; i < Globals.arr_circles.get_count() - 1; ++i)
                {
                    if (Globals.arr_circles.st[i].get_highlighted())
                        Globals.arr_circles.st[i].change_highlight();
                    Globals.arr_circles.st[i].draw();
                }
            }
            pictureBox1.Image = bmp;
        }

    }

    public static class Globals
    {
        //public static Pen circle = new Pen(Color.Blue, 20);
        //public static Pen line = new Pen(Color.Red,10);
        //public static SolidBrush blueBrush = new SolidBrush(Color.Blue);
        public static SolidBrush blueBrush = new SolidBrush(Color.FromArgb(207, 126, 220));
        public static SolidBrush redBrush = new SolidBrush(Color.Red);
        public static Storage arr_circles = new Storage();
    }
}





