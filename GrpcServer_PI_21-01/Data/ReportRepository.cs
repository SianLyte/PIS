using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class ReportRepository
    {
        private static List<Report> reports = new();

        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static List<Report> GenereteReport(DateTime start, DateTime finish)
        {
            reports = new List<Report>();
            foreach (var loc in LocationRepository.GetLocations())
            { 
                var allSity = ActRepository.GetActs()
                    .Where(x => x.Application.locality == loc.City & x.Date >= start & x.Date <= finish);
                int summ = 0;
                foreach (var act in allSity)
                {
                    int contractId = act.Contracts.IdContract;
                    int localityId = loc.IdLocation;
                    summ += (double)Location_Contract.GetAnimalCost(localityId, contractId, cn).Price;
                }
                if (summ != 0)
                    reports.Add(new Report(start, finish, loc, apps.Count(), acts.Sum(x => x.Sum), summ));
            }
            return reports;
        }
    }
}
