using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class  Algorytm
    {
        Board brd;
        Player play, ai;
        Operating opera;
        ConsoleColor aiColor, playColor;
        int turn;
        public Algorytm(Board brd, Player play, Player ai, Operating opera, ConsoleColor aiColor, ConsoleColor playColor)
        {
            this.brd = brd;
            this.play = play;
            this.ai = ai;
            this.opera = opera;
            this.aiColor = aiColor;
            this.playColor = playColor;
            turn = opera.turn;
        }

        public void MoveAi()
        {
            List<One> ch = new List<One>();
            for(int i=0; i<brd.h; i++)
            {
                for(int j=0; j< brd.w; j++)
                {
                    if (brd.board[i, j].value == "()" && brd.board[i, j].playerColor == aiColor)
                        ch.Add(brd.board[i, j]);
                }
               
            }

            AllMoves(ch);
            turn++;
        }

        public List<One> FindMovesForOne(One tile, List<One> av)
        {

            int x = tile.x;
            int y = tile.y;

            if (opera.IsAvaible(x, y, x + 1, y + 1)) av.Add(brd.board[x + 1, y + 1]);
            else if(opera.IsPlayerInNeigh(x+1,y+1, playColor) && opera.isSecFree(x+2,y+2)) av.Add(brd.board[x + 2, y + 2]);

            if (opera.IsAvaible(x, y, x - 1, y + 1)) av.Add(brd.board[x - 1, y + 1]);
            else if (opera.IsPlayerInNeigh(x - 1, y + 1, playColor) && opera.isSecFree(x - 2, y + 2)) av.Add(brd.board[x - 2, y + 2]);
                               
            if (opera.IsAvaible(x, y, x + 1, y - 1)) av.Add(brd.board[x + 1, y - 1]);
            else if (opera.IsPlayerInNeigh(x + 1, y - 1, playColor) && opera.isSecFree(x + 2, y - 2)) av.Add(brd.board[x + 2, y - 2]);

            if (opera.IsAvaible(x, y, x - 1, y - 1)) av.Add(brd.board[x - 1, y - 1]);
            else if (opera.IsPlayerInNeigh(x - 1, y - 1, playColor) && opera.isSecFree(x - 2, y - 2)) av.Add(brd.board[x - 2, y - 2]);

            return av;
        }

        public void AllMoves(List<One> cheqs)
        {
            int count = cheqs.Count;
            List<List<One>> cheqsWithMoves = new List<List<One>>();

            for (int i=0; i<count; i++)
            {
                List<One> temp = new List<One>();
                temp.RemoveRange(0, temp.Count);
                temp.Add(cheqs[i]);
                FindMovesForOne(cheqs[i], temp);
                cheqsWithMoves.Add(temp);
            }

            opera.PlayerMove(aiColor, playColor);

        }


    }
}
