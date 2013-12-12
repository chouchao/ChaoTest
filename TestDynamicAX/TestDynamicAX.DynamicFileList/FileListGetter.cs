using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ComponentModel.Composition;
using Newtonsoft.Json;
using TestDynamicAX.IDynamic;

namespace TestDynamicAX.DynamicFileList
{
    [Export(typeof(IDynamicExecuter))]
    public class FileListGetter : IDynamicExecuter
    {
        public string Execute(string param)
        {
            string[] files;
            if (param == null)
            {
                files = Directory.GetFiles("C:\\");
            }
            else
            {
                ExecuteParam p = JsonConvert.DeserializeObject<ExecuteParam>(param);
                //files = Directory.GetFiles(p.Path);
                return JsonConvert.SerializeObject(p);
            }
            return JsonConvert.SerializeObject(files);
        }

        public class ExecuteParam
        {
            public string Path { get; set; }
        }
    }
}
