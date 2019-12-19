using System;
using NUnit.Framework;
using Lab_08_TDD_Collections;
using Lab_09_Rabbit_Test;
using Lab_15_LINQ;
using Lab_22_Northwind_Products;
using Lab_31_Fibonacci;
using Lab_32_Simpsons_Rule_Area_Under_Graph_Simpsons_Rule;


namespace Tests
{
    [TestFixture]
    public class Tests
    {
        //Lab08ArrayListDictionary lab = new Lab08ArrayListDictionary();
        //RabbitCollection rc = new RabbitCollection();
        //[Test]
        //public void Test1()
        //{
        //    var expected = 280;
        //    var actual = lab.Lab08ArrayListDictionaryGetTotal(1, 2, 3, 4, 5);
        //    Assert.AreEqual(expected, actual);
        //}
        //[Test]
        //public void Test2()
        //{
        //    var expected = 693;
        //    var actual = lab.Lab08ArrayListDictionaryGetTotal(0, 4, 7, 8, 13);
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestCase(1, 4, 9, 16, 25, 1604)]
        //[TestCase(-1, -4, -9, -16, -25, 504)]
        //[TestCase(1, 17, 26, 49, 81, 11743)]
        //[TestCase(36, 49, 64, 81, 100, 27729)]
        //[TestCase(0, 10, 100, 1000, 10000, 101121275)]
        //public void ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e, int expected)
        //{
        //    var actual = lab.Lab08ArrayListDictionaryGetTotal(a, b, c, d, e);
        //    Assert.AreEqual(expected, actual);
        //}
        //[TestCase(1, 1, 2)]
        //[TestCase(2, 3, 4)]
        //[TestCase(3, 7, 8)]
        //[TestCase(4, 15, 16)]
        //public void RabbitGrowthTests(int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        //{
        //    //Arrange

        //    //Act
        //    (int actualCumulativeRabbitAge, int actualRabbitCount) = rc.MultiplyRabbits(totalYears);
        //    //Assert
        //    Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeRabbitAge);
        //    Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        //}
        //[TestCase(1, 1, 1)]
        //[TestCase(2, 2, 1)]
        //[TestCase(3, 3, 2)]
        //[TestCase(4, 5, 3)]

        //public void RabbitGrowthTestsWithAge(int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        //{
        //    //Arrange

        //    //Act
        //    (int actualCumulativeRabbitAge, int actualRabbitCount) = rc.MultiplyRabbitsWithAge(totalYears);
        //    //Assert
        //    Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeRabbitAge);
        //    Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        //}

        [TestCase(null, 91)]
        [TestCase("London", 6)]
        public void TestNumberOfNorthwindCustomers(string city, int expected)
        {
            //Arrange
           // var testInstance = new linq.NorthwindCustomers();
            //Act
            //var actual = testInstance.NumberOfNorthwindCustomers(city);
            //Assert
            Assert.AreEqual(expected, NorthwindCustomers.NumberOfNorthwindCustomers(city));
        }
        [Test]
        public void TestNumberOfNorthwindCustomersWithContactTitleOwner()
        {
            int expected = 17;
            Assert.AreEqual(expected, NorthwindCustomers.NumberOfCustomersWithContactTitleOwner());
        }
        [Test]
        public void TestNumberOfCustomersWithPhoneNumber01Or07()
        {
            int expected = 10;
            Assert.AreEqual(expected, NorthwindCustomers.NumberOfCustomersWithPhoneNumber01Or07());
        }
        [Test]
        public void TestNumberOfNorthwindProductsWithCategoryID1()
        {
            int expected = 12;
            Assert.AreEqual(expected, NorthwindProducts.NumberOfNorthwindProductsWithCategoryID1());
        }
        [Test]
        public void TestNumberOfNorthwindProductsWithUnitPriceOver20()
        {
            int expected = 37;
            Assert.AreEqual(expected, NorthwindProducts.NumberOfNorthwindProductsWithUnitPriceOver20());
        }
        [Test]
        public void TestNumberOfNorthwindProductsThatAreDiscontinued()
        {
            int expected = 8;
            Assert.AreEqual(expected, NorthwindProducts.NumberOfNorthwindProductsThatAreDiscontinued());
        }
        [Test]
        public void TestProductsStartingWithP()
        {
            int expected = 3;
            Assert.AreEqual(expected, NorthwindProductsLetter.ProductsStartingWithALetter("p"));
        }
        [TestCase("p", 3)]
        [TestCase("x", 0)]
        [TestCase("t", 6)]
        public void TestProductsStartingWithALetter(string letter, int expected)
        {
            Assert.AreEqual(expected, NorthwindProductsLetter.ProductsStartingWithALetter(letter));
        }
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(2,1)]
        [TestCase(3,2)]
        [TestCase(4,3)]
        [TestCase(5,5)]
        public void TestFibonacci(int n, int expected)
        {
            var fib = new Fibonacci();
            Assert.AreEqual(expected, fib.ReturnFibonacciNthItemInSequence(n));
        }
        //[TestCase(6, 0, 6, 72, 72)]
        //[TestCase(16, 0, 16, 1365.3, 1365.4)]
        //public void TestSimpsons(double n, double min, double max, double expectedGreater, double expectedLess)
        //{
        //    var sr = new SimpsonsRule();
        //    Assert.GreaterOrEqual(sr.GetAreaUnderGraphUsingSimpsonsRule(n, min, max), expectedGreater);
        //    Assert.LessOrEqual(sr.GetAreaUnderGraphUsingSimpsonsRule(n, min, max), expectedLess);
        //}
        [TestCase(6, 0, 6, 324)]
        [TestCase(10, 0, 10, 2500)]
        [TestCase(20, 0, 20, 40000)]
        public void TestSimpsons1(double n, double min, double max, double expected)
        {
            var sr = new SimpsonsRule();
            Assert.AreEqual(sr.GetAreaUnderGraphUsingSimpsonsRule(n, min, max), expected);
        }
    }
}

