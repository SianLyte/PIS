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

            var result = new LogInResult()
            {
                Successful = loggedIn,
            };

            if (loggedIn)
            {
                result.UserId = idUser is null ? -1 : idUser.Value;
                result.Name = user?.Name;
                result.Surname = user?.Surname;
                result.Patronymic = user?.Patronymic;
                result.Organization = user?.Organization.ToReply();
                result.PrivelegeLevel = privelege.ToString();
            }

            return Task.FromResult(result);
        }
    }
}
