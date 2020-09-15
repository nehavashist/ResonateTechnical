using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestPractices
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void LogToConsole(string message)
        {
            try
            {
                Console.WriteLine(message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
           
        }
    }
}
