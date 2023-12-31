﻿//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using GrpcClient_PI_21_01.Controllers;
using Grpc.Net.Client;
using Grpc.Core;
using System.Linq.Expressions;

namespace GrpcClient_PI_21_01
{
    internal static class ActService
    {
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

        public static void FillDataGrid(List<Act> acts, DataGridView dgv)
        {
            static Expression<Func<Act, object>> exp(Expression<Func<Act, object>> exp) => exp;

            // preparting columns
            dgv.Columns[0].Tag = exp(a => a.ActNumber);
            dgv.Columns[1].Tag = exp(a => a.CountDogs);
            dgv.Columns[2].Tag = exp(a => a.CountCats);
            dgv.Columns[3].Tag = exp(a => a.Organization);
            dgv.Columns[4].Tag = exp(a => a.Date);
            dgv.Columns[5].Tag = exp(a => a.TargetCapture);
            dgv.Columns[6].Tag = exp(a => a.Contracts);
            foreach (DataGridViewColumn c in dgv.Columns)
                c.SortMode = DataGridViewColumnSortMode.Programmatic;

            // filling in data
            acts.ForEach(a => dgv.Rows.Add(ToDataArray(a)));
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
