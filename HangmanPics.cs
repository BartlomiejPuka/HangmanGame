using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class HangmanPics
    {
        public static Dictionary<int, string> HangmanPicsDict = new Dictionary<int, string>()
        {
            {
                6,
@"+---+
  |   |
      |
      |
      |
      |
========="
            },
            {
                5,
@"+---+
  |   |
  O   |
      |
      |
      |
========="
            },
            {
                4,
@"+---+
  |   |
  O   |
  |   |
      |
      |
========="
            },
            {
                3,
@"+---+
  |   |
  O   |
 /|   |
      |
      |
========="
            },
            {
                2,
@"+---+
  |   |
  O   |
 /|\  |
      |
      |
========="
            },
            {
                1,
@"+---+
  |   |
  O   |
 /|\  |
 /    |
      |
========="
            },
            {
                0,
@"+---+
  |   |
  O   |
 /|\  |
 / \  |
      |
========="
            }
        };
    }
}
