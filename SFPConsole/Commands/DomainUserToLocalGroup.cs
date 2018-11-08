using SFPConsole.Model;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Logging;

namespace SFPConsole.Commands
{
    public class DomainUserToLocalGroup : ISPFCommandHandler
    {
        private static readonly LogWriter logger = HostLogger.Get<DomainUserToLocalGroup>();

        public string Execute(Dictionary<string, object> data)
        {
            var domainName = data["domain"].ToString();
            var userNames = data["user"].ToString().Split(';');
            var groupName = data["group"].ToString();

            DirectoryEntry direntgrouproot = new DirectoryEntry("WinNT://" + Environment.MachineName + ",Computer");
            DirectoryEntry direntgrp = direntgrouproot.Children.Find(groupName, "group");

            if(direntgrp == null)
            {
                logger.ErrorFormat("Group {0} not found", groupName);
            }

            foreach (var userName in userNames)
            {
                DirectoryEntry adRoot = new DirectoryEntry(string.Format("WinNT://{0}", domainName));
                DirectoryEntry user = adRoot.Children.Find(userName, "User");

                if (user == null)
                {
                    logger.ErrorFormat("User {0} not found", user);
                }

                direntgrp.Invoke("Add", new Object[] { user.Path.ToString() });
                logger.DebugFormat("DomainUserToLocalGroup executed:{0}", userName);
            }
            
            return null;
        }
    }
}
