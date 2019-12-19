using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace lab_04_Connect_To_Raw_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ means take literally what is in the following string
            //ie no escaping of characters allowed
            // eg @"c:\Folder\File" is fine
            //  however without @ it would have to be "c:\\Folder\\File" using escaping
            string connectionString = @"Data source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                //READ FROM DATABASE
                using (var sqlCommand = new SqlCommand("Select * from Customers", connection))
                {
                    // create a loop to read and iterate and parse data
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    // Loop while data present
                    while (reader.Read())
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-15}{ContactName}");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
