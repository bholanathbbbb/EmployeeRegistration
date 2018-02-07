using System;
using System.IO;
using System.Linq;

namespace ExceptionLayer
{
    public class ExceptionHandler
    {
        public static void HandleException(Exception ex)
        {
            string directory = System.Web.HttpContext.Current.Server.MapPath("~/Log/");
            string path = Path.Combine(directory, "logfile.txt");

            StreamWriter log;
            if (!File.Exists(path))
            {
                log = File.CreateText(path);
            }
            else
            {
                log = new StreamWriter(path);
            }
            // Write to the file:
            log.WriteLine("Data Time:" + DateTime.Now);
            log.WriteLine("Exception Name:" + ex.Message);
            log.WriteLine("Trace:" + ex.StackTrace);
            // Close the stream:
            log.Close();
        }
    }
}
