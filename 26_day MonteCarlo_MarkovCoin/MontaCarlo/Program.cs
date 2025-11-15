using System;
using System.Diagnostics.Contracts;




namespace MontaCarlo
{
    internal class Program
    {
        static string  HileliMadeniPara(double d , string OncekiDegir) 
        {
                if (OncekiDegir== "Tura")
                {
                    return d < 0.75 ? "Tura":"Yazi" ;
                }
                else
                {
                    return d < 0.5 ? "Tura" : "Yazi";
                }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();

            int tekrear = 1000000; 
            double  sayac = 0;


            double T = rand.NextDouble();
            string oncekiDeger = T < 0.5 ? "Tura":"Yazi";

          
            for (int i = 0; i < tekrear; i++)
            {

                double d = rand.NextDouble();

                string yeni = HileliMadeniPara( d , oncekiDeger);

                if (yeni == "Tura")
                {
                    sayac++;
                }

                oncekiDeger = yeni; 
            }
            Console.WriteLine("ala orani :"+ sayac/tekrear);
        }
    }
}
