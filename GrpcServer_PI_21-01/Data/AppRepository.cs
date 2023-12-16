using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GrpcServer_PI_21_01.Data
{

    internal class AppRepository : IRepository<App>
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<App>(req.Filter).GenerateSQLForCount();
                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {

                    cn.Open();
                    string count = "";
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        count = reader[0].ToString();
                    }
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
                throw ;
            }
        }

        public static bool UpdateApplication(App app)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE catch_request SET " +
                $"created_at = '{app.date}'," +
                $"territory = '{app.territory}'," +
                $"habitat = '{app.animalHabiat}'," +
                $"urgency = {app.urgencyOfExecution}," +
                $"descr = '{app.animaldescription}'," +
                $"client_category = '{app.applicantCategory}'," +
                $"cityid = '{app.locality.IdLocation}'," +
                $"status = '{app.status}'" +
                $" WHERE id = {app.number}")
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
                throw;
            }
        }

        public static bool AddApplication(App app)
        {
            try
            {
                // 'app' подаётся с Id = -1. После добавления в БД нужно присвоить
                // этому ссылочному значению новое Id, которое было присвоено самой БД
                //Applications.Add(app);
                using NpgsqlCommand cmd = new($"INSERT INTO catch_request " +
                    $"(created_at, territory, habitat, urgency, descr, client_category, cityid, status, organization_id)" +
                    $"VALUES ('{app.date}', '{app.territory}', '{app.animalHabiat}', {app.urgencyOfExecution}, " +
                    $"'{app.animaldescription}', '{app.applicantCategory}', '{app.locality.IdLocation}'," +
                    $" '{AppStatus.Registered}') RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    var returnValue = cmd.ExecuteScalar();
                    if (returnValue is not int id)
                        return false;
                    app.number = id;
                    //cmd.ExecuteNonQuery();
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

        public static bool RemoveApplication(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM catch_request WHERE id = {id}") { Connection = cn };
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

        //public static List<string[]> FilterByDate(string filter, string filter2)
        //{
        //    List<App> AppsFilter = GetApplications().Where(x => x.date >= DateTime.Parse(filter) && x.date <= DateTime.Parse(filter2)).ToList();
        //    List<string[]> apps = new();
        //    foreach (App app in AppsFilter)
        //    {
        //        var tempApp = new List<string>
        //        {
        //            app.date.ToString(),
        //            app.number.ToString(),
        //            app.locality.City,
        //            app.territory,
        //            app.animalHabiat,
        //            app.urgencyOfExecution,
        //            app.animaldescription,
        //            app.applicantCategory,
        //            App.EnumToString(app.status)
        //        };
        //        apps.Add(tempApp.ToArray());
        //    }
        //    return apps;
        //}

        public static List<App> GetApplications(DataRequest request)
        {
            try
            {
                var query = new Filter<App>(request.Filter).GenerateSQL(request.Page);

                List<App> apps = new();
                List<string?[]> appsEmpty = new();

                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        appsEmpty.Add(new string[10] {
                        reader[0].ToString(), //id
                        reader[1].ToString(), //date
                        reader[2].ToString(), //territory
                        reader[3].ToString(), //habitat
                        reader[4].ToString(), //urgency
                        reader[5].ToString(), //descr
                        reader[6].ToString(), //client_category
                        reader[7].ToString(), //locality
                        reader[8].ToString(), //status
                        reader[9].ToString() //orgid
                    });
                    }
                    reader.Close();
                    cn.Close();
                    for (int i = 0; i < appsEmpty.Count; i++)
                    {
                        var a = appsEmpty[i];
                        App app = new App(DateTime.Parse(a[1]), int.Parse(a[0]), LocationRepository.GetLocation(int.Parse(a[7])), a[2], a[3], a[4], a[5], a[6], Enum.Parse<AppStatus>(a[8]), OrgRepository.GetOrganization(int.Parse(a[9])));
                        apps.Add(app);
                        
                        
                    }
                }
                return apps;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static App? GetApplication(int id, bool connectionAlreadyOpen = false)
        {
            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM catch_request WHERE id = {id}");
                cmd.Connection = cn;
                if (!connectionAlreadyOpen)
                    cn.Open();
                var reader = cmd.ExecuteReader();
                string[] arr = { "0", "0", "0", "0", "0", "0", "0", "0" };
                while (reader.Read())
                {
                    arr[0] = (reader[1].ToString());
                    arr[1] = reader[7].ToString();
                    arr[2] = reader[2].ToString();
                    arr[3] = reader[3].ToString();
                    arr[4] = reader[4].ToString();
                    arr[5] = reader[5].ToString();
                    arr[6] = reader[6].ToString();
                    arr[7] = reader[8].ToString();
                    arr[8] = reader[9].ToString(); //orgid
                }
                var status = Enum.Parse<AppStatus>(arr[7]);
                reader.Close();
                if (!connectionAlreadyOpen)
                    cn.Close();
                if (arr[8] != null) {
                    return new App(DateTime.Parse(arr[0]), id, LocationRepository.GetLocation(int.Parse(arr[1])),
                    arr[2], arr[3], arr[4], arr[5], arr[6], status, OrgRepository.GetOrganization(int.Parse(arr[8])));
                }
                else
                {
                    return new App(DateTime.Parse(arr[0]), id, LocationRepository.GetLocation(int.Parse(arr[1])),
                arr[2], arr[3], arr[4], arr[5], arr[6], status, null);
                }
                
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public List<App> GetAll(DataRequest request)
        {
            return GetApplications(request);
        }
    }
}
