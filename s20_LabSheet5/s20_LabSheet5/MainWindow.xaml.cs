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

namespace s20_LabSheet5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1Container db = new Model1Container();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from b in db.Bands
                        select b;

            Lbx_Bands.ItemsSource = query.ToList();

            if (Lbx_Bands.Items.Count > 0 )
            {
                Lbx_Bands.SelectedItem = Lbx_Bands.Items[0];
            }
        }

        private void Lbx_Bands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // determine band 
            Band selectedBand = Lbx_Bands.SelectedItem as Band;

            if( selectedBand == null )
            {
                return;
            }

            // display band info
            string bandText = $"Year formed: {selectedBand.YearFormed}\nMembers: {selectedBand.Members}";
            Tblk_BandInfo.Text = bandText;

            // display band image
            Img_Band.Source = new BitmapImage(new Uri($"/images/{selectedBand.BandImage}", UriKind.Relative ));

            // display albums
            Lbx_Albums.ItemsSource = selectedBand.Albums;


            if (Lbx_Albums.Items.Count > 0)
            {
                Lbx_Albums.SelectedItem = Lbx_Albums.Items[0];
            }
        }

        private void Lbx_Albums_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // determine album 
            Album selectedAlbum = Lbx_Albums.SelectedItem as Album; //LbxBands.SelectedItem as Band;

            if (selectedAlbum == null)
            {
                return;
            }

            // display album info selectedAlbum.Sales  String.Format("{0:n0}", 9876)
            string albumText = $"Released: {selectedAlbum.Released.ToString("dd MMMM yyyy")}\nSales: {  String.Format("{0:n0}", selectedAlbum.Sales) }";
            Tblk_AlbumInfo.Text = albumText;

            // display album image
            Img_Album.Source = new BitmapImage(new Uri($"/images/{selectedAlbum.AlbumImage}", UriKind.Relative));

            /*  <Image x:Name="Img_Album" Source="{Binding Path=AlbumImage}" HorizontalAlignment="Left" Height="150" Margin="595,218,0,0" VerticalAlignment="Top" Width="150"/>  */
        
        }
    }
}
