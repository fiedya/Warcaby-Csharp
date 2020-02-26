using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class Board
    {
        public int w, h;
        public One[,] board;
        public Board(int w, int h)
        {
            this.w = w;
            this.h = h;

            board = new One[w, h];

            CreateOnes();
        }

        public void CreateOnes()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    board[i, j] = new One(i, j, "  ", ConsoleColor.Black, ConsoleColor.Black);
                }
            }
        }

    }

       


}
