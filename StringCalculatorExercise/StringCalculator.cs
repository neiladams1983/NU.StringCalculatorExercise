using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                    // Regex matching a pattern of- //[delim]\n[numbers]
                    Match match = Regex.Match(input, "//(.+)\\n(.+)");
                    int[] splitInput;

                    if (match.Success)
                    {
                        string deliminator = match.Groups[1].ToString();
                        string numberString = match.Groups[2].ToString();

                        splitInput = Array.ConvertAll(numberString.Split(deliminator), int.Parse);

                    }
                    else
                    {
                        //Split input string into an array of int
                        splitInput = Array.ConvertAll(input.Split(new Char[] { ',', '\n' }), int.Parse);

                    }

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
