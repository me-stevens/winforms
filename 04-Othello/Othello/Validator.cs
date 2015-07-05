using System;
using System.Collections.Generic;
using System.Linq;

namespace Othello
{
    public class Validator
    {
        public const string WRONG_FORMAT = "Type column letter and row number, for example: A1";
        public const string OFF_LIMITS = "Introduce a valid row number, between 1 and ";
        public const string WRONG_POSITION = "You can not place your chip there";

        private const int POSITION_LENGTH = 2;

        public string Error { get { return error; } }
        private string error = "";

        public int[] Validate(string position, Board board, HashSet<int[]> moves)
        {
            if (HasNotRightLength(position) || HasNotLetter(position) || HasNotNumber(position))
            {
                this.error = WRONG_FORMAT;
                return null;
            }

            int row = Row(position);

            if (board.IsOffLimits(row, 0))
            {
                this.error = OFF_LIMITS + Board.ROWS;
                return null;
            }

            int col = Col(position);

            if (IsWrongPosition(row, col, moves))
            {
                this.error = WRONG_POSITION;
                return null;
            }

            return new int[] { row, col };
        }

        private bool HasNotRightLength(string position)
        {
            return position.Length != POSITION_LENGTH;
        }

        private bool HasNotLetter(string position)
        {
            return Col(position) == -1;
        }

        private bool HasNotNumber(string position)
        {
            int irrelevant = 0;

            return !int.TryParse(Number(position), out irrelevant);
        }

        private bool IsWrongPosition(int row, int col, HashSet<int[]> moves)
        {
            foreach (int[] move in moves)
            {
                if (move[0] == row && move[1] == col)
                {
                    return false;
                }
            }

            return true;
        }

        private int Row(string position)
        {
            return Convert.ToInt32(Number(position)) - 1;
        }

        private int Col(string position)
        {
            return Array.IndexOf(Board.LETTERS, Letter(position));
        }

        private string Letter(string position)
        {
            return position.Substring(0, 1).ToUpper();
        }

        private string Number(string position)
        {
            return position.Substring(1, 1);
        }
    }
}
