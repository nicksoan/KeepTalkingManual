using KeepTalkingManual.Lib.Enums;
using KeepTalkingManual.Lib.Models;
using KeepTalkingManual.Lib.Models.KeypadSymbols;
using KeepTalkingManual.UnitTests.Wires;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.UnitTests.KeypadSymbols
{
    public class KeypadSymbolsTests
    {

        [Theory]
        [KeyPadListDataAttribute("Matching Sets: Set1, Set2", choices_KeypadSymbol.balloon)]
        [KeyPadListDataAttribute("Matching Sets: Set1, Set2", choices_KeypadSymbol.leftc, choices_KeypadSymbol.balloon, choices_KeypadSymbol.hookn)]
        [KeyPadListDataAttribute("Matching Sets: Set2, Set3",choices_KeypadSymbol.hollowstar)]
        public void ShouldMatch_SingleSymbolMatchesMultipleSets(List<choices_KeypadSymbol> keypadSymbols,string expectedResults)
        {
            KeypadSymbolModule keypadModule = new KeypadSymbolModule();
        
            Assert.Equal(expectedResults,keypadModule.GetInstructions(keypadSymbols));
            
        }

        [Theory]
        [KeyPadListDataAttribute("Matching Sets: Set1", choices_KeypadSymbol.balloon,choices_KeypadSymbol.at,choices_KeypadSymbol.squidknife)]
        [KeyPadListDataAttribute("Matching Sets: Set1", choices_KeypadSymbol.leftc, choices_KeypadSymbol.upsidedowny, choices_KeypadSymbol.hookn)]
        [KeyPadListDataAttribute("Matching Sets: Set1", choices_KeypadSymbol.at, choices_KeypadSymbol.leftc, choices_KeypadSymbol.squigglyn)]
        public void ShouldMatch_Set1(List<choices_KeypadSymbol> keypadSymbols, string expectedResults)
        {
            KeypadSymbolModule keypadModule = new KeypadSymbolModule();

            Assert.Equal(expectedResults, keypadModule.GetInstructions(keypadSymbols));

        }

        [Theory]
        [KeyPadListDataAttribute("Matching Sets: Set2", choices_KeypadSymbol.hollowstar, choices_KeypadSymbol.questionmark, choices_KeypadSymbol.euro)]
        [KeyPadListDataAttribute("Matching Sets: Set2", choices_KeypadSymbol.leftc, choices_KeypadSymbol.cursive, choices_KeypadSymbol.balloon)]
        [KeyPadListDataAttribute("Matching Sets: Set2", choices_KeypadSymbol.hookn, choices_KeypadSymbol.balloon, choices_KeypadSymbol.euro)]
        public void ShouldMatch_Set2(List<choices_KeypadSymbol> keypadSymbols, string expectedResults)
        {
            KeypadSymbolModule keypadModule = new KeypadSymbolModule();

            Assert.Equal(expectedResults, keypadModule.GetInstructions(keypadSymbols));

        }


    }
}
