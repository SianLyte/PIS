using Grpc.Core;
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

        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Report>(req.Filter).GenerateSQLForCount();
                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {

                    cn.Open();
                    string count = "";
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                        count = reader[0].ToString();
                    reader.Close();
                    cn.Close();
                    var a = Math.Ceiling((decimal)int.Parse(count) / req.Page);
                    return (int)a;
                };
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public static Report GenereteReport(DateTime start, DateTime finish)
        {
            double profit = 0;
            int animalsCount = 0;
            int closedAppsCount = 0;
            reports = new List<Report>();
            var request = new DataRequest()
            {
                Filter = new FilterReply(),
                Page = -1,
            };
            if (request.Actor.PrivelegeLevel != "Operator_Po_Otlovy")
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "У вас нет прав на это действие"));
            }
            foreach (var loc in LocationRepository.GetLocations(request))

            {
                //все заявки_акты за определнный период в конкретном городе по организации оператора
                var allActApps = ActRepository.GetActApps(request)
                    .Where(actapp => actapp.Act.Date >= start & 
                    actapp.Act.Date <= finish & 
                    actapp.Application.locality.IdLocation == loc.IdLocation &
                    actapp.Act.Organization.idOrg == request.Actor.Organization.IdOrganization);
                //массив уникальных актов
                List<Act> acts = new();
                //массив уникальных 
                List<App> apps = new();
                foreach (var actapp in allActApps)
                {
                    closedAppsCount += 1;
                    if (!acts.Contains(actapp.Act))
                    {
                        acts.Add(actapp.Act);
                    }
                    if (!apps.Contains(actapp.Application))
                    {
                        apps.Add(actapp.Application);
                    }
                }
                
                foreach (var act in acts)
                {
                    int contractId = act.Contracts.IdContract;
                    int localityId = loc.IdLocation;
                    profit += (double)Location_Contract.GetAnimalCost(localityId, contractId, cn).Price;
                    animalsCount += act.CountCats;
                    animalsCount += act.CountDogs;
                }

                //if (summ != 0)
                //    reports.Add(new Report(start, finish, loc, apps.Count(), acts.Sum(x => x.Sum), summ, ReportStatus.Revision, DateTime.Now));
            }
            return new Report(-1, DateTime.Now, DateTime.Now, start, finish, profit, closedAppsCount,
                animalsCount, UserRepository.GetUserById(request.Actor.UserId), ReportStatus.ApprovalFromMunicipalContractExecutor);
        }

        public static List<Report> GetReports(DataRequest r)
        {
            try
            {
                List<Report> reports= new();
                List<string?[]> reportsEmpty = new();
                var query = new Filter<Report>(r.Filter).GenerateSQL(r.Page);
                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        reportsEmpty.Add(new string?[10] {
                    reader[0].ToString(), //id
                    reader[1].ToString(), //created_at
                    reader[2].ToString(), //updated_at
                    reader[3].ToString(), //start_date
                    reader[4].ToString(), //end_date
                    reader[5].ToString(), //profit
                    reader[6].ToString(), //closed_apps_count
                    reader[7].ToString(), //animals_count
                    reader[8].ToString(), //user_id
                    reader[9].ToString(), //status
                    });
                    }
                    reader.Close();
                    cn.Close();

                    for (int i = 0; i < reportsEmpty.Count; i++)
                    {
                        var a = reportsEmpty[i];
                        Report report= new Report(int.Parse(a[0]), DateTime.Parse(a[1]), DateTime.Parse(a[2]), DateTime.Parse(a[3]),
                            DateTime.Parse(a[4]), double.Parse(a[5]), int.Parse(a[6]), int.Parse(a[7]), UserRepository.GetUserById(int.Parse(a[8])),
                            Enum.Parse<ReportStatus>(a[9]));
                        reports.Add(report);
                    }

                }
                return reports;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static bool AddReport(Report rep)
        {

            try
            {
                // 'rep' подаётся с Id = -1. Присвоить новое Id, которое было присвоено самой БД
                using NpgsqlCommand cmd = new($"INSERT INTO report " +
                    $"(created_at, updated_at, start_date, end_date, profit, closed_apps_count, animals_count, user_id, status)" +
                    $"VALUES ('{rep.CreatedAt}', '{rep.UpdatedAt}', '{rep.StartDate}', '{rep.EndDate}', {rep.Profit}, {rep.ClosedAppsCount}, {rep.AnimalsCount}, " +
                    $"{rep.User.IdUser}, '{ReportStatus.ApprovalFromMunicipalContractExecutor}') RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    int returnValue = (int)cmd.ExecuteScalar();
                    rep.Id= returnValue;
                    cn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
        }

        public static bool UpdateReport(Report rep)
        {
            if (rep.User.PrivelegeLevel == Roles.Curator_Po_Otlovy && (rep.Status == ReportStatus.ApprovedByMunicipalContractExecutor || rep.Status == ReportStatus.Revision))
            {
                ; ; ;
            }
            else if (rep.User.PrivelegeLevel == Roles.Podpisant_Po_Otlovy && (rep.Status == ReportStatus.Revision || rep.Status == ReportStatus.AgreedWithMunicipalContractExecutor))
            {
                ; ; ;
            }
            else if (rep.User.PrivelegeLevel == Roles.Curator_OMSY && (rep.Status == ReportStatus.Revision || rep.Status == ReportStatus.ApprovedByOmsy))
            {
                ; ; ;
            }
            else
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "У вас нет прав на это"));
            }

            try
            {
                using NpgsqlCommand cmd = new($"UPDATE report SET " +
                $"created_at = '{rep.CreatedAt}'," +
                $"updated_at = '{rep.UpdatedAt}'," +
                $"start_date = '{rep.StartDate}'," +
                $"end_date = '{rep.EndDate}'," +
                $"profit = {rep.Profit}," +
                $"closed_apps_count = {rep.ClosedAppsCount}," +
                $"animals_count = {rep.AnimalsCount}," +
                $"user_id = {rep.User.IdUser}," +
                $"status = '{rep.Status}'" +
                $" WHERE id = {rep.Id}")
                { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                //throw;
                throw new RpcException(new Status(StatusCode.PermissionDenied, e.Message));
            }
        }

        public static bool RemoveReport(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM report WHERE id = {id}") { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
        }
    }
}
