

using System;
class FuncExample
{


    /*
         In this C# example, I demonstrate how to pass a method as a parameter using both Delegate and Func.
         The project is divided into three clear parts:
        🔹 Func – the built-in generic delegate in .NET
        🔹 Delegate – a custom delegate defined manually
        🔹 Program – practical implementation of both approaches
        This comparison shows how delegates make your code more flexible and reusable.
     
     */


    public static Func<int, int> square = SquareMethod;

    public static int SquareMethod(int x)
    {
        return x * x;
    }
}

class DelegateExample
{
    public  delegate int SquareDelegate(int x);

    public static int SquareMethod(int x)
    {
        return x * x;
    }
}

class Program
{
    static void Main()
    {
        DelegateExample.SquareDelegate squareDelegateInstance =
            new DelegateExample.SquareDelegate(DelegateExample.SquareMethod);

        // general Use Of Func
        int result1 = FuncExample.square(5);

        // general Use Of Delegate
        int result2 = squareDelegateInstance(6);

        Console.WriteLine("The square of 5 is: " + result1);
        Console.WriteLine("The square of 6 is: " + result2);
        Console.ReadKey();
    }
}
