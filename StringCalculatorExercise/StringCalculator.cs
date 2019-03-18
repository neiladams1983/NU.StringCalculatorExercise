﻿using System;
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
                        string deliminator;

                        Match deliminatorMatch = Regex.Match(match.Groups[1].ToString(), "[[](.*?)[]]");

                        if (deliminatorMatch.Success)
                        {
                            deliminator = deliminatorMatch.Groups[1].ToString();
                        }
                        else
                        {
                            deliminator = match.Groups[1].ToString();
                        }

                        string numberString = match.Groups[2].ToString();

                        splitInput = Array.ConvertAll(numberString.Split(deliminator), int.Parse);

                    }
                    else
                    {
                        //Split input string into an array of int
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