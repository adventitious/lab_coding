using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethodProject
{

    public static class ExtensionMethodClass
    {
        public static int CountWords(this string str)
        {
            if (str == "")
                return 0;
            return str.Split().Length;
        }
    }




    class Program
    {
        static void Main(string[] args)
        {

            string s1 = "";
            Console.WriteLine("\nsentence: \t\t{0}", s1);
            Console.WriteLine("number of words: \t{0}", s1.CountWords());


            s1 = "Test that this works using several sentences of";
            Console.WriteLine("\nsentence: \t\t{0}", s1);
            Console.WriteLine("number of words: \t{0}", s1.CountWords());


            s1 = "The extension method should count the number of words in a sentence.";
            Console.WriteLine("\nsentence: \t\t{0}", s1);
            Console.WriteLine("number of words: \t{0}", s1.CountWords());

            Console.WriteLine();

        }
    }
}
