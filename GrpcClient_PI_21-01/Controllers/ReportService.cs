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
            var reports = new List<Report>();
            var acts = await ActService.GetActs();
            foreach (var loc in await LocationService.GetLocations())
            {
                // надо фиксануть в бд заявки, в ней должны быть int LocationId, а не string locality
                var allSity = acts
                    .Where(x => x.Application.locality == loc.City & x.Date >= start & x.Date <= finish);
                int summ = 0;
                foreach (var act in allSity)
                {
                    //summ += act.Contracts.Cost;
                    summ += 5;
                }
                if (summ != 0)
                    reports.Add(new Report(start, finish, loc, allSity.Count(), allSity.Sum(x => x.Sum), summ));
            }
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
