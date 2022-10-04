using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    


    class Lab_3
    {
        class Set
        {
           //Set()
           //{
                
           //}

           public void ADD(int a)
           {
                //базовый случай
                if(!flag)
                {
                    flag = true;

                    items[0] = a;

                    return;
                }

                //остальные случаи
                int[] newArr = new int[items.Length + 1];

                for (int i = 0; i < items.Length; i++)
                {
                    newArr[i] = items[i];
                }

                newArr[items.Length] = a;

                items = newArr;
           }


            //для добавления
            private int[] items = {0};
            static bool flag = false;
          
        }


        static void Main()
        {
            Set a = new Set();

            a.ADD(1);
            a.ADD(2);
        }
    }
}
