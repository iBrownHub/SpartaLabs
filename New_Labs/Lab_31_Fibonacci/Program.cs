using System;

namespace Lab_31_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            var fib = new Fibonacci();
            
            Console.WriteLine(fib.ReturnFibonacciNthItemInSequence(5));

        }
    }
    public class Fibonacci
    {
        public int ReturnFibonacciNthItemInSequence(int n)
        {
            //return n'th item in sequence
            int result = 0;
            int prev = 0;
            if (n > 0)
            {
                result++;
            }
            for (int i = 1; i < n; i++)
            {
                result = result + prev;
                prev = result - prev;
            }
            return result;
        }
    }
}
