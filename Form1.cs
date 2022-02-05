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
{
    public partial class Form1 : Form
    {
        public static Bitmap bmp;
        public bool ctrlPress = false;
        Storage stCircles = new Storage(10);
        public Form1()
            {
                InitializeComponent();
                bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Control) ctrlPress = true;
            if (e.KeyCode == Keys.Delete) // выделенные объекты удалятся из хранилища, и произойдет перерисовка
            {
                for (int i=0; i<stCircles.get_count(); ++i)
                {
                    if (stCircles.get_el(i).get_highlighted() == true)
                    {
                        stCircles.del(i);
                        i--;
                    }
                }
                pictureBox1.Invalidate(); ////////////
            }

        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Control) ctrlPress = false;
            //ctrlPress = e.Control;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            //if (e.Button == MouseButtons.Left)
            //{
            //    int k = -1; // попадание по кругу с индексом k
            //    int flag = 0; // выделены ли др. круги

            //    //проверяем попадание курсора по какому-либо кругу
            //    for (int i = 0; i < stCircles.get_count() - 1; ++i)
            //        if (stCircles.get_el(i).mouseClick_on_Object(e.X, e.Y))
            //        {
            //            k = i;//курсор попал по кругу с индексом k
            //        }
            //    if (k > -1)
            //    {//курсор попал по существующему кругу
            //     //выделяем круг, по которому попал курсор
            //        if (!stCircles.st[k].get_highlighted())//если объект не был выделен - выделяем
            //        {
            //            stCircles.st[k].highlight();
            //            stCircles.st[k].change_highlight();
            //        }
            //        //проверяем были ли уже выделены какие-то круги
            //        for (int i = 0; i < stCircles.get_count() - 1; ++i)
            //            if (stCircles.get_el(i).get_highlighted())
            //                flag = 1;//какие-то круг/круги уже выделены

            //        if (flag == 1)//круги уже выделены

            //            if (ctrlPress)//если при этом зажата ctrl - выделяем и этот круг
            //            {
            //                stCircles.st[k].highlight();
            //                stCircles.st[k].change_highlight();
            //            }
            //            else //если ctrl не зажата - убираем все выделения у кругов
            //            if (!ctrlPress)
            //            //if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Ctrl) == true)
            //            {
            //                for (int i = 0; i < stCircles.get_count(); ++i)
            //                {
            //                    if (stCircles.get_el(i).get_highlighted())
            //                        stCircles.get_el(i).change_highlight();
            //                    stCircles.get_el(i).draw();
            //                }
            //                stCircles.st[k].change_highlight();
            //                stCircles.st[k].highlight();
            //            }

            //        //else // если ни один круг не выделен
            //        //{
            //        //    stCircles.st[k].highlight();//выделяем круг, на который попали курсором
            //        //    stCircles.st[k].change_highlight();
            //        //} 
            //    }
            //    else //if (k==-1) - курсор попал в пустое место
            //    {
            //        stCircles.add(new CCircle(e.X, e.Y));//создаем новый круг
            //                                             //выделяем только этот новый круг
            //        stCircles.st[stCircles.get_count() - 1].highlight();
            //        for (int i = 0; i < stCircles.get_count() - 1; ++i)
            //        {
            //            if (stCircles.get_el(i).get_highlighted())
            //                stCircles.get_el(i).change_highlight();
            //            stCircles.get_el(i).draw();
            //        }
            //    }
            //    pictureBox1.Invalidate();
            //    //pictureBox1.Image = bmp;
            //}
        }
        private void setAllHighlightFalse() 
        {
            // в хранилище меняем у выделенных кругов св. выделенности
            for (int i = 0; i < stCircles.get_count(); ++i)
                if (stCircles.get_el(i).get_highlighted() == true)
                    stCircles.get_el(i).change_highlight();
            // нарисовать "сверху" невыделенные круги
        }
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int ind = -1; // попадание по кругу с индексом ind

                // определяем попадание по существующему кругу 
                for (int i = 0; i < stCircles.get_count(); ++i)
                    if (stCircles.get_el(i).mouseClick_on_Object(e.X, e.Y))
                        ind = i;

                // не попали по кругу - убираем все выделения, создаем и рисуем новый круг 
                if (ind == -1)
                {
                    setAllHighlightFalse();
                    stCircles.add(new CCircle(e.X, e.Y));
                    ind = stCircles.get_count()-1;
                    //stCircles.st[ind].change_highlight();
                    //stCircles.st[ind].draw();
                }
                // попал:
                else
                {
                    if (ctrlPress != true)
                    {
                        setAllHighlightFalse();
                    }
                    //stCircles.st[ind].change_highlight();
                    //stCircles.st[ind].draw();
                }
                stCircles.get_el(ind).change_highlight();
                stCircles.get_el(ind).draw();

                // 1)проверяем ctrl
                //    если ctrl не зажат - убираем остальные выделения

                // 2)выделяем круг, по которому попали

                pictureBox1.Image = bmp;
                pictureBox1.Invalidate();
                //pictureBox1_Paint(sender, null);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < stCircles.get_count(); ++i)
                if (stCircles.get_el(i) != null)
                    stCircles.get_el(i).draw();
        }

    }

    public static class Globals
    {
        //public static Pen circle = new Pen(Color.Blue, 20);
        //public static Pen line = new Pen(Color.Red,10);
        //public static SolidBrush blueBrush = new SolidBrush(Color.Blue);
        public static SolidBrush blueBrush = new SolidBrush(Color.FromArgb(207, 126, 220));
        //public static SolidBrush redBrush = new SolidBrush(Color.Red);
        public static SolidBrush redBrush = new SolidBrush(Color.FromArgb(219, 125, 171));
        //public static Storage stCircles = new Storage();
    }
}





