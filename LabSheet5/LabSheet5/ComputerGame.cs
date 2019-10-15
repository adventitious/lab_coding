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

        public override void UpdatePrice(decimal percentageIncrease)
        {
            Price *= (1 + percentageIncrease);
            Console.WriteLine( "Updating price by {0}%", percentageIncrease * 100 );
        }

        public override string ToString()
        {
            return base.ToString() + string.Format(" Pegi: {0}", Pegi);
        }
    }
}
