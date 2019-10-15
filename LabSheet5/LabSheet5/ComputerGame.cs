using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet5
{
    class ComputerGame:Game
    {

        public int Pegi { get; set; }


        public ComputerGame(string name, decimal price, DateTime releaseDate, int pegi )
           : base( name, price, releaseDate)
        {
            Pegi = pegi;
        }


        public decimal GetDiscountPrice()
        {
            return Price * 0.9m;
        }


    }
}
