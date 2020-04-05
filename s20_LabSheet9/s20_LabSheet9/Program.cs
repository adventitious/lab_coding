using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s20_LabSheet9
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class BankAccount
    {
        public decimal Balance { get; private set; }

        public BankAccount()
        {
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }
}
