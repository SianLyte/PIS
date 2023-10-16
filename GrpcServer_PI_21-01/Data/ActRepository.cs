using GrpcServer_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Hosting;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;

namespace GrpcServer_PI_21_01.Data
{
    class ActRepository

    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);
        // удалить это, когда будет прикручена БД
        //private readonly static List<Act> acts = new()
        //{
        //    new Act(1, 4, 0, OrgRepository.GetOrganizations()[0], DateTime.Parse("01-06-23"), "Отловить 4 собаки",
        //            AppRepository.GetApplications()[0], ContractRepository.GetContracts()[1]),

        //    new Act(2, 0, 4, OrgRepository.GetOrganizations()[1], DateTime.Parse("02-06-23"), "Отловить 4 кошки",
        //            AppRepository.GetApplications()[1], ContractRepository.GetContracts()[0]),

        //    new Act(3, 3, 2, OrgRepository.GetOrganizations()[2], DateTime.Parse("03-06-23"), "Отловить 3 собаки и 2 кошки",
        //            AppRepository.GetApplications()[2], ContractRepository.GetContracts()[1]),
        //};

        public static bool UpdateAct(Act actData)
        {
            using NpgsqlCommand cmd = new($"UPDATE act SET " +
                $"dog_count = {actData.CountDogs}," +
                $"cat_count = {actData.CountCats}," +
                $"organization_id = {actData.Organization.idOrg}," +
                $"created_at = '{actData.Date.ToString()}'," +
                $"goal = '{actData.TargetCapture}'," +
                $"catch_request_id = {actData.Application.number}," +
                $"municipal_contract_id = {actData.Contracts.IdContract}" +
                $" WHERE id = {actData.ActNumber}") { Connection = cn };
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

        public static bool AddAct(Act A)
        {
            using NpgsqlCommand cmd = new($"INSERT INTO act " +
                $"(dog_count, cat_count, organization_id, created_at," +
                $" goal, catch_request_id, municipal_contract_id) " +
                $"VALUES ({A.CountDogs}, {A.CountCats}, {A.Organization.idOrg}, '{A.Date}', '{A.TargetCapture}'" +
                $"{A.Application.number}, {A.Contracts.IdContract}) RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                A.ActNumber = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }
            // 'A' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД
            //acts.Add(A);

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
            return true;
        }

        public static bool RemoveAct(int choosedAct)
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

        public static List<Act> GetActs()
        {
            // должно забирать все акты отлова из БД (желательно сделать кэширование:
            // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
            // этого метода в течение 5 секунд возвращает кэшированное значение)
            // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
            List<Act> acts = new();
            List<string?[]> actsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM act") {Connection = cn})
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actsEmpty.Add(new string[8] {
                    reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString() });
                }
                reader.Close();

                for (int i = 0; i < actsEmpty.Count; i++)
                {
                    var actEmpty = actsEmpty[i];
                    Organization org = Organization.GetById(int.Parse(actEmpty[3]), cn);
                    App app = App.GetById(int.Parse(actEmpty[6].ToString()), cn);
                    Contract contr = Contract.GetById(int.Parse(actEmpty[7]), cn);
                    Act act = new Act(int.Parse(actEmpty[0]),
                        int.Parse(actEmpty[1]),
                        int.Parse(actEmpty[2]),
                        org,
                        DateTime.Parse(actEmpty[4]),
                        actEmpty[5],
                        app,
                        contr);
                    acts.Add(act);
                }
                cn.Close();
            };
            return acts;
        }

    }
}
