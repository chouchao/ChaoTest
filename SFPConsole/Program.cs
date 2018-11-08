using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SFPConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentDirectory = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            var rc = HostFactory.Run(x =>
            {
                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole()
                .WriteTo.RollingFile(Path.Combine(currentDirectory, "App_log", "Process_{Date}.log"))
                .CreateLogger();
                x.UseSerilog();

                x.Service<SFPService>(s =>
                {
                    s.ConstructUsing(name => new SFPService());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Share Folder Permisstion Service");
                x.SetDisplayName("SFPService");
                x.SetServiceName("SFPService");
            });

            var exitCode = (int)Convert.ChangeType(rc, rc.GetTypeCode());
            Environment.ExitCode = exitCode;
        }
    }
}
