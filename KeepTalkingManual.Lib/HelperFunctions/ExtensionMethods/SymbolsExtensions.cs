using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.HelperFunctions.ExtensionMethods
{
    public static class ComplexOptionsExtensions
    {
        public static string GetImage(this choices_KeypadSymbol symbol)
        {
            return symbol switch
            {
                choices_KeypadSymbol.copyright => "copyright.png",
                choices_KeypadSymbol.six => "six.png",
                choices_KeypadSymbol.squigglyn => "squigglyn.png",
                choices_KeypadSymbol.at => "at.png",
                choices_KeypadSymbol.ae => "ae.png",
                choices_KeypadSymbol.meltedthree => "meltedthree.png",
                choices_KeypadSymbol.euro => "euro.png",
                choices_KeypadSymbol.nwithhat => "nwithhat.png",
                choices_KeypadSymbol.dragon => "dragon.png",
                choices_KeypadSymbol.filledstar => "filledstar.png",
                choices_KeypadSymbol.questionmark => "questionmark.png",
                choices_KeypadSymbol.paragraph => "paragraph.png",
                choices_KeypadSymbol.rightc => "rightc.png",
                choices_KeypadSymbol.leftc => "leftc.png",
                choices_KeypadSymbol.pitchfork => "pitchfork.png",
                choices_KeypadSymbol.cursive => "cursive.png",
                choices_KeypadSymbol.tracks => "tracks.png",
                choices_KeypadSymbol.balloon => "balloon.png",
                choices_KeypadSymbol.hollowstar => "hollowstar.png",
                choices_KeypadSymbol.upsidedowny => "upsidedowny.png",
                choices_KeypadSymbol.bt => "bt.png",
                choices_KeypadSymbol.smileyface => "smileyface.png",
                choices_KeypadSymbol.doublek => "doublek.png",
                choices_KeypadSymbol.omega => "omega.png",
                choices_KeypadSymbol.squidknife => "squidknife.png",
                choices_KeypadSymbol.pumpkin => "pumpkin.png",
                choices_KeypadSymbol.hookn => "hookn.png",
                _ => "Unknown"
            };
        }
    }
}
