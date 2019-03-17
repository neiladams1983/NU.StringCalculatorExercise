using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringCalculatorExercise
{
    public class StringCalculator
    {
        public StringCalculator()
        {
        }

        public int Add(string input)
        {

            if (String.IsNullOrEmpty(input))
            {
                //Return 0 if the empty string is inputted
                return 0;
            }
            else
            {
                try
                {
                    //Split input string into an array of int
                    int[] splitInput = Array.ConvertAll(input.Split(','), int.Parse);

                    //Only allow the input to be 0,1,2 numbers long
                    if (splitInput.Length > 2)
                    {
                        throw new ApplicationException("Method can handle 0,1 or 2 numbers as input");
                    }
                    return splitInput.Sum();
                }
                catch (ApplicationException)
                {
                    throw;
                }
            }
        }
    }
}
