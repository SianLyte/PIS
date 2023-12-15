//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;

namespace GrpcClient_PI_21_01.Controllers
{
    static class PreveligeService
    {
        //public static bool SetPrivilege(NameMdels model)
        //{
        //    return PrivilegeRepository.SetPrivilege(model);
        //}

        public static List<Models.Previlege> GetPrevileges()
        {
            return new List<Models.Previlege>()
            {
                new Models.Previlege("Admin", "Администратор"),
                new Models.Previlege("OperatorOMSY", "Оператор ОМСУ"),
                new Models.Previlege("CuratorOMSY", "Куратор ОМСУ"),
                new Models.Previlege("SubscriberOMSY", "Подписант ОМСУ"),
                new Models.Previlege("OperatorVet", "Оператор вет-службы"),
                new Models.Previlege("CuratorVet", "Куратор вет-службы"),
                new Models.Previlege("SubscriberVet", "Подписант вет-службы"),
                new Models.Previlege("CuratorTrap", "Куратор по отлову"),
                new Models.Previlege("OperatorTrap", "Оператор по отлову"),
                new Models.Previlege("SubscriberTrap", "Подписант по отлову"),
                new Models.Previlege("OperatorShelter", "Оператор приюта"),
                new Models.Previlege("CuratorShelter", "Куратор приюта"),
                new Models.Previlege("SubscriberShelter", "Подписант приюта"),
            }; // hardcoded, better to pull from database
        }

        public static async Task<bool> IsUserPrevilegedFor(NameMdels model)
        {
            if (UserService.CurrentUser is null) return false;

            using var channel = GrpcChannel.ForAddress("https://localhost:7275");
            var client = new Previlege.PrevilegeClient(channel);
            var reply = await client.GetAccessForAsync(new UserRequest()
            {
                UserPrevilege = UserService.CurrentUser.PrivelegeLevel,
                RequestingForm = model.ToString(),
            });

            return reply.AccessGranted;
        }
    }
}
