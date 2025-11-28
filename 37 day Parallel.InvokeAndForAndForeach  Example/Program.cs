using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        // --------Parallel For --------- 
        Console.WriteLine("\nImplementing  Parallel For\n ");
        Parallel.For(0, 10, i =>
        {
            Console.WriteLine($"Processing item {i} on thread {Task.CurrentId}");
            Thread.Sleep(500); 
        });

        // --------Parallel ForEach ---------
        Console.WriteLine("\nImplementing  Parallel ForEach \n");
        List<string> URLs = new List<string>()
        {
           "https://www.amazon.com",
            "https://www.cnn.com"

        };

        Parallel.ForEach(URLs, url =>
        {
            string content;
            using (WebClient client = new WebClient())
            {
                Thread.Sleep(1000);
                //  await Task.Delay(1000);
                content = client.DownloadString(url);
            }
            Console.WriteLine($"url:{url} , {content.Length} caracters downloaded");
        });

        //--------Parallel Invoke --------- 
        Console.WriteLine("\nImplementing  Parallel Invoke\n ");
        Parallel.Invoke(
            () => Console.WriteLine($"Action 1 on thread {Task.CurrentId}"),
            () => Console.WriteLine($"Action 2 on thread {Task.CurrentId}"),
            () => Console.WriteLine($"Action 3 on thread {Task.CurrentId}")
        );
        Console.ReadKey();

    }


    
}