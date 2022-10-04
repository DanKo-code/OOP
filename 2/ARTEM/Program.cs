using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2
{

    class Lab_2
    {
        class Array
        {
            /////////////////////////////////ИНДЕКСАТОР//////////////////////////////////////

            public Array(int size)
            {
                a = new int[size];
                length = size;

            }

            public int this[int i]
            {
                get
                {
                    if (i >= 0 && i < length) return a[i];
                    else { error = true; return 0; }
                }

                set
                {
                    if (i >= 0 && i < length &&
                    value >= 0 && value <= 100) a[i] = value;
                    else error = true;
                }

            }

            public bool error = false;
            int[] a;
            int length;
        }

        static void Main()
        {
            Array first = new Array(5);

            


        }
    }

    
}
