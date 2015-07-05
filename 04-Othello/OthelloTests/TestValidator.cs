using Microsoft.VisualStudio.TestTools.UnitTesting;
using Othello;
using System.Collections.Generic;

namespace Tests
{
    [TestClass()]
    public class TestValidator
    {
        public Validator validator = new Validator();
        public Board board = new Board(new UI());
        public HashSet<int[]> moves = new HashSet<int[]>();

        [TestMethod]
        public void TestValidateSuccedsWithValidPosition()
        {
            CollectionAssert.AreEqual(Validate("A2"), new int[] { 1, 0 });
        }

        [TestMethod]
        public void TestValidateFailsIfPositionTooLong()
        {
            Assert.AreEqual(Validate("B22"), null);
            Assert.AreEqual(validator.Error, Validator.WRONG_FORMAT);
        }

        [TestMethod]
        public void TestValidateFailsIfNoLetterPresent()
        {
            Assert.AreEqual(Validate("1A"), null);
            Assert.AreEqual(validator.Error, Validator.WRONG_FORMAT);
        }

        [TestMethod]
        public void TestValidateFailsIfNoNumberPresent()
        {
            Assert.AreEqual(Validate("CC"), null);
            Assert.AreEqual(validator.Error, Validator.WRONG_FORMAT);
        }

        [TestMethod]
        public void TestValidateFailsIfNumberOffLimitst()
        {
            Assert.AreEqual(Validate("D9"), null);
            Assert.IsTrue(validator.Error.Contains(Validator.OFF_LIMITS));
        }

        [TestMethod]
        public void TestValidateFailsIfWrongPosition()
        {
            Assert.AreEqual(Validate("B1"), null);
            Assert.AreEqual(validator.Error, Validator.WRONG_POSITION);
        }

        public int[] Validate(string position)
        {
            board.opening(0);
            moves.Add(new int[] { 0, 0 });
            moves.Add(new int[] { 1, 0 });
            return validator.Validate(position, board, moves);
        }
    }
}
