﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lab4_OOP
{
    public class Storage
    {
        private int n, k;//количество элементов
        public Object[] st;
        public Storage()
        {
            st = new CCircle[2];
            n = 2;
            k = 0;
        }
        public Storage(int size)
        {
            st = new CCircle[size];
            n = size;
            k = 0;
        }

        void add(Object new_el)
        {
            if (k < n)
            {
                st[k] = new_el;
                k = k + 1;
            }
            else
            {
                n = n * 2;
                Object[] st_ = new Object[n];
                for (int i = 0; i < k; ++i)
                    st_[i] = st[i];
                st_[k] = new_el;
                k = k + 1;
                st = st_;
            }
        }
        public void del(int ind)
        {
            for (int i = ind; i < k - 1; ++i)
                st[i] = st[i + 1];
            k = k - 1;
        }
        public Object get_el(int ind)
        {
            return st[ind];
        }
        public int get_count()
        {
            return k;
        }
    };
}