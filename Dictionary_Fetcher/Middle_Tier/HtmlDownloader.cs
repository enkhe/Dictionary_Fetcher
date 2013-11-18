using System;
using System.IO;
using System.Net;

namespace Dictionary_Fetcher.Middle_Tier
{
    class HtmlDownloader : IHtmlDownloader
    {
        public static string DownloadThisLink(Uri uri)
        {
            var client = new WebClient();
            var data = client.OpenRead(uri);
            var reader = new StreamReader(data);
            return reader.ReadToEnd();
        }

        string IHtmlDownloader.DownloadThisLink(Uri uri)
        {
            return DownloadThisLink(uri);
        }
    }
}