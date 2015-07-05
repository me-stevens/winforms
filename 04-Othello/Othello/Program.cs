using System;

namespace Othello
{
    class Program
    {
        static void Main(string[] args)
        {
            UI ui = new UI();
            Board board = new Board(ui);
            Game game = new Game(board, ui);

            board.opening(0);
            ui.PrintBoard(board);
            ui.PrintHeader();

            // 32 fixed turns to fill the board (64 / 2 players)
            int turn = 0;
            do
            {
                turn++;
                ui.PrintTurn(turn);
            } while (turn < 32 && game.newTurn() == 0);

            board.andTheWinnerIs();
        }
    }
}
