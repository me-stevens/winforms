/***************************************
 * Simple CLI Client-Server Manager
 ***************************************/
using System;

namespace Client
{
    class Runner
    {
        public static string DIRECTORY = @"..\..\..\..\queue";

        static void Main(string[] args)
        {
            UI ui = new UI();
            FileCreator fileCreator = new FileCreator(DIRECTORY, ui);

            int id = ui.GetID(args);
            string command;

            do
            {
                command = ui.ReadCommand();

                if (PirateCondition(id, command))
                    ui.PrintPirateMessage();

                else
                    fileCreator.Create(id, command);

            } while (ui.PromptToContinue());
        }

        public static bool PirateCondition(int id, string command)
        {
            return command == "L" && id != 1;
        }
    }
}
