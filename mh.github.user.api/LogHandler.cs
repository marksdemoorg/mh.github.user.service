using System;
using System.Web;
using System.Reflection;

public static class LogHandler
{
    [Obsolete("Use Log(string logEntry, int issueNuber) instead")]
    public static void Log(string logEntry)
    {
        throw new NotImplementedException("Don't use me");
    }

    public static void Log(string logEntry, int issueNumber)
    {
        Console.WriteLine("Issue: " + issueNumber.ToString() + "Log: " + logEntry);
    }
    
}