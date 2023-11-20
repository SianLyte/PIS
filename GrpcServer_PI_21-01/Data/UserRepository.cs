using GrpcServer_PI_21_01.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Data
{
    class UserRepository
    {
        static readonly NpgsqlConnection cn = new NpgsqlConnection(DatabaseAssistant.ConnectionString);

        //private readonly static List<User> users = new()
        //                            {
        //                                new User(1, "UserOtlov", "ot", "Оператор по отлову"),
        //                                new User(2, "UserBET", "b", "Оператор вет. службы"),
        //                                new User(3, "UserOMCY", "o", "Оператор ОМСУ"),
        //                                new User(4, "User4", "4", "Сотрудник отлова"),
        //                                new User(5, "Admin", "Admin", "Admin")
        //                            };
        public static bool CheckUser(string login, string password)
        {
            var user = GetUsers().FirstOrDefault(x => x.Login == login);
            
            return user != null && user.Password == password;
        }

        public static User? GetUser(string login, string password)
        {
            var user = GetUsers().FirstOrDefault(x => x.Login == login);

            if (user != null && user.Password == password)
                return user;
            return null;
        }

        public static User GetUserById(int userId)
        {
            using var cmd = new NpgsqlCommand($"SELECT * FROM user WHERE " +
                $"user.UserId = {userId}")
            { Connection = cn };
            cn.Open();
            var reader = cmd.ExecuteReader();
            if (!reader.Read())
                throw new Exception("Userid " + userId + " not found in the database");
            var user = ExtractUserFromReaderInstance(userId, reader);
            cn.Close();
            return user;
        }

        public static List<User> GetUsers()
        {
            var users = new List<User>();
            using var cmd = new NpgsqlCommand($"SELECT * FROM user") { Connection = cn };
            cn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var userId = reader.GetInt32(reader.GetOrdinal("UserId"));

                var user = ExtractUserFromReaderInstance(userId, reader);
                users.Add(user);
            }
            cn.Close();

            return users;
        }

        private static User ExtractUserFromReaderInstance(int userId, NpgsqlDataReader reader)
        {
            var name = reader.GetString(reader.GetOrdinal("Name"));
            var surname = reader.GetString(reader.GetOrdinal("Surname"));
            var patronymic = reader.GetString(reader.GetOrdinal("Patronymic"));
            var privelegeLevel = reader.GetString(reader.GetOrdinal("PrivelegeLevel"));
            var login = reader.GetString(reader.GetOrdinal("Login"));
            var password = reader.GetString(reader.GetOrdinal("Password"));
            var org = Organization.GetById(reader.GetInt32(reader.GetOrdinal("OrganizationId")), cn);

            var user = new User(userId, login, password, privelegeLevel, name, surname, patronymic, org);
            return user;
        }
    }
}
   
