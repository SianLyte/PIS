using Grpc.Core;
using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Models;

namespace GrpcServer_PI_21_01.Services
{
    public class PrevilegeService : Previlege.PrevilegeBase
    {
        private readonly ILogger<PrevilegeService> _logger;
        public PrevilegeService(ILogger<PrevilegeService> logger)
        {
            _logger = logger;
        }

        public override Task<AccessReply> GetAccessFor(UserRequest request, ServerCallContext ctx)
        {
            var nameMdls = (NameMdels)Enum.Parse(typeof(NameMdels), request.RequestingForm);
            var accessGranted = PrivilegeRepository.SetPrivilege(request.UserPrevilege, nameMdls);

            return Task.FromResult(new AccessReply()
            {
                AccessGranted = accessGranted,
            });
        }
    }
}
