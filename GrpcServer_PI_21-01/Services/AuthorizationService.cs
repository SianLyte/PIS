using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Models;

namespace GrpcServer_PI_21_01.Services
{
    public class AuthorizationService : Authorization.AuthorizationBase
    {
        private readonly ILogger<AuthorizationService> _logger;
        public AuthorizationService(ILogger<AuthorizationService> logger)
        {
            _logger = logger;
        }

        public override Task<LogInResult> LogIn(Credentials credentials, ServerCallContext ctx)
        {
            var login = credentials.Login;
            var pw = credentials.Password;

            var user = UserRepository.GetUser(login, pw);
            var loggedIn = user != null;
            var idUser = user?.IdUser;
            var privelege = user?.PrivelegeLevel;

            return Task.FromResult(new LogInResult()
            {
                Successful = loggedIn,
                IdUser = idUser is null ? -1 : idUser.Value,
                Privelege = privelege,
            });
        }
    }
}
