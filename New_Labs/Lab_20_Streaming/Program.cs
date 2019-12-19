using System;
using System.IO; //Input Output
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Lab_20_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            var numberOfLines = 100000;
            Stopwatch s = new Stopwatch();
            s.Start();
            File.WriteAllText("data.txt", "Hello World!");
            var myArray = new string[] { "Hello", "World!" };
            File.WriteAllLines("ArrayData.txt", myArray);

            //Append data
            for (int i = 0; i < 10; i++)
            {
                File.AppendAllText("data.txt", $"{Environment.NewLine}Adding line {i} at {DateTime.Now}");
            }
            Console.WriteLine(File.ReadAllText("data.txt"));
            var output = File.ReadAllLines("ArrayData.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("ANewFolder");
            File.Create(@"ANewFolder\NewFile.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));



            //Stream some data to a file
            //System can cope with large files - breaks them down into blocks and sends them

            using (var writer01 = new StreamWriter("output.dat"))
            {
                for (int i = 0; i < numberOfLines; i++)
                {
                    writer01.WriteLine($"Logging some data at {DateTime.Now}");
                }
            }
            var writeTime = s.ElapsedMilliseconds;
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {numberOfLines} lines");
            string nextLine;
            using (var reader01 = new StreamReader("output.dat"))
            {
                // Reader doesn't know how big the file is
                // Read until reader01.ReadLine is null
                while ((nextLine = reader01.ReadLine()) != null)
                {
                    //Console.WriteLine(nextLine);
                }
                reader01.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds-writeTime} to read {numberOfLines} lines");
            //building a string
            // regular string building with + generates a new instance every time.
            // strings are immutable(because array) so we cannot change them
            // eg this
            //t=>th=>thi=>this
            s.Restart();
            var longString = "";
            using (var reader01 = new StreamReader("output.dat"))
            {
                // Reader doesn't know how big the file is
                // Read until reader01.ReadLine is null
                while ((nextLine = reader01.ReadLine()) != null)
                {
                    longString += nextLine;
                }
                reader01.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} lines together");
            //Console.WriteLine(longString);
            s.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();
            using (var reader01 = new StreamReader("output.dat"))
            {
                // Reader doesn't know how big the file is
                // Read until reader01.ReadLine is null
                while ((nextLine = reader01.ReadLine()) != null)
                {
                    stringBuilder.Append(nextLine);
                }
                reader01.Close();
            }
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to add {numberOfLines} lines together using String Builder");
        }
    }
}
