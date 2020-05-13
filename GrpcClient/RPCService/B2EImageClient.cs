using Grpc.Net.Client;
using SCMRPC;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient.RPCService
{
    public class B2EImageClient
    {
        public static async Task B2EImage_CompressB2EImageAsync(GrpcChannel channel, CompressB2EImageRequest request)
        {
            var client = new B2EImage.B2EImageClient(channel);
            var reply = await client.CompressB2EImageAsync(new CompressB2EImageRequest
            {
                Path = request.Path,
                IsMain = request.IsMain == null || request.IsMain == false ? false : true,
                Outputpath = request.Outputpath
            }, deadline: DateTime.UtcNow.AddMinutes(2));
        }
    }
}
