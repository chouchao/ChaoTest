using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPConsole.Model
{
    public class SFPCommand
    {
        public string Command { get; set; }

        // public bool? IsBuiltIn { get; set; }

        public Dictionary<string, object> Data { get; set; }

    }
}
