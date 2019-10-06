using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            CashRegister cr1 = new CashRegister();
            CashRegister cr2 = new CashRegister();
            CashRegister cr3 = new CashRegister();

            cr1.AddItem((decimal)10.50);
            cr2.AddItem((decimal)13.89);

            cr3.AddItem((decimal)30.80);
            cr2.AddItem((decimal)17.39);
            cr1.AddItem((decimal)10.40);
            cr3.AddItem((decimal)13.89);
            cr2.AddItem((decimal)9.19);
            cr1.AddItem((decimal)15.55);
            cr1.AddItem((decimal)18.09);

            Console.WriteLine();
            Console.WriteLine(cr1.ToString());
            Console.WriteLine(cr2.ToString());
            Console.WriteLine(cr3.ToString());

            Console.WriteLine();
            Console.WriteLine(CashRegister.CashRegistersInfo());
        }
    }
}
