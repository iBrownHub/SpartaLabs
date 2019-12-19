using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Lab_07_Northwind_SQLite
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            //AddCustomer();
            UpdateCustomer("RABSG");
            PrintCustomers();
        }
        static void PrintCustomers()
        {
            using (var db = new CustomerDbContext())
            {
                customers = db.Customers.ToList();
            }
            foreach (var customer in customers)
            {
                Console.WriteLine($"{customer.CustomerID,-10}{customer.ContactName,-40}{customer.CompanyName,-40}{customer.City, -15}{customer.Country}");
            }
        }
        static void AddCustomer()
        {
            Random rand = new Random();
            var newCustomer = new Customer()
            {
                CustomerID = "RABSG",
                ContactName = "Ross Brown",
                CompanyName = "Sparta Global",
                City = "Hemel Hempstead",
                Country = "UK"
            };
            using (var db = new CustomerDbContext())
            {
                db.Customers.Add(newCustomer);
                db.SaveChanges();
            }
        }
        static void UpdateCustomer(string ID)
        {

            //var randomRabbitName = Console.ReadLine();
            using (var db = new CustomerDbContext())
            {
                var updateCustomer = db.Customers.Find(ID);
                updateCustomer.Country += "Bolivia";
                db.Customers.Update(updateCustomer);
                db.SaveChanges();
            }
        }
    }
    class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
    class CustomerDbContext : DbContext
    {
        // set our table in Database called rabbits
        public DbSet<Customer> Customers { get; set; }

        // method to connect to database

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=C:\Users\Ross Brown\Engineering45\SQLite\Northwind.db";
            builder.UseSqlite(connectionString);
        }
    }
}
