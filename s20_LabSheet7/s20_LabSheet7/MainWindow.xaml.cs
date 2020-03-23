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

namespace s20_LabSheet7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NORTHWNDEntities db = new NORTHWNDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Q1Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        group c by c.Country into g
                        orderby g.Count() descending
                        select new
                        {
                            Country = g.Key,
                            Count = g.Count()
                        };

            Q1_Display.ItemsSource = query.ToList();
        }
        private void Q2Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Country == "Italy"
                        orderby c.CompanyName
                        select new
                        {
                            c.CompanyName,
                            c.ContactName,
                            c.City
                        };
            
            Q2_Display.ItemsSource = query.Distinct().ToList();

            //Q2_Display.ItemsSource = query.ToList().Distinct();

        }
        private void Q3Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        where ( (p.UnitsInStock - p.UnitsOnOrder) > 0)
                        select new
                        {
                            Product = p.ProductName,
                            Available = p.UnitsInStock - p.UnitsOnOrder
                        };

            Q3_Display.ItemsSource = query.ToList();
        }

        private void Q4Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from od in db.Order_Details
                        orderby od.Product.ProductName
                        where od.Discount > 0
                        select new
                        {
                            od.Product.ProductName,
                            DiscountGiven= od.Discount,
                            od.OrderID,
                        };

            Q4_Display.ItemsSource = query.ToList();
        }

        private void Q5Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        select o.Freight;

            var query2 = db.Orders.Sum(o => o.Freight);

            // Q5_Display.Content = string.Format("Total {0:C}", query.Sum());
            // Q5_Display.Content = $"Total {query2:C}";
            Q5_Display.Content = $"Total {query.Sum():C}";
        }
        private void Q6Button_Click(object sender, RoutedEventArgs e)
        {
            var query = (from p in db.Products
                        orderby p.Category.CategoryName descending, p.UnitPrice
                        select new
                        {
                            p.CategoryID,
                            p.Category.CategoryName,
                            p.ProductName,
                            p.UnitPrice
                        }).AsEnumerable().Reverse();

            Q6_Display.ItemsSource = query.ToList();
        }

        private void Q7Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        group o by o.CustomerID into g 
                        orderby g.Count() descending
                        select new
                        {
                            CustomerID = g.Key,
                            NumberOfOrders = g.Count()
                        };

            Q7_Display.ItemsSource = query.ToList();
        }

        private void Q8Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from o in db.Orders
                        group o by o.CustomerID into g
                        join c in db.Customers on g.Key equals c.CustomerID
                        orderby g.Count() descending
                        select new
                        {
                            c.CustomerID,
                            c.CompanyName,
                            NumberOfOrders = c.Orders.Count
                        };

            Q8_Display.ItemsSource = query.ToList().Take(10);
        }

        private void Q9Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        where c.Orders.Count == 0
                        orderby c.Orders.Count
                        select new
                        {
                            CompanyID = c.CustomerID,
                            c.CompanyName,
                            NumberOfOrders = c.Orders.Count
                        };

            Q9_Display.ItemsSource = query.ToList();
        }
    }
}
