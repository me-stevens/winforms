using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Othello
{
    public class Cell
    {
        public const int EMPTY = -1;
        public const int BLACK = 0;
        public const int WHITE = 1;

        public static int OppositePlayer(int cell)
        {
            return cell == Cell.BLACK ? Cell.WHITE : Cell.BLACK;
        }
    }
}
