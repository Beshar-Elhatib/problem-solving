using System;
using System.Linq;
using System.Xml.Schema;


class LINQJaggedArrayExample
{
    static void Main()
    {
        // Declare and initialize a jagged array
        int[][] jaggedArray = {
            new int[] { 1, 2, 3 },
            new int[] { 4, 5, 6 },
            new int[] { 7, 8, 9, 10 }
        };


        string[][] jagger =
        {
            new string[] { "apple", "banana" },
            new string[] { "cherry", "date", "fig" },
            new string[] { "grape" }
        };
        Console.WriteLine("result0:"+jagger.SelectMany(subArray => subArray).Max(s => s.Length));
       
       var result = jagger .SelectMany(subArray => subArray)
         .OrderByDescending(s => s.Length).First().Length;

        Console.WriteLine("result1:" + result);

        var result2 = jagger
         .SelectMany(subArray => subArray).Count();
        Console.WriteLine("result2:" + result2);  
        
        var result3 = jagger
         .SelectMany(subArray => subArray)
         .Where(s => s.Length > 4 ).ToList ();
        Console.WriteLine("result3:" + string.Join (",", result3));

        
        for (int i = 0; i < jagger.Length; i++)
        {
            Console.WriteLine();
            for (int j= 0; j < jagger[i].Length; j++)
            {
                
                Console.Write(jagger[i][j]+" ");
            }
        }


        Console.WriteLine("\n-----------------------------------------------------");



        // Flatten the jagged array and sum all elements
        int totalSum = jaggedArray.SelectMany(subArray => subArray).Sum();
        Console.WriteLine("Total Sum: " + totalSum);


        // Find the maximum element in the jagged array
        int maxElement = jaggedArray.SelectMany(subArray => subArray).Max();
        Console.WriteLine("Maximum Element: " + maxElement);


        // Filter arrays having more than 3 elements and select their first element
        var firstElements = jaggedArray.Where(subArray => subArray.Length > 3)
                                       .Select(subArray => subArray.First());
        Console.Write("First Elements of Long Rows: ");
        foreach (var element in firstElements)
        {
            Console.Write(element + " ");
        }
        Console.ReadKey();
    }
}
