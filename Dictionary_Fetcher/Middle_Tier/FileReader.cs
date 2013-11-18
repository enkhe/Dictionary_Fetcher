using System.Collections.Generic;
using System.IO;

namespace Dictionary_Fetcher.Middle_Tier
{
    class FileReader
    {
        public static List<string> GetEachLine(string filename)
        {
            var lines = new List<string>();
            using (var sr = new StreamReader(filename))
            {
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            return lines;
        }
    }
}