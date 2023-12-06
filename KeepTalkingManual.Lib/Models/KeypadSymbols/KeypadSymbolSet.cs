using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Models.KeypadSymbols
{
    public class KeypadSymbolSet
    {
        private Dictionary<string, List<choices_KeypadSymbol>> predefinedLists;
        public KeypadSymbolSet()
        {
            DefineSymbolSets();
        }

        public List<string> FindListNameWithMostMatches(List<choices_KeypadSymbol> userInput)
        {
            List<string> bestMatchingListNames = new List<string>();

            if (!userInput.Any())
            {
                return bestMatchingListNames;
            }
            
            int maxMatches = 0;

            foreach (var pair in predefinedLists)
            {
                int matches = userInput.Intersect(pair.Value).Count();

                if (matches > maxMatches)
                {
                    maxMatches = matches;
                    bestMatchingListNames = new List<string> { pair.Key };
                }
                else if (matches == maxMatches)
                {
                    bestMatchingListNames.Add(pair.Key);
                }
            }
            return bestMatchingListNames;
        }

        private void DefineSymbolSets()
        {
            predefinedLists = new Dictionary<string, List<choices_KeypadSymbol>>()
            {
                { "Set1",new List<choices_KeypadSymbol>() {
                                                choices_KeypadSymbol.balloon,
                                                choices_KeypadSymbol.at,
                                                choices_KeypadSymbol.upsidedowny,
                                                choices_KeypadSymbol.squigglyn,
                                                choices_KeypadSymbol.squidknife,
                                                choices_KeypadSymbol.hookn,
                                                choices_KeypadSymbol.leftc
                                                }
                },
                { "Set2", new List<choices_KeypadSymbol>() {
                                                choices_KeypadSymbol.euro,
                                                choices_KeypadSymbol.balloon,
                                                choices_KeypadSymbol.leftc,
                                                choices_KeypadSymbol.cursive,
                                                choices_KeypadSymbol.hollowstar,
                                                choices_KeypadSymbol.hookn,
                                                choices_KeypadSymbol.questionmark
                                                }
                },
                { "Set3",new List<choices_KeypadSymbol>() {
                                                choices_KeypadSymbol.copyright,
                                                choices_KeypadSymbol.pumpkin,
                                                choices_KeypadSymbol.cursive,
                                                choices_KeypadSymbol.doublek,
                                                choices_KeypadSymbol.meltedthree,
                                                choices_KeypadSymbol.upsidedowny,
                                                choices_KeypadSymbol.hollowstar
                                                }
                },
                {"Set4",new List<choices_KeypadSymbol>() {
                                                choices_KeypadSymbol.six,
                                                choices_KeypadSymbol.paragraph,
                                                choices_KeypadSymbol.bt,
                                                choices_KeypadSymbol.squidknife,
                                                choices_KeypadSymbol.doublek,
                                                choices_KeypadSymbol.questionmark,
                                                choices_KeypadSymbol.smileyface
                                                }
                },
                { "Set5", new List<choices_KeypadSymbol>() {
                                                choices_KeypadSymbol.pitchfork,
                                                choices_KeypadSymbol.smileyface,
                                                choices_KeypadSymbol.bt,
                                                choices_KeypadSymbol.rightc,
                                                choices_KeypadSymbol.paragraph,
                                                choices_KeypadSymbol.dragon,
                                                choices_KeypadSymbol.filledstar
                                                }
                },
                { "Set6",new List<choices_KeypadSymbol>() {
                                                choices_KeypadSymbol.six,
                                                choices_KeypadSymbol.euro,
                                                choices_KeypadSymbol.tracks,
                                                choices_KeypadSymbol.ae,
                                                choices_KeypadSymbol.pitchfork,
                                                choices_KeypadSymbol.nwithhat,
                                                choices_KeypadSymbol.omega
                                                } 
                }
            };
        }
    }
}
