using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab_06_Rabbits_DB
{
    class Program
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();
        public static List<Rabbit> newRabbits = new List<Rabbit>();
        static void Main(string[] args)
        {
            rabbits.Add(AddRabbit());
            while (rabbits.Count < 1001)
            {
                using (var db = new RabbitDbContext())
                {
                    rabbits = db.Rabbits.ToList();
                }
                foreach (var Rabbit in rabbits)
                {
                    if (Rabbit.RabbitAge >= 3)
                    {
                        AddRabbit();
                    }
                    UpdateRabbit(Rabbit.RabbitID);
                }
                using (var db = new RabbitDbContext())
                {
                    rabbits = db.Rabbits.ToList();
                }
            }
            PrintRabbits();
            //int rabbitToUpdate = Convert.ToInt32(Console.ReadLine());            
            //UpdateRabbit(rabbitToUpdate);
            
            //PrintRabbits();
        }
        static void PrintRabbits()
        {
            using (var db = new RabbitDbContext())
            {
                rabbits = db.Rabbits.ToList();
            }
            foreach (var rabbit in rabbits)
            {
                Console.WriteLine($"{rabbit.RabbitID,-10}{rabbit.RabbitName,-10}{rabbit.RabbitAge}");
            }
        }
        static Rabbit AddRabbit()
        {
            Random rand = new Random();
            var randomRabbitName = GenerateRandomRabbitName();
            var newRabbit = new Rabbit()
            {
                RabbitName = randomRabbitName,
                RabbitAge = 0
            };
            using (var db = new RabbitDbContext())
            {
                db.Rabbits.Add(newRabbit);
                db.SaveChanges();
            }
            return newRabbit;
        }
        static void UpdateRabbit(int ID)
        {
            
            //var randomRabbitName = Console.ReadLine();
            using (var db = new RabbitDbContext())
            {
                var updateRabbit = db.Rabbits.Find(ID);
                updateRabbit.RabbitAge += 1;
                db.Rabbits.Update(updateRabbit);
                db.SaveChanges();
            }
        }
        static string GenerateRandomRabbitName()
        {
            string result = string.Empty;
            Random rand = new Random();
            List<char> characters = new List<char>();
            for (int i = 65; i < 91; i++)
            {
                characters.Add((char)i);
            }
            for (int i = 0; i < 5; i++)
            {
                result += characters[rand.Next(0, characters.Count)];
            }            
            return result;
        }
    }

    class Rabbit
    {
        public Rabbit()
        {

        }
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int RabbitAge { get; set; }
    }

    // Connect To Database
    class RabbitDbContext : DbContext
    {
        // set our table in Database called rabbits
        public DbSet<Rabbit> Rabbits { get; set; }

        // method to connect to database

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=RabbitsDB;";
            builder.UseSqlServer(connectionString);
        }
    }
}
