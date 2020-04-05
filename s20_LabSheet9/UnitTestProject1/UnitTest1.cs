using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using s20_LabSheet9;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDeposit()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            decimal expectedBalance = 200m;

            // ACT
            acc1.Deposit(200);

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }


        [TestMethod]
        public void TestMultipleDeposits()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            decimal expectedBalance = 750m;

            // ACT
            acc1.Deposit(200);
            acc1.Deposit(300);
            acc1.Deposit(250);

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }


        [TestMethod]
        public void TestNewAccountHasZero()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            decimal expectedBalance = 0m;

            // ACT

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }

        [TestMethod]
        public void TestWithdrawSufficientFunds()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            acc1.Deposit(300);
            decimal expectedBalance = 100m;

            // ACT
            acc1.Withdraw(200);

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }

        [TestMethod]
        public void Test_Withdraw_InSufficient_Funds()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            acc1.Deposit(100);
            decimal expectedBalance = 100m;

            // ACT
            acc1.Withdraw(200);

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }


        [TestMethod]
        public void Test_Withdraw_Sufficient_Funds_with_Overdraft()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            acc1.OverdraftLimit = 100m;
            decimal expectedBalance = -50m;

            // ACT
            acc1.Withdraw(50);

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }

        [TestMethod]
        public void Test_Withdraw_InSufficient_Funds_with_Overdraft()
        {
            // ARRANGE
            BankAccount acc1 = new BankAccount();
            acc1.OverdraftLimit = 100m;
            decimal expectedBalance = 0m;

            // ACT
            acc1.Withdraw(500);

            // ASSERT
            Assert.AreEqual(expectedBalance, acc1.Balance);
        }
    }
}
