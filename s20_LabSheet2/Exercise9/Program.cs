using System;
using System.Linq;
using System.Collections.Generic;

namespace Exercise9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Exercise 9\n");
            q9();
            Console.WriteLine("");
            q9b();
        }

        //Select Syntax
        static void q9()
        {
            List<Customer> customers = GetCustomers();

            var query = from customer in customers
                        where customer.City == "Dublin"
                        select customer;

            foreach (Customer c in query)
            {
                Console.WriteLine("{0}, {1}", c.Name, c.City);
            }
        }

        // Lambda Syntax
        static void q9b()
        {
            List<Customer> customers = GetCustomers();

            var query = customers
                        .Where(customer => customer.City == "Dublin");

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
