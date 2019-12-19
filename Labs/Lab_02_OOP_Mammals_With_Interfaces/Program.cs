using System;

namespace Lab_02_OOP_Mammals_With_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Lion lion = new Lion();
            Tiger tiger = new Tiger();
            lion.Roar();
            lion.SeeMyPrey();
            lion.SmellMyPrey();
            tiger.Roar();
            tiger.SeeMyPrey();
            tiger.SmellMyPrey();
        }
    }
    class Mammal
    {
        bool isWarmBlooded = true;
       
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
    }
    class Cat : Mammal
    {
        public virtual void Roar()
        {

        }
    }
    class Lion : Cat, IUseVision, IUseSmell
    {
        public void SeeMyPrey()
        {
            Console.WriteLine("Lion is seeing it's prey!");

        }
        public void SmellMyPrey()
        {
            Console.WriteLine("Lion is smelling its prey!");

        }
        public override void Roar()
        {
            Console.WriteLine("Lion is Roaring!");
        }
    }
    class Tiger : Cat, IUseVision, IUseSmell
    {
        public void SeeMyPrey()
        {
            Console.WriteLine("Tiger is seeing it's prey!");
        }
        public void SmellMyPrey()
        {
            Console.WriteLine("Tiger is smelling it's prey!");
        }
        public override void Roar()
        {
            Console.WriteLine("Tiger is Roaring!");
        }
    }
    interface IUseVision
    {
        void SeeMyPrey();
    }
    interface IUseSmell
    {
        void SmellMyPrey();
    }
}
