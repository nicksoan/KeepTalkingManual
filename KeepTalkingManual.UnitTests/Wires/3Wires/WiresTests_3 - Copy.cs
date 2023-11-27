using KeepTalkingManual.Lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.UnitTests.Wires._3Wires
{
    public class WiresTests_3
    {
        [Theory]
        [InlineData("Red,Red,Blue")]
        [InlineData("Red,White,Blue")]
        public void Should_ExtractTextToCorrectOrder(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(3, wireModule.Wires.Count);
        }

        [Theory]
        [InlineData("Red,Red,Blu")]
        public void Should_ExtractTextValidateText(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(0, wireModule.Wires.Count);
            Assert.Equal(0, wireModule.Instructions.Count);
        }

        [Theory]
        [InlineData("White,Black,Blue")]
        public void Should_ReturnCorrectInstructions_NoRedWires(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("If there are no red wires, cut the second wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("White,Red,White")]
        [InlineData("WHITE,RED,WHITE")]
        public void Should_ReturnCorrectInstructions_LastWhite(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if the last wire is white, cut the last wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Red,Blue,Blue")]
        public void Should_ReturnCorrectInstructions_MultipleBlue(string wireList)
        {
            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, if there is more than one blue wire, cut the last blue wire.", wireModule.Instructions.First());
        }

        [Theory]
        [InlineData("Red,Yellow,Black")]
        [InlineData("Yellow,Red,Blue")]
        [InlineData("YELLOW,RED,BLUE")]
        public void Should_ReturnCorrectInstructions_Other(string wireList)
        {
            //yellow, red, blue, black, or white.

            WireModule wireModule = new WireModule(wireList);

            Assert.NotNull(wireModule.Wires);
            Assert.Equal(1, wireModule.Instructions.Count);
            Assert.Equal("Otherwise, cut the last wire.", wireModule.Instructions.First());
        }
    }
}
