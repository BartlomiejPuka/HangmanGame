using HangmanGame.mapper;
using System;
using System.Collections.Generic;

namespace HangmanGame
{
    class Program
    {
        static int healthPoints = 6;

        static bool IsWord(string secretWord, List<string> letterGuessed)
        {
            bool word = false;
            for (int i = 0; i < secretWord.Length; i++)
            {
                string c = Convert.ToString(secretWord[i]);
                if (letterGuessed.Contains(c))
                {
                    word = true;
                }
                else
                {
                    return word = false;
                }
            }
            return word;
        }
        static string Isletter(string secretWord, List<string> letterGuessed)
        {
            string correctletters = "";
            for (int i = 0; i < secretWord.Length; i++)
            {
                string c = Convert.ToString(secretWord[i]);
                if (letterGuessed.Contains(c))
                {
                    correctletters += c;
                }
                else
                {
                    correctletters += "_ ";
                }
            }
            return correctletters;
        }

        static void GetAlphabet(string letters)
        {
            List<string> alphabet = new List<string>();
            for (int i = 1; i <= 26; i++)
            {
                char alpha = Convert.ToChar(i + 96);
                alphabet.Add(Convert.ToString(alpha));
            }
            int num = 49;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Letters Left are :");
            for (int i = 0; i < num; i++)
            {
                if (letters.Contains(letters))
                {
                    alphabet.Remove(letters);
                    num -= 1;
                }
                Console.Write("[" + alphabet[i] + "] ");
            }
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            List<string> letterGuessed = new List<string>();
            var hangmanPics = HangmanPics.HangmanPicsDict;
            
            var list = SourceFileReader.GetListOfCountryDetails("../../../countries_and_capitals.txt");
            
            while (true)
            {
                int tries = 0;
                var t0 = DateTime.Now;
                int i = RandomNumberGenerator.getRandomNum(0, list.Count);
                var secretCountry = list[i];
                Console.WriteLine("Guess the capital ");
                Console.WriteLine("Guess for a {0} Letter Capital Word ", secretCountry.Capital.Length);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("You Have {0} Health points", healthPoints);
                Console.WriteLine(hangmanPics[healthPoints]);

                while (healthPoints > 0)
                {
                    string input = Console.ReadLine();
                    tries++;
                    if (input.ToLower() == secretCountry.Capital.ToLower())
                    {
                        Console.WriteLine("Congratulations, that was secret word!");
                        break;
                    }

                    if (letterGuessed.Contains(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You Entered Letter [{0}] already", input);
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.WriteLine("Try a Different Word");
                        GetAlphabet(input);
                        continue;
                    }
                    letterGuessed.Add(input);
                    if (IsWord(secretCountry.Capital, letterGuessed))
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(secretCountry.Capital);
                        Console.WriteLine("Congratulations");
                        Console.WriteLine($"The capital of { secretCountry.Name }.");
                        break;
                    }
                    else if (secretCountry.Capital.Contains(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Nice Entry");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        string letters = Isletter(secretCountry.Capital, letterGuessed);
                        Console.Write(letters);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Letter Not in My Word");
                        healthPoints--;
                        Console.WriteLine(hangmanPics[healthPoints]);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("You Have {0} Live", healthPoints);
                    }
                    Console.WriteLine();
                    if (healthPoints == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Game Over \nMy Secret Word is [ {0} ]", secretCountry.Capital);
                        Console.WriteLine($"The capital of { secretCountry.Name }.");
                        break;
                    }
                }
                var td = DateTime.Now;
                var measuredTime = td.Subtract(t0);
                Console.WriteLine($"This round took {measuredTime.ToString("mm")} minutes and {measuredTime.ToString("ss")} seconds.");


                Console.WriteLine("Do you want to play again? [Y/N]");
                string option = Console.ReadLine();
                if (option == "Y" || option == "y")
                {
                    healthPoints = 6;
                    letterGuessed.Clear();
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
