using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TestRx
{
    public class DataClient
    {
        private readonly ILogger _logger;
        private readonly HubConnection connection;
        private bool connectionStarted = false;
        private static object locker = new object();
        private readonly Dictionary<string, TaskCompletionSource<DataResult>> _tcsDic
            = new Dictionary<string, TaskCompletionSource<DataResult>>();

        public DataClient(ILogger<DataClient> logger)
        {
            this._logger = logger;
            connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/dataHub")
                .Build();

            connection.On<string, string>("Complete", (clietId, count) =>
            {
                _logger.LogInformation("Complete Event");
                if (_tcsDic.TryGetValue(clietId, out TaskCompletionSource<DataResult> clientTcs))
                {
                    _tcsDic.Remove(clietId);
                    clientTcs.TrySetResult(new DataResult() {
                        Success = true,
                        ClientId = clietId,
                        Count = count,
                    });
                }
                else
                {
                    _logger.LogInformation("Complete Event, clientTcs not found");
                }
            });
            _logger.LogInformation("DataClient");
        }

        public Task<DataResult> GetResult(string clientId)
        {
            var tcs = new TaskCompletionSource<DataResult>();
            _tcsDic[clientId] = tcs;

            if (!connectionStarted)
            {
                connection.StartAsync().Wait();
                _logger.LogInformation("DataClient Connection StartAsync");
                lock (locker)
                {
                    connectionStarted = true;
                }
            }

            SetTimeout(tcs, clientId);

            connection.InvokeAsync("Start", clientId).Wait();
            _logger.LogInformation("DataClient InvokeAsync Start");

            return tcs.Task;
        }

        private static void SetTimeout(TaskCompletionSource<DataResult> tcs, string clientId)
        {
            const int timeoutMs = 20000;
            var ct = new CancellationTokenSource(timeoutMs);
            //ct.Token.Register(() => tcs.TrySetCanceled(), useSynchronizationContext: false);
            ct.Token.Register(() => tcs.TrySetResult(new DataResult()
            {
                Success = false,
                ClientId = clientId,
                Message = "Client timeout"
            }), useSynchronizationContext: false);
        }
    }
}
