using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Services;
using Npgsql;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("userr")]

    public class User
    {
        [Filterable("userid")]

        public int IdUser { get; set; }
        [Filterable("login")]

        public string Login {get; set;}
        [Filterable("password")]

        public string Password { get; set; }
        [Filterable("privelefelevel")]

        public Roles PrivelegeLevel { get; }
        [Filterable("name")]

        public string Name { get; }
        [Filterable("surname")]

        public string Surname { get; }
        [Filterable("patronymic")]

        public string Patronymic { get; }
        [Filterable("organizationid")]

        public Organization Organization { get; }

        public User(int idUser, string login, string password, Roles privelegeLevel,
            string name, string surname, string patronymic, Organization org)
        {
            IdUser = idUser;
            Login = login;
            Password = password;
            PrivelegeLevel = privelegeLevel;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Organization = org;
        }


        public UserReply ToReply()
        {
            return new UserReply()
            {
                UserId = IdUser,
                Login = Login,
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                PrivelegeLevel = PrivelegeLevel.ToString().Replace("_", " "),
                Organization = Organization.ToReply(),
            };
        }

        public static User GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM userr WHERE userid = {id}");
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            string[] arr = { "0", "0", "0", "0", "0", "0", "0" };
            while (reader.Read())
            {
                arr[0] = reader[5].ToString(); //login
                arr[1] = reader[6].ToString(); //password
                arr[2] = reader[4].ToString(); //privelege
                arr[3] = reader[1].ToString(); //name
                arr[4] = reader[2].ToString(); //surname
                arr[5] = reader[3].ToString(); //patronymic
                arr[6] = reader[7].ToString(); //organizationid
            }
            reader.Close();
            cn.Close();
            return new User(id, arr[0], arr[1], Role.ToString(arr[2]), arr[3], arr[4], arr[5], OrgRepository.GetOrganization(int.Parse(arr[6])));
        }
    }
}
