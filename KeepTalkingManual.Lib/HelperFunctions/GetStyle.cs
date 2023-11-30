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
    }
}
