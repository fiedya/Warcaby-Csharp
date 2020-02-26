using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace warcaby
{
    class Operating
    {
        public Board brd;
        public OperatingBoard operabrd;
        public int playCheq, aiCheq;
        public int turn;
        public int end; //-1 dla ai, 0 ogólnie i 1 dla gracza
        public Operating(Board brd, OperatingBoard operabrd, int playCheq, int aiCheq, int turn)
        {
            this.turn = turn;
            this.brd = brd;
            this.operabrd = operabrd;
            this.playCheq = playCheq;
            this.aiCheq = aiCheq;
            end = 0;
        }

        public void BothMoves(ConsoleColor col, ConsoleColor enemy, Algorytm alg)
        {
            if (turn % 2 == 1)
            {
                //gracz
                PlayerMove(col, enemy);
                if (aiCheq == 0) end = 1;
            }
            else if (turn % 2 == 0)
            {
                //komp
                if (playCheq == 0) end = -1;
                alg.MoveAi();
            }


        }



        public void PlayerMove(ConsoleColor col, ConsoleColor enemy)
        {
            Console.BackgroundColor = col;
            Console.Write("literaNumer literaNumer: ");
            Console.ResetColor();

            string inp = Console.ReadLine(); //gracz wpisuje LiteraCyfra;
            char[] input = inp.ToCharArray();

           

            int oy =(int)input[0]-97; //pion
            int ox = (int)input[1]-49; //poziom


            int ny = (int)input[3]-97; //pion
            int nx = (int)input[4]-49; //poziom

            MoveTile(ox, oy, nx, ny, col, enemy);

        }

        public void MoveTile(int ox,int oy,int nx,int ny, ConsoleColor col, ConsoleColor enemy)
        {
            bool wannaKill = false;
            bool mayKill = false;
            if ((brd.board[ox, oy].value == "()" || brd.board[ox, oy].value == "[]") && brd.board[ox, oy].playerColor == col)
            {
                if(IsAvaible(ox, oy, nx, ny))
                {

                    if (Math.Abs(ox - nx) == 2 && Math.Abs(oy - ny) == 2) wannaKill = true;
                    else wannaKill = false;

                    if (wannaKill) 
                    {
                        mayKill = MayKill(ox, oy, nx, ny, enemy);
                        if (mayKill)
                        {
                            if (col == ConsoleColor.DarkMagenta)
                            {
                                aiCheq--;
                                brd.board[ox, oy].color = ConsoleColor.Yellow;
                                brd.board[ox, oy].playerColor = ConsoleColor.Black;
                                brd.board[nx, ny].color = ConsoleColor.Yellow;
                                brd.board[nx, ny].playerColor = col;
                                if (brd.board[ox, oy].value == "()")brd.board[nx, ny].value = "()";
                                else if (brd.board[ox, oy].value == "[]") brd.board[nx, ny].value = "[]";
                                brd.board[ox, oy].value = "  ";
                            }
                            else if (col == ConsoleColor.DarkBlue)
                            {
                                playCheq--;
                                brd.board[ox, oy].color = ConsoleColor.Yellow;
                                brd.board[ox, oy].playerColor = ConsoleColor.Black;
                                brd.board[nx, ny].color = ConsoleColor.Yellow;
                                brd.board[nx, ny].playerColor = col;
                                if (brd.board[ox, oy].value == "()") brd.board[nx, ny].value = "()";
                                else if (brd.board[ox, oy].value == "[]") brd.board[nx, ny].value = "[]";
                                brd.board[ox, oy].value = "  ";
                            }

                        }
                        
                    }
                    else if(Math.Abs(ox - nx) == 1 && Math.Abs(oy - ny) == 1)
                    {
                        brd.board[ox, oy].color = ConsoleColor.Yellow;
                        brd.board[ox, oy].playerColor = ConsoleColor.Black;
                        brd.board[nx, ny].color = ConsoleColor.Yellow;
                        brd.board[nx, ny].playerColor = col;
                        if (brd.board[ox, oy].value == "()") brd.board[nx, ny].value = "()";
                        else if (brd.board[ox, oy].value == "[]") brd.board[nx, ny].value = "[]";
                        brd.board[ox, oy].value = "  ";
                        turn++;
                    }


                }
                else
                {
                    Console.WriteLine("Ruch niemozliwy (chcesz wyjsc poza plansze czy wejsc na innego gracza?!)");
                }
            }

        }

        public bool IsAvaible(int ox, int oy, int nx, int ny)
        {
            if (ny > 7 || ny < 0 || nx > 7 || nx < 0) return false;
            if (brd.board[nx, ny].value == "()" || brd.board[nx, ny].value == "[]") return false;
            if (brd.board[nx, ny].color != ConsoleColor.Yellow) return false;
            if (Math.Abs(ox - nx) > 2 || Math.Abs(oy - ny) > 2) return false;
            return true;
        }

        public bool IsPlayerInNeigh(int nx, int ny,  ConsoleColor playColor)
        {
            if(ny > 7 || ny < 0 || nx > 7 || nx < 0) return false;
            if ((brd.board[nx, ny].value == "()" || brd.board[nx, ny].value == "[]") && brd.board[nx, ny].playerColor == playColor) return true;
            else return false;
        }
        public bool isSecFree(int x, int y)
        {
            if (y > 7 || y < 0 || x > 7 || x < 0) return false;
            if ((brd.board[x, y].value == "()" || brd.board[x, y].value == "[]") && brd.board[x, y].color ==ConsoleColor.Yellow) return true;
            else return false;
        }


        public bool MayKill(int ox, int oy, int nx, int ny, ConsoleColor enemy)
        {

                if ((brd.board[(ox + nx) / 2, (oy + ny) / 2].value == "()" || brd.board[(ox + nx) / 2, (oy + ny) / 2].value == "[]")
                    && brd.board[(ox + nx) / 2, (oy + ny) / 2].playerColor == enemy)//pomiędzy jest enemy
                   {
                        brd.board[(ox + nx) / 2, (oy + ny) / 2].playerColor = ConsoleColor.Black;
                        brd.board[(ox + nx) / 2, (oy + ny) / 2].color = ConsoleColor.Yellow;
                brd.board[(ox + nx) / 2, (oy + ny) / 2].value = "  ";
                        return true;
                    }
                else
                    return false;

        }

    }
}
