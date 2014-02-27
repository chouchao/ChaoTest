using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Order.Domain
{
    [DataContract]
    public class OrderInfo
    {
        [DataMember]
        public virtual int? ID { get; set; }

        [DataMember]
        public virtual int CustomerId { get; set; }

        [DataMember]
        public virtual DateTime OrderDate { get; set; }

        [DataMember]
        public virtual string Address { get; set; }

        [DataMember]
        public virtual int ProductId { get; set; }

        [DataMember]
        public virtual int ProductQuantity { get; set; }
    }
}
