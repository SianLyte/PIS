using Grpc.Core;
using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using Google.Protobuf.WellKnownTypes;
using Microsoft.Office.Interop.Excel;
using System.Linq.Expressions;

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
        public static string[] ToDataArray(Report rep)
        {
            return new string[]
            {
                    rep.Id.ToString(),
                    rep.CreatedAt.ToString(),
                    rep.UpdatedAt.ToString(),
                    rep.StartDate.ToString(),
                    rep.EndDate.ToString(),
                    rep.Profit.ToString(),
                    rep.AnimalsCount.ToString(),
                    rep.ClosedAppsCount.ToString(),
                    rep.User.Name.ToString(),
                    rep.Status.ToString()
            };
        }

        public static async void FillDataGrid(List<Report> reports, DataGridView dgv)
        {
            static Expression<Func<Report, object>> exp(Expression<Func<Report, object>> exp) => exp;

            // preparting columns
            dgv.Columns[0].Tag = exp(a => a.Id);
            dgv.Columns[1].Tag = exp(a => a.CreatedAt);
            dgv.Columns[2].Tag = exp(a => a.UpdatedAt);
            dgv.Columns[3].Tag = exp(a => a.StartDate);
            dgv.Columns[4].Tag = exp(a => a.EndDate);
            dgv.Columns[5].Tag = exp(a => a.Profit);
            dgv.Columns[6].Tag = exp(a => a.AnimalsCount);
            dgv.Columns[7].Tag = exp(a => a.ClosedAppsCount);
            dgv.Columns[8].Tag = exp(a => a.User.Name);
            dgv.Columns[9].Tag = exp(a => a.Status);
            foreach (DataGridViewColumn c in dgv.Columns)
                c.SortMode = DataGridViewColumnSortMode.Programmatic;

            // filling in data
            reports.ForEach(a => dgv.Rows.Add(ToDataArray(a)));
        }

        public static async Task<Report> GenereteReport(DateTime start, DateTime finish)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new ReportGenerator.ReportGeneratorClient(channel);

            var request = new Report_FilterReply()
            {
                Id = -1,
                BeginDate = start.ToUtc().ToTimestamp(),
                EndDate = finish.ToUtc().ToTimestamp(),
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
