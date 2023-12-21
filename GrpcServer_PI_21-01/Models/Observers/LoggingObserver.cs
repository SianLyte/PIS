using GrpcServer_PI_21_01.Data;
using GrpcServer_PI_21_01.Services;
using System.Data;
using Google.Protobuf.WellKnownTypes;

namespace GrpcServer_PI_21_01.Models.Observers
{
    public class LoggingObserver : IObserver
    {
        private readonly ILogger<DataService> _logger;
        private readonly DataCacheProxy<Operation> operationProxy;
        public LoggingObserver(ILogger<DataService> _logger, DataCacheProxy<Operation> operationProxy)
        {
            this.operationProxy = operationProxy;
            this._logger = _logger;        }
        
        public void Update<T>(ObserverArguments<T> args)
        {
            var user = args.User;
            var operation = new OperationReply()
            {
                Action = args.ActionType,
                ModifiedObjectId = args.ModifiedObjectId,
                ModifiedTableName = args.TableName,
                OperationId = -1,
                User = user,
                Date = DateTime.Now.ToUtc().ToTimestamp(),
            };
            var logged = OperationRepository.AddOperation(operation);
            if (!logged)
            {
                _logger.LogError("Error has occured during operation log. Please debug this log:" +
                    "\n{Username} has made changes to {tableName} table at index {modifId}." +
                    " Action type: {actType}.",
                    string.Join(" ", user.Surname, user.Name, user.Patronymic), args.TableName, args.ModifiedObjectId, args.ActionType);
            }
            else operationProxy.Reset();
        }
    }
}