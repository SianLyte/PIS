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
    class LocationRepository : IRepository<Location>
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);
        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Location>(req.Filter).GenerateSQLForCount();
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

        public static int GetLocationContractMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Location_Contract>(req.Filter).GenerateSQLForCount();
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

        public static List<Location> GetLocations(DataRequest req)
        {
            try
            {
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
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static Location GetLocation(int id)
        {
            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM city WHERE id = {id}");
                cmd.Connection = cn;
                cn.Open();

                var reader = cmd.ExecuteReader();
                if (!reader.Read()) throw new Exception("Unknown ID for location: " + id);
                var location = new Location(id, reader.GetString(reader.GetOrdinal("city")));

                reader.Close();
                cn.Close();

                return location;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static bool AddLocation(Location loc)
        {
            try
            {
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
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                return false;
                throw ;
            }
        }

        public static bool RemoveLocation(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM city WHERE id = {id}") { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                //throw new NotImplementedException();
                return true;
            }
            catch (Exception)
            {
                cn.Close();
                return false;
                throw new Exception();
            }

        }

        public static bool UpdateLocation(Location loc)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE city SET " +
                $"city = '{loc.City}' WHERE id = {loc.IdLocation}")
                { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                return true;
            }
            catch (Exception)
            {
                cn.Close();
                return false;
                throw new Exception();
            }
        }

        public static bool AddLocationContract(Location_Contract lc)
        {
            try
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
            catch (Exception)
            {
                cn.Close();
                return false;
                throw new Exception();
            }
        }

        public static bool UpdateLocationContract(Location_Contract lc)
        {
            try
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
            catch (Exception)
            {
                cn.Close();
                return false;
                throw new Exception();
            }
        }

        public static bool RemoveLocationContract(int id)
        {
            try
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
            catch (Exception)
            {
                cn.Close();
                return false;
                throw new Exception();
            }
        }

        public static Location_Contract GetLocationContract(int id)
        {
            try
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
                    return new Location_Contract(int.Parse(arr[0]), GetLocation(int.Parse(arr[2])), decimal.Parse(arr[0]), ContractRepository.GetContract(int.Parse(arr[1])));
                };
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static List<Location_Contract> GetLocationContracts(DataRequest r)
        {
            try
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
                        Models.Contract contract = ContractRepository.GetContract(int.Parse(lcEmpty[2]));
                        Location location = GetLocation(int.Parse(lcEmpty[3]));

                        Location_Contract lc = new Location_Contract(int.Parse(lcEmpty[0]), location, decimal.Parse(lcEmpty[1]), contract);
                        lcs.Add(lc);
                    }
                };
                return lcs;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public List<Location> GetAll(DataRequest request)
        {
            return GetLocations(request);
        }
    }
}
