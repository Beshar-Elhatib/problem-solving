using System;
using System.Security.Cryptography;
using static System.Collections.Specialized.BitVector32;

class  actionTest
{
    public static Action<int> multiply = (sayi) =>
    {
        Console.WriteLine("Multiply the number by 2 : " + 2 * sayi);
    };
}


class funcTest 
{ 
    public static Func <int ,int > multiply = (sayi) => 
    { 
        return 2 * sayi; 
    };
}

 class  delegetTest
{
    public delegate void MyDelegate(int sayi);
    public static void multiply(int sayi)
    {
        Console.WriteLine("Multiply the number by 2 : " + 2 * sayi);
    }
}

class predicateTest
{
     public static Predicate<int> eveOrOddNumber = (number)=>
    {
        if (number % 2 == 0)
        {
            return true;
        }
        else { 
            return false; 
        }
    };
}




class Program
{
    static void Main()
    {

        //action delegate kullanımı
        Console.WriteLine("action delegate kullanımı");

        actionTest.multiply(5);
        Console.WriteLine("---------------------------------");

        Console.WriteLine("Multiply the number by 2 in using func.  "+ funcTest.multiply(6) );
        Console.WriteLine("---------------------------------");

        Console.Write("Multiply the number by 2 in using the basic method of delegating :");

        delegetTest.MyDelegate myDelegate = new delegetTest.MyDelegate(delegetTest.multiply);
        myDelegate(7);

        Console.WriteLine( "----------------------------------");
        Console.WriteLine("The number is " + (predicateTest.eveOrOddNumber(8) ? "Even" : "Odd"));
        


        Console.ReadKey();

    }
}
