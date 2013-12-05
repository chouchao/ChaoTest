using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestDynamicAX.IDynamic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using Newtonsoft.Json;

namespace TestDynamicAX.DynamicProcess
{
    [Export(typeof(IDynamicExecuter))]
    public class ProcessGetter : IDynamicExecuter
    {
        public string Execute(string param)
        {
            var process = Process.GetProcesses().Select(o => o.ProcessName).ToArray();
            return JsonConvert.SerializeObject(process);
        }
    }
}
