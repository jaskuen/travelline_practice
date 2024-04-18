using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fighters.Functions
{
    internal class Functions
    {
        public static int ConsoleRead()
        {
            int result;
            while (!Int32.TryParse(Console.ReadLine(), out result))
            {
                Console.WriteLine("Not an int number, try again");
            }
            return result;
        }
    }
}
