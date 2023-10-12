using GrpcServer_PI_21_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class UserRepository
    {
        private readonly static List<User> users = new()
                                    {
                                        new User(1, "UserOtlov", "ot", "Оператор по отлову"),
                                        new User(2, "UserBET", "b", "Оператор вет. службы"),
                                        new User(3, "UserOMCY", "o", "Оператор ОМСУ"),
                                        new User(4, "User4", "4", "Сотрудник отлова"),
                                        new User(5, "Admin", "Admin", "Admin")
                                    };
        public static bool CheckUser(string login, string password)
        {
            var user = users.FirstOrDefault(x => x.Login == login);
            
            return user != null && user.Password == password;
        }

        public static User? GetUser(string login, string password)
        {
            var user = users.FirstOrDefault(x => x.Login == login);

            if (user != null && user.Password == password)
                return user;
            return null;
        }

        public static List<User> GetUsers()
        {
            return users;
        }
    }
}
   
