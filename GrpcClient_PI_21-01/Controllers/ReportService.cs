using GrpcClient_PI_21_01.Models;

namespace GrpcClient_PI_21_01.Controllers
{
    class ReportService
    {
        private static async Task<List<Report>> GetReports(DateTime start, DateTime finish)
        {
            var reports = new List<Report>();
            foreach (var loc in await LocationService.GetLocations())
            {
                var allSity = (await ActService.GetActs())
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
                    item.Loc.City,
                    item.Close.ToString(),
                    item.CountAnumals.ToString(),
                    item.Sum.ToString()
                };
                otvRep.Add(old);
            }
            return otvRep;
        }
    }
}
