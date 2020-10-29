using System;
using System.Collections.Generic;
using System.Text;

namespace HangmanGame.entities
{
    public class CountryDetails
    {
        public string Name { get; set; }
        public string Capital { get; set; }


        public override string ToString() => $"{ Name }, { Capital }";
    }
}
