using System;
using System.Linq;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberLambda();
            NumbersQuery();
        }
        static void NumberLambda()
        {
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };

            var outputNumbers = numbers.Where(n => n > 5);

            foreach (int number in outputNumbers)
            {
                Console.WriteLine(number.ToString());
            }
            Console.WriteLine( numbers.Length );
            Console.WriteLine( "output count:" + outputNumbers.Count() + "\n");
        }

        static void NumbersQuery()
        {
            int[] numbers = { 1, 5, 3, 6, 11, 2, 15, 21, 13, 12, 10 };

            int count = 0;

            foreach (int number in numbers)
            {
                if (number > 5)
                {
                    count++;
                }
            }

            int[] outputNumbers = new int[count];
            count = 0;

            foreach (int number in numbers)
            {
                if (number > 5)
                {
                    outputNumbers[count] = number;
                    count++;
                }
            }

            foreach (int number in outputNumbers)
            {
                Console.WriteLine(number.ToString());
            }
            Console.WriteLine("output count:" + outputNumbers.Count());
        }
    }
}
