using System;
using System.Collections.Generic;

namespace Lab_09_Rabbit_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    public class RabbitCollection
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        public static List<Rabbit> rabbitsWithAge = new List<Rabbit>();

        /*
         Input totalYears to run system
         Output will be list of rabbits
         Every year double number of rabbits
         Every year increment age also for every rabbit
         Test data
         year 0 1 rabbit age 0
         year 1 2 rabbits age 1,0
         year 2 4 rabbits age 2,1,0,0
         year 3 8 rabbits age 3,2,1,1,0,0,0,0
         */
        public (int cumulativeAge, int RabbitCount) MultiplyRabbits(int totalYears)
        {
            rabbits.Clear();
            int cumulativeRabbitAge = 0;
            var rabbit0 = new Rabbit
            {
                RabbitID = 0,
                RabbitName = "Rabbit0",
                RabbitAge = 0
            };
            rabbits.Add(rabbit0);
            // Needs to be coded properly
            for (int year = 0; year < totalYears; year++)
            {               
                foreach (var rabbit in rabbits.ToArray())
                {
                    rabbit.RabbitAge++;
                    var newRabbit = new Rabbit();
                    rabbits.Add(newRabbit);
                }                
            }
            foreach (var rabbit in rabbits)
            {
                cumulativeRabbitAge += rabbit.RabbitAge;
            }
            return (cumulativeRabbitAge, rabbits.Count);
        }
        public (int cumulativeAge, int RabbitCount) MultiplyRabbitsWithAge(int totalYears)
        {
            rabbitsWithAge.Clear();
            int cumulativeRabbitAgeWithAge = 0;
            var rabbit0 = new Rabbit
            {
                RabbitID = 0,
                RabbitName = "Rabbit0",
                RabbitAge = 0
            };
            rabbitsWithAge.Add(rabbit0);
            // Needs to be coded properly
            for (int year = 0; year < totalYears; year++)
            {
                foreach (var rabbit in rabbitsWithAge.ToArray())
                {
                    rabbit.RabbitAge++;
                    if (rabbit.RabbitAge >= 3)
                    {
                        var newRabbit = new Rabbit();
                        rabbitsWithAge.Add(newRabbit);
                    }
                }
            }
            foreach (var rabbit in rabbitsWithAge)
            {
                cumulativeRabbitAgeWithAge += rabbit.RabbitAge;
            }
            return (cumulativeRabbitAgeWithAge, rabbitsWithAge.Count);
        }
    }
    public class Rabbit
    {
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
        public Rabbit()
        {
            this.RabbitID = RabbitCollection.rabbits.Count + 1;
            RabbitName = "Rabbit" + RabbitID;
            RabbitAge = 0;
        }
    }
}
