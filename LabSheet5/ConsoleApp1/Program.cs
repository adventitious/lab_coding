using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class Demo
    {
        public static int myExtensionMethod(this string str)
        {
            return Int32.Parse(str);
        }


        public static int CountWords(this string str)
        {
            if (str == "")
                return 0;
            return str.Split().Length;
            // return Int32.Parse(str);
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            /*
             
             Project create a program and write an extension method.  
             The extension method should count the number of words in a sentence.  
             Test that this works using several sentences of text.

             */

            /*
            string str1 = "565";
            int n = str1.myExtensionMethod();
            Console.WriteLine("Result: {0}", n);
            Console.ReadLine();
            */

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
