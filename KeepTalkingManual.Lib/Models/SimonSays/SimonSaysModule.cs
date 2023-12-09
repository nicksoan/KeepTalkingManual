using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Models.SimonSays
{
    public class SimonSaysModule
    {
        public SimonSaysModule()
        {

        }

        public List<choices_SimonSaysColours> GetInstructions(int strikes, string serialNumber)
        {
            if (SerialNumberContainsVowel(serialNumber))
            {
                return GetVowelSets(strikes);
            }
            else
            {
                return GetConsonantSets(strikes);
            }
        }

        private List<choices_SimonSaysColours> GetVowelSets(int strikes)
        {
            switch (strikes)
            {
                case 0:
                    return new List<choices_SimonSaysColours>() { choices_SimonSaysColours.Blue, choices_SimonSaysColours.Red, choices_SimonSaysColours.Yellow, choices_SimonSaysColours.Green };
                case 1:
                    return new List<choices_SimonSaysColours>() { choices_SimonSaysColours.Yellow, choices_SimonSaysColours.Green, choices_SimonSaysColours.Blue, choices_SimonSaysColours.Red };
                case 2:
                    return new List<choices_SimonSaysColours>() { choices_SimonSaysColours.Green, choices_SimonSaysColours.Red, choices_SimonSaysColours.Yellow, choices_SimonSaysColours.Blue };
                default:
                    return new List<choices_SimonSaysColours>();
            }
        }
        private List<choices_SimonSaysColours> GetConsonantSets(int strikes)
        {
            switch (strikes)
            {
                case 0:
                    return new List<choices_SimonSaysColours>() { choices_SimonSaysColours.Blue, choices_SimonSaysColours.Yellow, choices_SimonSaysColours.Green, choices_SimonSaysColours.Red };
                case 1:
                    return new List<choices_SimonSaysColours>() { choices_SimonSaysColours.Red, choices_SimonSaysColours.Blue, choices_SimonSaysColours.Yellow, choices_SimonSaysColours.Green };
                case 2:
                    return new List<choices_SimonSaysColours>() { choices_SimonSaysColours.Yellow, choices_SimonSaysColours.Green, choices_SimonSaysColours.Blue, choices_SimonSaysColours.Red };
                default:
                    return new List<choices_SimonSaysColours>();
            }
        }

        private bool SerialNumberContainsVowel(string serialNumber)
        {
            return serialNumber.Any(s => "aeiouAEIOU".Contains(s));
        }
    }
}
