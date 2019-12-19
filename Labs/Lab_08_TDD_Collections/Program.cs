using System;
using System.Collections.Generic;

namespace Lab_08_TDD_Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            Lab08ArrayListDictionary lab = new Lab08ArrayListDictionary();
            Console.WriteLine(lab.Lab08ArrayListDictionaryGetTotal(40,41,42,43,44)); 
        }
    }
    public class Lab08ArrayListDictionary
    {
        public int Lab08ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e)
        {
            int finalSum = 0;
            int dictID = 0;
            List<int> numberList = new List<int>();
            Dictionary<int, int> numberDictionary = new Dictionary<int, int>();         
            int[] numbers = new int[5] {
                a+5,
                b+5,
                c+5,
                d+5,
                e+5
            };            
            foreach (int number in numbers)
            {
                int newNumber = number * number;
                numberList.Add(newNumber);
            }
            foreach (int number in numberList)
            {
                dictID++;
                int newNumber = number - 10;
                numberDictionary.Add(dictID, newNumber);
            }
            foreach (KeyValuePair<int, int> number in numberDictionary)
            {
                finalSum += number.Value;
            }
            
            return finalSum;
        }
    }
}
