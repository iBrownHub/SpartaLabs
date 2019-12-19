using System;

namespace Lab_03_OOP_Every_Feature_Combined
{
    class Program
    {
        static void Main(string[] args)
        {
            V8Car v8 = new V8Car();
            PetrolTank pt = new PetrolTank();
            v8.Engine();
            v8.TypeOfCar();
            pt.StartFlow();

        }
    }
    class Car : CarType
    {
        public virtual void Engine()
        {

        }
        int topSpeed = 165;
         public int PetrolAmount { get; set; }
        
        public override void TypeOfCar()
        {
            Console.WriteLine("Mercedes");
            Console.WriteLine("My top speed is {0}", topSpeed);
        }
    }
    abstract class CarType
    {
        public abstract void TypeOfCar();
    }
    sealed class PetrolTank
    {
        Car car = new Car();
        public void StartFlow()
        {
            car.PetrolAmount = 5;
            if (car.PetrolAmount > 0)
            {
                Console.WriteLine("Petrol is flowing");
            }
        }
    }
    class V8Car : Car
    {
        public override void Engine()
        {
            Console.WriteLine("this is a V8");
        }
    }
}
