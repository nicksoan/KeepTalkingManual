using KeepTalkingManual.Lib.Enums;
using KeepTalkingManual.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace KeepTalkingManual.UnitTests.Wires._4Wires
{
    public class WiresTests_4
    {

        [Theory]
        [ListEnumData("AL5QF3", choices_WireColour.Red, choices_WireColour.Black, choices_WireColour.Blue, choices_WireColour.Red)]
        [ListEnumData("AL5QF3", choices_WireColour.Red, choices_WireColour.Red, choices_WireColour.Blue, choices_WireColour.Yellow)]
        public void Should_ReturnCorrectInstructions_MultipleRed_OddSerial(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Instructions);
            Assert.Single(wireModule.Instructions);
            Assert.Equal("If there is more than one red wire and the last digit of the serial number is odd, cut the last red wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("AL5QF2", choices_WireColour.Red, choices_WireColour.Blue, choices_WireColour.Blue, choices_WireColour.Red)]
        [ListEnumData("AL5QF2", choices_WireColour.Red, choices_WireColour.Red, choices_WireColour.Black, choices_WireColour.Yellow)]
        public void Should_ReturnCorrectInstructions_MultipleRed_EvenSerial(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Instructions);
            Assert.Single(wireModule.Instructions);
            Assert.Equal("Otherwise, cut the second wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("AL5QF2", choices_WireColour.Blue, choices_WireColour.White, choices_WireColour.Blue, choices_WireColour.Yellow)]
        public void Should_ReturnCorrectInstructions_LastYellowNoRed(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if the last wire is yellow and there are no red wires, cut the first wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("AL5QF2", choices_WireColour.Yellow, choices_WireColour.Red, choices_WireColour.Blue, choices_WireColour.Black)]
        public void Should_ReturnCorrectInstructions_OneBlue(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if there is exactly one blue wire, cut the first wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("AL5QF2", choices_WireColour.Red, choices_WireColour.Yellow, choices_WireColour.Black, choices_WireColour.Yellow)]
        [ListEnumData("AL5QF2", choices_WireColour.Yellow, choices_WireColour.Yellow, choices_WireColour.Red, choices_WireColour.Black)]
        public void Should_ReturnCorrectInstructions_MultipleYellow(string serialNumber, List<choices_WireColour> wireList)
        {
            //yellow, red, blue, black, or white.

            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if there is more than one yellow wire, cut the last wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("AL5QF2", choices_WireColour.Red, choices_WireColour.Blue, choices_WireColour.Black, choices_WireColour.Blue)]
        [ListEnumData("AL5QF2", choices_WireColour.Red, choices_WireColour.Red, choices_WireColour.Red, choices_WireColour.Black)]
        [ListEnumData("AL5QF2", choices_WireColour.Blue, choices_WireColour.Blue, choices_WireColour.Red, choices_WireColour.Black)]
        public void Should_ReturnCorrectInstructions_Other(string serialNumber, List<choices_WireColour> wireList)
        {
            //yellow, red, blue, black, or white.

            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, cut the second wire.", wireModule.Instructions.First());
        }
    }
}
