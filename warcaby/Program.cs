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
            while (opera.end == 0)
            {
                opera.BothMoves(forePlayer, foreAI,alg);
                opera.operabrd.PrintBoard(play.cheqs, ai.cheqs, opera.turn);
            }
            string winner = "";
            if (opera.end == -1) winner = "Komputer!";
            else if (opera.end == 1) winner = "Ty!";
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(winner);
            Console.ReadKey();
        }
    }
}
