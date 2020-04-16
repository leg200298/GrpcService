using Grpc.Net.Client;
using SCMRPC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcClient.RPCService
{
    public  class B2CImageClient
    {
        public static async Task B2CImage_ConveyB2CImageAsync(GrpcChannel channel)
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
    }
}
