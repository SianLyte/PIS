﻿using GrpcServer_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Microsoft.Extensions.Hosting;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Xml.Linq;

namespace GrpcServer_PI_21_01.Data
{
    class ActRepository

    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        public static bool UpdateAct(Act actData)
        {
            using NpgsqlCommand cmd = new($"UPDATE act SET " +
                $"dog_count = {actData.CountDogs}," +
                $"cat_count = {actData.CountCats}," +
                $"organization_id = {actData.Organization.idOrg}," +
                $"created_at = '{actData.Date.ToString()}'," +
                $"goal = '{actData.TargetCapture}'," +
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
                $" goal, municipal_contract_id) " +
                $"VALUES ({A.CountDogs}, {A.CountCats}, {A.Organization.idOrg}, '{A.Date}', '{A.TargetCapture}'," +
                $" {A.Contracts.IdContract}) RETURNING id")
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

        public static List<Act> GetActs(DataRequest request)
        {
            var query = new Filter<Act>(request.Filter).GenerateSQL(request.Page);

            List<Act> acts = new();
            List<string?[]> actsEmpty = new();

            using (NpgsqlCommand cmd = new(query) {Connection = cn})
            {
                cn.Open();
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
                    Organization org = Organization.GetById(int.Parse(actEmpty[3]), cn);
                    Contract contr = Contract.GetById(int.Parse(actEmpty[6]), cn);
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

        public static ActApp GetActApp(int id)
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
                }
                reader.Close();
                cn.Close();
                return new ActApp(int.Parse(arr[0]), Act.GetById(int.Parse(arr[1]), cn), App.GetById(int.Parse(arr[2]), cn));

            };

        }

        public static List<ActApp> GetActApps()
        {
            List<ActApp> actsApps = new();
            List<string?[]> actsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM act_catch_request") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actsEmpty.Add(new string[3] {
                        reader[0].ToString(), //id
                        reader[1].ToString(), //act_id
                        reader[2].ToString()  //app_id
                    });
                }
                reader.Close();
                cn.Close();
                for (int i = 0; i < actsEmpty.Count; i++)
                {
                    var actEmpty = actsEmpty[i];
                    App app = App.GetById(int.Parse(actEmpty[2].ToString()), cn);
                    Act act = Act.GetById(int.Parse(actEmpty[1]), cn);
                    actsApps.Add(new ActApp(int.Parse(actEmpty[0]), act, app));
                }
            };
            return actsApps;
        }

        public static bool AddActApp(ActApp actApp)
        {
            using NpgsqlCommand cmd = new($"INSERT INTO act_catch_request " +
                $"(act_id, catch_request_id) " +
                $"VALUES ({actApp.Act.ActNumber}, {actApp.Application.number}) RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                actApp.ActAppNumber = returnValue;
                cn.Close();
            }
            // 'A' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
            return true;
        }

        public static bool UpdateActApp(ActApp actApp)
        {
            using NpgsqlCommand cmd = new($"UPDATE act_catch_request SET " +
                $"act_id = {actApp.Act.ActNumber}," +
                $"catch_request_id = {actApp.Application.number}" +
                $" WHERE id = {actApp.ActAppNumber}")
            { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            return true;
        }

        public static bool RemoveActAppp(int id)
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

        public static Act? GetAct(int id)
        {
            throw new NotImplementedException();
        }
    }
}
