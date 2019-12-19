using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAb_19_northwind_Tests
{
    class Program
    {
        List<Customer> customers = new List<Customer>();
        static void Main(string[] args)
        {
            NorthwindCustomers nc = new NorthwindCustomers();
            Console.WriteLine(nc.NumberOfNorthwindCustomers(""));
            Console.WriteLine(nc.NumberOfNorthwindCustomers("London"));
            Console.WriteLine(nc.NumberOfNorthwindCustomers("Berlin"));
            Console.ReadKey();
        }
    }
    public class NorthwindCustomers
    {
        public int NumberOfNorthwindCustomers(string city)
        {
            using (var db = new NorthwindEntities())
            {
                if (city == null || city == "")
                {
                    return db.Customers.Count();
                }
                else
                {
                    var londonCustomers =
                        (from cust in db.Customers
                         where cust.City == city
                         select cust).ToList();
                    return londonCustomers.Count();
                }
            }
        }
    }

}
