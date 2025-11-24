using System;
using System.Collections;
using System.Linq;
using System.Runtime.InteropServices;


class Program
{
    static void Main(string[] args)
    {

        ArrayList arrayList = new ArrayList() { 1,2,3,4,5,6,7,8,9,10 };

        ArrayList list = new ArrayList(); // Creating an ArrayList
        list.Add(10); // Adding elements
        list.Add("Hello");
        list.Add(true);


        var evenNumbers =arrayList.Cast<int>().Where(num => num % 2 == 0);
        foreach (var num in evenNumbers)
        {
            Console.Write("item : " + num); 
        }

        Console.WriteLine("--------");

        Console.WriteLine("The Max number in the array :"+ arrayList.Cast<int>().Max());
        Console.WriteLine("The Min number in the array :"+arrayList.Cast<int>().Min());
        Console.WriteLine("The Total Is :" + arrayList.Cast<int>().Sum());
        Console.WriteLine("Average values in the ArrayList:" + arrayList.Cast<int>().Average());
        Console.WriteLine("Total elements in ArrayList: " + list.Count);

        Console.WriteLine(arrayList.Cast<int>().Count(n=> n>5));

        
        Console.WriteLine("Content of ArrayList using index:");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine("Index " + i + ": " + list[i]);
        }
        Console.WriteLine("Content of ArrayList using foreach:");
        foreach (var item in list)
        {
            Console.WriteLine("Item: " + item);
        }


        Console.ReadKey();
    }
}