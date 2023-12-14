using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GrpcServer_PI_21_01.Data
{
    internal class OrgRepository : IRepository<Organization>
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Organization>(req.Filter).GenerateSQLForCount();
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
                throw;
            }
        }

        public static bool UpdateOrganization(Organization org)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE organization SET " +
                $"namee = '{org.name}'," +
                $"inn = '{org.INN}'," +
                $"kpp = '{org.KPP}'," +
                $"registration = '{org.registrationAdress.IdLocation}'," +
                $"typee = '{org.type}'," +
                $"status = '{org.status}'" +
                $" WHERE id = {org.idOrg}")
                { Connection = cn };
                {
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                }
                // возвращаем true, если обновление произошло успешно,
                // вовзращаем false, если что-то пошло не так (например, контракта с таким Id не существует в БД)
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

        public static bool AddOrganization(Organization org)
        {
            try
            {
                // 'org' подаётся с Id = -1. После добавления в БД нужно присвоить
                // этому ссылочному значению новое Id, которое было присвоено самой БД
                //OrganizationsMas.Add(org);
                using NpgsqlCommand cmd = new($"INSERT INTO organization " +
                    $"(namee, inn, kpp, registration, typee, status)" +
                    $"VALUES ('{org.name}', '{org.INN}', '{org.KPP}', '{org.registrationAdress.IdLocation}', " +
                    $"'{org.type}', '{org.status}') RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    int returnValue = (int)cmd.ExecuteScalar();
                    org.idOrg = returnValue;
                    cn.Close();
                }

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

        public static bool RemoveOrganization(int id)
        {
            try
            {
                using NpgsqlCommand cmd = new($"DELETE FROM organization WHERE id = {id}") { Connection = cn };
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

        public static List<Organization> GetOrganizations(DataRequest r)
        {
            try
            {
                List<Organization> orgs = new();
                List<string?[]> orgsEmpty = new();
                var query = new Filter<Organization>(r.Filter).GenerateSQL(r.Page);


                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        orgsEmpty.Add(new string?[7] {
                    reader[0].ToString(), //id
                    reader[1].ToString(), //namee
                    reader[2].ToString(), //inn
                    reader[3].ToString(), //kpp
                    reader[4].ToString(), //registration
                    reader[5].ToString(), //typee
                    reader[6].ToString() //status
                    });
                    }
                    reader.Close();
                    cn.Close();

                    for (int i = 0; i < orgsEmpty.Count; i++)
                    {
                        var a = orgsEmpty[i];
                        Organization org = new Organization(int.Parse(a[0]), a[1], a[2], a[3],
                            LocationRepository.GetLocation(int.Parse(a[4])), Enum.Parse<OrganizationType>(a[5]), a[6]);
                        orgs.Add(org);
                    }

                }
                return orgs;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static Organization? GetOrganization(int id)
        {
            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM organization WHERE id = {id}") { Connection = cn };
                string[] arr = { "0", "0", "0", "0", "0", "0", "0" };
                cn.Open();

                var reader = cmd.ExecuteReader();
                if (!reader.Read()) throw new Exception("Unknown ID for organization: " + id);

                var name = reader.GetString(reader.GetOrdinal("namee"));
                var inn = reader.GetString(reader.GetOrdinal("inn"));
                var kpp = reader.GetString(reader.GetOrdinal("kpp"));
                var registrationAdress = reader.GetInt32(reader.GetOrdinal("registration"));
                var type = reader.GetString(reader.GetOrdinal("typee"));
                var status = reader.GetString(reader.GetOrdinal("status"));

                reader.Close();
                cn.Close();
                return new Organization(id, name, inn, kpp,
                    LocationRepository.GetLocation(registrationAdress),
                    Enum.Parse<OrganizationType>(type), status);
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public List<Organization> GetAll(DataRequest request)
        {
            return GetOrganizations(request);
        }
    }
}
