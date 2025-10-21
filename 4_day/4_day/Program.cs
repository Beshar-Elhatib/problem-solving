using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_day
{
    internal class Program
    {   /*
         You are given an array of integers containing all the numbers from 1 to N, except for one missing number.
         Write a C# program to find the missing number in the shortest and most efficient way possible.
         */
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 4, 5, 6 };
            int n = nums.Length + 1;
            int missing = n * (n + 1) / 2 - nums.Sum();
            Console.WriteLine($"Missing number is: {missing}");
        }
    }
}
