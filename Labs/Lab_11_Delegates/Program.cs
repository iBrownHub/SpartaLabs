using System;

namespace Lab_11_Delegates
{
    class Program
    {
        public delegate void Delegate01();

        delegate float Delegate02(float x);
        static void Main(string[] args)
        {
            // A delegate can be referenced as a class
            //so we can use the new keyword. 
            var delegateInstance = new Delegate01(MyMethod01);
            // call this
            delegateInstance();

            // in trivial cases we can simplify to get the same result
            // 1. omit 'New'
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2();

            // final trivial case
            // Action delegate is void and takes no parameters
            Action delegateInstance3 = MyMethod01;
            delegateInstance3();
            //Action delegateInstance4 = MyMethod02;  - cannot do this as an action delegate must have no return type
            Delegate02 delegateInstance4 = (x) => { return x * x * x; }; //Lambda
                                // Input Params   { // Code Body    }
            Delegate02 delegateInstance5 = x => x * x * x; //Lambda
                                                           // Input Params   { // Code Body    }
            Console.WriteLine(MyMethod03(delegateInstance5(35)));
        }
        static void MyMethod01()
        {
            Console.WriteLine("Running MyMethod01");
        }
        static string MyMethod02()
        {
            return "Running MyMethod01";
        }
        static float MyMethod03(float x)
        {
            return x * x;
        }
    }
}
