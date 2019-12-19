using System;
using System.Collections.Generic;

namespace Lab_32_Simpsons_Rule_Area_Under_Graph_Simpsons_Rule
{
    class Program
    {
        static void Main(string[] args)
        {
            var sr = new SimpsonsRule();
            Console.WriteLine(sr.GetAreaUnderGraphUsingSimpsonsRule(6, 0, 6));
            Console.WriteLine(sr.GetAreaUnderGraphUsingSimpsonsRule(10, 0, 10));
            Console.WriteLine(sr.GetAreaUnderGraphUsingSimpsonsRule(20, 0, 20));
        }
    }
    public class SimpsonsRule
    {
        public double GetAreaUnderGraphUsingSimpsonsRule(double n, double min, double max)
        {
            List<double> xPoints = new List<double>();            
            List<double> yPoints = new List<double>();
            double yMin = min * min * min;
            double yMax = max * max * max;
            double evens = 0;
            double odds = 0;
            for (int i = 1; i <= n-1; i++)
            {
                xPoints.Add(min + (i / n) * (max - min));
            }
            foreach (var item in xPoints)
            {
                yPoints.Add(item * item * item);
            }
            for (int i = 0; i < yPoints.Count; i++)
            {
                if (i%2 == 0)
                {
                    odds += yPoints[i];
                }
                else
                {
                    evens += yPoints[i];
                }
            }
            
            double area = (((max - min) / (3 * n)) * (yMin + (4 * odds) + (2 * evens) + yMax));
            return Math.Round(area, 2);
        }
    }
}
