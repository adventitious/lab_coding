using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet5
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g1 =
                new ComputerGame("Monopoly", 19.99m, new DateTime(1970, 01, 31), 8);


            Game g2 =
                new ComputerGame("Cluedo", 15.99m, new DateTime(1965, 02, 26), 12);

            //  Game g2 = 
            //    new Game() { Price = 10.99m, ReleaseDate = new DateTime(2000, 6, 15) };


            ComputerGame cg1 = new ComputerGame("Pong", 49.99m, new DateTime(1985, 08, 20), 12);
            ComputerGame cg2 = new ComputerGame("Galaga", 55.99m, new DateTime(1983, 10, 19), 16);

            //Console.WriteLine(g1.ToString());

            DisplayGame(g1);
            DisplayGame(g2);
            DisplayGame(cg1);
            DisplayGame(cg2);
        }

        static void DisplayGame( Game game )
        {
            Console.WriteLine( game );
        }
    }
}
