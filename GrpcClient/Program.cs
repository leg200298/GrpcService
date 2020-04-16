using Grpc.Core;
using Grpc.Net.Client;
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

        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build(); 

            Console.WriteLine($"Test RPCService Url : http://127.0.0.1:{Convert.ToInt32(config.GetSection("Port").Value)}");
            Console.WriteLine($"MillisecondsTime : {Convert.ToInt32(config.GetSection("TimeSeconds").Value)}");
            Console.WriteLine($"TaskCount : {Convert.ToInt32(config.GetSection("TaskCount").Value)}");


            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress($"http://127.0.0.1:{config.GetSection("Port").Value}");

            Task.Run(async () =>
            {
                while (true)
                {
                    Task.Run(async () => {

                        number = number + 1;

                        Console.WriteLine($"Start RBAC client run count : {number} , time = {DateTime.Now}");

                        //B2CImage_ConveyB2CImageAsync(channel);
                        Media_SaveFrontendIcon(channel);                 
                    });
                }
                Thread.Sleep(Convert.ToInt32(config.GetSection("TimeSeconds").Value));
            });

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
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

        private static async Task B2CImage_ConveyB2CImageAsync(GrpcChannel channel)
        {
            var client = new B2CImage.B2CImageClient(channel);
            var reply = await client.ConveyB2CImageAsync(new ConveyB2CImageRequest
            {
                SalesMixId = 51972,
                //SalesMixId = 5005029,
                Platform = 3,
                ImageType = ConveyB2CImageRequest.Types.ImageType.All,
                Overwrite = true
            });

            Console.WriteLine("Response: " + JsonSerializer.Serialize(reply.Res));
        }

        private static async Task Media_SaveFrontendIcon(GrpcChannel channel)
        {
            using (FileStream fs = File.OpenRead("20200415test.png"))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);

                    var client = new Media.MediaClient(channel);

                    var reply = await client.SaveFrontendIconAsync(new SaveFrontendIconRequest
                    {

                        FilePath = "/ETMALLNAS/FrontendIcon/00000000/20200415test.png",
                        FileData = Google.Protobuf.ByteString.CopyFrom(ms.ToArray()),
                        Req = new REQ { Guid = Guid.NewGuid().ToString("N") }
                    });

                    Console.WriteLine("Response: " + JsonSerializer.Serialize(reply.Res));
                }
            }
        }
    }
}