using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCA
{
    class Program
    {
        static void Main(string[] args)
        {
            cwl("Hello World!");

            Player player1 = new Player(1, "Millie", 0);
            Player player2 = new Player(2, "Katie", 0);
            Player player3 = new Player(3, "Kevin", 0);
            Player player4 = new Player(4, "Conor", 0);
            Player player5 = new Player(5, "Pauline", 0);

            List<Player> list1 = new List<Player>();

            list1.Add(player1);
            list1.Add(player2);
            list1.Add(player3);
            list1.Add(player4);
            list1.Add(player5);

            DisplayPlayerScores(list1);


            int playerInt = -1;

            while (playerInt != 0)
            {
                playerInt = GetPlayerIntFromConsole();
                if (playerInt > 0)
                {
                    if (playerInt > list1.Count)
                    {
                        cwl("there are not that many players");
                    }
                    else
                    {
                        list1.ElementAt(playerInt - 1).IncreaseScore(1);
                        DisplayPlayerScores(list1);
                        Console.WriteLine();
                    }
                }
            }

            DisplayPlayerDetails(list1);
            list1.Sort();
            DisplayPlayerDetails(list1);
            Console.WriteLine();
        }

        static void DisplayPlayerScores(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                cw("{0,-20}", "player " + (1 + i));
            }
            cwl("");
            foreach (Player p in players)
            {
                cw("{0,-20}", p.Score);
            }

            cwl("");

        }

        static void DisplayPlayerDetails(List<Player> players)
        {
            Console.WriteLine("\n{0, -12}{1,-12}{2,-12}", "Id", "username", "score");
            Console.WriteLine("-------------------------------");
            foreach (Player p in players)
            {
                cwl(p.ToString());
            }
            Console.WriteLine("HighScore:{0}", Player.HighScore);

        }


        static int GetPlayerIntFromConsole()
        {
            cw("enter number of Player to update score: ");
            string input = Console.ReadLine();

            bool res;
            int a;

            res = int.TryParse(input, out a);

            if (!res)
            {
                return -1;
            }

            return a;
        }


        static void cw(string writeOut)
        {
            Console.Write(writeOut);
        }

        static void cw(string writeOut, object writeOutValues)
        {
            Console.Write(writeOut, writeOutValues);
        }
        static void cwl(string writeOut)
        {
            Console.WriteLine(writeOut);
        }

        static void cwl(string writeOut, object writeOutValues)
        {
            Console.WriteLine(writeOut, writeOutValues);
        }
    }
}
