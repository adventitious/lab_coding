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

namespace ComputerGames
{
    public partial class MainWindow : Window
    {
        GameData db = new GameData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from g in db.Games
                        select g.Title;

            var games = query.ToList();

            lbxGames.ItemsSource = games;

            lbxGames.SelectedItem = 0;
            string title = games.ElementAt(0);

            ChangeCharacters(title);

            imgCharacter.Source = new BitmapImage(new Uri($"/images/mario.png", UriKind.Relative));
        }

        private void lbxGames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string title = (string)lbxGames.SelectedValue;
            ChangeCharacters(title);
            lbxCharacters.SelectedItem = 0;
        }

        private void ChangeCharacters(string title)
        {
            var characters = from c in db.Characters
                          where c.Game.Title == title
                          select c.Name;

            lbxCharacters.ItemsSource = characters.ToList();
        }

        private void lbxCharacters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string characterName = (string)lbxCharacters.SelectedValue;

            string imLoc = "/images/" + characterName + ".png";

            //result = MessageBox.Show("Hello MessageBox" + imLoc);

            imgCharacter.Source = new BitmapImage(new Uri( imLoc, UriKind.Relative));
        }
    }
}
