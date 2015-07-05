using System;
using System.Collections.Generic;
using System.Linq;

namespace Othello
{
    internal class Game
    {
        private Board board;
        private UI ui;

        public Game(Board board, UI ui)
        {
            this.board = board;
            this.ui = ui;
        }

        public int newTurn()
        {
            int player = Cell.BLACK;

            if (board.IsFull())
                ui.PrintNoPositionsForPlayer();
            else
                PlayTurn(player, HumanTurn);

            player = Cell.WHITE;
            ui.PrintComputerTurn();

            if (board.IsFull())
                ui.PrintNoPositionsForComputer();
            else
                PlayTurn(player, ComputerTurn);

            ui.PromptToContinue();

            if (board.IsFull())
            {
                ui.PrintNoPositionsForAnyPlayer();
                return -1;
            }

            return 0;
        }

        private void PlayTurn(int player, Func<HashSet<int[]>, int[]> turnMethod)
        {
            HashSet<int[]> moves = board.calculateMoves(player);
            int[] position = turnMethod(moves);
            board.placeChip(player, position[0], position[1]);
            ui.PrintUpdatedBoard(board);
        }

        private int[] HumanTurn(HashSet<int[]> moves)
        {
            ui.PrintAvailablePositions(board.GetFormatedAvailablePositions(moves));
            ui.PrintBoard(board, moves);

            return ui.GetIndices(board, moves);
        }

        private int[] ComputerTurn(HashSet<int[]> moves)
        {
            Random random = new Random();
            return moves.ElementAt(random.Next(moves.Count));
        }
    }
}
