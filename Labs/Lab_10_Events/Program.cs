using System;

namespace Lab_10_Events
{
    class Program
    {
        delegate void MyDelegate();
        static event MyDelegate myEvent;
        static void Main(string[] args)
        {
            myEvent += Method01;
            myEvent += Method02;
            myEvent();
        }
        static void Method01()
        {
            Console.WriteLine("Running Method 01");
        }
        static void Method02()
        {
            Console.WriteLine("Running Method 02");
        }
    }
}
