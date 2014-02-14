using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Res.Core;
using Res2.Domain;

namespace Res2.Service
{
    public class Res2DataService : IRes2DataService
    {
        public IRepository<Res2Data> Res2DataRepository { get; set; }
    }
}
