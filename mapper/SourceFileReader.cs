using HangmanGame.entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace HangmanGame.mapper
{
    class SourceFileReader
    {
        private static string eurpeanCountriesFilePath = "../../../european_countries.txt";

        public static List<string> europeanCountries { get; set; } = GetEuropeanCountries();
        
        public static List<string> GetEuropeanCountries()
        {
            List<string> lines = File.ReadLines(eurpeanCountriesFilePath).ToList();
            return lines.ConvertAll(i => i.ToLower());
        }
        public static List<CountryDetails> GetListOfCountryDetails(string filePath)
        {
            var result = new List<CountryDetails>();
            List<string> lines = File.ReadAllLines(filePath).ToList();
            CountryDetails tempModel;
            foreach (var line in lines)
            {
                string[] entries = line.Split("|");
                tempModel = new CountryDetails()
                {
                    Name = entries[0].Trim('\r','\n','\t').Replace(" ", string.Empty).ToLower(),
                    Capital = entries[1].Trim('\r', '\n', '\t').Replace(" ", string.Empty).ToLower(),
                };
                if (europeanCountries.Contains(tempModel.Name.ToLower()))
                {
                    result.Add(tempModel);
                }
            }
            return result;
        }
    }
}
