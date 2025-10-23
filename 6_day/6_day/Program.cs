using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6_day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Problem:
            // Given an integer array where every element appears exactly three times except for one.
            // Find the single element that appears only once.
            // You must implement a solution with O(n) time complexity and O(1) space complexity.
            //
            // Example:
            // Input:  [2, 2, 3, 2]
            // Output: 3
            //
            // Explanation:
            // Every number appears 3 times except for 3, which appears once.
            // Hint: Use bit manipulation to track bits that appear once and twice.

            int[] nums = { 2, 2, 3, 2 };
            Console.WriteLine(SingleNumber(nums)); // Output: 3
        }

        static int SingleNumber(int[] nums)
        {
            int ones = 0, twos = 0;

            foreach (int num in nums)
            {
                ones = (ones ^ num) & ~twos;
                twos = (twos ^ num) & ~ones;
            }

            return ones;
        }
    }
}
