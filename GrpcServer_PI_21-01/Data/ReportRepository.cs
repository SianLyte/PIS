﻿using GrpcServer_PI_21_01.Models;
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
                //все заявки_акты за определнный период в конкретном городе
                var allActApps = ActRepository.GetActApps().Where(actapp => actapp.Act.Date >= start & actapp.Act.Date <= finish & actapp.Application.locality == loc.City);
                //массив уникальных актов
                List<Act> acts = new(); 
                //массив уникальных 
                List<App> apps = new();
                foreach (var actapp in allActApps)
                {
                    if (!acts.Contains(actapp.Act))
                    {
                        acts.Add(actapp.Act);
                    }
                    if (!apps.Contains(actapp.Application))
                    {
                        apps.Add(actapp.Application);
                    }
                }
                int summ = 0;
                foreach (var act in acts)
                {
                    int contractId = act.Contracts.IdContract;
                    int localityId = loc.IdLocation;
                    summ += (int)Location_Contract.GetAnimalCost(localityId, contractId, cn).Price;
                }
                if (summ != 0)
                    reports.Add(new Report(start, finish, loc, apps.Count(), acts.Sum(x => x.Sum), summ));
            }
            return reports;
        }
    }
}
