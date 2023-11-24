//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;
using Grpc.Core;

namespace GrpcClient_PI_21_01.Controllers
{
    class AnimalCardService
    {
        //public static void AddAnimalCard(string[] animalCard)
        //{
        //    var otpAnimalCard = new AnimalCard(
        //        AnimalRepository.animalCards.Max(x => x.IdAnimalCard) + 1,
        //        animalCard[0], animalCard[1], animalCard[2],
        //        int.Parse(animalCard[3]), animalCard[4], animalCard[5],
        //        animalCard[6], animalCard[7], animalCard[8], animalCard[9],
        //        LocationCostReposiroty.locationCosts[LocationCostReposiroty.locationCosts.FindIndex(x => x.IdLocation == int.Parse(animalCard[10]))],
        //        ActRepository.acts[ActRepository.acts.FindIndex(x => x.ActNumber == int.Parse(animalCard[11]))], null);

        //    AnimalRepository.AddAnimalCard(otpAnimalCard);
        //}

        public static async Task<bool> AddAnimalCard(AnimalCard animalCard)
        {
            animalCard.IdAnimalCard = -1;
            var reply = animalCard.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddAnimalCardAsync(reply);
            animalCard.IdAnimalCard = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<List<AnimalCard>> GetAnimalCards()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetAnimalCards(UserService.CurrentUser?.ToReply());
            var responseStream = serverData.ResponseStream;
            var animalCards = new List<AnimalCard>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                animalCards.Add(response.FromReply());
            }
            return animalCards;
        }
    }
}
