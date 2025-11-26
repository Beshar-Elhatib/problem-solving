using System;
using System.Net;
using System.Net.Http;
using System.Threading;

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting threads...");

        Thread t1 = new Thread(() => DownloadAndPrint("https://www.cnn.com"));
        t1.Start();
        Console.WriteLine("Thread 1 started...");

        Thread t2 = new Thread(() => DownloadAndPrint("https://www.amazon.com"));
        t2.Start();
        Console.WriteLine("Thread 2 started...");

        Thread t3 = new Thread(() => DownloadAndPrint("https://www.notion.com"));
        t3.Start();
        Console.WriteLine("Thread 3 started...\n");


        t1.Join();
        t2.Join();
        t3.Join();


        Console.WriteLine("\nDone all threads finished execution.");
        Console.ReadKey();

    }

    static void DownloadAndPrint(string url)
    {
        string content;

        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Add("User-Agent",
                "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");

            Thread.Sleep(100);
            content = client.GetStringAsync(url).Result;
        }

        Console.WriteLine($"{url}: {content.Length} characters downloaded");
    }

}
