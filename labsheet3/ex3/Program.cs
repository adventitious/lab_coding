using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace labsheet3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            // enter main code herez
            // TaskCar();
            TaskCashRegister();
            Tasks();
        }

        static void TaskCar()
        {
            Car car1 = new Car();
            car1.Make = "toyota";
            car1.Model = "camry";
            car1.CurrentSpeed = 0;
            car1.EngineSize = 1.8;

            Car car2 = new Car();
            car2.Make = "renault";
            car2.Model = "megane";
            car2.CurrentSpeed = 30;
            car2.EngineSize = 1.6;

            Console.WriteLine("car 1 make and model: {0} {1}", car1.Make, car1.Model);
            Console.WriteLine("car 1 current speed: {0}", car1.CurrentSpeed);
            Console.WriteLine("car 1 engine size: {0}\n", car1.EngineSize);

            Console.WriteLine("car 2 make and model: {0} {1}", car2.Make, car2.Model);
            Console.WriteLine("car 2 current speed: {0}", car2.CurrentSpeed);
            Console.WriteLine("car 2 engine size: {0}\n", car2.EngineSize);

            car1.DisplayCarInfo();
            Console.WriteLine(car1.ToString());
            for (int i = 0; i < 10; i++)
            {
                car1.Accelerate();
            }
            Console.WriteLine(car1.ToString());
        }
        static void TaskBank()
        {
            BankAccount account1 = new BankAccount(1, "megan", 20);
            Console.WriteLine(account1.GetAccountDetails());

            BankAccount account2 = new BankAccount(2, "cammy", 30);
            Console.WriteLine(account2.GetAccountDetails());

            Console.WriteLine("account1 deposits 5");
            Console.WriteLine("account2 withdraws 10\n");

            account1.Deposit(5);
            account2.Withdraw(10);

            Console.WriteLine(account1.GetAccountDetails());
            Console.WriteLine(account2.GetAccountDetails());

        }

        static void TaskCashRegister()
        {
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
        }


        static void Tasks()
        {

        }
    }
}
