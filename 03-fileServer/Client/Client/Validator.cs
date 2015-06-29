using System;
using System.Linq;

namespace Client
{
    public class Validator
    {
		public const int MINIMUM_LENGTH = 3;
        public const string POSITIVE_ANSWER = "aye";
        public static readonly string[] VALID_ANSWERS = { POSITIVE_ANSWER, "nope" };

        public bool IsInvalidLength(string[] arguments)
		{
			return arguments.Length < MINIMUM_LENGTH;
		}

        public bool IsNotNumber(string number)
        {
            int irrelevant;
            return !int.TryParse(number, out irrelevant);
        }

        public bool IsNegative(int id)
        {
            return id < 0;
        }

        public bool IsInvalidCommand(string command)
        {
            return Differ(command, "S") && Differ(command, "H") && Differ(command, "L");
        }

        public bool IsInvalidAnswer(string answer)
        {
            return !VALID_ANSWERS.Contains(answer);
        }

        public bool IsPositiveAnswer(string answer)
        {
            return answer == POSITIVE_ANSWER;
        }

        private bool Differ(string command, string letter)
        {
            return !(bool)(command?.Equals(letter, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
