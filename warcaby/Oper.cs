using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class Oper
    {
        public Operating opera;
        public Algorytm alg;
        public Board brd;
        public Player play, ai;
        public Oper(Operating opera, Algorytm alg, Board brd, Player play, Player ai)
        {
            this.opera = opera;
            this.alg = alg;
            this.brd = brd;
            this.play = play;
            this.ai = ai;
        }

        public void BothMoves()
        {

        }
    }
}
