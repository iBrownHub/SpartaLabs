using System;

namespace Lab_12_OOP_Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var newChild = new Child("James");
            newChild.Grow();
            newChild.Grow();
            newChild.Grow();
            newChild.Grow();
            newChild.Grow();
        }
    }
    class Child
    {
        public Child(string name)
        {
            this.Name = name;
            this.Age = 0;
            HaveABirthday += HaveAParty; // Placeholder
        }
        // Trivial Event annual Birthday! WWWWWWWWWWWWOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        delegate void BirthdayDelegate();
        event BirthdayDelegate HaveABirthday;
        public string Name { get; set; }
        public int Age { get; set; }
        public void HaveAParty()
        {
            Age++;
            Console.WriteLine("Hey celebrating another Year, you're now {0} years of age", Age);
        }
        public void Grow()
        {
            HaveABirthday();
        }
    }
}
