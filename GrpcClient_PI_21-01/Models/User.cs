using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class User
    {
        [Filterable("userid")]
        public int IdUser { get; set; }
        //public string Login {get; set;}
        //public string Password { get; set; }
        //public Role Role { get; }

        //public User (int idUser, string login, string password, Role role)
        //{
        //    IdUser = idUser;
        //    Login = login;
        //    Password = password;
        //    Role = role;
        //}
        [Filterable("privelegelevel")]

        public string PrivelegeLevel { get; }
        [Filterable("login")]

        public string Login { get; }
        [Filterable("organizationid")]

        public Organization Organization { get; }
        [Filterable("name")]

        public string Name { get; }
        [Filterable("surname")]

        public string Surname { get; }
        [Filterable("patronymic")]

        public string Patronymic { get; }

        public User(int idUser, string login, string privelegeLevel,
            string name, string surname, string patronymic, Organization org)
        {
            IdUser = idUser;
            PrivelegeLevel = privelegeLevel;
            Login = login;
            Organization = org;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
        }

        public UserReply ToReply()
        {
            return new UserReply()
            {
                Login = Login,
                Name = Name,
                Surname = Surname,
                Patronymic = Patronymic,
                Organization = Organization.ToReplyWithoutActor(),
                PrivelegeLevel = PrivelegeLevel,
                UserId = IdUser,
            };
        }

        public static User FromReply(UserReply r)
        {
            return new User(r.UserId,
                r.Login,
                r.PrivelegeLevel,
                r.Name,
                r.Surname,
                r.Patronymic,
                r.Organization.FromReply());
        }
    }
}
