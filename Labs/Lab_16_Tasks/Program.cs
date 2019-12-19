using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab_16_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            //inside here can go a delegate or an anonymous method using lambda syntax
            var task01 = new Task(
                () =>
                { }
                );
            var task02 = new Task(
                () =>
                { Console.WriteLine("In Task 02"); }
                );
            task02.Start();
            var task03 = Task.Run
                (
                () => { Console.WriteLine("In task 03"); }
                );
            var task04 = Task.Run
                (
                () => { Console.WriteLine("In task 04"); }
                );
            var task05 = Task.Run
                (
                () => { Console.WriteLine("In task 05"); }
                );
            //Add stopwatch
            //Array of tasks
            //Wait for one to complete/all to complete
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
            Console.ReadLine();
        }
    }
}
