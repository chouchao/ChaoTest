using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Customer.Domain
{
   [DataContract]
    public class CustomerInfo
    {
       [DataMember]
        public virtual int? ID { get; set; }

        [DataMember]
        public virtual string Name { get; set; }

        [DataMember]
        public virtual decimal Money { get; set; }
    }
}
