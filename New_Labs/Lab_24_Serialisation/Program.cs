using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;

namespace Lab_24_Serialisation
{
    class Program
    {
        static void Main(string[] args)
        {
            var customer = new Customer(1, "Joe", "GF207356L");
            var customer2 = new Customer(2, "Claudia", "JX342105Y");
            var customers = new List<Customer>() { customer, customer2 };
            //serialise customer to XML format
            //Create object for serilisation
            //SOAP - Simple Object Access Protocol - XML transission mechanism
            var formatter = new SoapFormatter();
            //Stream customer to file WRITE
            //About to stream data to xml file - each time create new file
            using (var stream = new FileStream(
                "data.xml", FileMode.Create, FileAccess.Write, FileShare.None))
            {
                //Serialise data to XML as a stream of data and send to the file stream
                formatter.Serialize(stream, customers);
            }
            //Print out file
            //Console.WriteLine(File.ReadAllText("data.xml"));
            //Reverse

            var customersFromXMLFile = new List<Customer>();
            //stream read
            using(var reader = File.OpenRead("data.xml"))
            {
                //Deserialise XML to Customer
                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }
            customersFromXMLFile.ForEach((cust) => { Console.WriteLine(cust.CustomerID); Console.WriteLine(cust.CustomerName); });
        }
    }
    [Serializable]
    class Customer
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
