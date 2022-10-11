using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
        public static class StatisticOperation
        {
            public static int GetSumFirstLastElement(Lab_3.MySet first)
            {
                return first.items.Max() + first.items.Min();
            }

            public static int GetDifferenceFirstLastElement(Lab_3.MySet first)
            {
                return first.items.Max() - first.items.Min();
            }

            public static int GetAlementsAmount(Lab_3.MySet first)
            {
                return first.items.Length;
            }

            public static void DeletePositiveElements(this Lab_3.MySet first, ref Lab_3.MySet second)
            {
                first = new Lab_3.MySet();

                for (int i = 0; i < second.items.Length; i++)
                {
                    if (second.items[i] < 0)
                    {
                    first.Push_Back(second.items[i]);
                    }
                }

                second = first;
            }

            public static char GetFirstElement(this string first)
            {
                foreach (char symbol in first)
                {
                    if (48 < symbol && symbol < 57) return (char)symbol;
                }

                return ' ';
            }

        }
}
