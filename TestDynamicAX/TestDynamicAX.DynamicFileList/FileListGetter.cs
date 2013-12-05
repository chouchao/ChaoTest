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
            var files = Directory.GetFiles("C:\\");
            return JsonConvert.SerializeObject(files);
        }
    }
}
