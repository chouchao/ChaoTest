using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace TestRx.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now);
            HubConnection connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/dataHub")
                .Build();

            connection.On<string>("Start", async (clietId) =>
            {
                Console.WriteLine("Start");
                if (clietId == "1")
                {
                    Thread.Sleep(2000);
                }
                else
                {
                    Thread.Sleep(30000);
                }
                await connection.InvokeAsync("Complete", clietId, "100");
            });

            connection.StartAsync().Wait();

            Console.ReadLine();
        }
    }
}
