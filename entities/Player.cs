using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame
{
    public class Player
    {
        public string Name;
        public DateTime Date;
        public int Minutes;
        public int GuessingTries;
        public string GuessWord;

        public override string ToString() => $"{ Name } | { Date.ToString("dd.MM.YYYY HH:MM") } | { Minutes } | { GuessingTries } | { GuessWord }";
    }
}
