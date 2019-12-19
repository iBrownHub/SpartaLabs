using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace New_Labs
{
    class Program
    {
        static Stopwatch s = new Stopwatch();

        static void Main(string[] args)
        {
            s.Start();
            var task01 = Task.Run(() =>
            {
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task01 completed at time: {s.ElapsedMilliseconds}");
            }
            );
            var actionDelegate = new Action(SpecialActionMethod);
            var task02 = new Task(actionDelegate);
            task02.Start();
            //Array of tasks
            Task[] taskArray = new Task[]
            {
                new Task(()=>{ }),
                new Task(()=>{ }),
                new Task(()=>{ }),
                new Task(()=>{ }),
                new Task(()=>{ })
            };
            foreach (var task in taskArray)
            {
                task.Start();
            }

            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"Array Task 1 completes after {s.ElapsedMilliseconds}");
            }
            );
            taskArray2[1] = Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"Array Task 2 completes after {s.ElapsedMilliseconds}");
            }
            );
            taskArray2[2] = Task.Run(() =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Array Task 3 completes after {s.ElapsedMilliseconds}");
            }
            );
            Task.WaitAny(taskArray2);
            Console.WriteLine($"waiting for first taskArray2, completes at: {s.ElapsedMilliseconds}");
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Waiting for all taskArray2, completes at: {s.ElapsedMilliseconds}");
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            Stopwatch s1 = new Stopwatch();
            s1.Start();
            Parallel.ForEach(myCollection, (item) => 
            {
                Thread.Sleep(item * 100);
                Console.WriteLine($"async for each loop item {item} finishing at time {s.ElapsedMilliseconds}");
            }
            );
            Console.WriteLine($"Async loop took {s1.ElapsedMilliseconds} seconds to finish");
            Stopwatch s2 = new Stopwatch();
            s2.Start();
            foreach (var item in myCollection)
            {
                //Thread.Sleep(item * 100);
                Console.WriteLine($"sync for each loop item {item} finishing at time {s.ElapsedMilliseconds}");
            }
            Console.WriteLine($"Sync loop took {s2.ElapsedMilliseconds} seconds to finish");
            var databaseOutput =
                (from item in myCollection
                 select item * item).AsParallel().ToList();
            var taskWithoutReturn = new Task( () => { });
            var taskWithReturn = new Task<int>(() => 
            {
                int total = 1;
                for (int i = 0; i < 100; i++)
                {
                    int j = i * i;
                    total += j;
                }
                return total;
            });
            taskWithReturn.Start();
            Console.WriteLine($"I have counted to 100 using this background task so i dont have to hang the main thread while i wait." +
                $" The answer is {taskWithReturn.Result}");
            Console.WriteLine("Actually, Disclaimer, the act of waiting for a result my definition turns this into a synchronous operation");
            Console.WriteLine($"Application completed at time: {s.ElapsedMilliseconds}");
            Console.ReadLine();
        }
        static void SpecialActionMethod()
        {
            Console.WriteLine("This action takes no parameters, returns nothing, but just performs an action, in this case print out...");
            var total = 0;
            for (int i = 0; i < 500_000_000; i++)
            {
                total++;
            }
            Thread.Sleep(1000);
            Console.WriteLine($"Special action method completed at time : {s.ElapsedMilliseconds}");
        }
    }
}
