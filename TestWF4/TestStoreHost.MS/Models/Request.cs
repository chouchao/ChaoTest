using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSH.Core.Domain;

namespace TestStoreHost.MS.Models
{
    public class Request : EntityBase
    {
        public string Name { get; set; }

        public string File1 { get; set; }

        public string File2 { get; set; }

        public string File3 { get; set; }

        public RequestStatus Status { get; set; }

        public DateTime UpdateTime { get; set; }

        public Guid? WokflowId { get; set; }
    }
}
