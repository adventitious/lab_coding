using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherSampleCA
{
    class Program
    {
        const double travelCost = 0.45;
        const double squareMetreCost = 3.25;

        static protected int Fittings { get; set; }
        static protected double TotalCost { get; set; }

        static void Main(string[] args)
        {
            Console.WriteLine("Carpet Fitting Cost Calculator");

            try2();
        }

        static void try2()
        {
            int zeroOrOne = 1;
            do
            {
                try1();
                zeroOrOne = GetZeroOrOneFromConsole("Enter a 0 to end or 1 to input another fitting: ");                
            }
            while (zeroOrOne == 1);
            try3();
        }


        static int try3()
        {
            Console.WriteLine("{0,-18}eur {1:0.00}", "total costs:", TotalCost);
            Console.WriteLine("{0,-18}eur {1:0.00}", "average cost:", (TotalCost / Fittings));

            return 0;
        }


        static int try1()
        {
            int kilometres = GetIntFromConsole("Enter a distance in kilometres: ");
            double carpetSize = GetDoubleFromConsole("Enter a carpet size: " );

            double cost = CaclulateCost(kilometres, carpetSize);

            Console.WriteLine("{0,-18}eur {1:0.00}", "cost:", cost);

            return 1;
        }

        static double CaclulateCost(int kilometres, double carpetSize )
        {
            double a = travelCost * kilometres;
            double b = squareMetreCost * carpetSize;

            double cost = a + b;
            if(cost > 250 )
            {
                cost = cost * 0.9;
            }

            Fittings++;
            TotalCost += cost;

            return cost;
        }


        static int GetZeroOrOneFromConsole(string messageForConsole)
        {
            int result = 0;
            do
            {
                result = GetIntFromConsole2(messageForConsole);
            }
            while ( result != 0 && result != 1 );

            return result;
        }

        static int GetIntFromConsole(string messageForConsole)
        {
            int result = 0;
            do
            {
                result = GetIntFromConsole2(messageForConsole);
            }
            while (result == -1);

            return result;
        }

        static double GetDoubleFromConsole(string messageForConsole)
        {
            double result = 0;
            do
            {
                result = GetDoubleFromConsole2(messageForConsole);
            }
            while (result == -1);

            return result;
        }


        static double GetDoubleFromConsole2(string messageForConsole)
        {
            Console.Write(messageForConsole);
            string input = Console.ReadLine();

            bool res;
            double a;

            res = double.TryParse(input, out a);

            if (!res)
            {
                return -1;
            }

            return a;
        }

        static int GetIntFromConsole2(string messageForConsole)
        {
            Console.Write(messageForConsole);
            string input = Console.ReadLine();

            bool res;
            int a;

            res = int.TryParse(input, out a);

            if (!res)
            {
                return -1;
            }

            return a;
        }
    }
}
