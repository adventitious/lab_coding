using System;
using System.Linq;
using System.Collections.Generic;


namespace Exercise10
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 10 \n");
            q10();
            Console.WriteLine();
            q10b();
        }


        //Select Syntax
        static void q10()
        {
            List<Customer> customers = GetCustomers();

            var query = from customer in customers
                        where customer.City == "Dublin" || customer.City == "Galway"
                        select customer;

            foreach (Customer c in query)
            {
                Console.WriteLine("{0}, {1}", c.Name, c.City);
            }
        }

        // Lambda Syntax
        static void q10b()
        {
            List<Customer> customers = GetCustomers();

            var query = customers
                        .Where(customer => customer.City == "Dublin" || customer.City == "Galway");

            foreach (Customer c in query)
            {
                Console.WriteLine("{0}, {1}", c.Name, c.City);
            }
        }

        public class Customer
        {
            public string Name;
            public string City;
        }

        static List<Customer> GetCustomers()
        {
            Customer c1 = new Customer { Name = "Tom", City = "Dublin" };
            Customer c2 = new Customer { Name = "Sally", City = "Galway" };
            Customer c3 = new Customer { Name = "George", City = "Cork" };
            Customer c4 = new Customer { Name = "Molly", City = "Dublin" };
            Customer c5 = new Customer { Name = "Joe", City = "Galway" };

            List<Customer> customers = new List<Customer>();
            customers.Add(c1);
            customers.Add(c2);
            customers.Add(c3);
            customers.Add(c4);
            customers.Add(c5);

            return customers;
        }


    }
}
