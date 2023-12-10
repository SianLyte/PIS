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

        //new User(1, "UserOtlov", "ot", "Оператор по отлову"),
        //new User(2, "UserBET", "b", "Оператор вет. службы"),
        //new User(3, "UserOMCY", "o", "Оператор ОМСУ"),
        //new User(4, "User4", "4", "Сотрудник отлова"),
        //new User(5, "Admin", "Admin", "Admin")
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
            try
            {
                using var cmd = new NpgsqlCommand($"SELECT * FROM userr WHERE " +
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
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public static List<User> GetUsers()
        {
            try
            {
                List<User> users = new();
                List<string?[]> usersEmpty = new();

                using (NpgsqlCommand cmd = new("SELECT * FROM userr") { Connection = cn })
                {
                    cn.Open();
                    NpgsqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        usersEmpty.Add(new string?[8] {
                    reader[0].ToString(), //id
                    reader[1].ToString(), //name
                    reader[2].ToString(), //surname
                    reader[3].ToString(), //patron
                    reader[4].ToString(), //role
                    reader[5].ToString(), //login
                    reader[6].ToString(), //password
                    reader[7].ToString() //orgId
                    });
                    }
                    reader.Close();
                    cn.Close();
                    for (int i = 0; i < usersEmpty.Count; i++)
                    {
                        var userEmpty = usersEmpty[i];
                        Organization org = OrgRepository.GetOrganization(int.Parse(userEmpty[7]));

                        User user = new User(int.Parse(userEmpty[0]),
                            userEmpty[5],
                            userEmpty[6],
                            Role.ToString(userEmpty[4]),
                            userEmpty[1], userEmpty[2],
                            userEmpty[3], org);
                        users.Add(user);
                    }

                };
                return users;
            }
            catch (Exception e)
            {
                cn.Close();
                Console.WriteLine(e.Message);
                throw;
            }
        }

        private static User ExtractUserFromReaderInstance(int userId, NpgsqlDataReader reader)
        {
            var name = reader.GetString(reader.GetOrdinal("Name"));
            var surname = reader.GetString(reader.GetOrdinal("Surname"));
            var patronymic = reader.GetString(reader.GetOrdinal("Patronymic"));
            var privelegeLevel = reader.GetString(reader.GetOrdinal("PrivelegeLevel"));
            var login = reader.GetString(reader.GetOrdinal("Login"));
            var password = reader.GetString(reader.GetOrdinal("Password"));
            var org = OrgRepository.GetOrganization(reader.GetInt32(reader.GetOrdinal("OrganizationId")));

            var user = new User(userId, login, password, Role.ToString(privelegeLevel), name, surname, patronymic, org);
            return user;
        }
    }
}
   
