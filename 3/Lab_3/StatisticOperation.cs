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

        public static void DeletePositiveElements(this Lab_3.MySet set)
        {
            int newArrLength = 0;
            foreach (int item in set.items)
            {
                if (item <= 0)
                {
                    newArrLength++;
                }
            }

            int[] newArr = new int[newArrLength];

            for (int i = 0, j = 0; j < newArrLength; i++)
            {
                if (set.items[i] <= 0)
                {
                    newArr[j++] = set.items[i];
                }
            }

            set.items = newArr;
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
