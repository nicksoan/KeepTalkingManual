using KeepTalkingManual.Lib.Enums;
using KeepTalkingManual.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace KeepTalkingManual.UnitTests.Wires._3Wires
{
    public class WiresTests_3
    {
        [Theory]
        [ListEnumData("", choices_WireColour.Red, choices_WireColour.White, choices_WireColour.Blue)]
        public void Should_ExtractTextToCorrectOrder(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal("Otherwise, cut the last wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("", choices_WireColour.White, choices_WireColour.Black, choices_WireColour.Blue)]
        public void Should_ReturnCorrectInstructions_NoRedWires(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("If there are no red wires, cut the second wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("", choices_WireColour.White, choices_WireColour.Red, choices_WireColour.White)]
        public void Should_ReturnCorrectInstructions_LastWhite(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if the last wire is white, cut the last wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("", choices_WireColour.Red, choices_WireColour.Blue, choices_WireColour.Blue)]
        public void Should_ReturnCorrectInstructions_MultipleBlue(string serialNumber, List<choices_WireColour> wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if there is more than one blue wire, cut the last blue wire.", wireModule.Instructions.First());
        }

        [Theory]
        [ListEnumData("", choices_WireColour.Red, choices_WireColour.Yellow, choices_WireColour.Black)]
        [ListEnumData("", choices_WireColour.Yellow, choices_WireColour.Red, choices_WireColour.Blue)]
        public void Should_ReturnCorrectInstructions_Other(string serialNumber, List<choices_WireColour> wireList)
        {
            //yellow, red, blue, black, or white.

            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Instructions);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, cut the last wire.", wireModule.Instructions.First());
        }
    }
}
