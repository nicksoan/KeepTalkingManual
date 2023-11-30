using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace KeepTalkingManual.UnitTests.Wires
{
    public class ListEnumDataAttribute : DataAttribute
    {
        private readonly List<object[]> _data = new List<object[]>();

        public ListEnumDataAttribute(string strParam, params choices_WireColour[] enumValues)
        {
            // Convert the array of enum values into a List and add it along with the string parameter to _data
            _data.Add(new object[] { strParam ,enumValues.ToList() });
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return _data;
        }
    }
}
