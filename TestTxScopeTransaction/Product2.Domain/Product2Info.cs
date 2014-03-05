using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Product2.Domain
{
    public class Product2Info
    {
        public virtual int? ID { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal Price { get; set; }
    }
}
