using System;
using System.Collections.Generic;

namespace Othello
{
    public class Board
    {
        public const int ROWS = 8;
        public const int COLS = 8;
        public static string[] LETTERS = { "A", "B", "C", "D", "E", "F", "G", "H" };

        public int[,] board;
        private UI ui;

        public Board(UI ui)
        {
            this.board = new int[ROWS, COLS];
            this.ui = ui;
            InitializeBoard();
        }

        public void opening(int i)
        {
            // Typical opening:
            if (i == 0)
            {
                board[3, 3] = Cell.WHITE;
                board[3, 4] = Cell.BLACK;
                board[4, 3] = Cell.BLACK;
                board[4, 4] = Cell.WHITE;
            }
            // Other openings go here
        }

        public bool IsBlackCell(int i, int j)
        {
            return board[i, j] == Cell.BLACK;
        }

        public bool IsWhiteCell(int i, int j)
        {
            return board[i, j] == Cell.WHITE;
        }

        public bool IsEmptyCell(int i, int j)
        {
            return board[i, j] == Cell.EMPTY;
        }

        public bool IsFull()
        {
            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    if (board[i, j] == Cell.EMPTY)
                        return false;
                }
            }

            return true;
        }

        public bool IsOffLimits(int i, int j)
        {
            return !(i >= 0 && i < ROWS && j >= 0 && j < COLS);
        }

        public string Index2Position(int i, int j)
        {
            i++;
            return LETTERS[j] + i;
        }

        public string[] GetFormatedAvailablePositions(HashSet<int[]> moves)
        {
            List<string> available = new List<string>();

            foreach (int[] move in moves)
                available.Add(Index2Position(move[0], move[1]));

            return available.ToArray();
        }

        public HashSet<int[]> calculateMoves(int player)
        {
            HashSet<int[]> positions = new HashSet<int[]>();

            for (int i = 0; i < ROWS; i++)
            {
                for (int j = 0; j < COLS; j++)
                {
                    // Search for a chip of opposite color
                    if (board[i, j] == Cell.OppositePlayer(player))
                    {
                        positions.UnionWith(AvailablePositions(i, j, player));
                    }
                }
            }

            return positions;
        }

        public void placeChip(int player, int i, int j)
        {
            // Place disc in square
            int oppositePlayer = Cell.OppositePlayer(player);
            board[i, j] = player;

            // Start the flip party:
            for (int m = i - 1; m <= i + 1; m++)
            {
                for (int n = j - 1; n <= j + 1; n++)
                {
                    // Search for a chip of the opposite color
                    if (!IsOffLimits(m, n) && board[m, n] == oppositePlayer)
                    {
                        int[,] flipThese = new int[ROWS, COLS];

                        // See if there's a chip of the player's color
                        int deltam = m - i;
                        int deltan = n - j;
                        Boolean exit = false;
                        Boolean found = false;

                        // Advance in (m, n) direction
                        int k = m + deltam;
                        int l = n + deltan;

                        while (!IsOffLimits(k, l) && !exit)
                        {
                            // If square is empty, there's no reason to continue searching
                            if (board[k, l] == -1)
                                exit = true;

                            // If same color as player, exit and flip opposites
                            else if (board[k, l] == board[i, j])
                            {
                                found = true;
                                exit = true;
                            }

                            // Else, chip is opposite color, save position andcontinue
                            else
                            {
                                exit = false;
                                flipThese[k, l] = 1;
                            }

                            k += deltam;
                            l += deltan;
                        }

                        // If the exit is because I found a player's chip
                        if (found)
                        {
                            // Add the first we found
                            flipThese[m, n] = 1;
                            for (int u = 0; u < flipThese.GetLength(0); u++)
                                for (int v = 0; v < flipThese.GetLength(1); v++)

                                    // Change the color of the chips in the stored positions to the player's color
                                    if (flipThese[u, v] == 1)
                                        board[u, v] = board[i, j];
                        } // IF FOUND
                    } // IF
                } // FOR
            } // FOR
        }

        public void andTheWinnerIs()
        {
            int blacks = 0;
            int whites = 0;

            foreach (int cell in board)
            {
                if (cell == Cell.BLACK)
                    blacks++;
                else if (cell == Cell.WHITE)
                    whites++;
            }

            ui.printSummary(blacks, whites);
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < ROWS; i++)
                for (int j = 0; j < COLS; j++)
                    board[i, j] = Cell.EMPTY;
        }

        private HashSet<int[]> AvailablePositions(int i, int j, int player)
        {
            HashSet<int[]> positions = new HashSet<int[]>();

            for (int m = i - 1; m <= i + 1; m++)
            {
                for (int n = j - 1; n <= j + 1; n++)
                {
                    if (IsOffLimits(m, n) || !IsEmptyCell(m, n))
                        continue;

                    // Set increments to advance in the right direction
                    // Gives -1, 0 or 1 automatically
                    int deltam = i - m;
                    int deltan = j - n;

                    // Start search for a chip of the same color as condition to place chip
                    int k = i + deltam;
                    int l = j + deltan;

                    Boolean exit = false;

                    while (!IsOffLimits(k, l) && !exit)
                    {
                        // If square is empty, there's no reason to continue searching
                        if (IsEmptyCell(k, l))
                            exit = true;

                        // If same color as player, square is a possible placement for the chip
                        else if (board[k, l] == player)
                        {
                            positions.Add(new int[] { m, n });
                            exit = true;
                        }

                        // Else, chip is opposite color, continue
                        else
                            exit = false;

                        k += deltam;
                        l += deltan;
                    }
                }
            }

            return positions;
        }
    }
}
