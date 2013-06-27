using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WriteLineActivitySample
{
    public class WFWriter : TextWriter
    {
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }

        public override void WriteLine(string value)
        {
            Console.WriteLine("WF:" + value);
        }
    }
}
