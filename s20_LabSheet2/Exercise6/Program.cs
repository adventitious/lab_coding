using System;
using System.Linq;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 6\n");

            // simple LINQ query which displays the names to screen.
            q6();
            Console.WriteLine();
            q6b();
        }

        // Select Syntax
        static void q6()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query = from name in names
                        select name;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        // Lambda Syntax
        static void q6b()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query = names;
                        

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
