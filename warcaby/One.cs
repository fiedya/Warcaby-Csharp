using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class One
    {
        public int x, y;
        public ConsoleColor color, playerColor;
        public string value;
        public One(int x, int y, string value, ConsoleColor color, ConsoleColor playerColor)
        {
            this.x = x;
            this.y = y;
            this.color = color;
            this.playerColor = playerColor;
            this.value = value;
        }

        public string printOne()
        {
            Console.BackgroundColor = color;
            Console.ForegroundColor = playerColor;
            string s = value;
            return s;
        }
    }
}
