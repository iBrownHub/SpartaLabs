using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab_15_LINQ
{
    public class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine(NorthwindCustomers.NumberOfNorthwindCustomers(null)
            + Environment.NewLine + NorthwindCustomers.NumberOfCustomersWithContactTitleOwner()
            + Environment.NewLine + NorthwindCustomers.NumberOfCustomersWithPhoneNumber01Or07() 
            + Environment.NewLine + NorthwindProducts.NumberOfNorthwindProductsWithCategoryID1()
            + Environment.NewLine + NorthwindProducts.NumberOfNorthwindProductsWithUnitPriceOver20()
            + Environment.NewLine + NorthwindProducts.NumberOfNorthwindProductsThatAreDiscontinued());
            /*
                 Read northwind using entity core 2.1.1
                 Basic LINQ
                 More advanced LINQ with lambda
            */
            //Nuget - microsoft.entityframeworkcore/.sqlserver/.design -v 2.1.1
            //List<Product> products = new List<Product>();
            //List<Customer> customers = new List<Customer>();
            //List<Category> categories = new List<Category>();
            //List<ModifiedCustomer> modifiedCustomers = new List<ModifiedCustomer>();
            //using(var db = new Northwind())
            //{
            //    customers = db.Customers.ToList();
            //    //Simple linq from local collection
            //    //Whole data set is returned (more data)
            //    // Ienumerable array
            //    //speed and data not much of an issue
            //    var selectedCustomers =
            //        from customer in customers
            //        select customer;
            //    //Same query over database directly
            //    //only return the data we need
            //    //lazy loading - query is not actually executed
            //    //data has not actually arrived just yet
            //    var selectedCustomers2 =
            //        (from customer in db.Customers
            //         where customer.City == "London" || customer.City == "Berlin"
            //         orderby customer.ContactName
            //        select customer).ToList();
            //    // force data by pushing it to a list ie .tolist() or by making aggregate eg sum,count
            //    printCustomers(selectedCustomers2);
            //    var selectedCustomers3 =
            //        from customer in db.Customers
            //        select new
            //        {
            //            Name = customer.ContactName,
            //            Location = customer.City + ", " + customer.Country
            //        };
            //    foreach (var c in selectedCustomers3.ToList())
            //    {
            //        Console.WriteLine($"{c.Name,-20}{c.Location}");
            //    }
            //    var selectedCustomer4 =
            //        (from customer in db.Customers
            //        select new ModifiedCustomer(customer.ContactName, customer.City + ", " + customer.Country)).ToList();

            //    var selectedCustomer5 =
            //        (from c in db.Customers
            //        group c by c.City into Cities
            //        orderby Cities.Count() descending
            //        select new
            //        {
            //            City = Cities.Key,
            //            Count = Cities.Count()
            //        }).ToList();
            //    foreach (var c in selectedCustomer5)
            //    {
            //        Console.WriteLine($"{c.City,-15}{c.Count}");
            //    }
            //    var listOfProducts =
            //        (from p in db.Products
            //         join c in db.Categories
            //         on p.CategoryID equals c.CategoryID
            //         select new
            //         {
            //             ID = p.ProductID,
            //             Name = p.ProductName,
            //             Category = c.CategoryName
            //         }).ToList();
            //    listOfProducts.ForEach(p => Console.WriteLine($"{p.ID, -5}{p.Name, -40}{p.Category}"));

            //    products = db.Products.ToList();
            //    categories = db.Categories.ToList();
            //    products.ForEach(p => Console.WriteLine($"{p.ProductID, -5}{p.ProductName, -40}{p.Category.CategoryName}"));
            //    categories.ForEach
            //    (c =>
            //    {
            //        Console.WriteLine($"{c.CategoryID} {c.CategoryName} has {c.Products.Count} products");
            //        foreach (var p in c.Products)
            //        {
            //            Console.WriteLine($"\t\t\t\t{p.ProductID, -5}{p.ProductName}");
            //        }
            //    }
            //    );
            //    customers = db.Customers.ToList();
            //    Console.WriteLine($"Count is {customers.Count}");
            //    var cityList = db.Customers.Select(c => c.City).Distinct().ToList();
            //    cityList.ForEach(city => Console.WriteLine(city));
            //    var cityListFiltered =
            //        db.Customers.Select(c => c.City).Where(City => City.Contains("o"))
            //            .Distinct().OrderBy(c => c).ToList();
            //    cityListFiltered.ForEach(city => Console.WriteLine(city));
            //}
        }
        static void printCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-30}{c.CompanyName,-30}{c.City}"));
        } 
    }
    #region DatabaseContextAndClasses
    // connect to database

    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }

    public class ModifiedCustomer
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public ModifiedCustomer (string Name, string Location)
        {
            this.Name = Name;
            this.Location = Location;
        }
    }
    public class NorthwindCustomers
    {
        public static int NumberOfNorthwindCustomers(string city)
        {
            using (var db = new Northwind())
            {
                if (string.IsNullOrEmpty(city))
                {
                    return db.Customers.Count();
                }
                else
                {
                    var customersCity =
                        (from cust in db.Customers
                         where cust.City == city
                         select cust).ToList();
                    return customersCity.Count();
                }
            }
        }
        public static int NumberOfCustomersWithContactTitleOwner()
        {
            using (var db = new Northwind())
            {
                var customerOwner =
                    (from cust in db.Customers
                     where cust.ContactTitle == "Owner"
                     select cust).ToList();
                return customerOwner.Count();
            }
        }
        public static int NumberOfCustomersWithPhoneNumber01Or07()
        {
            using (var db = new Northwind())
            {
                var customerNumber =
                    (from cust in db.Customers
                     where cust.Phone.Contains("01") || cust.Phone.Contains("07")
                     select cust).ToList();
                return customerNumber.Count();
            }
        }
    }
    public class NorthwindProducts
    {
        public static int NumberOfNorthwindProductsWithCategoryID1()
        {
            using(var db = new Northwind())
            {
                var productsCategoryID =
                    (from prod in db.Products
                     where prod.CategoryID == 1
                     select prod).ToList();
                return productsCategoryID.Count();
            }
        }
        public static int NumberOfNorthwindProductsWithUnitPriceOver20()
        {
            using (var db = new Northwind())
            {
                var productsUnitPrice =
                    (from prod in db.Products
                     where prod.UnitPrice > 20
                     select prod).ToList();
                return productsUnitPrice.Count();
            }
        }
        public static int NumberOfNorthwindProductsThatAreDiscontinued()
        {
            using (var db = new Northwind())
            {
                var productsDiscontinued =
                    (from prod in db.Products
                     where prod.Discontinued == true
                     select prod).ToList();
                return productsDiscontinued.Count();
            }
        }
    }
    #endregion
}
