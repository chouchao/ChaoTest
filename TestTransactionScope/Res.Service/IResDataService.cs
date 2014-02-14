using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Res1.Domain;
using Res.Dto;

namespace Res.Service
{
    public interface IResDataService
    {
        void Create(Res1Data entity);

        ResDatatDto GetAll();
    }
}
