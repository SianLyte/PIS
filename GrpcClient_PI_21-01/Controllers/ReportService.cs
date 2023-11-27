using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using Google.Protobuf.WellKnownTypes;

namespace GrpcClient_PI_21_01.Controllers
{
    class ReportService
    {
        private static async Task<List<Report_ActCapture>> GetReports(DateTime start, DateTime finish)
        {
            var reports = new List<Report_ActCapture>();
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);
            var serverData = client.Generate_ActCaptureReport(new FilterReply()
            {
                Actor = UserService.CurrentUser?.ToReply(),
                BeginDate = start.ToUtc().ToTimestamp(),
                EndDate = start.ToUtc().ToTimestamp(),
            });
            var responseStream = serverData.ResponseStream;
            await foreach (var response in responseStream.ReadAllAsync())
                reports.Add(response);
            return reports;

        }



        public static async Task<List<string[]>> GenereteReport(DateTime start, DateTime finish)
        {
            var rep = await GetReports(start, finish);
            var otvRep = new List<string[]>();
            foreach (var item in rep)
            {
                var old = new string[]
                {
                    //item.DateStart.ToString(),
                    //item.DateFinish.ToString(),
                    item.Locality.City,
                    item.ClosedAppCount.ToString(),
                    item.CapturedAnimalsCount.ToString(),
                    item.Summary.ToString("F2")
                };
                otvRep.Add(old);
            }
            return otvRep;
        }
    }
}
