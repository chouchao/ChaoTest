using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spring.Transaction.Interceptor;
using Res.Core;
using Res1.Domain;
using Res2.Domain;
using Res.Dto;

namespace Res.Service
{
    public class ResDataService : IResDataService
    {
        public IRepository<Res1Data> Res1DataRepository { get; set; }

        public IRepository<Res2Data> Res2DataRepository { get; set; }

        [Transaction]
        public void Create(Res1Data entity)
        {
            Res1DataRepository.Save(entity);
        }

        [Transaction(ReadOnly=true)]
        public ResDatatDto GetAll()
        {
            var result = new ResDatatDto();

            result.Res1DataList = Res1DataRepository.LinqQuery.ToList();
            result.Res2DataList = Res2DataRepository.LinqQuery.ToList();

            return result;
        }
    }
}
