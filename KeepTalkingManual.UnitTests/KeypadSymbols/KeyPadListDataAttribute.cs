using KeepTalkingManual.Lib.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace KeepTalkingManual.UnitTests.KeypadSymbols
{
    public class KeyPadListDataAttribute : DataAttribute
    {
        private readonly List<object[]> _data = new List<object[]>();

        public KeyPadListDataAttribute(string strParam, params choices_KeypadSymbol[] enumValues)
        {
            // Convert the array of enum values into a List and add it along with the string parameter to _data
            _data.Add(new object[] { enumValues.ToList(),strParam });
        }

        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return _data;
        }
    }
}
