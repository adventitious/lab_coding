using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labsheet3
{
    class CashRegister
    {
        private static int CashRegistersInTotal { get; set; }
        private int CashRegisterNumber { get; set; }



        private int ItemCount { get; set; }
        private decimal ItemValueTotal { get; set; }

        public CashRegister()
        {
            CashRegistersInTotal++;
            CashRegisterNumber = CashRegistersInTotal;
        }

        public void AddItem( decimal itemValue)
        {
            Console.WriteLine("Adding an item worth {0:c} to cash register number {1}", itemValue, CashRegisterNumber);
            ItemCount++;
            ItemValueTotal += itemValue;
        }

        new public string ToString()
        {
            string s1 = "cash register {0}, Total: {1:C}, Items: {2} ";
            string output = String.Format( s1, CashRegisterNumber, ItemValueTotal, ItemCount);
            return output;
        }
    }
}
