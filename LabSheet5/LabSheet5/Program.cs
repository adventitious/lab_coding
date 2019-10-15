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
                new Game("Monopoly", 19.99m, new DateTime(1970, 01, 31));

          //  Game g2 = 
            //    new Game() { Price = 10.99m, ReleaseDate = new DateTime(2000, 6, 15) };

            Console.WriteLine(g1.ToString());

        }
    }
}
