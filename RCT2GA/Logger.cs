using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RCT2GA
{
    public static class Logger
    {
        static List<string> logLines = new List<string>();

        public static void Log(string message)
        {
            Console.WriteLine(message);
            logLines.Add(message);
        }

        public static void Clear()
        {
            logLines.Clear();
        }

        public static void Save(string filepath)
        {
            using (StreamWriter sw = new StreamWriter(filepath))
            {
                for (int i = 0; i < logLines.Count(); i++)
                {
                    sw.WriteLine(logLines[i]);
                }
            }
        }
    }
}
