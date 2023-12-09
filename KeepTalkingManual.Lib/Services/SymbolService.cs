using KeepTalkingManual.Lib.Enums;
using KeepTalkingManual.Lib.Models;
using KeepTalkingManual.Lib.Models.KeypadSymbols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Services
{
    public class SymbolService
    {
        public List<choices_KeypadSymbol> SelectedSymbols = new List<choices_KeypadSymbol>();
        public string SerialNumber { get; set; }
        public KeypadSymbolModule KeypadModule;
        public string Result { get; set; }
        public SymbolService()
        {
            KeypadModule = new KeypadSymbolModule();
        }

        public void AddSymbolToList(choices_KeypadSymbol symbol)
        {
            SelectedSymbols.Add(symbol);
            HandleChange();
        }
        public void ResetSelectedSymbols()
        {
            SelectedSymbols.Clear();
            HandleChange();
        }

        private void HandleChange()
        {
            Result = KeypadModule.GetInstructions(SelectedSymbols);
        }
    }
}
