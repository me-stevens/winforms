using System;
using System.Collections.Generic;

namespace Othello
{
    public class UI
    {
        private const string AVAILABLE = " ?";
        private const string EMPTY = "  ";
        private const string BLACK = " X";
        private const string WHITE = " O";

        public void PrintHeader()
        {
            Console.WriteLine("\n------------------------------------");
            Console.WriteLine("         WELCOME TO REVERSI");
            Console.WriteLine("------------------------------------");

            Console.WriteLine("\n --- PRESS ENTER TO START ---");
            Console.ReadLine();
        }

        public void PrintUpdatedBoard(Board board)
        {
            Console.WriteLine("Updated board:");
            PrintBoard(board);
        }

        public void PrintBoard(Board board)
        {
            HashSet<int[]> moves = new HashSet<int[]>();
            PrintBoard(board, moves);
        }

        public void PrintBoard(Board board, HashSet<int[]> moves)
        {
            int cols = 0;
            int rows = 1;

            Console.Write("\n\n\t  {0}\n\t" + rows, String.Join(" ", Board.LETTERS));

            for (int i = 0; i < Board.ROWS; i++)
            {
                for (int j = 0; j < Board.COLS; j++)
                {
                    if (board.IsEmptyCell(i, j))
                    {
                        if (Contains(i, j, moves))
                            Console.Write(AVAILABLE);
                        else
                            Console.Write(EMPTY);
                    }

                    if (board.IsBlackCell(i, j))
                        Console.Write(BLACK);

                    if (board.IsWhiteCell(i, j))
                        Console.Write(WHITE);

                    cols++;
                    if (cols % Board.COLS == 0)
                    {
                        rows++;
                        if (rows <= Board.ROWS)
                            Console.Write("\n\t" + rows);
                    }
                }
            }
            Console.WriteLine("\n");
        }

        public void PrintAvailablePositions(string[] available)
        {
            Console.Write("\nAvailable squares: ");
            Console.Write(String.Join(" ", available));
        }

        public int[] GetIndices(Board board, HashSet<int[]> moves)
        {
            Validator validator = new Validator();
            int[] indices;

            do
            {
                Console.WriteLine(validator.Error);
                Console.Write("Place your chip in square: ");
                indices = validator.Validate(Console.ReadLine(), board, moves);
            } while (indices == null);

            return indices;
        }

        public void PrintTurn(int turn)
        {
            Console.WriteLine(" --- Turn " + turn + " ---------------");
        }

        public void PrintComputerTurn()
        {
            Console.Write("My turn now");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(500);
            }
            Console.WriteLine();
        }

        public void PrintNoPositionsForPlayer()
        {
            Console.WriteLine("No positions available, you loose 1 turn");
        }

        public void PrintNoPositionsForComputer()
        {
            Console.WriteLine("No positions available, I loose 1 turn");
        }

        public void PrintNoPositionsForAnyPlayer()
        {
            Console.WriteLine("No more positions for any of the players. Exiting game");
        }

        public void PromptToContinue()
        {
            Console.WriteLine("\n --- PRESS ENTER TO CONTINUE ---");
            Console.ReadLine();
        }

        public void printSummary(int blacks, int whites)
        {
            if (blacks > whites)
                Console.WriteLine("--- THE BLACKS WIN! ---");
            else
                Console.WriteLine("--- THE WHITES WIN! ---");

            Console.ReadLine();
        }

        private bool Contains(int i, int j, HashSet<int[]> moves)
        {
            foreach (int[] move in moves)
            {
                if (move[0] == i && move[1] == j)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
