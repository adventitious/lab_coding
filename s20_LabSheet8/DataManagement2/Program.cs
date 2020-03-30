using ComputerGames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataManagement2
{
    class Program
    {
        static void Main(string[] args)
        {
            GameData db = new GameData();

            using (db)
            {
                Game game1 = new Game()
                { GameID = 1, Title = "Super Mario World", Platform = "Super Nintendo", Genre = "Platformer", YearOfRelease = 1990 };
                Game game2 = new Game()
                { GameID = 2, Title = "Sonic the Hedgehog 2", Platform = "Megadrive", Genre = "Platformer", YearOfRelease = 1990 };

                Character char1 = new Character()
                { CharacterID = 1, Name = "Tails", Ability = "Flying", YearOfFirstAppearance = 1992, GameID = 2, Game = game2 };
                Character char2 = new Character()
                { CharacterID = 2, Name = "Mario", Ability = "Jumping", YearOfFirstAppearance = 1981, GameID = 1, Game = game1 };
                Character char3 = new Character()
                { CharacterID = 3, Name = "Yoshi", Ability = "Swallow Enemies", YearOfFirstAppearance = 1990, GameID = 1, Game = game1 };
                Character char4 = new Character()
                { CharacterID = 4, Name = "Sonic", Ability = "Speed", YearOfFirstAppearance = 1991, GameID = 2, Game = game2 };


                db.Games.Add(game1);
                db.Games.Add(game2);

                Console.WriteLine("Added games to database");

                db.Characters.Add(char1);
                db.Characters.Add(char2);
                db.Characters.Add(char3);
                db.Characters.Add(char4);

                Console.WriteLine("Added characters to database");

                db.SaveChanges();

                Console.WriteLine("Saved changes to database");
            }
        }
    }
}
