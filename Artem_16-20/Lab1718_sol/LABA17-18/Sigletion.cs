using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA17_18
{
    public class Singleton
    {
        private static Singleton instance;
        public ConsoleColor ForegroundColor { get; private set; }
        public ConsoleColor BackgroundColor { get; private set; }
        private static readonly object theadlock = new object();

        public string OS;
        private Singleton(string OS, ConsoleColor forColor, ConsoleColor backColor)
        {
            this.OS = OS;
            ForegroundColor = forColor;
            BackgroundColor = backColor;
        }

        public static Singleton getInstance(string OS, ConsoleColor forColor, ConsoleColor backColor)
        {
                lock (theadlock)
                {
                    if (instance == null)
                        instance = new Singleton(OS, forColor, backColor);
                    return instance;
                }

        }
    }
}