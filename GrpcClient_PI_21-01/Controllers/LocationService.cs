using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;
using Grpc.Core;

namespace GrpcClient_PI_21_01.Controllers
{
    internal class LocationService
    {
        public static Location GetLocationFromReply(LocationReply reply)
        {
            return new Location(reply.IdLocation, reply.City);
        }

        public static async Task<List<Location>> GetLocations()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetLocations(UserService.CurrentUser?.ToReply());
            var responseStream = serverData.ResponseStream;
            var locations = new List<Location>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                locations.Add(response.FromReply());
            }
            return locations;
        }

        public static async Task<int> GetPageCount(int pageSize, Filter<Location>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetLocationsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static async Task<List<Location_Contract>> GetLocationContracts()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetLocationContracts(UserService.CurrentUser?.ToReply());
            var responseStream = serverData.ResponseStream;
            var locationContractsList = new List<Location_Contract>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                locationContractsList.Add(response.FromReply());
            }
            return locationContractsList;
        }

        public static async Task<int> GetLocationContractPageCount(int pageSize, Filter<Location_Contract>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetLocationContractsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static async Task<Location_Contract> GetLocationContract(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.GetLocationContractAsync(new IdRequest()
            {
                Id = id,
                Actor = UserService.CurrentUser?.ToReply(),
            });
            return response.FromReply();
        }

        public static async Task<bool> AddLocation(Location loc)
        {
            loc.IdLocation = -1;
            var reply = loc.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddLocationAsync(reply);
            loc.IdLocation = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> AddLocationContract(Location_Contract lc)
        {
            lc.Id = -1;
            var reply = lc.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddLocationContractAsync(reply);
            lc.Id = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> UpdateLocationContract(Location_Contract lc)
        {
            var reply = lc.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.UpdateLocationContractAsync(reply);
            return response.Successful;
        }

        public static async Task<bool> RemoveLocationContract(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.RemoveLocationContractAsync(new IdRequest()
            {
                Id = id,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return response.Successful;
        }
    }
}
