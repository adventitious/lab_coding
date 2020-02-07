using System;
using System.Linq;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 7\n");
            q7();
            Console.WriteLine();
            q7b();
        }

        // Select Syntax
        static void q7()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query = from name in names
                        orderby name
                        select name;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

        // Lambda Syntax
        static void q7b()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query = names
                        .OrderBy(n => n);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
