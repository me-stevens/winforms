using System;

namespace Client
{
	public class UI
	{
		private Validator validator;

		public UI()
		{
			this.validator = new Validator();
	    }

        public int GetID(string[] arguments)
        {
            while (validator.IsInvalidLength(arguments))
            {
                Console.WriteLine("\navast, ye landlubber! to enter me ship, type: client.exe -i <ID>");
                arguments = Console.ReadLine().Split(' ');
            }

            string number = arguments[2];
            while (validator.IsNotNumber(number))
            {
                Console.WriteLine("\nMe can't read '" + number + "', not a numbarrr! Retype number");
                number = Console.ReadLine();
            }

            int id = ToInt(number);
            while (validator.IsNegative(id))
            {
                Console.WriteLine("\nMe can't read negative " + id + ". Retype positive number");
                id = ToInt(Console.ReadLine());
            }

            return id;
        }

        public string ReadCommand()
        {
            Console.WriteLine("\nAhoy matey! choose yer rum:");
            Console.Write("S, H or L?: ");
            string command = Console.ReadLine();

            while (validator.IsInvalidCommand(command))
            {
                Console.Write("Avast, ye landlubber! Please choose S, H or L?: ");
                command = Console.ReadLine();
            }

            command = command.ToUpper();
            Console.WriteLine("Arrr! Here's what ye chose: " + command + "\n");
            return command;
        }

        public void PrintPirateMessage()
        {
            Console.WriteLine("Swim with the fishes, ye scurvy dog, mwahuahuahaha...");
        }

        public void PrintFilename(string filename)
        {
            Console.WriteLine("Ship ahoy! It's called '" + filename + "'.");
        }

        public void PrintFileCreationError(Exception exception)
        {
            Console.WriteLine("Thar be nothin' in the sea! Unable to create ship");
            Console.WriteLine(exception.ToString());
        }

        public bool PromptToContinue()
        {
            string answer;

            do
            {
                Console.Write("\nWrite 'aye' to drink moar rum or 'nope' to leave me ship: ");
                answer = Console.ReadLine().ToLower();
            } while (validator.IsInvalidAnswer(answer));

            return validator.IsPositiveAnswer(answer);
        }

        private int ToInt(string number)
        {
            return Convert.ToInt32(number);
        }
    }
}
