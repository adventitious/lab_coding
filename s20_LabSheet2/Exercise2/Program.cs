using System;
using System.IO;
using System.Linq;

namespace Exercise2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Worldx!");
            q2b();
        }

        static void q2()
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();

            var query = from item in files
                        where item.Length > 10000
                        orderby item.Length, item.Name
                        select new MyFileInfo
                        {
                            Name = item.Name,
                            Length = item.Length,
                            CreationTime = item.CreationTime
                        };
            Console.WriteLine("Filename\tSize\tCreationDate");

            foreach( var item in query )
            {
                Console.WriteLine("{0} \t{1} bytes,\t{2}", item.Name, item.Length, item.CreationTime);
            }
            Console.WriteLine();
        }

        static void q2b()
        {
            var files = new DirectoryInfo("C:\\Windows").GetFiles();

            var query = files
                .Where(f => f.Length > 10000)
                .OrderBy(f => f.Length).ThenBy(f => f.Name)
                .Select(f => new MyFileInfo
                {
                    Name = f.Name,
                    Length = f.Length,
                    CreationTime = f.CreationTime
                } );

            Console.WriteLine("Filename\tSize\tCreationDate");

            foreach (var item in query)
            {
                Console.WriteLine("{0} \t{1} bytes,\t{2}", item.Name, item.Length, item.CreationTime);
            }
        }
    }

    public class MyFileInfo
    {
        public string Name{ get; set;}
        public long Length{ get; set;}
        public DateTime CreationTime{ get; set;}
    }
}
