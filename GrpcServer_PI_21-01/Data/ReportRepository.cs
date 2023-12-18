﻿using Grpc.Core;
using GrpcServer_PI_21_01.Models;
using Npgsql;
using GrpcServer_PI_21_01.Services;

namespace GrpcServer_PI_21_01.Data
{
    internal class ReportRepository : IRepository<Report>
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


        public static Report GenereteReport(DataRequest request, DateTime start, DateTime finish, int id = -1)
        {
            if (request.Actor.PrivelegeLevel != "Operator_Po_Otlovy" && request.Actor.PrivelegeLevel != "Admin")
            {
                throw new RpcException(new Status(StatusCode.PermissionDenied, "У вас нет прав на это действие"));
            }

            var profit = 0.0;
            var animalsCount = 0;
            var closedApps = new List<App>();
            var org = request.Actor.Organization.FromReply();
            var actFilter = new Filter<Act>();
            actFilter.AddFilter(a => a.Organization, org.idOrg.ToString(), FilterType.Equals);
            var actFilterReply = new FilterReply();
            actFilter.ExtendReply(actFilterReply);
            var dataRequest = new DataRequest()
            {
                Actor = request.Actor,
                Filter = actFilterReply,
                Page = -1,
            };
            var acts = ActRepository.GetActs(dataRequest);

            foreach (var act in acts)
            {
                var actAppFilter = new Filter<ActApp>();
                actAppFilter.AddFilter(aa => aa.Act, act.ActNumber.ToString());
                var actAppFilterReply = new FilterReply();
                actAppFilter.ExtendReply(actAppFilterReply);
                var actAppRequest = new DataRequest()
                {
                    Actor = request.Actor,
                    Filter = actAppFilterReply,
                    Page = -1,
                };
                var actApps = ActRepository.GetActApps(actAppRequest);

                foreach (var actApp in actApps)
                {
                    var animalCount = actApp.CountDogs + actApp.CountCats;

                    var lcFilter = new Filter<Location_Contract>();
                    lcFilter.AddFilter(lc => lc.Contract, act.Contracts.IdContract.ToString());
                    lcFilter.AddFilter(lc => lc.Locality, actApp.Application.locality.IdLocation.ToString());
                    var lcFilterReply = new FilterReply();
                    lcFilter.ExtendReply(lcFilterReply);
                    var lcRequest = new DataRequest()
                    {
                        Actor = request.Actor,
                        Filter = lcFilterReply,
                        Page = -1,
                    };
                    var lcs = LocationRepository.GetLocationContracts(lcRequest);

                    var lc = lcs.Single(); // найден должен быть один единственный

                    profit += animalCount * (double)lc.Price;
                    animalsCount += animalCount;
                    if (!closedApps.Any(a => a.number == actApp.Application.number)
                        && actApp.Application.status == AppStatus.Fulfilled)
                    {
                        closedApps.Add(actApp.Application);
                    }
                }
            }

            return new Report(id, DateTime.Now, DateTime.Now, start, finish, profit, closedApps.Count, animalsCount,
                UserRepository.GetUserById(request.Actor.UserId), ReportStatus.Draft);
        }

        public static List<Report> GetReports(DataRequest r)
        {
            try
            {
                List<Report> reports= new();
                List<string?[]> reportsEmpty = new();
                var query = new Filter<Report>(r.Filter).GenerateSQLReport(r.Page);
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
        public List<Report> GetAll(DataRequest request)
        {
            return GetReports(request);
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

        public static Report? GetReport(int id, bool connectionAlreadyOpen = false)
        {
            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM report WHERE id = {id}");
                cmd.Connection = cn;
                cn.Open();
                var reader = cmd.ExecuteReader();
                string[] arr = { "0", "0", "0", "0", "0", "0", "0", "0" };
                while (reader.Read())
                {
                    arr[0] = (reader[1].ToString()); //createdat
                    arr[1] = reader[7].ToString(); //updatedat
                    arr[2] = reader[2].ToString(); //startdate
                    arr[3] = reader[3].ToString(); //enddate
                    arr[4] = reader[4].ToString(); //profit
                    arr[5] = reader[5].ToString(); //closed_apps_count
                    arr[6] = reader[6].ToString(); //animals_sount
                    arr[7] = reader[8].ToString(); //userId
                    arr[8] = reader[9].ToString(); //status
                }
                var status = Enum.Parse<AppStatus>(arr[7]);
                reader.Close();
                    cn.Close();
                return new Report(id, DateTime.Parse(arr[0]), DateTime.Parse(arr[1]), DateTime.Parse(arr[2]), DateTime.Parse(arr[3]), double.Parse(arr[4]),
                    int.Parse(arr[5]), int.Parse(arr[6]), UserRepository.GetUserById(int.Parse(arr[7])), Enum.Parse<ReportStatus>(arr[8]));

            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
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
