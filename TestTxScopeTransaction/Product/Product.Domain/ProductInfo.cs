using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Product.Domain
{
    public class ProductInfo
    {
        public virtual int? ID { get; set; }

        public virtual string Name { get; set; }

        public virtual decimal Price { get; set; }
    }
}
