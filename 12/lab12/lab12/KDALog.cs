using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab12
{
    internal class KDALog
    {


        int counterUpdate = 0;
        private readonly string patch;

        public KDALog(string patch)
        {
            this.patch = patch;
        }

        //записывать в этот файл все действия

        public void WriteActionInFile(string messageUpdate)
        {
            using (StreamWriter sw = new StreamWriter(patch, true))
            {
                sw.WriteLine($"<><><><><><><><><><><><><> Action: {counterUpdate + 1} <><><><><><><><><><><><><>\n");
                sw.WriteLine($"Time Update: {DateTime.Now.ToString()}\n");
                sw.WriteLine(messageUpdate);
                sw.WriteLine($"\n<><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><><");
            }
            counterUpdate++;
        }
    }
}
