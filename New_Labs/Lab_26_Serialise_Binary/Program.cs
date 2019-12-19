using System;
using System.IO;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using Lab_25_Serialise_JSON;


namespace Lab_26_Serialise_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Joe", "GF207356L");
            var customer2 = new Customer(2, "Claudia", "JX342105Y");
            var customers = new List<Customer>() { customer, customer2 };
            var formatter = new BinaryFormatter();
            using (var stream = new FileStream("data.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                formatter.Serialize(stream, customers);
            };
            var customersFromBinary = new List<Customer>();
            using (var reader = File.OpenRead("data.bin"))
            {
                customersFromBinary = formatter.Deserialize(reader) as List<Customer>;
            }
            customersFromBinary.ForEach((cust) => { Console.WriteLine(cust.CustomerID); Console.WriteLine(cust.CustomerName); });
        }
    }
}
