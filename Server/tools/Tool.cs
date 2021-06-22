using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
public static partial class Tool
{
    /// <summary>
    /// 打印调试信息
    /// </summary>
    /// <param name="s">要打印的信息</param>
    public static void DebugLog(string s)
    {
        Console.ForegroundColor = ConsoleColor.White;
        string outputMsg = "[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "]:" + s;
        Console.WriteLine(outputMsg);
        LogWriter.WriteLog("[L]" + outputMsg);
    }
    /// <summary>
    /// 打印警告信息
    /// </summary>
    /// <param name="s">要打印的信息</param>
    public static void DebugWarning(string s)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        string outputMsg = "[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "]:" + s;
        Console.WriteLine(outputMsg);
        LogWriter.WriteLog("W" + outputMsg);
    }
    /// <summary>
    /// 打印错误信息
    /// </summary>
    /// <param name="s">要打印的信息</param>
    public static void DebugError(string s)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        string outputMsg = "[" + DateTime.Now.ToString("MM-dd HH:mm:ss") + "]:" + s;
        Console.WriteLine(outputMsg);
        LogWriter.WriteLog("E" + outputMsg);
    }
    /// <summary>
    /// 获取时间戳
    /// </summary>
    /// <returns></returns>
    public static long GetTimeStamp()
    {
        TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return Convert.ToInt64(ts.TotalSeconds);
    }

    /// <summary>
    /// 判断字符串str是否为安全字符串（防止SQL注入）
    /// </summary>
    /// <param name="str">待检测的字符串</param>
    /// <returns></returns>
    public static bool IsSafeString(string str)
    {
        return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\{|\}|%|@|\*|!|\']");
    }

    /// <summary>
    /// 获取字符串str的md5加密哈希值
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static string GetMD5Hash(string str)
    {
        string ret = "";
        if (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str)) return ret;

        using(var md5 = MD5.Create())
        {
            //计算md5
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < s.Length; ++i)
            {
                //将得到的字符串使用十六进制格式
                ret = ret + s[i].ToString("X");
            }
        }      
        return ret;
    }
}
