using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public partial class Program
    {
        public class ProgramGuide
        {
            public void Delete(int index)
            {
                TvProgram[] buf = new TvProgram[items.Length -1];

                for (int i = 0, j = 0; i < items.Length; i++, j++)
                {
                    if (i == index)
                    {
                        --j;
                        continue;
                    }
                        

                    buf[j] = items[i]; 
                }

                items = buf;
            }

            public void Set(TvProgram newaItem , int index)
            {
                items[index] = newaItem;
            }

            public TvProgram Get(int index)
            {
                return items[index];
            }

            public void Print()
            {
                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(items[i].ToString());
                }
               
            }

            public void Push_Back(TvProgram a)
            {
                TvProgram[] buf = new TvProgram[items.Length + 1];
                items.CopyTo(buf, 0);
                buf[items.Length] = a;
                items = buf;
            }

            public TvProgram[] items = Array.Empty<TvProgram>();
        }
    }
}
