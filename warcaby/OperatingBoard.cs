using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class OperatingBoard
    {
        int h, w;
        Board brd;
        ConsoleColor backOne, backTwo,  foreOne,  foreTwo;

        public OperatingBoard(Board brd, ConsoleColor backOne, 
            ConsoleColor backTwo, ConsoleColor foreOne, ConsoleColor foreTwo)
        {
            this.brd = brd;
            h = brd.h;
            w = brd.w;
            this.backTwo = backTwo;
            this.backOne = backOne;
            this.foreOne = foreOne;
            this.foreTwo = foreTwo;
            CreateNewBoard();

        }

        public void CreateNewBoard()
        {
            for (int i = 0; i < h; i++)
            {
                for (int j = 0; j < w; j++)
                {
                    One temp = brd.board[i, j];
                    if ((i + j) % 2 == 0)
                    {

                            brd.board[i, j] = new One(i, j, "  ", backOne, ConsoleColor.Yellow);
                    }
                    else if ((i + j) % 2 == 1)
                    {
                            brd.board[i, j] = new One(i, j, "  ", backTwo, ConsoleColor.Yellow);
                    }

                }
            }


                for (int i = 0; i < h; i++)
                {
                    for (int j = 0; j < w; j++)
                    {

                            if (i < 2 && brd.board[i, j].color == backOne)
                            {
                                brd.board[i, j] = new One(i, j, "()", backOne, foreOne);
                            }

                            else if (i>(h-3) && brd.board[i, j].color == backOne)
                            {
                                brd.board[i, j] = new One(i, j, "[]", backOne, foreTwo);
                            }


                    }
                }
            
        }

        public void PrintBoard(int playCheq, int aiCheq, int turn)
        {
           // Console.Clear();
            Console.WriteLine(" A B C D E F G H");
            for (int i = 0; i < h; i++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(i+1);
                for (int j = 0; j < w; j++)
                {
                    Console.Write(brd.board[i, j].printOne());
                }
                Console.ResetColor();
                Console.Write(i+1);
                Console.WriteLine();
            }
            Console.WriteLine(" A B C D E F G H");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Tura: "+turn+".");
        }


    }
}
