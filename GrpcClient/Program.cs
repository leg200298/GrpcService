using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient.Model.Enum;
using GrpcClient.RPCService;
using GrpcService;
using Microsoft.Extensions.Configuration;
using SCMRPC;
using System;
using System.Configuration;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static int number = 0;
        static object lockKey = new object();

        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            var threadTime = Convert.ToInt32(config.GetSection("TimeSeconds").Value);
            var taskCount = Convert.ToInt32(config.GetSection("TaskCount").Value);
            RPCServiceType rPCServiceType = (RPCServiceType)Convert.ToInt32(config.GetSection("Type").Value);

            Console.WriteLine($"Test RPCService Url : http://127.0.0.1:{Convert.ToInt32(config.GetSection("Port").Value)}");
            Console.WriteLine($"MillisecondsTime : {threadTime}");
            Console.WriteLine($"TaskCount : {taskCount}");



            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress($"http://127.0.0.1:{config.GetSection("Port").Value}");

            Task.Run(() =>
            {
                while (true)
                {
                    for (var i = 1; i <= taskCount; i++)
                    {
                        Task.Run(async () =>
                        {
                            lock (lockKey)
                            {
                                number = number + 1;
                            }

                            Console.WriteLine($"Start RBAC client run count : {number} , time = {DateTime.Now}");

                            switch (rPCServiceType)
                            {
                                case RPCServiceType.B2CImage:
                                    Console.WriteLine($"RPCServiceType : {rPCServiceType.ToString()}");
                                    B2CImageClient.B2CImage_ConveyB2CImageAsync(channel);
                                    break;
                                case RPCServiceType.Media:
                                    Console.WriteLine($"RPCServiceType : {rPCServiceType.ToString()}");
                                    MediaClient.Media_SaveFrontendIcon(channel);
                                    break;
                                default:
                                    Console.WriteLine($"RPCServiceType not found : {rPCServiceType}");
                                    break;
                            }
                        });
                    }
                    Thread.Sleep(threadTime);
                }
            });

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine("RPC channel dispose");
            channel.Dispose();

            #region 範例
            // The port number(5001) must match the port of the gRPC server.

            //var httpClientHandler = new HttpClientHandler();
            //// Return `true` to allow certificates that are untrusted/invalid
            //httpClientHandler.ServerCertificateCustomValidationCallback =
            //    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            //var httpClient = new HttpClient(httpClientHandler);

            //using var channel = GrpcChannel.ForAddress("https://localhost:5001", new GrpcChannelOptions { HttpClient = httpClient });
            //var client = new Greeter.GreeterClient(channel);
            //var reply = await client.SayHelloAsync(
            //                  new GrpcService.HelloRequest { Name = "GreeterClient" });
            //Console.WriteLine("Greeting: " + reply.Message);
            //Console.WriteLine("Press any key to exit...");
            //Console.ReadKey();
            #endregion
        }
    }
}