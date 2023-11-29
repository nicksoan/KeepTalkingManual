using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Models
{
    public class HeldButton
    {
        public choices_ColourStrip _ColourStrip { get; set; }
        public string DefuseInstruction = "";

        public HeldButton(choices_ColourStrip colourStrip)
        {
            _ColourStrip = colourStrip;
            var defuseInstructionTexts = DefuseInstructionText();

            List<choices_ColourStrip> ValidColours = new List<choices_ColourStrip>() { choices_ColourStrip.Blue, choices_ColourStrip.White, choices_ColourStrip.Yellow };

            if (ValidColours.Contains(_ColourStrip))
            {
                DefuseInstruction = defuseInstructionTexts[_ColourStrip.ToString()];
            }
            else {
                DefuseInstruction = defuseInstructionTexts["Other"];
            }
        }

        private Dictionary<string, string> DefuseInstructionText()
        {
            Dictionary<string, string> buttonInstructions = new Dictionary<string, string>() {
                { "Blue",@"release when the countdown timer has a 4 in any position."},
                { "White","release when the countdown timer has a 1 in any position."},
                { "Yellow","release when the countdown timer has a 5 in any position."},
                { "Other","release when the countdown timer has a 1 in any position."}
            };

            return buttonInstructions;
        }
    }
}
