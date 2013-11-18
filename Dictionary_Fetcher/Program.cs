using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dictionary_Fetcher.Middle_Tier;

namespace Dictionary_Fetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveTranslatedWordsToDb();

            Console.ReadLine();
        }

        private static string UnicodeString(string text)
        {
            return Encoding.UTF8.GetString(Encoding.ASCII.GetBytes(text));
        }

        private static void SaveTranslatedWordsToDb()
        {
            var fileDir = AppDomain.CurrentDomain.BaseDirectory.ToString(CultureInfo.InvariantCulture).Replace("\\", "/");

            //const string fileName = "C:/Users/Enkh/Downloads/web/wordsEn.txt";
            //const string fileResult = "C:/Users/Enkh/Downloads/web/result.txt";

            const string fileName = "wordsEn.txt";
            const string fileResult = "result.txt";
            var rootWordList = FileReader.GetEachLine(fileName);
            var counter = 1;
            foreach (var rootWord in rootWordList)
            {
                var stopWatch = new Stopwatch();
                stopWatch.Start();

                HtmlParser.Parse(rootWord, fileDir);

                stopWatch.Stop();
                var strInfo = counter++ + "\t" + stopWatch.Elapsed.Milliseconds + "\t" + rootWord;
                FileWriter.WriteToThis(fileResult, strInfo);
                writeln(strInfo);
            }


        }


        static void writeln(string s)
        {
            Console.WriteLine(s);
        }

        static void write(string s)
        {
            Console.Write(s);
        }
    }
}
