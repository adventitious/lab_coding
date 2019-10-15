﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet5
{
    abstract class Game
    {
        #region properties
        private readonly string _name;
        // public string Name { get; private set; }
        public string Name
        {
            get
            {
                return _name;
            }
        }
        protected decimal Price { get;  set; }
        public DateTime ReleaseDate { get;  set; }

        #endregion properties

        public Game(string name, decimal price, DateTime releaseDate)
        {
            _name = name;
            Price = price;
            ReleaseDate = releaseDate;
        }


        public Game(string name, decimal price)
            : this(name, price, DateTime.Now)
        {

        }
        
        public Game()
            : this("", 0)
        {

        }

        public abstract void UpdatePrice(decimal percentageIncrease);


        public override string ToString()
        {
            return string.Format("Name: {0}, Price: {1}, ReleaseDate: {2}", Name, Price, ReleaseDate.ToShortDateString() );
        }
    }
}
