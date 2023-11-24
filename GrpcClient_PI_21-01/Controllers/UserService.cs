using Grpc.Net.Client;
using GrpcClient_PI_21_01.Models;
using System.Runtime.Serialization.Formatters.Binary;

namespace GrpcClient_PI_21_01.Controllers
{
    class UserService
    {
        public static User? CurrentUser { get; private set; }

        public static async Task<User?> CheckUser(string login, string password)
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new Authorization.AuthorizationClient(channel);
            var reply = await client.LogInAsync(new Credentials() { Login = login, Password = password });
            if (reply.Successful)
            {
                return new User(reply.UserId, login, reply.PrivelegeLevel,
                    reply.Name, reply.Surname, reply.Patronymic, reply.Organization.FromReply());
            }
            return null;
        }

        public static void LogIn(User? user)
        {
            CurrentUser = user;
        }
    }
}
