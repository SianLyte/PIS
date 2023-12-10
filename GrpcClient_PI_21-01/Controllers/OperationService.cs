using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using System.Xml.Linq;

namespace GrpcClient_PI_21_01.Controllers
{
    public class OperationService
    {
        public static async Task<List<Operation>> GetOperations(int page = -1, Filter<Operation>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetOperations(UserService.GenerateDataRequest(page, filter));
            var responseStream = serverData.ResponseStream;
            var ops = new List<Operation>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                ops.Add(response.FromReply());
            }
            return ops;
        }

        public static async Task<int> GetPageCount(int pageSize, Filter<Operation>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetOperationsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static string[] ToDataArray(Operation operation)
        {
            return new string[10] { operation.Actor.Surname.ToString(),
                                    operation.Actor.Name.ToString(),
                                    operation.Actor.Patronymic.ToString(),
                                    operation.Actor.Organization.name.ToString(),
                                    operation.Actor.PrivelegeLevel.ToString(),
                                    operation.Actor.Login.ToString(),
                                    operation.ActionDate.ToString(),
                                    operation.ModifiedObjectId.ToString(),
                                    operation.ActionType.ToString(),
                                    operation.ModifiedTableName.ToString()};

        }
    }
}
