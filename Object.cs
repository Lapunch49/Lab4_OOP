using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Lab4_OOP
{
    public class Object
    {
        public virtual void Draw() { }
    }
    public class CCircle : Object
    {
        private int x, y, r;
        public CCircle()
        {
            x = 0;
            y = 0;
        }
        public CCircle(int x, int y)
        {
            this.x = x;
            this.y = y;
            r = 30;
        }
        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Form1.bmp);
            g.FillEllipse(Globals.blueBrush, x, y, 20, 20);
            
        }
    };
}
