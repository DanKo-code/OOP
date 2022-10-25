using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_4performance
{
    public static class Controller
    {
        public static Program.TvProgram[] GetSameYearFilms(this Program.ProgramGuide temp, int year)
        {
            Program.TvProgram[] buf = Array.Empty<Program.TvProgram>();
           

            for (int i = 0; i < temp.items.Length; i++)
            {
                if(temp.items[i] is Program.Film test)  
                {
                    if(test.releaseYear == year)
                    {
                        Program.TvProgram[] buf2 = new Program.TvProgram[buf.Length + 1];
                        buf.CopyTo(buf2, 0);
                        buf2[buf.Length] = temp.items[i];
                        buf = buf2;
                    }
                }
            }

            return buf;
        }

        public static int GetProgramTime(this Program.ProgramGuide temp)
        {
            int time = 0;

            for (int i = 0; i < temp.items.Length; i++)
            {
                time += temp.items[i].Duration;
            }

            return time;
        }

        public static int GetAdvertisingNumb(this Program.ProgramGuide temp)
        {
            int advertisingNumb = 0;

            for (int i = 0; i < temp.items.Length; i++)
            {
                if (temp.items[i] is Program.Advertising) ++advertisingNumb;
            }

            return advertisingNumb;
        }
    }
}
