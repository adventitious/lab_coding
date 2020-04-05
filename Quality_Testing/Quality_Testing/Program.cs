using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quality_Testing
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hey!");

            InsuranceService insSer = new InsuranceService();

            Console.WriteLine("ans: {0}",insSer.CalcPremium(22,"rural") );
        }
    }


    public class InsuranceService
    {
        public double CalcPremium(int age, string location)
        {
            double premium;

            if (location == "urban")
            {
                if ((age >= 18) && (age <= 30))
                {
                    premium = 5.0;
                }
                else
                {
                    if (age >= 31)
                    {
                        premium = 2.50;
                    }
                    else
                    {
                        premium = 0.0;
                    }
                }
            }

            else
            {
                if (location == "rural")
                {
                    if ((age >= 18) && (age <= 35))
                    {
                        premium = 60;
                    }

                    else
                    {
                        if (age >= 36)
                        {
                            premium = 50;
                        }
                        else
                        {
                            premium = 0.0;
                        }
                    }
                }
                else
                {
                    premium = 0.0;
                }
            }
            if (age >= 50)
            {
                premium = premium * 0.15;
            }
            return premium;
        }
    }
}
