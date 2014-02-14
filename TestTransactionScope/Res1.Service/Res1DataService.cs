using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Res.Core;
using Res1.Domain;
using Spring.Transaction.Interceptor;

namespace Res1.Service
{
    public class Res1DataService : IRes1DataService
    {
        public IRepository<Res1Data> Res1DataRepository { get; set; }

        [Transaction(ReadOnly = false)]
        public void Create(Res1Data entity)
        {
            Res1DataRepository.Save(entity);
        }
    }
}
