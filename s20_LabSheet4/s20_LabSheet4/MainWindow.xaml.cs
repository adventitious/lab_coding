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


            Lsbx_Suppliers.ItemsSource = query1.ToList();

            var query2 = query1
                .OrderBy(s => s.Country)
                .Select(s => s.Country);

            var countries = query2.ToList();

            Lsbx_Country.ItemsSource = countries.Distinct();

        }

        private void Lsbx_StockLevel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var query = from p in db.Products
                        where p.UnitsInStock < 50
                        orderby p.ProductName
                        select p.ProductName;

            string selected = Lsbx_StockLevel.SelectedItem as string;

            switch( selected )
            {
                case "Low":
                    break;
                case "Normal":
                    {
                        query = from p in db.Products
                                where p.UnitsInStock >= 50 && p.UnitsInStock <= 100
                                orderby p.ProductName
                                select p.ProductName;
                        break;
                    }
                case "Overstocked":
                    {
                        query = from p in db.Products
                                where p.UnitsInStock > 100
                                orderby p.ProductName
                                select p.ProductName;
                        break;
                    }
            }
            Lsbx_Products.ItemsSource = query.ToList();
        }

        private void Lsbx_Suppliers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int supplierID = Convert.ToInt32(Lsbx_Suppliers.SelectedValue);

            var query = from p in db.Products
                        where p.SupplierID == supplierID
                        orderby p.ProductName
                        select p.ProductName;

            Lsbx_Products.ItemsSource = query.ToList();
        }

        private void Lsbx_Country_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string country = (string)(Lsbx_Country.SelectedValue);

            var query = from p in db.Products
                        where p.Supplier.Country == country
                        orderby p.ProductName
                        select p.ProductName;

            Lsbx_Products.ItemsSource = query.ToList();
        }
    }
    public enum StockLevel { Low, Normal, Overstocked };
    /*


          HorizontalAlignment="Left" Height="100" Margin="10,49,0,0" VerticalAlignment="Top" Width="100" 

    HorizontalAlignment="Left" Height="100" Margin="432,49,0,0" VerticalAlignment="Top" Width="100"

    HorizontalAlignment="Left" Height="100" Margin="10,193,0,0" VerticalAlignment="Top" Width="522"




            <Label Content="Stock Level" HorizontalContentAlignment="Center"  HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" FontSize="14"/>
            <Label Content="Suppliers"   HorizontalContentAlignment="Center"  Margin="225,10,217,0" VerticalAlignment="Top" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" FontSize="14"/>
            <Label Content="Products"    HorizontalContentAlignment="Center"  HorizontalAlignment="Right" VerticalAlignment="Top" FontSize="14" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" Margin="0,154,217,0"/>
            <Label Content="Country"     HorizontalContentAlignment="Center"  HorizontalAlignment="Left" Margin="432,10,0,0" VerticalAlignment="Top" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" FontSize="14"/>


            <Label Content="Stock Level" />
            <Label Content="Suppliers"   />
            <Label Content="Products"    />
            <Label Content="Country"     />

























    <Window x:Class="s20_LabSheet4.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:s20_LabSheet4"
            mc:Ignorable="d"
            Title="MainWindow" Height="335" Width="550" Loaded="Window_Loaded">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="3"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="3"/>
            </Grid.RowDefinitions>

            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="2"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>

            <ListBox x:Name="Lsbx_StockLevel" Grid.Row="1" Margin="10" SelectionChanged="Lsbx_StockLevel_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Suppliers" DisplayMemberPath="SupplierName" SelectedValuePath="SupplierID" HorizontalAlignment="Left" Height="100" Margin="115,49,0,0" VerticalAlignment="Top" Width="312" SelectionChanged="Lsbx_Suppliers_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Country" Grid.Column="2" Grid.Row="1" Margin="10" SelectionChanged="Lsbx_Country_SelectionChanged"/>

            <ListBox x:Name="Lsbx_Products" Grid.ColumnSpan="3" Grid.Row="3" Margin="10"  />

            <Label Content="Stock Level" Grid.Row="0" Grid.Column="0" />
            <Label Content="Suppliers"   Grid.Row="0" Grid.Column="1" />
            <Label Content="Products"    Grid.Row="0" Grid.Column="2" />
            <Label Content="Country"     Grid.Row="2" Grid.ColumnSpan="3" HorizontalAlignment="Center" />

        </Grid>
    </Window>














    <Window x:Class="s20_LabSheet4.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:s20_LabSheet4"
            mc:Ignorable="d"
            Title="MainWindow" Height="335" Width="550" Loaded="Window_Loaded">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="*"/>
                <RowDefinition Height="3"/>
                <RowDefinition Height="*"/>
                <RowDefinition Height="3"/>
            </Grid.RowDefinitions>

            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="2"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>

            <ListBox x:Name="Lsbx_StockLevel" Grid.Row="1" Margin="10" SelectionChanged="Lsbx_StockLevel_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Suppliers" DisplayMemberPath="SupplierName" SelectedValuePath="SupplierID" HorizontalAlignment="Left" Height="100" Margin="115,49,0,0" VerticalAlignment="Top" Width="312" SelectionChanged="Lsbx_Suppliers_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Country" Grid.Column="2" Grid.Row="1" Margin="10" SelectionChanged="Lsbx_Country_SelectionChanged"/>

            <ListBox x:Name="Lsbx_Products" Grid.ColumnSpan="3" Grid.Row="3" Margin="10"  />

            <Label Content="Stock Level" Grid.Row="0" Grid.Column="0" />
            <Label Content="Suppliers"   Grid.Row="0" Grid.Column="1" />
            <Label Content="Products"    Grid.Row="0" Grid.Column="2" />
            <Label Content="Country"     Grid.Row="2" Grid.ColumnSpan="3" HorizontalAlignment="Center" />

        </Grid>
    </Window>









    <Window x:Class="s20_LabSheet4.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            xmlns:local="clr-namespace:s20_LabSheet4"
            mc:Ignorable="d"
            Title="MainWindow" Height="335" Width="550" Loaded="Window_Loaded">
        <Grid>

            <ListBox x:Name="Lsbx_StockLevel" HorizontalAlignment="Left" Height="100" Margin="10,49,0,0" VerticalAlignment="Top" Width="100" SelectionChanged="Lsbx_StockLevel_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Suppliers" DisplayMemberPath="SupplierName" SelectedValuePath="SupplierID" HorizontalAlignment="Left" Height="100" Margin="115,49,0,0" VerticalAlignment="Top" Width="312" SelectionChanged="Lsbx_Suppliers_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Country" HorizontalAlignment="Left" Height="100" Margin="432,49,0,0" VerticalAlignment="Top" Width="100" SelectionChanged="Lsbx_Country_SelectionChanged"/>
            <ListBox x:Name="Lsbx_Products" HorizontalAlignment="Left" Height="100" Margin="10,193,0,0" VerticalAlignment="Top" Width="522"/>

            <Label Content="Stock Level" HorizontalContentAlignment="Center"  HorizontalAlignment="Left" Margin="10,10,0,0" VerticalAlignment="Top" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" FontSize="14"/>
            <Label Content="Suppliers"   HorizontalContentAlignment="Center"  Margin="225,10,217,0" VerticalAlignment="Top" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" FontSize="14"/>
            <Label Content="Products"    HorizontalContentAlignment="Center"  HorizontalAlignment="Right" VerticalAlignment="Top" FontSize="14" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" Margin="0,154,217,0"/>
            <Label Content="Country"     HorizontalContentAlignment="Center"  HorizontalAlignment="Left" Margin="432,10,0,0" VerticalAlignment="Top" Background="#FF726B6B" Foreground="#FFF3F3F3" Height="34" Width="100" FontWeight="Bold" FontSize="14"/>

        </Grid>
    </Window>


         */
}

