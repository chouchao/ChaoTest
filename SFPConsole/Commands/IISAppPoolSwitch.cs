using Microsoft.Web.Administration;
using SFPConsole.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf.Logging;

namespace SFPConsole.Commands
{
    public class IISAppPoolSwitch : ISPFCommandHandler
    {
        private static readonly LogWriter logger = HostLogger.Get<IISAppPoolSwitch>();

        public string Execute(Dictionary<string, object> data)
        {
            var command = (data["command"] ?? string.Empty).ToString().ToUpper();
            var name = (data["name"] ?? string.Empty).ToString();

            if (string.IsNullOrWhiteSpace(command))
            {
                logger.Error("command can not be null or empty.");
                return null;
            }
            if (string.IsNullOrWhiteSpace(name))
            {
                logger.Error("name can not be null or empty.");
                return null;
            }
            var manager = new ServerManager();
            var apppool = manager.ApplicationPools.FirstOrDefault(o => o.Name == name);
            if (apppool != null)
            {
                if (command == "START")
                {
                    try
                    {
                        apppool.Start();
                        logger.Info($"App Pool [{name}] start success.");
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"App Pool [{name}] start error.", ex);
                    }
                }
                else if (command == "STOP")
                {
                    try
                    {
                        apppool.Stop();
                        logger.Info($"App Pool [{name}] stop success.");
                    }
                    catch (Exception ex)
                    {
                        logger.Error($"App Pool [{name}] stop error.", ex);
                    }
                }
                else
                {
                    logger.ErrorFormat($"Command [{name}] not support.");
                }
            }
            else
            {
                logger.ErrorFormat($"App Pool [{name}] not found.");
            }

            return null;
        }
    }
}
