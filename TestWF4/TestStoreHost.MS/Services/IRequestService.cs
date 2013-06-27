using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NSH.Core.Service;
using TestStoreHost.MS.Models;
using TestStoreHost.MS.Dtos;

namespace TestStoreHost.MS.Services
{
    public interface IRequestService : IServiceListBase<Request, RequestQueryDto>
    {
    }
}
