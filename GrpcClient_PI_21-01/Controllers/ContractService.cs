//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;
using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Controllers
{
    internal class ContractService
    {
        //public static List<string[]> ShowContract(string filter1, string filter2)
        //{
        //    List<string[]> contracts = stringMassChencher(ContractRepository.ShowCont(filter1, filter2));
        //    return contracts;
        //}

        //public static void EditCont(string[] ContData)
        //{
        //    var conData = new Contract(int.Parse(ContData[0]), 
        //                          DateTime.Parse(ContData[1]), DateTime.Parse(ContData[2]),
        //                          LocationCostReposiroty.locationCosts[LocationCostReposiroty.locationCosts.FindIndex(x => x.IdLocation == int.Parse(ContData[3]))],
        //                          int.Parse(ContData[4]),
        //                          OrgRepository.Organizations[OrgRepository.Organizations.FindIndex(x => x.idOrg == int.Parse(ContData[5]))],
        //                          OrgRepository.Organizations[OrgRepository.Organizations.FindIndex(x => x.idOrg == int.Parse(ContData[6]))]);
        //    ContractRepository.EditContractData(conData);
        //}
        //public static void DeleteContract(string cont)
        //{
        //    foreach (Contract contract in ContractRepository.contract)
        //        if (contract.IdContract == int.Parse(cont))
        //        {
        //            ContractRepository.DeleteContract(contract);
        //            break;
        //        }
        //}

        //public static void AddContract(Contract cont)
        //{
        //    ContractRepository.SaveAdd(cont);
        //}

        public static List<string[]> stringMassChencher(IEnumerable<Contract> contracts)
        {
            var result = new List<string[]>();
            foreach (Contract contract in contracts)
            {
                var oldContract = new List<string>
                {
                    contract.IdContract.ToString(),
                    contract.DateConclusion.ToString(),
                    contract.ActionDate.ToString(),
                    contract.Executer.name,
                    contract.Costumer.name
                };
                result.Add(oldContract.ToArray());
            }
            return result;
        }

        public static string[] ToDataArray(Contract contr)
        {
            return new string[]
            {
                contr.IdContract.ToString(),
                contr.DateConclusion.ToString(),
                contr.ActionDate.ToString(),
                contr.Executer.name,
                contr.Costumer.name
            };
        }

        public static Contract GetContractFromReply(ContractReply reply)
        {
            return new Contract(
                reply.IdContract,
                reply.DateConclusion.ToDateTime(),
                reply.ActionDate.ToDateTime(),
                LocationService.GetLocationFromReply(reply.LocationCost),
                reply.Cost,
                OrgService.GetOrganizationFromReply(reply.Costumer),
                OrgService.GetOrganizationFromReply(reply.Executer)
                );
        }

        public static async Task<IEnumerable<Contract>> GetContracts()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var contracts = await client.GetContractsAsync(new Google.Protobuf.WellKnownTypes.Empty());
            return contracts.Contracts.Select(cr => GetContractFromReply(cr));
        } 
        
        public static async Task<Contract> GetContract(int contrId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var contr = await client.GetContractAsync(new IdRequest() { Id = contrId });
            return contr.FromReply();
        }

        public static async Task<bool> RemoveContract(int contrId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.RemoveContractAsync(new IdRequest() { Id = contrId });
            return response.Successful;
        }

        public static async Task<bool> AddContract(Contract contr)
        {
            contr.IdContract = -1;
            var reply = contr.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.AddContractAsync(reply);
            contr.IdContract = response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> UpdateContract(Contract contr)
        {
            var reply = contr.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new DataRetriever.DataRetrieverClient(channel);
            var response = await client.UpdateContractAsync(reply);
            return response.Successful;
        }
    }
}
