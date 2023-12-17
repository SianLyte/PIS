using GrpcServer_PI_21_01.Models;
using Npgsql;

namespace GrpcServer_PI_21_01.Data
{
    public class ActRepository : IRepository<Act>
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static bool UpdateAct(Act actData)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE act SET " +
                    $"dog_count = {actData.CountDogs}," +
                    $"cat_count = {actData.CountCats}," +
                    $"organization_id = {actData.Organization.idOrg}," +
                    $"created_at = '{actData.Date}'," +
                    $"goal = '{actData.TargetCapture}'," +
                    $"municipal_contract_id = {actData.Contracts.IdContract}" +
                    $" WHERE id = {actData.ActNumber}")
                { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                // на вход получаем новый акт отлова, нам нужно найти в БД акт отлова с
                // ID = actData.ActNumber и апдейтнуть его по всем остальным полям
                //var index = acts.FindIndex(x => x.ActNumber == actData.ActNumber);
                //acts[index] = actData;
                // возвращаем true, если обновление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, акт отлова с таким Id не существует в БД)
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

        public static bool AddAct(Act A)
        {
            try
            {
                using NpgsqlCommand cmd = new($"INSERT INTO act " +
                    $"(dog_count, cat_count, organization_id, created_at," +
                    $" goal, municipal_contract_id) " +
                    $"VALUES ({A.CountDogs}, {A.CountCats}, {A.Organization.idOrg}, '{A.Date}', '{A.TargetCapture}'," +
                    $" {A.Contracts.IdContract}) RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    int returnValue = (int)cmd.ExecuteScalar();
                    A.ActNumber = returnValue;
                    cn.Close();
                }
                // 'A' подаётся с Id = -1. После добавления в БД нужно присвоить
                // этому ссылочному значению новое Id, которое было присвоено самой БД
                //acts.Add(A);
                // возвращаем true, если добавление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
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

        public static bool RemoveAct(int choosedAct)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM act WHERE id = {choosedAct}") { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                //var index = acts.FindIndex(x => x.ActNumber == choosedAct);
                //acts.RemoveAt(index);
                // возвращаем true, если удаление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, акт отлова с таким Id не существует в БД)
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw ;
            }
        }

        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Act>(req.Filter).GenerateSQLForActCount();
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

        public static int GetActAppMaxPage(DataRequest xXxXxThe_request420xXxXx)
        {
            try
            {
                var query = new Filter<ActApp>(xXxXxThe_request420xXxXx.Filter).GenerateSQLForActCount();
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
                    var a = Math.Ceiling((decimal)int.Parse(count) / xXxXxThe_request420xXxXx.Page);
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

        public static List<Act> GetActs(DataRequest request)
        {
            try
            {
                var query = new Filter<Act>(request.Filter).GenerateSQLAct(request.Page);

                List<Act> acts = new();
                List<string?[]> actsEmpty = new();

                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    //cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                    actsEmpty.Add(new string[7] {
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString() });
                    }
                    reader.Close();
                    cn.Close();
                    
                    for (int i = 0; i < actsEmpty.Count; i++)
                    {
                        var actEmpty = actsEmpty[i];
                        Organization org = OrgRepository.GetOrganization(int.Parse(actEmpty[3]));
                        Contract contr = ContractRepository.GetContract(int.Parse(actEmpty[6]));
                        Act act = new Act(int.Parse(actEmpty[0]),
                            int.Parse(actEmpty[1]),
                            int.Parse(actEmpty[2]),
                            org,
                            DateTime.Parse(actEmpty[4]),
                            actEmpty[5],
                            contr);
                        acts.Add(act);
                    }
                };
                return acts;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static ActApp GetActApp(int id)
        {
            try
            {
                string[] arr = { "0", "0", "0" };

                using (NpgsqlCommand cmd = new($"SELECT * FROM act_catch_request WHERE id = {id}") { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        arr[0] = reader[0].ToString();
                        arr[1] = reader[1].ToString();
                        arr[2] = reader[2].ToString();
                        arr[3] = reader[3].ToString();
                        arr[4] = reader[4].ToString();
                    }
                    reader.Close();
                    cn.Close();
                    return new ActApp(int.Parse(arr[0]), GetAct(int.Parse(arr[1])), AppRepository.GetApplication(int.Parse(arr[2])), int.Parse(arr[3]), int.Parse(arr[4]));
                };
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static List<ActApp> GetActApps(DataRequest r)
        {
            try
            {
                var query = new Filter<ActApp>(r.Filter).GenerateSQL(r.Page);
                List<ActApp> actsApps = new();
                List<string?[]> actsEmpty = new();

                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        actsEmpty.Add(new string[5] {
                        reader[0].ToString(), //id
                        reader[1].ToString(), //act_id
                        reader[2].ToString(),  //app_id
                        reader[3].ToString(), //dogs
                        reader[4].ToString()  //cats
                    });
                    }
                    reader.Close();
                    cn.Close();
                    for (int i = 0; i < actsEmpty.Count; i++)
                    {
                        var actEmpty = actsEmpty[i];
                        App app = AppRepository.GetApplication(int.Parse(actEmpty[2].ToString()));
                        Act act = GetAct(int.Parse(actEmpty[1]));
                        actsApps.Add(new ActApp(int.Parse(actEmpty[0]), act, app, int.Parse(actEmpty[3]), int.Parse(actEmpty[4])));
                    }
                };
                return actsApps;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static bool CheckCatchedAnimals(App app)
        {
            try
            {
                using NpgsqlCommand cmd = new($"SELECT count_dogs, count_cats FROM act_catch_request WHERE catch_request_id = {app.number} ")
                { Connection = cn };
                {
                    var AppCatchedAnimals = 0;
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        AppCatchedAnimals += int.Parse(reader[3].ToString());
                        AppCatchedAnimals += int.Parse(reader[4].ToString());
                    };
                    reader.Close();
                    cn.Close();
                    if (AppCatchedAnimals >= app.animalCount)
                    {
                        var a = new App(app.date, app.number, app.locality, app.territory, app.animalHabiat, app.urgencyOfExecution,
                            app.animaldescription, app.applicantCategory, AppStatus.Fulfilled, app.organization, app.animalCount);
                        AppRepository.UpdateApplication(a);
                        return true;
                    }
                    return false;
                }
                
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw;
            }
        }

        public static bool AddActApp(ActApp actApp)
        {

            try
            {
                using NpgsqlCommand cmd = new($"INSERT INTO act_catch_request " +
                $"(act_id, catch_request_id, count_dogs, count_cats) " +
                $"VALUES ({actApp.Act.ActNumber}, {actApp.Application.number}, {actApp.CountDogs}, {actApp.CountCats}) RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    int returnValue = (int)cmd.ExecuteScalar();
                    actApp.ActAppNumber = returnValue;
                    cn.Close();
                }
                CheckCatchedAnimals(actApp.Application);
                
                // 'A' подаётся с Id = -1. После добавления в БД нужно присвоить
                // этому ссылочному значению новое Id, которое было присвоено самой БД

                // возвращаем true, если добавление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw ;
            }
        }

        public static bool UpdateActApp(ActApp actApp)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE act_catch_request SET " +
                $"act_id = {actApp.Act.ActNumber}," +
                $"catch_request_id = {actApp.Application.number}," +
                $"count_dogs = {actApp.CountDogs}," +
                $"count_cats = {actApp.CountCats}" +
                $" WHERE id = {actApp.ActAppNumber}")
                { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                CheckCatchedAnimals(actApp.Application);
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw ;
            }
        }

        public static bool RemoveActAppp(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM act_catch_request WHERE id = {id}") { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                //var index = acts.FindIndex(x => x.ActNumber == choosedAct);
                //acts.RemoveAt(index);
                // возвращаем true, если удаление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, акт отлова с таким Id не существует в БД)
                return true;
            }
            catch (Exception e)
            {
                
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw ;
            }
        }

        public static Act? GetAct(int id)
        {
            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM act WHERE id = {id}");
                cmd.Connection = cn;
                    cn.Open();

                var reader = cmd.ExecuteReader();
                if (!reader.Read()) throw new Exception("Unknown ID for act: " + id);

                var dogCount = reader.GetInt32(reader.GetOrdinal("dog_count"));
                var catCount = reader.GetInt32(reader.GetOrdinal("cat_count"));
                var orgId = reader.GetInt32(reader.GetOrdinal("organization_id"));
                var createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                var goal = reader.GetString(reader.GetOrdinal("goal"));
                var contrId = reader.GetInt32(reader.GetOrdinal("municipal_contract_id"));

                reader.Close();
                    cn.Close();

                return new Act(id, dogCount, catCount,
                    OrgRepository.GetOrganization(orgId),
                    createdAt, goal,
                    ContractRepository.GetContract(contrId));
            }
            catch (Exception e)   
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public List<Act> GetAll(DataRequest request)
        {
            return GetActs(request);
        }
    }
}
