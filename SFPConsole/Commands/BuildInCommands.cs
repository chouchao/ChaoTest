using SFPConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SFPConsole.Commands
{
    public static class BuildInCommands
    {
        public static Dictionary<string, ISPFCommandHandler> Handlers =
            new Dictionary<string, ISPFCommandHandler>(){
                {nameof(DomainUserToLocalGroup), new DomainUserToLocalGroup()},
                {nameof(IISAppPoolSwitch), new IISAppPoolSwitch()}
            };

        public static bool Contains(string key)
        {
            return Handlers.ContainsKey(key);
        }
    }
}
