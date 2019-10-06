using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolsDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            School[] schools = new School[5];

            for (int i = 0; i < schools.Length; i++)
            {
                Console.Write("enter school name: ");
                string name = Console.ReadLine();

                Console.Write("enter enrollment: ");
                int pupils = int.Parse(Console.ReadLine());

                schools[i] = new School(name, pupils);
            }
            for (int i = 0; i < schools.Length; i++)
            {
                Console.WriteLine(schools[i].ToString());
            }

            Console.WriteLine("\nsorting array");
            Array.Sort(schools);

            for (int i = 0; i < schools.Length; i++)
            {
                Console.WriteLine(schools[i].ToString());
            }
        }
    }
}
