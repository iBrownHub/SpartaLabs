using System;
using System.Net;
using System.Diagnostics;

namespace Lab_21_HTTP
{
    class Program
    {
        static void Main(string[] args)
        {
            var uri = new Uri("https://www.bbc.co.uk/weather");
            Console.WriteLine($"Host is {uri.Host}");
            Console.WriteLine($"Port is {uri.Port}");
            Console.WriteLine($"Path is {uri.AbsolutePath}");
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "localPage.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "localPage.html");
        }
    }
}
