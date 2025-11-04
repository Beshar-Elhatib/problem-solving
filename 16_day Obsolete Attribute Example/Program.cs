using System;

public class MyClass
{

    /*
     In this example, I implemented the [Obsolete] attribute to mark a method as deprecated.
     The attribute serves as a compiler-level warning to inform developers that a specific
     method should no longer be used because it will be removed or replaced in future versions.
     This helps maintain clean and future-proof code by guiding developers toward the updated 
     or recommended methods.
     */


    [Obsolete("This method is marked as obsolete, and will be deprecated in the future.")]
    public void Method1()
    {
        Console.WriteLine("This method is marked as obsolete, and will be deprecated in the future.");
    }

    public void Method2()
    {
        Console.WriteLine("This is the recommended method to use.");
    }
}

class Program
{
    static void Main()
    {
        MyClass myObject = new MyClass();

        // Deprecated method usage
        myObject.Method1(); // Generates a compiler warning

        // New method usage
        myObject.Method2();

        Console.ReadLine();
    }
}