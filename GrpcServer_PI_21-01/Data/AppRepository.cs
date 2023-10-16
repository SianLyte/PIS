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

    internal class AppRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        // удалить, когда привяжем БД
        //private readonly static List<App> Applications = new()
        //{
        //    new App(DateTime.Parse("20-02-2023"), 1, "г. Тюмень", "р-н Ленинский", "около дома 10", "10", "Белая собака с черным ухом, порода неизвестна,", "Физ. лицо"),
        //    new App(DateTime.Parse("15-02-2023"), 2, "г. Тюмень","р-н Калининский", "около магазина Магнит", "15", "Рыжая собака", "Физ. лицо"),
        //    new App(DateTime.Parse("20-03-2023"), 3,"г. Сургут", "мкр. 10", "двор дома №6", "7", "Черная собака", "Физ. лицо")
        //};

        public static bool UpdateApplication(App app)
        {
            using NpgsqlCommand cmd = new($"UPDATE catch_request SET " +
                $"created_at = '{app.date}'," +
                $"territory = '{app.territory}'," +
                $"habitat = '{app.animalHabiat}'," +
                $"urgency = {app.urgencyOfExecution}," +
                $"descr = '{app.animaldescription}'," +
                $"client_category = '{app.applicantCategory}'," +
                $"locality = '{app.locality}'" +
                $" WHERE id = {app.number}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            // на вход получаем новую заявку, нам нужно найти в БД заявку с
            // ID = app.number и апдейтнуть его по всем остальным полям
            //var id = Applications.FindIndex(x => x.number == app.number);
            //Applications[id] = app;

            // возвращаем true, если обновление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, контракта с таким Id не существует в БД)
            return true;
        }

        public static bool AddApplication(App app)
        {
            // 'app' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД
            //Applications.Add(app);
            using NpgsqlCommand cmd = new($"INSERT INTO catch_request " +
                $"(created_at, territory, habitat, urgency, descr, client_category, locality)" +
                $"VALUES ('{app.date}', '{app.territory}', '{app.animalHabiat}', {app.urgencyOfExecution}, " +
                $"'{app.animaldescription}', '{app.applicantCategory}', '{app.locality}') RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                app.number = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
            return true;
        }

        public static bool RemoveApplication(int id)
        {
            // ~~old code~~ Applications.Remove(app);
            using NpgsqlCommand cmd = new($"DELETE FROM catch_request WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            //throw new NotImplementedException();
            return true;
            // возвращаем true, если удаление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, организации с таким Id не существует в БД)
        }

        public static List<string[]> FilterByDate(string filter, string filter2)
        {
            List<App> AppsFilter = GetApplications().Where(x => x.date >= DateTime.Parse(filter) && x.date <= DateTime.Parse(filter2)).ToList();
            List<string[]> apps = new();
            foreach (App app in AppsFilter)
            {
                var tempApp = new List<string>
                {
                    app.date.ToString(),
                    app.number.ToString(),
                    app.locality,
                    app.territory,
                    app.animalHabiat,
                    app.urgencyOfExecution,
                    app.animaldescription,
                    app.applicantCategory
                };
                apps.Add(tempApp.ToArray());
            }
            return apps;
        }

        public static List<App> GetApplications()
        {
            // должно забирать все заявки из БД (желательно сделать кэширование:
            // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
            // этого метода в течение 5 секунд возвращает кэшированное значение)
            // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
            List<App> apps = new();
            List<string?[]> appsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM catch_request") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    appsEmpty.Add(new string[8] {
                    reader[0].ToString(), //id
                    reader[1].ToString(), //date
                    reader[2].ToString(), //territory
                    reader[3].ToString(), //habitat
                    reader[4].ToString(), //urgency
                    reader[5].ToString(), //descr
                    reader[6].ToString(), //client_category
                    reader[7].ToString(), //locality
                    });
                }
                reader.Close();

                for (int i = 0; i < appsEmpty.Count; i++)
                {
                    var a = appsEmpty[i];
                    App app = new App(DateTime.Parse(a[1]), int.Parse(a[0]), a[7], a[2], a[3], a[4], a[5], a[6]);
                    apps.Add(app);
                }
                cn.Close();
            }
            return apps;
        }
    }
}
