using System;

class Program
{
    static void Main(string[] args)
    {
        LogError("An error occurred while processing the request", DateTime.Now);
        LogWarning("This action might lead to data loss", DateTime.Now);
    }

    public static void LogError(string message, DateTime timestamp)
    {
        string formattedMessage = FormatLogMessage("ERROR", message, timestamp);
        Console.WriteLine(formattedMessage);
    }

    public static void LogWarning(string message, DateTime timestamp)
    {
        string formattedMessage = FormatLogMessage("WARNING", message, timestamp);
        Console.WriteLine(formattedMessage);
    }

    private static string FormatLogMessage(string logType, string message, DateTime timestamp)
    {
        string formattedTimestamp = timestamp.ToString("yyyy-MM-dd HH:mm:ss");
        return $"{logType}: {formattedTimestamp} - {message}";
    }
}