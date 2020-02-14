using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace s20_LabSheet3
{

    public partial class MainWindow : Window
    {
        // project --> add new item --> data --> new ado.net
        NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnQueryEx1_Click(object sender, RoutedEventArgs e)
        {
            // query syntax
            var query = from c in db.Customers
                        select c.CompanyName;

            // lambda syntax
            var queryLambda = (db.Customers.Select(c => c.CompanyName));

            if( query.Equals( queryLambda ) )
            {
                MessageBox.Show( "query equals queryLambda" );
            }

            var list1 = query.ToList();
            var list2 = queryLambda.ToList();

            if ( list1.Count() != list2.Count() )
            {
                MessageBox.Show("list1 not equal to list2");
            }

            // lbxCustomersEx1.ItemsSource = query.ToList();
            lbxCustomersEx1.ItemsSource = queryLambda.ToList();
        }

        private void BtnQueryEx2_Click(object sender, RoutedEventArgs e)
        {
            // query Syntax
            var query = from c in db.Customers
                        select c;

            // lambda Syntax
            var queryLambda = db.Customers.Select(c => c);

            //dgrQueryEx2.ItemsSource = query.ToList();
            dgrQueryEx2.ItemsSource = queryLambda.ToList();
        }

        private void BtnQueryEx3_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        where o.Customer.City.Equals("London")
                        || o.Customer.City.Equals("Paris")
                        || o.Customer.City.Equals("USA")
                        orderby o.Customer.CompanyName
                        select new
                        {
                            CustomerName = o.Customer.CompanyName,
                            City = o.Customer.City,
                            Address = o.ShipAddress
                        };


            var queryLambda = db.Orders
                            .Where(o => o.Customer.City.Equals("London")
                            || o.Customer.City.Equals("Paris")
                            || o.Customer.City.Equals("USA") )
                            .OrderBy(o=>o.Customer.CompanyName)
                            .Select(o => new
                            {
                                CustomerName = o.Customer.CompanyName,
                                City = o.Customer.City,
                                Address = o.ShipAddress
                            });
            ;

            //dgrQueryEx3.ItemsSource = query.ToList();
            dgrQueryEx3.ItemsSource = queryLambda.ToList();
        }

        private void BtnQueryEx4_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };


            var queryLambda = db.Products
                .Where(p => p.Category.CategoryName.Equals("Beverages"))
                .OrderByDescending(p => p.ProductID)
                .Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.Category.CategoryName,
                    p.UnitPrice
                });

            // dgrQueryEx4.ItemsSource = queryLambda.ToList();
            dgrQueryEx4.ItemsSource = query.ToList();
        }

        private void BtnQueryEx5_Click(object sender, RoutedEventArgs e)
        {
            Product p = new Product()
            {
                ProductName = "Kickapoo Jungle Joy Juice",
                UnitPrice = 12.49m,
                CategoryID = 1
            };

            db.Products.Add(p);
            db.SaveChanges();

            ShowProducts(dgrQueryEx5);
        }
        private void ShowProducts( DataGrid CurrentGrid )
        {
            var query = from p in db.Products
                        where p.Category.CategoryName.Equals("Beverages")
                        orderby p.ProductID descending
                        select new
                        {
                            p.ProductID,
                            p.ProductName,
                            p.Category.CategoryName,
                            p.UnitPrice
                        };

            var queryLambda = db.Products
                .Where( p => p.Category.CategoryName.Equals("Beverages"))
                .OrderByDescending(p => p.ProductID)
                .Select(p => new
                {
                    p.ProductID,
                    p.ProductName,
                    p.Category.CategoryName,
                    p.UnitPrice
                });


            //CurrentGrid.ItemsSource = query.ToList();
            CurrentGrid.ItemsSource = queryLambda.ToList();
        }

        private void BtnQueryEx6_Click(object sender, RoutedEventArgs e)
        {
            // q6. update product, Lambda
            Product p1 = (db.Products
                .Where(p => p.ProductName.StartsWith("Kick"))
                .Select(p => p)
                ).First();

            p1.UnitPrice = 100m;

            // q6. update product, Query syntax
            Product p2 = (from p in db.Products
                         where p.ProductName.StartsWith("Kick")
                         select p).First();

            p2.UnitPrice = 102m;

            db.SaveChanges();
            ShowProducts(dgrQueryEx6);
        }

        private void BtnQueryEx7_Click(object sender, RoutedEventArgs e)
        {
            // q7. multiple update
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;

            // q7. multiple update, Lambda
            var products2 = db.Products
                .Where(p => p.ProductName.StartsWith("Kick"))
                .Select(p => p);

            foreach ( var item in products )
            {
                item.UnitPrice = 202m;
            }

            db.SaveChanges();
            ShowProducts(dgrQueryEx7);
        }

        private void BtnQueryEx8_Click(object sender, RoutedEventArgs e)
        {
            // q8. delete, Query Syntax
            var products = from p in db.Products
                           where p.ProductName.StartsWith("Kick")
                           select p;

            // q8. delete, Lambda Syntax
            var products2 = db.Products
                           .Where(p => p.ProductName.StartsWith("Kick"))
                           .Select(p => p);

            db.Products.RemoveRange(products2);
            db.SaveChanges();

            ShowProducts(dgrQueryEx8);
        }

        private void BtnQueryEx9_Click(object sender, RoutedEventArgs e)
        {
            // q9. Stored Procedure
            var query = db.Customers_By_City("London");

            dgrQueryEx9.ItemsSource = query.ToList();
        }
    }
}
