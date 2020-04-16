using Grpc.Net.Client;
using SCMRPC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrpcClient.RPCService
{
    public class MediaClient
    {
        public static async Task Media_SaveFrontendIcon(GrpcChannel channel, SaveFrontendIconRequest request)
        {
            using (FileStream fs = File.OpenRead(Path.GetFileName(request.FilePath)))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fs.CopyTo(ms);

                    var client = new Media.MediaClient(channel);

                    var reply = await client.SaveFrontendIconAsync(new SaveFrontendIconRequest
                    {

                        FilePath = request.FilePath,
                        FileData = Google.Protobuf.ByteString.CopyFrom(ms.ToArray()),
                        Req = new REQ { Guid = Guid.NewGuid().ToString("N") }
                    });

                    Console.WriteLine("Response: " + JsonSerializer.Serialize(reply.Res));
                }
            }
        }
    }
}
