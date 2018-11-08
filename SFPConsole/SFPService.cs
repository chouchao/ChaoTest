using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;
using SFPConsole.Commands;
using SFPConsole.Model;
using Topshelf.Logging;

namespace SFPConsole
{
    public class SFPService
    {
        private static readonly LogWriter logger = HostLogger.Get<SFPService>();
        private readonly string CurrentDirectory;
        private readonly string CommandDirectory;
        private bool IsExecuting = false;

        readonly Timer _timer;
        public SFPService()
        {
            CurrentDirectory = Path.GetDirectoryName(this.GetType().Assembly.Location);
            logger.Debug(string.Format("CurrentDirectory is {0}", CurrentDirectory));
            CommandDirectory = Path.Combine(CurrentDirectory, "commands");
            var template = Path.Combine(CurrentDirectory, "template.json");
            if (!File.Exists(template))
            {
                File.WriteAllText(template, JsonConvert.SerializeObject(new SFPCommand()
                {
                    Command = "DomainUserToLocalGroup",
                    Data = new Dictionary<string, object>()
                    {
                        { "domain", "dir" },
                        { "user", "test.a.user" },
                        { "group", "0.PMO_RW" }
                    }
                }), Encoding.UTF8);
            }

            if (!Directory.Exists(CommandDirectory))
            {
                Directory.CreateDirectory(CommandDirectory);
            }

            _timer = new Timer(5000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Execute();
        }

        private void Execute()
        {
            if (IsExecuting)
            {
                return;
            }
            IsExecuting = true;
            logger.InfoFormat("It is {0} and all is well", DateTime.Now);

            var commandFiles = Directory.GetFiles(CommandDirectory, "*.json");
            string executedFile;

            foreach (var commandFile in commandFiles)
            {
                logger.Info(string.Format("Execute command file:{0}", commandFile));
                try
                {
                    var commandJson = File.ReadAllText(commandFile, Encoding.UTF8);
                    var command = JsonConvert.DeserializeObject<SFPCommand>(commandJson);
                    if (BuildInCommands.Contains(command.Command))
                    {
                        BuildInCommands.Handlers[command.Command].Execute(command.Data);
                    }
                    else
                    {
                        Process.Start(command.Command, commandFile);
                    }

                    executedFile = commandFile + ".executed";
                    CleanExecutedFile(executedFile);

                    File.Move(commandFile, executedFile);
                }
                catch (Exception ex)
                {
                    logger.Error("Execute faild", ex);
                }

            }
            IsExecuting = false;
        }

        private static void CleanExecutedFile(string executedFile)
        {
            try
            {
                if (File.Exists(executedFile))
                {
                    File.Delete(executedFile);
                }
                logger.Warn("Clean executed file:" + executedFile);
            }
            catch (Exception ex)
            {
                logger.Error("Clean executed file faild", ex);
            }
        }

        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
    }
}
