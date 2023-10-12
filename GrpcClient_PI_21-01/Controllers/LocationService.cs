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
            var serverData = client.GetLocations(new Google.Protobuf.WellKnownTypes.Empty());
            var responseStream = serverData.ResponseStream;
            var locations = new List<Location>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                locations.Add(response.FromReply());
            }
            return locations;
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
    }
}
