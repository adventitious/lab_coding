using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabSheet4
{

    class Player
    {
        public string Name { get; private set; }
        public string Position { get; private set; }

        public Player( string name, string position )
        {
            Name = name;
            Position = position;
        }

        public string DisplayPlayerTable()
        {
            return string.Format($"{Name,-20}{Position,-20}");
        }

    }
}
