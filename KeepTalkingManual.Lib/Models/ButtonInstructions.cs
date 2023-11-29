using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeepTalkingManual.Lib.Models
{
    public class ButtonInstructions
    {
        public List<string> Instructions { get; set; } = new List<string>();
        public bool RequiresHold { get; set; } = false;
    }
}
