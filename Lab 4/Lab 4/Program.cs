using System;
using System.Collections.Generic;
using System.Text;
using Lab_4.Database;
using Lab_4.Database.Service;
using Lab_4.TypeAccount;
using Lab_4.UI;
using Lab_4.UI.Base;

namespace Lab_4
{
    class Program
    {
        private List<IUserInterface> _commands;

        public Program(GameAccountService accountService, GameService gameService)
        {
            _commands = new List<IUserInterface>
            {
                new StartGame(accountService, gameService),
                new ShowAccount(accountService),
                new AddAccounts(accountService),
                new ShowGame(accountService),
                new ShowSpecificAccount(accountService),
                new EndProgram()
            };
        }

        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var context = new DbContext();
            var accountService = new GameAccountService(context);
            var gameService = new GameService(context);
            Program program = new Program(accountService, gameService);
            program.Start();
        }

        public void Start()
        {
            while (true)
            {
                DisplayCommands();
                int choice = GetCommandChoice();
                ExecuteCommand(choice);
            }
        }

        private void DisplayCommands()
        {
            Console.WriteLine("\nДоступні команди:");

            for (int i = 0; i < _commands.Count; i++)
            {
                Console.Write($"{i + 1}. ");
                _commands[i].DisplayCommandInfo();
            }

            Console.WriteLine(); 
        }

        private int GetCommandChoice()
        {
            Console.Write("\nВведіть номер команди яку хочете обрати: ");
            return int.Parse(Console.ReadLine()) - 1;
        }

        private void ExecuteCommand(int choice)
        {
            if (choice >= 0 && choice < _commands.Count)
            {
                _commands[choice].Action();
            }
            else
            {
                Console.WriteLine("Невірне значенння спробуйте знову");
            }
        }
    }
}
