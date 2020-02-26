using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class Player
    {
        public int cheqs;
        public ConsoleColor color;
        public Player(int cheqs, ConsoleColor color)
        {
            this.cheqs=cheqs;
            this.color = color;
        }
    }
}
