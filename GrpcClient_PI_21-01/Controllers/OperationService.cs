using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Controllers
{
    public class OperationService
    {
        public static async Task<List<OperationReply>> GetOperations()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetOperations(UserService.CurrentUser?.ToReply());
            var responseStream = serverData.ResponseStream;
            var ops = new List<OperationReply>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                ops.Add(response);
            }
            return ops;
        }
    }
}
