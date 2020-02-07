using System;
using System.IO;
using System.Linq;


namespace Exerercise3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("question 3\n");
            q3();
            Console.WriteLine("\n\n");
            q3b();
        }

        static void q3()
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();

            var query = from item in files
                        where item.Length > 1000
                        orderby item.Length, item.Name
                        select new
                        {
                            Name = item.Name,
                            Length = item.Length,
                            CreationTime = item.CreationTime
                        };
            // return query;
            foreach (var item in query)
            {
                Console.WriteLine("{0} \t{1} bytes,\t{2}", item.Name, item.Length, item.CreationTime);
            }

        }


        static void q3b()
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();

            var query = files
                        .Where ( f => f.Length > 10000)
                        .OrderBy(f => f.Length).ThenBy(f => f.Name)
                        .Select(f => new
                        {
                            Name = f.Name,
                            Length = f.Length,
                            CreationTime = f.CreationTime
                        });

            foreach (var item in query)
            {
                Console.WriteLine("{0} \t{1} bytes,\t{2}", item.Name, item.Length, item.CreationTime);
            }
        }
    }
}
