using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices
{
    public class FileLogger : IFileLogger
    {
        public async void LogtoFile(string msg)
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
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file or directory cannot be found.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            
        }
    }
}
