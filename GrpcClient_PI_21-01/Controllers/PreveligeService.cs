//using GrpcClient_PI_21_01.Data;
using GrpcClient_PI_21_01.Models;
using Grpc.Net.Client;

namespace GrpcClient_PI_21_01.Controllers
{
    class PreveligeService
    {
        //public static bool SetPrivilege(NameMdels model)
        //{
        //    return PrivilegeRepository.SetPrivilege(model);
        //}

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
