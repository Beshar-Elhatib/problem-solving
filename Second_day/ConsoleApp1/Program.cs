using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    /*
     Password Strength Checker

            Write a C# program that asks the user to enter a password and checks if it is strong based on the following rules:

            Minimum length of 8 characters

            Contains at least one uppercase letter (A-Z)

            Contains at least one lowercase letter (a-z)

            Contains at least one digit (0-9)

            Contains at least one special character (e.g., ! @ # $ %)

            If the password meets all conditions → Print: "Strong password ✅"
            Otherwise → Print the reason why it is not strong.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a password: ");

            string password = Console.ReadLine();

            string message = CheckPassword(password);

            Console.WriteLine(message);

        }




        static string CheckPassword(string pass)
        {
            if (pass.Length < 8)
                return "The password must be at least 8 characters long.";

            bool hasUpper = false;
            bool hasLower = false;
            bool hasDigit = false;
            bool hasSpecial = false;

            foreach (char c in pass)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSpecial = true;
            }

            if (!hasUpper) return "The password must contain at least one uppercase letter.";
            if (!hasLower) return "The password must contain at least one lowercase letter.";
            if (!hasDigit) return "The password must contain at least one digit.";
            if (!hasSpecial) return "The password must contain at least one special character.";

            return "Strong password!";
        }
    }
}
