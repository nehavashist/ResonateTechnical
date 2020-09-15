

using System;

namespace BestPractices
{
    public class Foo<T>
    {
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator<double>(1.5d);
            Logger.LogToConsole("Hello world");
            Logger.LogtoFile("Hello world");
            var result1 = calculator.DoCalc(1, 2);
            var result2 = calculator.HigherOrderCalculation((x, y) => x + y, 3, 4);
            Console.ReadLine();

        }
    }
}
