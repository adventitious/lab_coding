using System;
using System.Linq;

namespace Exercise4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 4");
            q4();
            Console.WriteLine();
            q4b();
        }

        private static int DoubleIt( int value)
        {
            Console.WriteLine("About to double the nummber: " + value.ToString());
            return value * 2;
        }

        private static void q4()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            // var query * from number in numbers
            //             select DoubleIt( number )

            // LINQ Query Lambda Syntax, =chevron
            var query = numbers
                         .Select(n => DoubleIt(n));

            Console.WriteLine("Before the foreach loop");

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        private static void q4b()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query = from number in numbers
                       select DoubleIt(number);

            // var query = numbers
            //              .Select(n => DoubleIt(n));

            Console.WriteLine("Before the foreach loop");

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
