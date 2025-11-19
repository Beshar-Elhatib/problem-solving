using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {

        //The Event Log is a logbook for the system and programmes.
        //It helps developers record errors and important events,
        //and is considered a powerful tool for diagnosing problems
        //and ensuring programme quality, especially in large systems.

        // Specify the source name for the event log
        string sourceName = "MyApp";


        // Create the event source if it does not exist
        if (!EventLog.SourceExists(sourceName))
        {
            EventLog.CreateEventSource(sourceName, "Application");
            Console.WriteLine("Event source created.");
        }


        // Log an information event
        EventLog.WriteEntry(sourceName, "This is My information :-).", EventLogEntryType.Information);
        
        // Log a Warning event
        EventLog.WriteEntry(sourceName, "This My Warning :-)", EventLogEntryType.Warning);

        // Log an Error event
        EventLog.WriteEntry(sourceName, "This My Error :-)", EventLogEntryType.Error);


        Console.WriteLine("Event written to the log.");
        Console.ReadKey();

    }
}