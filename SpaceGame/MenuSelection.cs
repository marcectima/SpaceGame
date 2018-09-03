using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame
{
    class MenuSelection
    {
        public MenuSelection(string inputString)
        {
            // declaring an integer to be used as an output type-comparison for TryParse().
            int integer;
            // attempts to convert the inputted string into an interger. 
            // If the outcome is of integer type assigns TRUE value to inNumeric, if not assigns FALSE.
            bool isNumeric = int.TryParse(inputString, out integer);
            try
            {
                if (isNumeric)
                {
                    selection = int.Parse(inputString);
                }
                else
                {
                    throw new Exception("\nInvalid Entry");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private int selection;

        public int GetSelection() => selection;

    }
}
