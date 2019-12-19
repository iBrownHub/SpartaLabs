using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using System.Runtime.Serialization.Formatters.Soap;

namespace Lab_27_Serialising_Homework
{
    public class Program
    {
        public static List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            Customer cust1 = new Customer(1, "Jamie", 34);
            Customer cust2 = new Customer(2, "Gary", 28);
            var serialise = new SerialisingDifferentTypes();
            customers.Add(cust1);
            customers.Add(cust2);
            serialise.SerialiseToBinary();
            serialise.SerialiseToJSON();
            serialise.SerialiseToXML();
        }
    }
    class SerialisingDifferentTypes
    {
        public void SerialiseToBinary()
        {
            var binFormatter = new BinaryFormatter();
            using (var stream = new FileStream("data1.bin", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormatter.Serialize(stream, Program.customers);
            }
            var customersFromBinary = new List<Customer>();
            using (var reader = File.OpenRead("data1.bin"))
            {
                customersFromBinary = binFormatter.Deserialize(reader) as List<Customer>;
            }
            customersFromBinary.ForEach(cust => Console.WriteLine($"{cust.ID}, {cust.name}, {cust.age}"));
        }
        public void SerialiseToXML()
        {
            var soapFormatter = new SoapFormatter();
            using (var stream = new FileStream("data1.xml",FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormatter.Serialize(stream, Program.customers);
            }
            var customersFromXML = new List<Customer>();
            using (var reader = File.OpenRead("data1.xml"))
            {
                customersFromXML = soapFormatter.Deserialize(reader) as List<Customer>;
            }
            customersFromXML.ForEach(cust => Console.WriteLine($"{cust.ID}, {cust.name}, {cust.age}"));

        }
        public void SerialiseToJSON()
        {
            var jsonCustomerList = JsonConvert.SerializeObject(Program.customers);
            File.WriteAllText("data1.json", jsonCustomerList);
            var gettingJSONFile = File.ReadAllText("data1.json");
            var customersFromJSON = JsonConvert.DeserializeObject<List<Customer>>(gettingJSONFile);
            customersFromJSON.ForEach(cust => Console.WriteLine($"{cust.ID}, {cust.name}, {cust.age}"));
        }
    }
    [Serializable]
    public class Customer
    {
        public int ID { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Customer(int ID, string name, int age)
        {
            this.ID = ID;
            this.name = name;
            this.age = age;
        }
    }
}
