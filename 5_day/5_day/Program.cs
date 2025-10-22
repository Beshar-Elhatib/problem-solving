using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Problem: Reverse Only Odd Numbers in an Array
            // Description:
            // Given an array of integers, write a function that reverses the order of odd numbers
            // in the array while keeping even numbers in their original positions.
            //
            // Example:
            // Input:  [1, 2, 3, 4, 5]
            // Output: [5, 2, 3, 4, 1]
            //
            // Explanation:
            // - Odd numbers are 1, 3, 5 → reversed to 5, 3, 1
            // - Even numbers 2, 4 stay in their original positions

            int[] arr = { 1, 2, 3, 4, 5 };
            int[] result = ReverseOdds(arr);
            Console.WriteLine(string.Join(", ", result)); // Output: 5, 2, 3, 4, 1
        }

        static int[] ReverseOdds(int[] arr)
        {
            // Collect all odd numbers
            List<int> odds = new List<int>();
            foreach (var num in arr)
            {
                if (num % 2 != 0) odds.Add(num);
            }

            // Reverse the order of odd numbers
            odds.Reverse();

            // Rebuild the array keeping even numbers in place
            int index = 0;
            int[] result = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                    result[i] = odds[index++];
                else
                    result[i] = arr[i];
            }

            return result;
        }
    }
}
