using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_day
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Problem: Longest Substring Without Repeating Characters
            // Description:
            // Given a string, find the length of the longest substring without repeating characters.
            //
            // Example 1:
            // Input: "abcabcbb"
            // Output: 3
            // Explanation: The answer is "abc", with the length of 3.
            //
            // Example 2:
            // Input: "bbbbb"
            // Output: 1
            // Explanation: The answer is "b", with the length of 1.
            //
            // Example 3:
            // Input: "pwwkew"
            // Output: 3
            // Explanation: The answer is "wke", with the length of 3.
            //
            // Hint: Use the sliding window technique with a dictionary to track characters.

            string s = "abcabcbb";
            Console.WriteLine(LengthOfLongestSubstring(s)); // Output: 3
        }

        static int LengthOfLongestSubstring(string s)
        {
            int maxLen = 0, left = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();

            for (int right = 0; right < s.Length; right++)
            {
                if (map.ContainsKey(s[right]))
                {
                    // Move the left pointer after the last occurrence of the current character
                    left = Math.Max(map[s[right]] + 1, left);
                }
                map[s[right]] = right;
                maxLen = Math.Max(maxLen, right - left + 1);
            }

            return maxLen;
        }
    }
}
