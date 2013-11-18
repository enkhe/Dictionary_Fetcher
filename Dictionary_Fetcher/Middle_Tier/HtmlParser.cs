using System;
using System.Globalization;
using System.IO;

namespace Dictionary_Fetcher.Middle_Tier
{
    class HtmlParser
    {

        public static void Parse(string rootWord, string fileDir)
        {
            /* Not Being used right now.
            var fileDir = "";
            EnumLoop<UrlType>
                .ForEach(typeOfUrl =>
                    SaveWordDefinitionsToFileFromWebsite(typeOfUrl, rootWord, fileDir)
                ); 
            SaveWordDefinitionsToFileFromWebsite(UrlType.Asuult, rootWord, fileDir);
            */

            var fileDirBo = fileDir + "_bo/";
            CreateIfMissing(fileDirBo);
            SaveBolorToliDefinitionsToFile(rootWord, fileDirBo);


            //var fileDirAs = fileDir + "_as/";
            //CreateIfMissing(fileDirAs);
            //SaveAsuultToliDefinitionsToFile(rootWord, fileDirAs);
        }

        private static void SaveBolorToliDefinitionsToFile(string rootWord, string fileDir)
        {
            var htmlLinkBolor = GetUrlLink(rootWord, UrlType.BolorToli);
            var htmlBolor = HtmlDownloader.DownloadThisLink(new Uri(htmlLinkBolor));
            var fileName = fileDir + rootWord + ".html";
            const string strDefExist = "Your requested term has not found in dictionary!";
            FileWriter.WriteToThis(fileName, htmlBolor.Contains(strDefExist) ? "" : htmlBolor);
        }

        private static void SaveAsuultToliDefinitionsToFile(string rootWord, string fileDir)
        {
            var htmlLinkAsuult = GetUrlLink(rootWord, UrlType.Asuult);
            var htmlAsuult = HtmlDownloader.DownloadThisLink(new Uri(htmlLinkAsuult));
            var fileName = fileDir + rootWord + ".html";
            FileWriter.WriteToThis(fileName, htmlAsuult);
        }

        private static void CreateIfMissing(string path)
        {
            bool folderExists = Directory.Exists(path);
            if (!folderExists)
                Directory.CreateDirectory(path);
        }

        private static string GetUrlLink(string rootWord, UrlType urlType)
        {
            var urlLink = "";
            switch (urlType)
            {
                case UrlType.Asuult:
                    urlLink = "http://asuult.net/dic/hailtiin_hariu.php?haih_ug=" + rootWord + "&huudasnii_too=0&chiglel=English-Mongolian";
                    break;
                case UrlType.BolorToli:
                    urlLink = "http://www.bolor-toli.com/index.php?pageId=10&go=1&direction=mn-en&search=" + rootWord;
                    break;
                default:
                    break;
            }
            return urlLink;
        }

        /*     Not Being used right now.
         * 
         * 
        private static void SaveWordDefinitionsToFileFromWebsite(UrlType webType, string rootWord, string fileDir)
        {
            var htmlLink = GetUrlLink(rootWord, webType);
            var htmlBolor = HtmlDownloader.DownloadThisLink(new Uri(htmlLink));
            //var fileDir = AppDomain.CurrentDomain.BaseDirectory.ToString(CultureInfo.InvariantCulture).Replace("\\", "/");
            //const string fileDir = @"C:\_words\";
            //var fileName = "_bo_" + rootWord + ".html";
            var fileName = fileDir + rootWord + ".html";
            FileWriter.WriteToThis(fileName, htmlBolor);
        }

        private static void DoBolorToli(string rootWord)
        {
            var htmlLinkBolor = GetUrlLink(rootWord, UrlType.BolorToli);
            var htmlBolor = HtmlDownloader.DownloadThisLink(new Uri(htmlLinkBolor));
            var defTable1 = new DefinitionsTable
            {
                Word = rootWord,
                LinkAddress = htmlLinkBolor,
                HtmlText = htmlBolor,
                TypeOfWebsite = "bolor-toli.com"
            };
            Repository.Add(defTable1);
            Repository.Save();
        }

        */
    }
    /* Not Being Used
    class EnumLoop<TKey> where TKey : struct, IConvertible
    {
        static readonly TKey[] Arr = (TKey[])Enum.GetValues(typeof(TKey));
        static internal void ForEach(Action<TKey> act)
        {
            foreach (TKey t in Arr)
            {
                act(t);
            }
        }
    }
    */
}
