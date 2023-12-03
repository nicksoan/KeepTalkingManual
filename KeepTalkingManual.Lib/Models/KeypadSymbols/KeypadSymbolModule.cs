using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Models.KeypadSymbols
{
    public class KeypadSymbolModule
    {
        private readonly KeypadSymbolSet _keypadSymbolSet;
        public KeypadSymbolModule()
        {
            _keypadSymbolSet = new KeypadSymbolSet();
        }

        public string GetInstructions(List<choices_KeypadSymbol> userInput   )
        {
            List<string> bestMatchingListNames = _keypadSymbolSet.FindListNameWithMostMatches(userInput);
            string returnText = "";
            if (bestMatchingListNames.Any())
            {
                returnText = $"Matching Sets: {string.Join(", ", bestMatchingListNames)}" ;
            }
            else
            {
                returnText ="No matching sets found.";
            }

            return returnText;
        }
    }
}
