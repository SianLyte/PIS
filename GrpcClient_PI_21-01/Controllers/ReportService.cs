using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Office.Interop.Excel;

namespace GrpcClient_PI_21_01.Controllers
{
    public static class ReportService
    {
        public static async Task<List<Report>> GetReports(int page = -1, Filter<Report>? filter = null)
        {
            var reports = new List<Report>();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);
            var serverData = client.GetReports(UserService.GenerateDataRequest(page, filter));
            //{
            //    Actor = UserService.CurrentUser?.ToReply(),
            //    BeginDate = start.ToUtc().ToTimestamp(),
            //    EndDate = finish.ToUtc().ToTimestamp(),
            //});
            var responseStream = serverData.ResponseStream;
            await foreach (var response in responseStream.ReadAllAsync())
                reports.Add(response.FromReply());
            return reports;
        }

        public static async Task<Report> GenereteReport(DateTime start, DateTime finish, int id = -1)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);
            var serverData =await  client.GenerateReportAsync(new Report_FilterReply()
            {
                Id = id,
                BeginDate = start.ToTimestamp(),
                EndDate = finish.ToTimestamp(),
                Actor = UserService.CurrentUser?.ToReply()
            });
            var report = serverData.FromReply();
            return report;
            
            //foreach (var item in rep)
            //{
            //    var old = new string[]
            //    {
            //        //item.DateStart.ToString(),
            //        //item.DateFinish.ToString(),
            //        item.Locality.City,
            //        item.ClosedAppCount.ToString(),
            //        item.CapturedAnimalsCount.ToString(),
            //        item.Summary.ToString("F2")
            //    };
            //    otvRep.Add(old);
            //}
            //return otvRep;
        }
        public static async Task<bool> RemoveReport(int reportId)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);
            var response = await client.RemoveReportAsync(new IdRequest()
            {
                Id = reportId,
                Actor = UserService.CurrentUser?.ToReply()
            });
            return response.Successful;
        }

        public static async Task<bool> AddReport(Report rep)
        {
            rep.Id = -1;
            var reply = rep.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);
            var response = await client.AddReportAsync(reply);
            rep.Id= response.ModifiedId ?? -1;
            return response.Successful;
        }

        public static async Task<bool> UpdateReport(Report rep)
        {
            var reply = rep.ToReply();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);
            var response = await client.UpdateReportAsync(reply);
            return response.Successful;
        }
    }
}
