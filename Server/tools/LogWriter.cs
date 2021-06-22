using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public static class LogWriter
{
    private static StreamWriter writer;

    static LogWriter()
    {
        if (!Directory.Exists("log"))
        {
            Directory.CreateDirectory("log");
        }
        writer = new StreamWriter(string.Format("log\\Log_{0}.txt", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")));
        writer.AutoFlush = true;
    }

    public static void WriteLog(string log)
    {
        writer.WriteLine(log);
    }
}
