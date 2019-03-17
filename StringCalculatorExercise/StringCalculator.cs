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
                    int[] splitInput = Array.ConvertAll(input.Split(new Char[] { ',', '\n' }), int.Parse);

                    return splitInput.Sum();

                }
                catch
                {
                    throw new Exception("Input string is malformed");
                }

            }
        }
    }
}
