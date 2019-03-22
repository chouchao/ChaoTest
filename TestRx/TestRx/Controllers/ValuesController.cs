using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;

namespace TestRx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly DataClient _dataClient;

        public ValuesController(ILogger<ValuesController> logger, DataClient dataClient)
        {
            this._logger = logger;
            this._dataClient = dataClient;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<DataResult>> Get(string clientId)
        {
            return await this._dataClient.GetResult(clientId);
        }
    }
}
