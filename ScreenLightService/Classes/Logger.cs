using System;
using System.IO;
using System.Text;

namespace ScreenLightService.Classes
{
    public class Logger
    {
        public static void Log(Exception ex)
        {
            using (StreamWriter sw = new StreamWriter("log.log", true))
            {
                var sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.Append("\t");
                sb.Append(ex.Message);
                sb.Append("\t");
                sb.Append(ex.StackTrace);
                sb.Append("\t");
                sb.Append(ex.Source);

                sw.WriteLine(sb.ToString());
                sw.Flush();
            }
        }

        public static void Log(string log)
        {
            using (StreamWriter sw = new StreamWriter("log.log", true))
            {
                var sb = new StringBuilder();
                sb.Append(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                sb.Append("\t");
                sb.Append(log);

                sw.WriteLine(sb.ToString());
                sw.Flush();
            }
        }
    }
}
