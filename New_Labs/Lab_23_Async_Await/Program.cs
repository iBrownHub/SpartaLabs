using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Diagnostics;

namespace Lab_23_Async_Await
{
    class Program
    {
        static void Main(string[] args)
        {
            //Main method here
            //Setup - Create data file
            //CSV - Comma Separated Values
            File.WriteAllText("data.csv", "id,name,age" + Environment.NewLine);
            File.AppendAllText("Data.csv", "1,Bob,21" + Environment.NewLine);
            File.AppendAllText("Data.csv", "2,Tom,26" + Environment.NewLine);
            File.AppendAllText("Data.csv", "3,Graeme,26" + Environment.NewLine);
            ReadDataSync();
            ReadDataAsync();
            GetWebPageAsync();
            GetWebPageSync();
            Console.WriteLine("Code has finished");
            Console.ReadLine();
            //Sync method - we wait for it
            //Async method - we dont wait for it
        }
        static void ReadDataSync()
        {
            var s = new Stopwatch();
            s.Start();
            var output = File.ReadAllText("data.csv");
            Console.WriteLine("Counting to 5");
            Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);
            Console.WriteLine(s.ElapsedMilliseconds);
        }
        static async void ReadDataAsync()
        {
            var s = new Stopwatch();
            s.Start();
            var output = await File.ReadAllTextAsync("data.csv");
            Console.WriteLine("Counting to 5");
            Thread.Sleep(5000);
            Console.WriteLine("\nAsync\n");
            Console.WriteLine(output);
            Console.WriteLine(s.ElapsedMilliseconds);
        }
        static void GetWebPageSync()
        {
            var s = new Stopwatch();
            s.Start();
            var uri = new Uri("https://www.google.co.uk");
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFile(uri, "googleWebPageSync.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "googleWebPageSync.html");
            Console.WriteLine($"Sync method took {s.ElapsedMilliseconds} milliseconds");
        }
        static async void GetWebPageAsync()
        {
            var s = new Stopwatch();
            s.Start();
            var uri = new Uri("https://www.google.co.uk");
            var webClient = new WebClient { Proxy = null };
            webClient.DownloadFileAsync(uri, "googleWebPageAsync.html");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "googleWebPageAsync.html");
            Console.WriteLine($"Async methood took {s.ElapsedMilliseconds} milliseconds");
        }
    }
}
