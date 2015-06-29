using Microsoft.VisualStudio.TestTools.UnitTesting;

using Client;

namespace Tests
{
    [TestClass()]
    public class TestValidator
    {
        [TestMethod()]
        public void TestIsInvalidLengthIfLowerThanMinimum()
        {
            string[] arguments = { "foo", "bar" };
            Assert.IsTrue((new Validator()).IsInvalidLength(arguments));
        }

        [TestMethod()]
        public void TestIsNotInvalidLengthIfMinimumLength()
        {
            string[] arguments = { "foo", "bar", "qux" };
            Assert.IsFalse((new Validator()).IsInvalidLength(arguments));
        }

        [TestMethod()]
        public void TestIsNotNumberIfNotParseable()
        {
            Assert.IsTrue((new Validator()).IsNotNumber("not a number"));
        }

        [TestMethod()]
        public void TestIsNumberIfParseable()
        {
            Assert.IsFalse((new Validator()).IsNotNumber("123"));
        }

        [TestMethod()]
        public void TestIsNegativeIfLowerThanZero()
        {
            Assert.IsTrue((new Validator()).IsNegative(-1));
        }

        [TestMethod()]
        public void TestIsNotNegativeIfZeroOrHigher()
        {
            Assert.IsFalse((new Validator()).IsNegative(0));
        }

        [TestMethod()]
        public void TestIsInvalidCommandIfIllegalValue()
        {
            Assert.IsTrue((new Validator()).IsInvalidCommand("Invalid"));
        }

        [TestMethod()]
        public void TestIsNotInvalidCommandIfLegalValue()
        {
            Assert.IsFalse((new Validator()).IsInvalidCommand("S"));
            Assert.IsFalse((new Validator()).IsInvalidCommand("H"));
            Assert.IsFalse((new Validator()).IsInvalidCommand("L"));
        }

        [TestMethod()]
        public void TestIsInvalidAnswerIfNotInPermittedAnswers()
        {
            Assert.IsTrue((new Validator()).IsInvalidAnswer("Invalid"));
        }

        [TestMethod()]
        public void TestIsNotInvalidAnswerIfPermitted()
        {
            Assert.IsFalse((new Validator()).IsInvalidAnswer(Validator.VALID_ANSWERS[0]));
            Assert.IsFalse((new Validator()).IsInvalidAnswer(Validator.VALID_ANSWERS[1]));
        }

        [TestMethod()]
        public void TestIsPositiveAnswerIfValidPositive()
        {
            Assert.IsTrue((new Validator()).IsPositiveAnswer(Validator.VALID_ANSWERS[0]));
        }

        [TestMethod()]
        public void TestIsNotPositiveAnswerIfNotValidPositive()
        {
            Assert.IsFalse((new Validator()).IsPositiveAnswer("anything else"));
        }
    }
}
