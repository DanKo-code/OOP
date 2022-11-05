using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;


namespace Lab_6performance
{
    public partial class Program
    {
        public class ProgramGuide
        {
            public void Delete(int index)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

                // исключение - индекс не в диапазоне [0 - items.Length]!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length-1) throw new WrongIndexException("Неверный индекс элемента");

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
                Debug.Assert(newaItem != null, "Передаваемый объект не может указывать на null!");

                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (newaItem == null) throw new TestNullObject("Передан обьект с null ссылкой!");

                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента!");
               
                items[index] = newaItem;
            }

            public TvProgram Get(int index)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (index < 0 || index > items.Length - 1) throw new WrongIndexException("Неверный индекс элемента!");
                return items[index];
            }

            public void Print()
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (items.Length == 0) throw new NullCollectionException("ProgramGuide пуст!");

                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine(items[i].ToString());
                }
               
            }

            public void Push_Back(TvProgram a)
            {
                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                if (a == null) throw new TestNullObject("Передан обьект с null ссылкой!");

                TvProgram[] buf = new TvProgram[items.Length + 1];
                items.CopyTo(buf, 0);
                buf[items.Length] = a;
                items = buf;
            }

            public TvProgram[] items = Array.Empty<TvProgram>();
        }
    }
}
