using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;


class Program
{
    static void Main()
    {
        // Creating and populating a HashSet of integers

        HashSet<int> set1 = new HashSet<int> { 1, 2, 3 };
        HashSet<int> set2 = new HashSet<int> { 3, 4, 5 };
        HashSet<int> set3 = new HashSet<int> { 1, 2, 3, 4, 5, 6, 7 };

        int [] Array = new int [] {1,2,3,4,4 ,5,5,6,7,8 };  // Array with duplicate values
        HashSet<int > set0 = new HashSet<int>(Array);       // HashSet to remove duplicates from the array

        //how to add elements to HashSet    
        set0.Add(0);
        //how to contain elements in HashSet    
        bool containsThree = set0.Contains(3); // Checking if 3 is in set0
        //how to reemove elements from HashSet   
        set0.Remove(5); // Removing 5 from set0 



        // linq and HashSet example
        var evenNumbersFromSet0 = set0.Where(n => n % 2 == 0);// LINQ query to filter even numbers from set0
        var ordderedEvenNumbersDescending = evenNumbersFromSet0.OrderByDescending(n => n); // Ordering the even numbers


        // How to merge two HashSet collections
        set1.UnionWith(set2); // Merging set2 into set1

        //how to exept elements of one HashSet from another
        set1.IntersectWith(set2); // Retaining only elements present in both set1 and set3

        set1.ExceptWith(set3); // Removing elements in set3 from set1

        //how to marge tow hashset and remove duplicate elements
        set1.SymmetricExceptWith(set3); // Merging set1 and set3, removing duplicates

        //how to compare two hashset
        Console.WriteLine(set1.SetEquals(set2));

        // set1 is subset of set3 
        Console.WriteLine(set1.IsSubsetOf(set3)) ;

        // set3 is superset of set1
        Console.WriteLine(set3.IsSupersetOf(set1));

        // set1 is overlap with set3
        Console.WriteLine(set1.Overlaps(set3));

    }
}