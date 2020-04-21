using Grpc.Net.Client;
using SCMRPC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcClient.RPCService
{
    public class B2CImageClient
    {
        public static async Task B2CImage_ConveyB2CImageAsync(GrpcChannel channel, ConveyB2CImageRequest request)
        {
            var client = new B2CImage.B2CImageClient(channel);
            var reply = await client.ConveyB2CImageAsync(new ConveyB2CImageRequest
            {
                SalesMixId = request.SalesMixId,
                Platform = request.Platform,
                ImageType = request.ImageType,
                Overwrite = request.Overwrite
            }, deadline: DateTime.Now.AddMinutes(2));

            Console.WriteLine("Response: " + JsonSerializer.Serialize(reply.Res));
        }
    }
}
