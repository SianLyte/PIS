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
        static readonly NpgsqlConnection cn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=123;Database=animal_capture;");

        // это удалить когда БД будет привязана
        //private readonly static List<Contract> contract = new()
        //{ 
        //    new Contract(1, DateTime.Parse("02.05.2023"), DateTime.Parse("05.05.2023"), 
        //        LocationRepository.GetLocations()[0], 1000, 
        //        OrgRepository.GetOrganizations()[0], OrgRepository.GetOrganizations()[1]),

        //    new Contract(2, DateTime.Parse("12.05.2023"), DateTime.Parse("15.05.2023"), 
        //        LocationRepository.GetLocations()[1], 2000, 
        //        OrgRepository.GetOrganizations()[1], OrgRepository.GetOrganizations()[1]),

        //    new Contract(3, DateTime.Parse("10.05.2023"), DateTime.Parse("19.05.2023"),
        //        LocationRepository.GetLocations()[2], 1550,
        //        OrgRepository.GetOrganizations()[2], OrgRepository.GetOrganizations()[1]),

        //    new Contract(4, DateTime.Parse("20.05.2023"), DateTime.Parse("25.05.2023"),
        //        LocationRepository.GetLocations()[0], 2100,
        //        OrgRepository.GetOrganizations()[0], OrgRepository.GetOrganizations()[2])
        //};

        public static bool UpdateContract(Contract c)
        {
            using NpgsqlCommand cmd = new($"UPDATE municipal_contract SET " +
                $"created_at = '{c.ActionDate}'," +
                $"validity_date = '{c.DateConclusion}'," +
                $"customer_id = {c.Costumer.idOrg}," +
                $"performer_id = {c.Executer.idOrg}," +
                $" WHERE id = {c.IdContract}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            // на вход получаем новый контракт, нам нужно найти в БД контракт с
            // ID = cont.IdContract и апдейтнуть его по всем остальным полям
            //var index = contract.FindIndex(x => x.IdContract == cont.IdContract); // старый код, на замену
            //contract[index] = cont; // старый код, на замену

            // возвращаем true, если обновление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, контракта с таким Id не существует в БД)
            return true;
        }

        public static bool AddContract(Contract c)
        {
            // 'cont' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД
            using NpgsqlCommand cmd = new($"INSERT INTO municipal_contract " +
                $"(created_at, validity_date, customer_id, performer_id)" +
                $"VALUES ('{c.ActionDate}', '{c.DateConclusion}', {c.Costumer.idOrg}, {c.Executer.idOrg}) RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                c.IdContract = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }
            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
            return true;
        }

        public static bool DeleteContract(int id)
        {
            // contract.Remove(cont); // старый код, на замену
            using NpgsqlCommand cmd = new($"DELETE FROM municipal_contract WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //throw new NotImplementedException();
            return true;    
            // возвращаем true, если удаление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, контракта с таким Id не существует в БД)
            return true;
        }

        public static List<Contract> GetContracts()
        {
            // должно забирать все контракты из БД (желательно сделать кэширование:
            // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
            // этого метода в течение 5 секунд возвращает кэшированное значение)
            // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
            List<Contract> contracts = new();
            List<string?[]> contractsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM municipal_contract") { Connection = cn })
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

                for (int i = 0; i < contractsEmpty.Count; i++)
                {
                    var a = contractsEmpty[i];
                    Contract contract = new (
                        int.Parse(a[0]),
                        DateTime.Parse(a[1]),
                        DateTime.Parse(a[2]), 
                        Organization.GetById(int.Parse(a[3]),cn),
                        Organization.GetById(int.Parse(a[4]), cn));
                    contracts.Add(contract);
                }
                cn.Close();
            }
            return contracts;
        }
    }
}
