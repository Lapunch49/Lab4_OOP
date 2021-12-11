using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_OOP
{
    public class Object
    {

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
        public void Draw()
        {

        }
    };
}
