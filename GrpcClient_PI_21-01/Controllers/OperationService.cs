using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;

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

        public static async Task<int> GetPageCount(int pageSize, Filter<OperationReply>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetOperationsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }
    }
}
