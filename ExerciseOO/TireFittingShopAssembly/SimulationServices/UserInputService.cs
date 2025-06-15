using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TireFittingShopAssembly.SimulationServices
{
    /// <summary>
    /// Service for validated user input.
    /// Ensures only positive integers are accepted for simulation parameters.
    /// </summary>
    public class UserInputService
    {
        /// <summary>
        /// Prompts the user until a valid positive integer is entered.
        /// </summary>
        /// <param name="prompt">The prompt message to display.</param>
        /// <returns>A positive integer entered by the user.</returns>
        public int GetPositiveInt(string prompt)
        {
            do
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out int value) && value > 0)
                    return value;

                Console.WriteLine("Please enter a valid positive integer.");
            } while (true);
        }
    }
}
