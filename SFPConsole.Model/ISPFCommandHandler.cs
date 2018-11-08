using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPConsole.Model
{
    public interface ISPFCommandHandler
    {
        string Execute(Dictionary<string, object> data);
    }
}
