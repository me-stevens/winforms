using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

using Othello;

namespace Tests
{
    [TestClass()]
    public class TestBoard
    {
        [TestMethod()]
        public void TestIsBlackCellDetectsBlackCell()
        {
            Assert.IsTrue(DefaultBoard().IsBlackCell(3, 4));
        }

        [TestMethod()]
        public void TestIsBlackCellDetectsNonBlackCell()
        {
            Assert.IsFalse(DefaultBoard().IsBlackCell(3, 3));
        }

        [TestMethod()]
        public void TestIsWhiteCellDetectsWhiteCell()
        {
            Assert.IsTrue(DefaultBoard().IsWhiteCell(3, 3));
        }

        [TestMethod()]
        public void TestIsWhiteCellDetectsNonWhiteCell()
        {
            Assert.IsFalse(DefaultBoard().IsWhiteCell(3, 4));
        }

        [TestMethod()]
        public void TestIsEmptyCellDetectsEmptyCell()
        {
            Assert.IsTrue(DefaultBoard().IsEmptyCell(0, 0));
        }

        [TestMethod()]
        public void TestIsEmptyCellDetectsNonEmptyeCell()
        {
            Assert.IsFalse(DefaultBoard().IsEmptyCell(3, 4));
        }

        [TestMethod()]
        public void TestIsFullDetectsFullBoard()
        {
            Assert.IsTrue(FullBoard().IsFull());
        }

        [TestMethod()]
        public void TestIsFullDetectsNoFullBoard()
        {
            Assert.IsFalse(DefaultBoard().IsFull());
        }

        [TestMethod()]
        public void TestIsOffLimitsDetectsBelowLimitsInRows()
        {
            Assert.IsTrue(DefaultBoard().IsOffLimits(-5, 0));
        }

        [TestMethod()]
        public void TestIsOffLimitsDetectsBeyondLimitsInRows()
        {
            Assert.IsTrue(DefaultBoard().IsOffLimits(Board.ROWS, 0));
        }

        [TestMethod()]
        public void TestIsOffLimitsDetectsBelowLimitsInCols()
        {
            Assert.IsTrue(DefaultBoard().IsOffLimits(0, -5));
        }

        [TestMethod()]
        public void TestIsOffLimitsDetectsBeyondLimitsInCols()
        {
            Assert.IsTrue(DefaultBoard().IsOffLimits(0, Board.COLS));
        }

        [TestMethod()]
        public void TestIsOffLimitsDetectsInLimits()
        {
            Assert.IsFalse(DefaultBoard().IsOffLimits(0, 0));
        }

        [TestMethod()]
        public void TestIndex2PositionConvertsIndicesToLetterNumber()
        {
            Assert.AreEqual(DefaultBoard().Index2Position(1, 3), "D2");
        }

        [TestMethod()]
        public void TestGeGetFormatedAvailablePositionsGetsArrayOfMoves()
        {
            HashSet<int[]> moves = new HashSet<int[]>();
            moves.Add(new int[] { 0, 0 });
            moves.Add(new int[] { 1, 0 });

            string[] formatted = DefaultBoard().GetFormatedAvailablePositions(moves);
            CollectionAssert.AreEqual(formatted, new string[] { "A1", "A2" });
        }

        public Board DefaultBoard()
        {
            Board board = new Board(new UI());
            board.opening(0);
            return board;
        }

        public Board FullBoard()
        {
            Board board = new Board(new UI());

            for (int i = 0; i < Board.ROWS; i++)
            {
                for (int j = 0; j < Board.COLS; j++)
                    board.board[i, j] = Cell.BLACK;
            }

            return board;
        }
    }
}
