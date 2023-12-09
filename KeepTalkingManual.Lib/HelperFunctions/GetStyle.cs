using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.HelperFunctions
{
    public static class GetStyle
    {
        public static string GetCheckboxStyle(choices_WireColour wire)
        {
            return wire switch
            {
                choices_WireColour.Red => "red-div",
                choices_WireColour.Black => "black-div",
                choices_WireColour.Blue => "blue-div",
                choices_WireColour.White => "white-div",
                choices_WireColour.Yellow => "yellow-div",
                // Add more cases as needed
                _ => "default-checkbox"
            };
        }

        public static string GetButtonStyle(choices_ButtonColour buttonColour)
        {
            return buttonColour switch
            {
                choices_ButtonColour.Red => "red-div",
                choices_ButtonColour.Black => "black-div",
                choices_ButtonColour.Blue => "blue-div",
                choices_ButtonColour.White => "white-div",
                choices_ButtonColour.Yellow => "yellow-div",
                // Add more cases as needed
                _ => "default-checkbox"
            };
        }

        public static string GetSimonSaysStyle(choices_SimonSaysColours colour)
        {
            return colour switch
            {
                choices_SimonSaysColours.Red => "red-div",
                choices_SimonSaysColours.Blue => "blue-div",
                choices_SimonSaysColours.Yellow => "yellow-div",
                choices_SimonSaysColours.Green => "green-div",
                // Add more cases as needed
                _ => "default-checkbox"
            };
        }
    }
}
