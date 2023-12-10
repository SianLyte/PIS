using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class ContractRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static int GetMaxPage(DataRequest req)
        {
            try
            {
                var query = new Filter<Contract>(req.Filter).GenerateSQLForCount();
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

        public static bool UpdateContract(Contract c)
        {
            try
            {
                using NpgsqlCommand cmd = new($"UPDATE municipal_contract SET " +
                                $"created_at = '{c.DateConclusion}'," +
                                $"validity_date = '{c.ActionDate}'," +
                                $"customer_id = {c.Costumer.idOrg}," +
                                $"performer_id = {c.Executer.idOrg}," +
                                $" WHERE id = {c.IdContract}")
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
                throw ;
            }
        }

        public static bool AddContract(Contract c)
        {
            try
            {
                // 'cont' подаётся с Id = -1. После добавления в БД нужно присвоить
                // этому ссылочному значению новое Id, которое было присвоено самой БД
                using NpgsqlCommand cmd = new($"INSERT INTO municipal_contract " +
                    $"(created_at, validity_date, customer_id, performer_id)" +
                    $"VALUES ('{c.DateConclusion}', '{c.ActionDate}', {c.Costumer.idOrg}, {c.Executer.idOrg}) RETURNING id")
                { Connection = cn };
                {
                    cn.Open();
                    int returnValue = (int)cmd.ExecuteScalar();
                    c.IdContract = returnValue;
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

        public static bool DeleteContract(int id)
        {
            try
            {
                // contract.Remove(cont); // старый код, на замену
                using NpgsqlCommand cmd = new($"DELETE FROM municipal_contract WHERE id = {id}") { Connection = cn };
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

        public static List<Contract> GetContracts(DataRequest request)
        {
            try
            {
                var query = new Filter<Contract>(request.Filter).GenerateSQL(request.Page);

                List<Contract> contracts = new();
                List<string?[]> contractsEmpty = new();

                using (NpgsqlCommand cmd = new(query) { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        contractsEmpty.Add(new string[5] {
                    reader[0].ToString(), //id
                    reader[1].ToString(), //created_at
                    reader[2].ToString(), //validity_date
                    reader[3].ToString(), //customer_id
                    reader[4].ToString() //performer_id
                    });
                    }
                    reader.Close();
                    cn.Close();
                    for (int i = 0; i < contractsEmpty.Count; i++)
                    {
                        var a = contractsEmpty[i];
                        Contract contract = new(
                            int.Parse(a[0]),
                            DateTime.Parse(a[1]),
                            DateTime.Parse(a[2]),
                            OrgRepository.GetOrganization(int.Parse(a[3])),
                            OrgRepository.GetOrganization(int.Parse(a[4])));
                        contracts.Add(contract);
                    }
                }
                return contracts;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }

        public static Contract? GetContract(int id)
        {
            try
            {
                NpgsqlCommand cmd = new($"SELECT * FROM municipal_contract WHERE id = {id}");
                cmd.Connection = cn;
                cn.Open();

                var reader = cmd.ExecuteReader();
                if (!reader.Read()) throw new Exception("Unknown ID for Contract: " + id);

                var createdAt = reader.GetDateTime(reader.GetOrdinal("created_at"));
                var overAt = reader.GetDateTime(reader.GetOrdinal("validity_date"));
                var performerId = reader.GetInt32(reader.GetOrdinal("performer_id"));
                var customerId = reader.GetInt32(reader.GetOrdinal("customer_id"));

                reader.Close();
                cn.Close();

                return new Contract(id, createdAt, overAt,
                    OrgRepository.GetOrganization(performerId),
                    OrgRepository.GetOrganization(customerId));
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw ;
            }
        }
    }
}
