using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterProject
{

    class CashRegister
    {
        private static decimal CashRegistersCashTotal { get; set; }
        private static int CashRegistersItemTotal { get; set; }
        private static int CashRegistersInTotal { get; set; }
        private int CashRegisterNumber { get; set; }

        private int ItemCount { get; set; }
        private decimal ItemValueTotal { get; set; }

        public CashRegister()
        {
            CashRegistersInTotal++;
            CashRegisterNumber = CashRegistersInTotal;
        }

        public void AddItem(decimal itemValue)
        {
            Console.WriteLine("Adding an item worth {0:c} to cash register number {1}", itemValue, CashRegisterNumber);
            ItemCount++;
            CashRegistersItemTotal++;
            CashRegistersCashTotal += itemValue;
            ItemValueTotal += itemValue;
        }

        new public string ToString()
        {
            string s1 = "cash register {0}, Total: {1:C}, Items: {2} ";
            string output = String.Format(s1, CashRegisterNumber, ItemValueTotal, ItemCount);
            return output;
        }

        public static string CashRegistersInfo()
        {
            string s1 = "{0} cash registers , TotalCash: {1:C}, TotalItems: {2} ";
            string output = String.Format(s1, CashRegistersInTotal, CashRegistersCashTotal, CashRegistersItemTotal);
            return output;

        }
    }




}
