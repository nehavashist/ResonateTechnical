using System;


namespace BestPractices
{
    public class Calculator<T> 
    {
        static public T Value { get; private set; }

        public Calculator(T value)
        {
            Value = value;
        }

        public Calculator()
        {
           
        }


        public int DoCalc(T arg1, T arg2)
        {
            return (Convert.ToInt32(arg1) + Convert.ToInt32(arg2)) / Convert.ToInt32(Value);
        }

        public  T HigherOrderCalculation(Func<T, T, T> Func, T one, T two)
        {
            return Func(one, two);
        }

    }
}
