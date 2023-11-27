using KeepTalkingManual.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.UnitTests.Wires._3Wires
{
    public class WiresTests_4
    {
        [Theory]
        [InlineData("Red,Red,Blue,White")]
        [InlineData("Red,White,Blue,Black")]
        public void Should_ExtractTextToCorrectOrder(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(4, wireModule.Wires.Count);
        }

        [Theory]
        [InlineData("Red,Red,Blu,Bl")]
        public void Should_ExtractTextValidateText(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(0, wireModule.Wires.Count);
            Assert.Equal(0, wireModule.Instructions.Count);
        }

        [Theory]
        [InlineData("Red,Black,Blue,Red", "AL5QF3")]
        [InlineData("Red,Red,Blue,Yellow", "AL5QF3")]
        public void Should_ReturnCorrectInstructions_MultipleRed_OddSerial(string wireList, string serialNumber)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Wires);
            Assert.Single(wireModule.Instructions);
            Assert.Equal("If there is more than one red wire and the last digit of the serial number is odd, cut the last red wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Red,Blue,Blue,Red", "AL5QF2")]
        [InlineData("Red,Red,Black,Yellow", "AL5QF2")]
        public void Should_ReturnCorrectInstructions_MultipleRed_EvenSerial(string wireList, string serialNumber)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Wires);
            Assert.Single(wireModule.Instructions);
            Assert.Equal("Otherwise, cut the second wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Blue,White,blue,Yellow", "AL5QF2")]
        [InlineData("BLUE,WHITE,BLUE,YELLOW", "AL5QF2")]
        public void Should_ReturnCorrectInstructions_LastYellowNoRed(string wireList, string serialNumber)
        {
            WireModule wireModule = new WireModule(wireList,serialNumber);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if the last wire is yellow and there are no red wires, cut the first wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Red,Blue,Blue", "AL5QF2")]
        public void Should_ReturnCorrectInstructions_OneBlue(string wireList, string serialNumber)
        {
            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if there is more than one blue wire, cut the last blue wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Red,Yellow,Black,Yellow", "AL5QF2")]
        [InlineData("Yellow,Yellow,Red,Black", "AL5QF2")]
        [InlineData("YELLOW,YELLOW,RED,BLACK", "AL5QF2")]
        public void Should_ReturnCorrectInstructions_MultipleYellow(string wireList, string serialNumber)
        {
            //yellow, red, blue, black, or white.

            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if there is more than one yellow wire, cut the last wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Red,Blue,Black,Blue", "AL5QF2")]
        [InlineData("Red,Red,Red,Black", "AL5QF2")]
        [InlineData("Blue,Blue,RED,Black", "AL5QF2")]
        public void Should_ReturnCorrectInstructions_Other(string wireList, string serialNumber)
        {
            //yellow, red, blue, black, or white.

            WireModule wireModule = new WireModule(wireList, serialNumber);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, cut the second wire.", wireModule.Instructions.First());
        }
    }
}
