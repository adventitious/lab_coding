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

namespace s20_LabSheet6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public NORTHWNDEntities db = new NORTHWNDEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Ex1Button_Click(object sender, RoutedEventArgs e)
        {
             var query = from c in db.Categories
                         join p in db.Products on c.CategoryName equals p.Category.CategoryName
                         orderby c.CategoryName
                         select new { Category = c.CategoryName, Product = p.ProductName };

            var results = query.ToList();
            Ex1Display.ItemsSource = results;
            Ex1_Count.Content = results.Count.ToString();
        }

        private void Ex2Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        orderby p.Category.CategoryName
                        select new { Category = p.Category.CategoryName, Product = p.ProductName };

            var results = query.ToList();
            Ex2Display.ItemsSource = results;
            Ex2_Count.Content = results.Count.ToString();
        }

        private void Ex3Button_Click(object sender, RoutedEventArgs e)
        {
            // return the number of orders for product 7
            var query1 = from detail in db.Order_Details
                         where detail.ProductID == 7
                         select detail;

            // return the number of orders for product 7
            var query2 = from detail in db.Order_Details
                         where detail.ProductID == 7
                         select detail.UnitPrice * detail.Quantity;

            int numberOfOrders = query1.Count();
            decimal totalValue = query2.Sum();
            decimal averageValue = query2.Average();

            //String s = string.Format("Total number of orders {0}\nValue of orders {1:C}\nAverage order value {2:C}", numberOfOrders, totalValue, averageValue );
            Ex3_Display.Content = string.Format("Total number of orders {0}\nValue of orders {1:C}\nAverage order value {2:C}", numberOfOrders, totalValue, averageValue);
        }

        private void Ex4Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        where customer.Orders.Count >= 20
                        select new
                        {
                            Name = customer.CompanyName,
                            OrderCount = customer.Orders.Count
                        };
            Ex4_Display.ItemsSource = query.ToList();
        }

        private void Ex5Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        where customer.Orders.Count < 3
                        select new
                        {
                            Company = customer.CompanyName,
                            City = customer.City,
                            Region = customer.Region,
                            OrderCount = customer.Orders.Count
                        };
            Ex5_Display.ItemsSource = query.ToList();
        }

        private void Ex6Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from customer in db.Customers
                        orderby customer.CompanyName
                        select customer.CompanyName;

            Ex6_Display.ItemsSource = query.ToList();
        }

        private void Ex6_Display_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string company = (string)Ex6_Display.SelectedItem;

            if( company == null )
            {
                return;
            }
            var query = (from detail in db.Order_Details
                        where detail.Order.Customer.CompanyName == company
                        select detail.UnitPrice * detail.Quantity).Sum();

            Ex6_Display2.Text = string.Format("Total for supplier {0} \n\n{1:C}", company, query);
        }

        private void Ex7Button_Click(object sender, RoutedEventArgs e)
        {
            var query = from p in db.Products
                        group p by p.Category.CategoryName into g
                        orderby g.Count() descending
                        select new
                        {
                            Category = g.Key,
                            Count = g.Count()
                        };
            Ex7_Display.ItemsSource = query.ToList();
        }
    }
}
