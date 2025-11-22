using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        // Create a SortedSet of integers
        SortedSet<int> sortedSet = new SortedSet<int>() { 1, 2, 3, 7, 12, 0, 9, 10 };


        if (sortedSet.Contains(2)) {
            Console.WriteLine($"sayi bulundu:{2} ?");
        }

        if (sortedSet.Remove(2))
        {
            Console.WriteLine("sayi basariyla silindi ?");
        }



        var b = sortedSet .GroupBy(k => k>5).OrderBy(d=>d.Key).Select(d =>d);
        foreach (var item in b)
        {
            Console.WriteLine($"key:{item.Key}");
            foreach (var i in item)
            {
                Console.WriteLine(i);
            }
        }


        var filteredSet = sortedSet.Where(n => n % 2==0 ); 
        foreach (var item in filteredSet)
        {
            Console.Write($",{item} ");
        }
        Console.WriteLine("\n");

        Console.WriteLine("Sum:"+sortedSet.Sum());
        Console.WriteLine("average:"+sortedSet.Average());

        Console.WriteLine(sortedSet.Max);
        Console.WriteLine(sortedSet.Min);

        var sortedListDesc = sortedSet.OrderByDescending(sorted => sorted);
        Console.Write("SortecSet oradared  is a descending:");
        foreach (var item in sortedListDesc)
        {
            Console.Write(item+ " ");
        }
        Console.WriteLine("\n");


        var evenNumbersSquared = sortedSet.Where(x => x % 2 == 0).Select(x => x * x);
        Console.WriteLine("Squares of even numbers:");
        foreach (var item in evenNumbersSquared)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine("\n");



        SortedSet<int>Set1 = new SortedSet<int>() { 3, 4, 5 ,6}; 
        SortedSet<int>Set2 = new SortedSet<int>() { 3, 4, 5, 6, 7 };

        SortedSet<int> Set3 = new SortedSet<int>() { 3, 4, 5, 6, 7 };
        //Union
        //Set1.UnionWith(Set2); 
        //Set1.IntersectWith(Set2); //Kesisim
        //Set1.ExceptWith(Set2);
        //Console.WriteLine(Set1.IsSubsetOf(Set2));
        //Console.WriteLine(Set2.IsSupersetOf(Set1)); 
        //Console.WriteLine(Set3.SetEquals(Set2));

        //foreach (var item in Set1)
        //{
        //    Console.Write(item + " ");
        //} 

        Console.ReadKey();
    }
}