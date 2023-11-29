using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KeepTalkingManual.Lib.Enums;

namespace KeepTalkingManual.Lib.Models
{
    public class ButtonModule
    {

        public List<ButtonInstructions> Instructions { get; set; } = new List<ButtonInstructions>();
        public choices_ButtonColour ButtonColour;
        public choices_ButtonText ButtonText;
        public List<choices_Indicatortext> LitIndicators { get; set; } = new List<choices_Indicatortext>();
        public int BatteryCount { get; set; } = 0;
        public choices_ColourStrip StripColour;
        public bool RequiresHold { get; set; } = false;

        public ButtonModule(choices_ButtonColour buttonColour, choices_ButtonText buttonText, List<choices_Indicatortext> litIndicators, int batteryCount, choices_ColourStrip stripColour)
        {
            ButtonColour = buttonColour;
            ButtonText = buttonText;
            LitIndicators = litIndicators;
            BatteryCount = batteryCount;
            StripColour = stripColour;

            Instructions = GetDefuseInstructions();
        }

        public List<ButtonInstructions> GetDefuseInstructions()
        {
            Dictionary<string, string> defuseInstructionText = DefuseInstructionText();

            if (ButtonColour == choices_ButtonColour.Blue && ButtonText == choices_ButtonText.Abort)
            {
                return ReturnInstructions(defuseInstructionText, "Blue_Abort", true, StripColour);
            }

            if (BatteryCount > 1 && ButtonText == choices_ButtonText.Detonate)
            {
                return ReturnInstructions(defuseInstructionText, "OneBattery_Detonate", false);
            }

            if (ButtonColour == choices_ButtonColour.White && LitIndicators.Contains(choices_Indicatortext.CAR))
            {
                return ReturnInstructions(defuseInstructionText, "White_CAR", true, StripColour);
            }

            if (BatteryCount > 2 && LitIndicators.Contains(choices_Indicatortext.FRK))
            {
                return ReturnInstructions(defuseInstructionText, "TwoBatteries_FRK", false);
            }

            if (ButtonColour == choices_ButtonColour.Yellow)
            {
                return ReturnInstructions(defuseInstructionText, "Yellow", true, StripColour);
            }

            if (ButtonColour == choices_ButtonColour.Red && ButtonText == choices_ButtonText.Hold)
            {
                return ReturnInstructions(defuseInstructionText, "Red_Hold", false);
            }

            return new List<ButtonInstructions>();
        }

        private static List<ButtonInstructions> ReturnInstructions(Dictionary<string, string> defuseInstructionText, string defuseInstructionKey, bool requiresHold, choices_ColourStrip colourStrip = choices_ColourStrip.None)
        {
            List<ButtonInstructions> instructionsList = new List<ButtonInstructions>();
            List<string> instructions = new List<string>();

            instructions.Add(defuseInstructionText[defuseInstructionKey]);

            if (requiresHold && colourStrip != choices_ColourStrip.None)
            {
                HeldButton heldButton = new HeldButton(colourStrip);
                instructions.Add(heldButton.DefuseInstruction);
            }

            instructionsList.Add(new ButtonInstructions()
            {
                Instructions = instructions,
                RequiresHold = requiresHold
            });
            return instructionsList;
        }

        private Dictionary<string, string> DefuseInstructionText()
        {
            Dictionary<string, string> buttonInstructions = new Dictionary<string, string>() {
                { "Blue_Abort",@"If the button is blue and the button says 'Abort', hold the button and refer to 'Releasing a Held Button'."},
                { "OneBattery_Detonate","If there is more than 1 battery on the bomb and the button says \"Detonate\", press and immediately release the button."},
                { "White_CAR","If the button is white and there is a lit indicator with label CAR, hold the button and refer to \"Releasing a Held Button\""},
                { "TwoBatteries_FRK","If there are more than 2 batteries on the bomb and there is a lit indicator with label FRK, press and immediately release the button."},
                { "Yellow","If the button is yellow, hold the button and refer to \"Releasing a Held Button\""},
                { "Red_Hold","If the button is red and the button says \"Hold\", press and immediately release the button."},
                { "Otherwise","If none of the above apply, hold the button and refer to \"Releasing a Held Button\"."}
            };

            return buttonInstructions;
        }
    }
}
