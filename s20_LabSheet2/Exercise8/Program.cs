using System;
using System.Linq;

namespace Exercise8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 8\n");
            q8();
            Console.WriteLine();
            q8b();
        }


        // Select Syntax
        static void q8()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query = from name in names
                        where name[0] == 'M'
                        orderby name  // ascending
                        select name;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }


        // Lambda Syntax
        static void q8b()
        {
            string[] names = { "Mary", "Joseph", "Michael", "Sarah", "Margaret", "John" };

            var query = names
                .Where(n => n[0] == 'M' )
                .OrderBy(n => n);

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }

    }
}
