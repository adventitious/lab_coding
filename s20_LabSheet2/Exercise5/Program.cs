using System;
using System.Linq;


namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 5");
            q5();
            Console.WriteLine();
            q5b();
            Console.WriteLine();
            q5c();
            Console.WriteLine();
            q5d();
        }

        private static int DoubleIt(int value)
        {
            Console.WriteLine("About to double the nummber: " + value.ToString());
            return value * 2;
        }

        // LINQ Lambda Syntax
        static void q5()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query1 = numbers
                         .OrderByDescending(n => n);

            var query2 = query1
                        .Where(n => n < 8);

            var query3 = query2
                        .Select(n => DoubleIt(n));

            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
        }

        // Query Syntax
        static void q5b()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query1 = from number in numbers
                         orderby number descending
                         select number;

            var query2 = from number in query1
                         where number < 8
                         select number;

            var query3 = from number in query2
                        select DoubleIt(number);

            foreach (var item in query3)
            {
                Console.WriteLine(item);
            }
        }

        // Lambda Syntax
        static void q5c()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };


            var query1 = numbers
                         .OrderByDescending(n => n)
                         .Where(n => n < 8)
                         .Select(n => DoubleIt(n));

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }
        }

        // Query Syntax
        static void q5d()
        {
            int[] numbers = { 1, 5, 3, 6, 10, 12, 8 };

            var query1 = from number in numbers
                         orderby number descending
                         where number < 8
                         select DoubleIt(number);

            foreach (var item in query1)
            {
                Console.WriteLine(item);
            }
        }
    }
}
