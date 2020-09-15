using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CodeRev
{
    //The name of the class has no relevance to the functions defined within the class
   // ClassName: Calculator
    public class Foo<T>
    {
        //StartValue doesnt show relevance to its Usage in the DoCalc,the name can be changed to something meaningful.
        //Also the static modifier usage is questionable.
        static protected T StartValue { get; private set; }

        /* There is only a Parameterized constructor initialized in the class 
         * that takes in startValue as the input parameter,but the startValue is only consumed by DoCalc Method that 
         * does not share any link with rest of the methods within the class.
         * Hence it makes sense to have a default parameterless Constructor to call other methods 
         * without having to pass startvalue.
         * */
        public Foo(T startValue)
        {
            StartValue = startValue;
        }

        /* 1. In the below Do Calc Function , both the input argumenmts and startValue is converted to Int
         * but it doesnt adhere to the benifits of making a class generic which is to make a method/class reusuable and 
         * type safe.
         * -----
         * 2. One of the arguments is made generic whose datatype can be set while calling the method but 
         * the object still can take in any datatype which can result in wrong cast Exception at  runtime.
         * 3. Using an Object type in the generic class contradicts with its advantages of generics which is not having to do boxing and unboxing.
         * 4. The return type needs to be Generic as well as the dateType is decided at compile time
         * 5. Exception handling needs to be done in order to handle the data type mismatch.
         */
        
        public static int DoCalc(Object arg1, T arg2)
        {
            return (int)arg1 + Convert.ToInt32(arg2) / Convert.ToInt32(StartValue);
        }

        /* 1. The method name does not follow pascal casing.i.e has to be "HigherOrderCalculation".
         * 2. Although the method works fine, the method is still allowing int parameters while the class is accepting 
         * only a generic type of double, which is very confusing and contradictory to how generics are used.
         * 3. As the functionlity/operation performed by the method is decided based on the operation set by the calling function-
         * such as a divided by operation taking in 2 int say I pass 3,0..Then the func throws divide by 0 exception.
         * Hence exception handling needs to be done.
         * */
        public static int higherOrderCalculation(Func<int, int, int> Func, int one, int two)
        {
            return Func(one, two);
        }

        /* 1.The method below does not have a purpose within the class as it is not contributing to
         * the responsibility of the class which is to Calculate somehting.
         * 2.Can be moved to a another class that implements the relavant interface which can be inherited by this class.
         * 3. string.Format is used to insert an object or variable to another string to be used later ,
         * but in the below code adding string.format does not change anything.
         * 4. Null check needs to be performed else NullException will be thrown
         */
        public void LogToConsole(string message)
        {
            Console.WriteLine(string.Format(message));
        }

        /*1. The below method can also be moved to another class as it does not 
         * adhere to single responsibility principle of the class.
         * 2. There needs to be a condition to see if the file exists else will end up throwing an exception.
         * 3. "Using" should be used to define the scope of the File Object so that it can be disposed after being used.
         * 4. The method is performing an async await but File.AppendAllText does not return anything ie Cannot await a void.
         * */
        public async void LogtoFile(string msg)
        {
            await File.AppendAllText($"logfile{DateTime.Now.ToString("yyyy-mm-dd")}.log", "msg");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //var result1 = Foo<double>.DoCalc(1, 2);
            //object test = 3;
            //Foo<int>.DoCalc(test, 3);
           // foo.LogToConsole("Neha");
          
            var result2 = Foo<double>.higherOrderCalculation((x, y) => x / y, 3, 0);

        }
    }
}
