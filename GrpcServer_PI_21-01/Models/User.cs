using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrpcServer_PI_21_01.Services;

namespace GrpcServer_PI_21_01.Models
{
    class User
    {
        public int IdUser { get; set; }
        public string Login {get; set;}
        public string Password { get; set; }
        public string PrivelegeLevel { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public Organization Organization { get; }

        public User(int idUser, string login, string password, string privelegeLevel,
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
    }
}
