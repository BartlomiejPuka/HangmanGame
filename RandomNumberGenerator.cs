using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class RandomNumberGenerator
    {
        private static readonly Random _random = new Random();

        public static int getRandomNum(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}
