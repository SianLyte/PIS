using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class LocationRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        // это удалить когда БД будет привязана
        //private readonly static List<Location> locationCosts = new()
        //{ new Location(1, "г. Тюмень"), 
        //    new Location(2, "г. Тобольск"),
        //    new Location(3, "г. Сургут")};

        public static int GetMaxPage(DataRequest req)
        {
            var query = new Filter<Location>(req.Filter).GenerateSQLForCount();
            using (NpgsqlCommand cmd = new("SELECT count(*) from city") { Connection = cn })
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

        public static int GetLocationContractMaxPage(DataRequest uest)
        {
            throw new NotImplementedException();
        }

        public static List<Location> GetLocations(DataRequest req)
        {
            // должно забирать все местности из БД (желательно сделать кэширование:
            // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
            // этого метода в течение 5 секунд возвращает кэшированное значение)
            // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
            var query = new Filter<Location>(req.Filter).GenerateSQL(req.Page);
            List<Location> locs = new();
            List<string?[]> locsEmpty = new();

            using (NpgsqlCommand cmd = new(query) { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    locsEmpty.Add(new string?[2] {
                    r[0].ToString(), //id
                    r[1].ToString(), //city
                    });
                }
                r.Close();
                cn.Close();
                for (int i = 0; i < locsEmpty.Count; i++)
                {
                    var a = locsEmpty[i];
                    Location loc = new(int.Parse(a[0]), a[1]);
                    locs.Add(loc);
                }
                
            }
            return locs;
        }

        public static Location GetLocation(int id)
        {
            throw new NotImplementedException();
        }

        public static bool AddLocation(Location loc)
        {
            // 'loc' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД
            using NpgsqlCommand cmd = new($"INSERT INTO city " +
                $"(city)" +
                $"VALUES ('{loc.City}') RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                loc.IdLocation = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
        }

        public static bool RemoveLocation(int id)
        {
            using NpgsqlCommand cmd = new($"DELETE FROM city WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //throw new NotImplementedException();
            return true;

            // возвращаем true, если удаление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, местности с таким Id не существует в БД)
        }

        public static bool UpdateLocation(Location loc)
        {
            // на вход получаем новую местность, нам нужно найти в БД местность с
            // ID = loc.IdLocation и апдейтнуть его по всем остальным полям
            using NpgsqlCommand cmd = new($"UPDATE city SET " +
                $"city = '{loc.City}' WHERE id = {loc.IdLocation}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;

            // возвращаем true, если обновление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, местности с таким Id не существует в БД)
        }

        public static bool AddLocationContract(Location_Contract lc)
        {
            // не забудь присовить переменной lc id после добавления в бд
            using NpgsqlCommand cmd = new($"INSERT INTO city_contract " +
                $"(cost, contract_id, city_id)" +
                $"VALUES ({lc.Price}, {lc.Contract.IdContract}, {lc.Locality.IdLocation}) RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                lc.Id = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;
        }

        public static bool UpdateLocationContract(Location_Contract lc)
        {
            using NpgsqlCommand cmd = new($"UPDATE city_contract SET " +
                $"cost = {lc.Price}," +
                $"contract_id = {lc.Contract.IdContract}," +
                $"city_id = {lc.Locality.IdLocation}" +
                $" WHERE id = {lc.Id}")
            { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;
        }

        public static bool RemoveLocationContract(int id)
        {
            using NpgsqlCommand cmd = new($"DELETE FROM city_contract WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //throw new NotImplementedException();
            return true;
        }

        public static Location_Contract GetLocationContract(int id)
        {
            string?[] arr = { "0", "0", "0" };

            using (NpgsqlCommand cmd = new($"SELECT * FROM city_contract WHERE id = {id}") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    arr[0] = reader[1].ToString(); //cost
                    arr[1] = reader[2].ToString(); //cotractid
                    arr[2] = reader[3].ToString(); //locid
                }
                reader.Close();
                cn.Close();
                return new Location_Contract(int.Parse(arr[0]), Location.GetById(int.Parse(arr[2]), cn), decimal.Parse(arr[0]), Models.Contract.GetById(int.Parse(arr[1]), cn));
            };
        }

        public static List<Location_Contract> GetLocationContracts(DataRequest r)
        {
            var query = new Filter<Location_Contract>(r.Filter).GenerateSQL(r.Page);
            List<Location_Contract> lcs = new();
            List<string?[]> lcsEmpty = new();

            using (NpgsqlCommand cmd = new(query) { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    lcsEmpty.Add(new string?[4] {
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString()});
                }
                reader.Close();
                cn.Close();
                for (int i = 0; i < lcsEmpty.Count; i++)
                {
                    var lcEmpty = lcsEmpty[i];
                    Models.Contract contract = Models.Contract.GetById(int.Parse(lcEmpty[2]), cn);
                    Location location = Location.GetById(int.Parse(lcEmpty[3]), cn);

                    Location_Contract lc = new Location_Contract(int.Parse(lcEmpty[0]), location, decimal.Parse(lcEmpty[1]), contract);
                    lcs.Add(lc);
                }
            };
            return lcs;
        }
    }
}
