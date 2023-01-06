using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motor_depot.Singleton
{
    internal class Singleton
    {
        private static Singleton single = null;

        protected Singleton()
        {

        }

        public void Clearconsole()
        {
            Console.Clear();
        }

        public void CBC ()
        {
            Console.BackgroundColor = ConsoleColor.Green;
        }

        public static Singleton Initialize()
        {
            if(single == null)
                single = new Singleton();

            return single;
        }
    }
}
