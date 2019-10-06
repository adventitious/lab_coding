using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labsheet3
{
    class BankAccount
    {
        public int AccountNumber { get; set; }
        public string AccountHolder { get; set; }
        public decimal AccountBalance { get; set; }

        public BankAccount(int argAccountNumber, string argAccountHolder, decimal argAccountBalance )
        {
            AccountNumber = argAccountNumber;
            AccountHolder = argAccountHolder;
            AccountBalance = argAccountBalance;
        }

        public void Deposit(decimal Amount)
        {
            AccountBalance += Amount;
        }
        public void Withdraw(decimal Amount)
        {
            if ( AccountBalance >= Amount )
            {
                AccountBalance -= Amount;
            }
        }

        public string GetAccountDetails()
        {
            string output = String.Format("Account Number: {0}\n", AccountNumber);
            output += String.Format("Account Holder: {0}\n", AccountHolder);
            output += String.Format("Account Balance: {0}\n\n", AccountBalance);
            return output;
        }
    }
}
