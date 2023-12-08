//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Controllers;
using Grpc.Net.Client;
using Grpc.Core;

namespace GrpcClient_PI_21_01
{
    internal static class ActService
    {
        //public static List<string[]> ShowAct(string filter)
        //{
        //    List<string[]> acts = stringMassChencher(ActRepository.ShowAct(filter));
        //    return acts;
        //}

        //public static void EditAct(string[] takedActData)
        //{
        //    var actData = new Act(
        //        int.Parse(takedActData[0]),
        //        int.Parse(takedActData[1]), int.Parse(takedActData[2]),
        //        OrgRepository.Organizations[OrgRepository.Organizations.FindIndex(x => x.idOrg == int.Parse(takedActData[3]))],
        //        DateTime.Parse(takedActData[4]), takedActData[5],
        //        AppRepository.Applicatiions[AppRepository.Applicatiions.FindIndex(x => x.number == int.Parse(takedActData[6]))],
        //        ContractRepository.contract[ContractRepository.contract.FindIndex(x => x.IdContract == int.Parse(takedActData[7]))]);
        //    ActRepository.SaveActData(actData);
        //}

        //public static void DeleteAct(int choosedAct)
        //{
        //    ActRepository.Delete(choosedAct);
        //}

        //public static void Save(string[] A)
        //{
        //    var actData = new Act(
        //       ActRepository.acts.Max(x => x.ActNumber) + 1,
        //       int.Parse(A[0]), int.Parse(A[1]),
        //       OrgRepository.Organizations[OrgRepository.Organizations.FindIndex(x => x.idOrg == int.Parse(A[2]))],
        //       DateTime.Parse(A[3]), A[4],
        //       AppRepository.Applicatiions[AppRepository.Applicatiions.FindIndex(x => x.number == int.Parse(A[5]))],
        //       ContractRepository.contract[ContractRepository.contract.FindIndex(x => x.IdContract == int.Parse(A[6]))]);
        //    ActRepository.Save(actData);
        //}

        //private static List<string[]> stringMassChencher(List<Act> acts)
        //{
        //    var result = new List<string[]>();
        //    foreach (Act act in acts)
        //    {
        //        var oldAct = new List<string>
        //        {
        //            act.ActNumber.ToString(),
        //            act.CountDogs.ToString(),
        //            act.CountCats.ToString(),
        //            act.Organization.name,
        //            act.Date.ToShortDateString(),
        //            act.TargetCapture,
        //            act.Application.number.ToString(),
        //            act.Contracts.IdContract.ToString()
        //        };
        //        result.Add(oldAct.ToArray());
        //    }
        //    return result;
        //}

        public static string[] ToDataArray(Act act)
        {
            return new string[]
            {
                    act.ActNumber.ToString(),
                    act.CountDogs.ToString(),
                    act.CountCats.ToString(),
                    act.Organization.name,
                    act.Date.ToShortDateString(),
                    act.TargetCapture,
                    act.Contracts.IdContract.ToString()
            };
        }

        public static Act GetActFromReply(ActReply reply)
        {
            return new Act(
                reply.ActNumber,
                reply.CountDogs,
                reply.CountCats,
                OrgService.GetOrganizationFromReply(reply.Organization),
                reply.Date.ToDateTime(),
                reply.TargetCapture,
                ContractService.GetContractFromReply(reply.Contract));
        }

        public static async Task<List<Act>> GetActs(int page = -1, Filter<Act>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetActs(UserService.GenerateDataRequest(page, filter));
            var responseStream = serverData.ResponseStream;
            var acts = new List<Act>();
            var tasks = new List<Task>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                tasks.Add(Task.Run(() => acts.Add(GetActFromReply(response))));
            }
            await Task.WhenAll(tasks);
            return acts;
        }

        public static async Task<int> GetPageCount(int pageSize, Filter<Act>? filter)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var pageCount = await client.GetActsPageCountAsync(UserService.GenerateDataRequest(pageSize, filter));
            return pageCount.Count;
        }

        public static async Task<Act> GetAct(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var actReply = await client.GetActAsync(new IdRequest()
            {
                Id = id,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return GetActFromReply(actReply);
        }

        public static async Task<bool> UpdateAct(Act updatedAct)
        {
            var reply = updatedAct.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.UpdateActAsync(reply);
            return response.Successful;
        }

        public static async Task<bool> AddAct(Act newAct)
        {
            newAct.ActNumber = -1;
            var reply = newAct.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddActAsync(reply);
            newAct.ActNumber = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> RemoveAct(int actId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.RemoveActAsync(new IdRequest()
            {
                Id = actId,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return response.Successful;
        }

        public static async Task<bool> AddActApp(ActApp aa)
        {
            var actApp = aa.ToReply();
            actApp.Id = -1;
            actApp.Actor = UserService.CurrentUser?.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddActAppsAsync(actApp);
            actApp.Id = response.ModifiedId ?? -1;
            aa.ActAppNumber = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> UpdateActApp(ActApp actApp)
        {
            var reply = actApp.ToReply();
            reply.Actor = UserService.CurrentUser?.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.UpdateActAppsAsync(reply);
            return response.Successful;
        }

        public static async Task<bool> RemoveActApp(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.RemoveActAppsAsync(new IdRequest()
            {
                Id = id,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return response.Successful;
        }

        public static async Task<ActApp> GetActApp(int id)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var actApp = await client.GetActAppAsync(new IdRequest()
            {
                Id = id,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return actApp.FromReply();
        }

        public static async Task<List<ActApp>> GetActApps(int page = -1, Filter<ActApp>? filter = null)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var serverData = client.GetActApps(UserService.GenerateDataRequest(page, filter));
            var responseStream = serverData.ResponseStream;
            var actApps = new List<ActApp>();
            await foreach (var response in responseStream.ReadAllAsync())
            {
                actApps.Add(response.FromReply());
            }
            return actApps;
        }
    }
}
