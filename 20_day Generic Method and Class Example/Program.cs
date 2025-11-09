using System;
using System.Security.Policy;


class GenericBox<T>
{
    public T Value;
    public GenericBox(T value)
    {
       Value = value;
    }

    public T GetContent()
    {
        return Value; 
    }
}
public class Utility
{
    public static T Swap<T>(ref T first, ref T second)
    {
        T temp = first;
        first = second;
        second = temp;
        return temp;
    }
}


class Program
{
    static void Main()
    {
        // Usage with integers
        int a = 5, b = 10;

        Console.WriteLine($"Before swap: a = {a}, b = {b}");
        Utility.Swap(ref a, ref b);

        Console.WriteLine($"After swap: a = {a}, b = {b}");
        Console.WriteLine();

        // Usage with strings
        string x = "Hello", y = "World";
        Console.WriteLine($"Before swap: x = {x}, y = {y}");
        Utility.Swap(ref x, ref y);
        Console.WriteLine($"After swap: x = {x}, y = {y}\n\n\n\n\n");



        // Usage of GenericBox

        GenericBox<int> intBox = new GenericBox<int>(42);
        Console.WriteLine($"GenericBox contains: {intBox.GetContent()}");
        GenericBox<string> strBox = new GenericBox<string>("Generic Programming");
        Console.WriteLine($"GenericBox contains: {strBox.GetContent()}");
        GenericBox<double> doubleBox = new GenericBox<double>(3.14);    
        Console.WriteLine($"GenericBox contains: {doubleBox.GetContent()}");

        Console.ReadKey();

    }
}
