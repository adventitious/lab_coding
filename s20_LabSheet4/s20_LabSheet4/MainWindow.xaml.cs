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

namespace s20_LabSheet4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // string db = "";
        NORTHWNDEntities db = new NORTHWNDEntities();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Lsbx_StockLevel.ItemsSource = Enum.GetNames(typeof(StockLevel));
            //   System.Windows.MessageBox.Show("You said: " + " wwww:224 ");

            var query1 = from s in db.Suppliers
                         orderby s.CompanyName
                         select new
                         {
                             SupplierName = s.CompanyName,
                             SupplierID = s.SupplierID,
                             Country = s.Country
                         };

            var query1b = query1
                .Select(s => s.SupplierName);


            Lsbx_Suppliers.ItemsSource = query1b.ToList();

            var query2 = query1
                .OrderBy(s => s.Country)
                .Select(s => s.Country);

            var countries = query2.ToList();

            Lsbx_Country.ItemsSource = countries;

        }

        public enum StockLevel { Low, Normal, Overstocked };
    }
}
