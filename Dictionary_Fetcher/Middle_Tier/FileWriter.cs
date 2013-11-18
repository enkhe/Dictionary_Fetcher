using System.IO;

namespace Dictionary_Fetcher.Middle_Tier
{
    class FileWriter
    {
        public static void WriteToThis(string filename, string line)
        {
            using (var writer = new StreamWriter(filename, true))
            {
                writer.WriteLine(line);
                writer.Close();
            }
        }
    }
}