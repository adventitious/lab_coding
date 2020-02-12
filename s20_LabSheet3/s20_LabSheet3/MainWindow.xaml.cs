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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
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
            lbxCustomersEx1.ItemsSource = query.ToList();
        }

        private void BtnQueryEx2_Click(object sender, RoutedEventArgs e)
        {
            var query = from c in db.Customers
                        select c;
            dgrQueryEx2.ItemsSource = query.ToList();
        }

        private void BtnQueryEx3_Click(object sender, RoutedEventArgs e)
        {
        }

        private void BtnQueryEx4_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
