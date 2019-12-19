using System;
using System.Collections.Generic;


namespace Lab_33_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{Scramble("gforeachfedfd", "foreach")}, { Scramble("rkqodlw", "world")}, { Scramble("cedewaraaossoqqyt", "codewars")}, { Scramble("katas", "steak")}, { Scramble("scriptjavx", "javascript")}, { Scramble("scriptingjava", "javascript")}, { Scramble("scriptsjava", "javascripts")}, { Scramble("javscripts", "javascript")}, { Scramble("aabbcamaomsccdd", "commas")}, { Scramble("commas", "commas")}, { Scramble("sammoc", "commas")} ");

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static bool Scramble(string str1, string str2)
        {
            char[] charArray = str1.ToCharArray();
            string result = "";
            foreach (var item in str2)
            {
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (charArray[i] == item)
                    {
                        result += charArray[i].ToString();
                        charArray[i] = ' ';
                        break;
                    }
                }
            }
            if (str2.Equals(result))
            {
                return true;
            }
            else
            {
                Console.WriteLine($"{str2}, {result}");
                return false;
            }
        }
    }
}
