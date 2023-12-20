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
                PrivelegeLevel = PrivelegeLevel.ToString(),
                Organization = Organization.ToReply(),
            };
        }


    }
}
