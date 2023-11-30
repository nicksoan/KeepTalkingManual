using KeepTalkingManual.Lib.Enums;
using KeepTalkingManual.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Services
{
    public class WireService
    {
        public List<choices_WireColour> SelectedWires { get; private set; } = new List<choices_WireColour>();
        public string SerialNumber { get; set; }
        public WireModule WireModule;
        public event Action OnWiresUpdated;

        public WireService()
        {
        }

        public void UpdateWireList(choices_WireColour wireColour)
        {
            SelectedWires.Add(wireColour);
            DetermineAction();
        }

        public void ClearWireSelection()
        {
            SelectedWires.Clear();
            DetermineAction();
        }

        public void OnSerialNumberKeyup(string serialNumber)
        {
            SerialNumber = serialNumber;
            DetermineAction();
        }

        public void DetermineAction()
        {
            WireModule = new WireModule(SelectedWires, SerialNumber);
            OnWiresUpdated?.Invoke();
        }
    }
}
