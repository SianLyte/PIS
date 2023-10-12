using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    class User
    {
        public int IdUser { get; set; }
        public string Login {get; set;}
        public string Password { get; set; }
        public string PrivelegeLevel { get; }


        public User(int idUser, string login, string password, string privelegeLevel) {
            IdUser = idUser;
            Login = login;
            Password = password;
            PrivelegeLevel = privelegeLevel;
        }
    }
}
