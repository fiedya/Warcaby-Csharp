using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace warcaby
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor dark = ConsoleColor.DarkGray;
            ConsoleColor light = ConsoleColor.Yellow;
            ConsoleColor foreAI = ConsoleColor.DarkBlue;
            ConsoleColor forePlayer = ConsoleColor.DarkMagenta;
            int aiCheq = 8;
            int playCheq = 8;
            int turn = 1;
            Player play = new Player(playCheq, forePlayer);
            Player ai = new Player(aiCheq, foreAI);
            Board brd = new Board(8, 8);
           
            OperatingBoard operabrd = new OperatingBoard(brd,light,dark, foreAI, forePlayer);
            Operating opera = new Operating(brd, operabrd, play.cheqs, ai.cheqs, turn);

            Algorytm alg = new Algorytm(brd, play, ai, opera, foreAI, forePlayer);

            Oper op = new Oper(opera, alg, brd, play, ai);




            operabrd.PrintBoard(playCheq, aiCheq, turn);
            int x = 1;
            while( aiCheq>0 || playCheq> 0)
            {
                opera.PlayerMove(forePlayer, foreAI);
                alg.MoveAi();
                x++;
            }
            Console.ReadKey();
        }
    }
}
