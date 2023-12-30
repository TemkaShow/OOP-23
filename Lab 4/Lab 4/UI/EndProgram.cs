using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab_4.UI.Base;

namespace Lab_4.UI
{
    internal class EndProgram : IUserInterface
    {
        public void Action()
        {
            Console.WriteLine("Завершення програми... Дякую за гру!");
            Environment.Exit(0);
        }
        public void DisplayCommandInfo()
        {
            Console.WriteLine("Завершення програми");
        }
    }

}
