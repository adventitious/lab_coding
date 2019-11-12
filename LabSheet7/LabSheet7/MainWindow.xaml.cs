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

namespace LabSheet7
{


    public class Expense
    {
        string ExpType { get; set; }
        public double Amount {  get; private  set; }
        DateTime TheDate { get; set; }

        public Expense( string exptype, double amount, DateTime theDate )
        {
            ExpType = exptype;
            Amount = amount;
            TheDate = theDate;
        }

        public override string ToString()
        {
            return string.Format("{0} {1:c} {2}", ExpType, Amount, TheDate.ToString("dd/MM/yyyy") );
        }
    }

    public partial class MainWindow : Window
    {
        List<Expense> Expenses;
        Random r = new Random();
        string[] ExpenseTypes = { "Travel", "Office" };

        public MainWindow()
        {
            InitializeComponent();
            Expenses = new List<Expense>();

            AddAnExpense();
            AddAnExpense();
            AddAnExpense();

            LblSum.Content = string.Format("{0:c}", SumExpenses() ) ;
        }

        public Expense CreateExpense()
        {
            int expTypeInt = r.Next(0, ExpenseTypes.Length );
            double amount = r.Next(7500, 20000) * 0.01;
            Expense expense = new Expense(ExpenseTypes[expTypeInt], amount, GetRandomDate());
            return expense;
        }

        public void AddAnExpense()
        {
            Expense expense = CreateExpense();
            Expenses.Add(expense);
            LbxMain.Items.Add(expense);
        }

        public DateTime GetRandomDate()
        {// DateTime.Now;

            int days = r.Next(10, 500);

            DateTime d1 = DateTime.Today.AddDays(-days);

            return d1;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddAnExpense();
            LblSum.Content = string.Format("{0:c}", SumExpenses());
        }

        public double SumExpenses()
        {
            double total = 0;
            foreach( Expense e in Expenses )
            {
                total += e.Amount;
            }
            return total;
        }
    }
}
