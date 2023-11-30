using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Models
{
    public class WireModule
    {
        public List<string> Instructions { get; set; }
        private readonly List<choices_WireColour> Wires;
        private readonly string? _SerialNumber;

        public WireModule(List<choices_WireColour> wireOrder, string? serialNumber = null)
        {
            _SerialNumber = serialNumber ?? string.Empty;
            Wires = wireOrder;
            Instructions = GetInstructions();
        }

        private List<string> GetInstructions()
        {
            switch (Wires.Count)
            {
                case 3:
                    return GetInstructions_3Wires();
                case 4:
                    return GetInstructions_4Wires();
                default:
                    return new List<string>();
            }
        }

        private List<string> GetInstructions_3Wires()
        {
            var instuctions = WiresInstuctions_3Wires();
            List<string> instructionOutput = new();

            if (Wires.Count(w => w == choices_WireColour.Red) < 1)
            {
                instructionOutput.Add(instuctions["NoRed"]);
                return instructionOutput;
            }

            if (Wires.Last() == choices_WireColour.White)
            {
                instructionOutput.Add(instuctions["LastWhite"]);
                return instructionOutput;
            }

            if (Wires.Count(w => w == choices_WireColour.Blue) > 1)
            {
                instructionOutput.Add(instuctions["MultipleBlue"]);
                return instructionOutput;
            }

            instructionOutput.Add(instuctions["Otherwise"]);
            return instructionOutput;
        }

        private List<string> GetInstructions_4Wires()
        {
            var instuctions = WiresInstuctions_4Wires();
            List<string> instructionOutput = new();

            bool isSerialOdd = false;
            try
            {
                isSerialOdd = IsLastDigitOdd(_SerialNumber);
            }
            catch (Exception ex)
            {
                instructionOutput.Add(ex.Message);
                return instructionOutput;
            }

            if (Wires.Count(w => w == choices_WireColour.Red) > 1 && isSerialOdd)
            {
                instructionOutput.Add(instuctions["Odd_MultipleRed"]);
                return instructionOutput;
            }

            if (Wires.Last() == choices_WireColour.Yellow && Wires.Count(w => w == choices_WireColour.Red) == 0)
            {
                instructionOutput.Add(instuctions["Even_LastYellowNoRed"]);
                return instructionOutput;
            }

            if (Wires.Count(w => w == choices_WireColour.Blue) == 1)
            {
                instructionOutput.Add(instuctions["Even_OneBlue"]);
                return instructionOutput;
            }

            if (Wires.Count(w => w == choices_WireColour.Yellow) > 1)
            {
                instructionOutput.Add(instuctions["Even_MultipleYellow"]);
                return instructionOutput;
            }

            instructionOutput.Add(instuctions["Even_Otherwise"]);
            return instructionOutput;
        }

        private Dictionary<string, string> WiresInstuctions_3Wires()
        {
            Dictionary<string, string> wireInstuctions = new Dictionary<string, string>() {
                { "NoRed","If there are no red wires, cut the second wire."},
                { "LastWhite","Otherwise, if the last wire is white, cut the last wire."},
                { "MultipleBlue","Otherwise, if there is more than one blue wire, cut the last blue wire."},
                { "Otherwise","Otherwise, cut the last wire."}
            };

            return wireInstuctions;
        }

        private Dictionary<string, string> WiresInstuctions_4Wires()
        {
            Dictionary<string, string> wireInstuctions = new Dictionary<string, string>() {
                { "Odd_MultipleRed","If there is more than one red wire and the last digit of the serial number is odd, cut the last red wire."},
                { "Even_LastYellowNoRed","Otherwise, if the last wire is yellow and there are no red wires, cut the first wire."},
                { "Even_OneBlue","Otherwise, if there is exactly one blue wire, cut the first wire."},
                { "Even_MultipleYellow","Otherwise, if there is more than one yellow wire, cut the last wire."},
                { "Even_Otherwise","Otherwise, cut the second wire."}
            };

            return wireInstuctions;
        }

        private bool IsLastDigitOdd(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Serial Number cannot empty.");
            }

            char lastChar = input[^1]; // Using ^1 to get the last character

            if (!char.IsDigit(lastChar))
            {
                throw new ArgumentException("Serial Number Last character is not a digit.");
            }

            int lastDigit = lastChar - '0'; // Convert char to int

            return lastDigit % 2 != 0; // Return true if odd, false if even
        }
    }
}
