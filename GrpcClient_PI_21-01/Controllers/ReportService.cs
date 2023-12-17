using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using Google.Protobuf.WellKnownTypes;

namespace GrpcClient_PI_21_01.Controllers
{
    public static class ReportService
    {
        private static async Task<List<Report>> GetReports(int page = -1, Filter<Report>? filter = null)
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



        public static async Task<Report> GenereteReport(DateTime start, DateTime finish)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);

            var request = new Report_FilterReply()
            {
                Id = -1,
                BeginDate = start.ToTimestamp(),
                EndDate = finish.ToTimestamp(),
                Actor = UserService.CurrentUser?.ToReply(),
            };
            var report = await client.GenerateReportAsync(request);
            return report.FromReply();
            //var rep = await GetReports(start, finish);
            //var otvRep = new List<string[]>();
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
    }
}
