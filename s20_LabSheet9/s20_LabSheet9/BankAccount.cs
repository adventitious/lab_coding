using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace s20_LabSheet9
{
    public class BankAccount
    {
        public decimal Balance { get; private set; }
        public decimal OverdraftLimit { get; set; }

        public BankAccount()
        {
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
        public void Withdraw(decimal amount)
        {
            // availableFunds = Balance + OverdraftLimit
            if (amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
            }
        }
    }
}
