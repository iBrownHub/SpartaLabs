using System;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Lab_05_CRUD_App_Raw_SQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer customerJustAdded;
        static void Main(string[] args)
        {
            var connectionString = @"Data source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";

            using (var sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                Console.WriteLine(sqlConnection.State);
                customerJustAdded = AddCustomer(sqlConnection);
                ListCustomers(sqlConnection);
                UpdateCustomer(sqlConnection, customerJustAdded);
                ListCustomers(sqlConnection);
                DeleteCustomer(sqlConnection, customerJustAdded);
                ListCustomers(sqlConnection);
            }
        }

        static void UpdateCustomer(SqlConnection sqlConnection, Customer c)
        {
            c.ContactName = "Ross Brown";
            var updateSqlString = $"UPDATE Customers SET ContactName='{c.ContactName}' WHERE CustomerID='{c.CustomerID}'";
            using (var sqlCommand = new SqlCommand(updateSqlString, sqlConnection))
            {
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} records(s) updated");
            }
        }

        static void DeleteCustomer(SqlConnection sqlConnection, Customer c)
        {
            var deleteSqlString = $"DELETE FROM Customers WHERE CustomerID='{c.CustomerID}'";
            using (var sqlCommand = new SqlCommand(deleteSqlString, sqlConnection))
            {
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} records(s) deleted: {c.CustomerID} {c.ContactName}");
            }
        }

        static Customer AddCustomer(SqlConnection sqlConnection)
        {
            var randomCustomerID = GenerateRandomCustomerID();
            var newCustomer = new Customer()
            {
                CustomerID = randomCustomerID,
                CompanyName = "Sparta Global",
                ContactName = "Ross",
                City = "Hemel Hempstead",
                Country = "UK"
            };
            // you can use this commented out code below to create a string too with hard coded values but as coders we prefer to use
            // different variables
            //var sqlString = "INSERT INTO Customers(CustomerID, CompanyName, ContactName, City, Country)" +
            //    "VALUES ('Ross0', 'Sparta Global', 'Ross', 'Hemel Hempstead', 'UK')";
            var sqlString2 = $"INSERT INTO Customers(CustomerID, CompanyName, ContactName, City, Country)" +
                $"VALUES ('{newCustomer.CustomerID}', '{newCustomer.CompanyName}', '{newCustomer.ContactName}', '{newCustomer.City}', '{newCustomer.Country}')";
            using (var sqlCommand = new SqlCommand(sqlString2, sqlConnection))
            {
                // ExecuteNonQuery - ie were not reading data but we are updating data
                // will return an integer for number of records successfully updated/inserted
                // affected should equal one after it is run as we have added one customer
                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} new record(s) added to database");
                if (affected == 1)
                {
                    return newCustomer;
                }
            }
            return null;            
        }

        static string GenerateRandomCustomerID()
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
            Console.WriteLine(result);
            return result;
        }

        static void ListCustomers(SqlConnection sqlConnection)
        {
            customers.Clear();
            //Get Customers

            using (var sqlCommand = new SqlCommand("SELECT * FROM Customers", sqlConnection))
            {
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    var newCustomer = new Customer()
                    {
                        CustomerID = sqlReader["CustomerID"].ToString(),
                        ContactName = sqlReader["ContactName"].ToString(),
                        CompanyName = sqlReader["CompanyName"].ToString(),
                        City = sqlReader["City"].ToString(),
                        Country = sqlReader["Country"].ToString()
                    };
                    customers.Add(newCustomer);
                }
                sqlReader.Close();
            }
            //Put into a list
            //Print the list
            //A) foreach method
            //foreach (var c in customers)
            //{
            //    Console.WriteLine($"{c.CustomerID}{c.ContactName}{c.CompanyName}{c.City}{c.Country}");
            //}
            //B) Lambda foreach
            Console.WriteLine($"{"CustomerID",-15}{"ContactName",-30}{"CompanyName",-40}{"City",-20}{"Country",-10}");
            customers.ForEach(c =>
            Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-30}{c.CompanyName,-40}{c.City,-20}{c.Country,-10}"));
        }
    }
    // We want to make a class to hold the Customer Table
    class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}