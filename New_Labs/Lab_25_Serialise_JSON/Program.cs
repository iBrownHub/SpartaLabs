using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab_25_Serialise_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Joe", "GF207356L");
            var customer2 = new Customer(2, "Claudia", "JX342105Y");
            var customers = new List<Customer>() { customer, customer2 };
            //Serialise
            var jsonCustomerList = JsonConvert.SerializeObject(customers);            
            //Peek at this object
            Console.WriteLine(jsonCustomerList);
            //Save to file
            File.WriteAllText("data.json", jsonCustomerList);
            //Read
            var jsonString = File.ReadAllText("data.json");
            //Deserialise
            var customersFromJSON = JsonConvert.DeserializeObject<List<Customer>>(jsonString);
            //Print
            customersFromJSON.ForEach((cust) => { Console.WriteLine(cust.CustomerID); Console.WriteLine(cust.CustomerName); });
        }
    }
    [Serializable]
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        [NonSerialized]
        private string NINO;

        public Customer(int id, string name, string nino)
        {
            CustomerID = id;
            CustomerName = name;
            NINO = nino;
        }
    }
}
