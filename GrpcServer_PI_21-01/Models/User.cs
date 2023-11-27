using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcServer_PI_21_01.Services;
using Npgsql;

namespace GrpcServer_PI_21_01.Models
{
    public class User
    {
        public int IdUser { get; set; }
        public string Login {get; set;}
        public string Password { get; set; }
        public Roles PrivelegeLevel { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
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
                Organization = Organization.ToReply(),
            };
        }

        public static User GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM userr WHERE id = {id}");
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
            return new User(id, arr[0], arr[1], Role.ToString(arr[2]), arr[3], arr[4], arr[5], Organization.GetById(int.Parse(arr[6]), cn));
        }
    }
}
