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
                        string numberString = match.Groups[2].ToString();

                        //Regex matching a pattern of- [delim].  
                        MatchCollection deliminatorMatch = Regex.Matches(match.Groups[1].ToString(), "[[](.*?)[]]+");

                        if (deliminatorMatch.Count == 1)
                        {
                            //Only one deliminator is included in the input string
                            //As only one match then use the deliminator found by the regex
                            string deliminator = deliminatorMatch.First().Groups[1].ToString();
                            splitInput = Array.ConvertAll(numberString.Split(deliminator), int.Parse);
                        }
                        else if (deliminatorMatch.Count > 1)
                        {
                            //As there's more than one match then create an array.
                            //For each match in the Match Collection object add the deliminators found by the regex.
                            string[] matches = deliminatorMatch.Cast<Match>().Select(r => r.Groups[1].Value).ToArray();
                            splitInput = Array.ConvertAll(numberString.Split(matches, StringSplitOptions.None), int.Parse);
                        }
                        else
                        {
                            //Simple deliminator is provided without needing square brackets.  e.g  //;\n1;2
                            string deliminator = match.Groups[1].ToString();
                            splitInput = Array.ConvertAll(numberString.Split(deliminator), int.Parse);
                        }

                    }
                    else
                    {
                        //Split input string into an array of int
                        //This is the default case where either a comma or newline can be used as a deliminator without being in the input string
                        splitInput = Array.ConvertAll(input.Split(new Char[] { ',', '\n' }), int.Parse);

                    }

                    //Check the split array for negative numbers
                    if (splitInput.Count(r => r < 0) > 0)
                    {
                        string errorString = "negatives are not allowed";
                        foreach (var i in splitInput.Where(r => r < 0))
                        {
                            errorString += $" {i}";
                        }
                        throw new ArgumentOutOfRangeException(errorString);
                    }

                    //Skip any number in the array that's bigger than 1000
                    return splitInput.Where(r => r <= 1000).Sum();


                }
                catch (ArgumentOutOfRangeException)
                {
                    throw;
                }
                catch
                {
                    throw new Exception("Input string is malformed");
                }

            }
        }
    }
}