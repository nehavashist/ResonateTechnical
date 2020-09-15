using System;
using System.IO;
using System.Text;


namespace BestPractices
{
    public static class Logger 
    {
        public static async void LogtoFile(string msg)
        {
            UnicodeEncoding uniencoding = new UnicodeEncoding();
            var message = uniencoding.GetBytes("msg");
            try
            {
                if (File.Exists($"logfile{DateTime.Now.ToString("yyyy-mm-dd")}.log"))
                {
                    using (FileStream sourceStream = new FileStream($"logfile{DateTime.Now.ToString("yyyy-mm-dd")}.log",
                    FileMode.Append, FileAccess.Write, FileShare.None,
                     bufferSize: 4096, useAsync: true))
                    {
                        await sourceStream.WriteAsync(message, 0, message.Length);
                    };
                }
                else
                {
                    using (FileStream sourceStream = new FileStream($"logfile{DateTime.Now.ToString("yyyy-mm-dd")}.log",
                   FileMode.Create, FileAccess.Write, FileShare.None,
                    bufferSize: 4096, useAsync: true))
                    {
                        await sourceStream.WriteAsync(message, 0, message.Length);
                    };
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        public static void LogToConsole(string message)
        {
            try
            {
                Console.WriteLine(message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
