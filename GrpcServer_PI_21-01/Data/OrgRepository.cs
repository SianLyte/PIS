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
    internal class OrgRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection("Host=localhost;Username=postgres;Password=123;Database=animal_capture;");

        // это удалить после привязки БД
        //private readonly static List<Organization> OrganizationsMas = new()
        //{
        //    new Organization(1,"МКУ «ЛесПаркХоз»", "3664069397", "770201001", "г. Сургут", "Коммерческий", "действующее"),
        //    new Organization(2,"ГосОтлов", "9574637594","770495001", "г. Тюмень", "Государственная организация", "действующее"),
        //    new Organization(3,"ПРОО «Общество защиты животных»", "5769384756", "720294631", "г. Тюмень", "Коммерческий", "действующее")
        //};

        public static bool UpdateOrganization(Organization org)
        {
            // на вход получаем новую организацию, нам нужно найти в БД организацию с
            // ID = org.idOrg и апдейтнуть его по всем остальным полям
            //var IdOrg = OrganizationsMas.FindIndex(x => x.idOrg == org.idOrg);
            
            //OrganizationsMas[IdOrg] = org;
            using NpgsqlCommand cmd = new($"UPDATE organization SET " +
                $"namee = '{org.name}'," +
                $"inn = '{org.INN}'," +
                $"kpp = '{org.KPP}'," +
                $"registration = '{org.registrationAdress}'," +
                $"typee = '{org.type}'" +
                $"status = '{org.status}'" +
                $" WHERE id = {org.idOrg}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

            // возвращаем true, если обновление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, контракта с таким Id не существует в БД)
            return true;
        }

        public static bool AddOrganization(Organization org)
        {
            // 'org' подаётся с Id = -1. После добавления в БД нужно присвоить
            // этому ссылочному значению новое Id, которое было присвоено самой БД
            //OrganizationsMas.Add(org);
            using NpgsqlCommand cmd = new($"INSERT INTO organization " +
                $"(namee, inn, kpp, registration, typee, status)" +
                $"VALUES ('{org.name}', '{org.INN}', '{org.KPP}', '{org.registrationAdress}', " +
                $"'{org.type}', '{org.status}') RETURNING id")
            { Connection = cn };
            {
                cn.Open();
                int returnValue = (int)cmd.ExecuteScalar();
                org.idOrg = returnValue;
                //cmd.ExecuteNonQuery();
                cn.Close();
            }

            // возвращаем true, если добавление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, поле, которое не может быть null, вдруг стало null)
            return true;
        }

        public static bool RemoveOrganization(int id)
        {
            // ~~old code~~ OrganizationsMas.Remove(organization);
            using NpgsqlCommand cmd = new($"DELETE FROM organizataion WHERE id = {id}") { Connection = cn };
            {
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }
            // возвращаем true, если удаление произошло успешно,
            // вовзращаем false, если что-то пошло не так (например, организации с таким Id не существует в БД)
            return true;
        }

        public static List<Organization> GetOrganizations()
        {
            // должно забирать все организации из БД (желательно сделать кэширование:
            // один раз читается и результат сохраняется на, например, 5 секунд, т.е. любой вызов
            // этого метода в течение 5 секунд возвращает кэшированное значение)
            // P.S. кэширование должно очищаться после выполнения других действий CRUD кроме Read
            List<Organization> orgs = new();
            List<string?[]> orgsEmpty = new();

            using (NpgsqlCommand cmd = new("SELECT * FROM organization") { Connection = cn })
            {
                cn.Open();
                NpgsqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orgsEmpty.Add(new string[7] {
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

                for (int i = 0; i < orgsEmpty.Count; i++)
                {
                    var a = orgsEmpty[i];
                    Organization org = new Organization(int.Parse(a[0]), a[1], a[2], a[3], a[4], a[5], a[6]);
                    orgs.Add(org);
                }
                cn.Close();
            }
            return orgs;
        }
    }
}
