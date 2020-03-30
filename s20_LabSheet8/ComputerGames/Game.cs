using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGames
{
    public class Character
    {
        public int CharacterID { get; set; }
        public string Name { get; set; }
        public string Ability { get; set; }
        public int YearOfFirstAppearance { get; set; }
        public int GameID{ get; set; }
        public virtual Game Game{ get; set; }
    }

    public class Game
    {
        public int GameID { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public int YearOfRelease { get; set; }
        public virtual List<Character> Characters { get; set; }
    }

    public class GameData : DbContext
    {
        public GameData() : base("MyGameData") { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
