using Grpc.Core;
using GrpcServer_PI_21_01.Data;
using Google.Protobuf.WellKnownTypes;
using GrpcServer_PI_21_01.Models;
using System.Diagnostics.Contracts;

namespace GrpcServer_PI_21_01.Services
{
    public class ReportService : ReportGenerator.ReportGeneratorBase
    {
        const int CacheDurationMs = 60000;
        private readonly ILogger<ReportService> _logger;
        private readonly DataCacheProxy<Report> reportCacheProxy = new(new ReportRepository(), CacheDurationMs);
        private readonly DataCacheProxy<Operation> operationProxy = new(new OperationRepository(), CacheDurationMs);
        //private readonly StatusReportObserver statusReportObserver = new StatusReportObserver();
        //private readonly StatusReportSubject statusReportSubject = new StatusReportSubject();

        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
        }

        private static Task<OperationResult> CRUD(int modifiedId, bool successful)
        {
            var result = new OperationResult()
            {
                ModifiedId = modifiedId,
                Successful = successful,
            };
            return Task.FromResult(result);
        }

        //public void Log(ActionType actType, string tableName, int modifId, UserReply actor)
        //{
        //    var operation = new OperationReply()
        //    {
        //        Action = actType,
        //        ModifiedObjectId = modifId,
        //        ModifiedTableName = tableName,
        //        OperationId = -1,
        //        User = actor,
        //        Date = DateTime.Now.ToUtc().ToTimestamp(),
        //    };
        //    var logged = OperationRepository.AddOperation(operation);
        //    if (!logged)
        //    {
        //        _logger.LogError("Error has occured during operation log. Please debug this log:" +
        //            "\n{Username} has made changes to {tableName} table at index {modifId}." +
        //            " Action type: {actType}.",
        //            string.Join(" ", actor.Surname, actor.Name, actor.Patronymic), tableName, modifId, actType);
        //    }
        //    else operationProxy.Reset();
        //}
        public override async Task GetReports(DataRequest request, IServerStreamWriter<ReportReply> responseStream, ServerCallContext context)
        {
            var filter = new Filter<Report>(request.Filter);
            foreach (var app in reportCacheProxy.GetAll(request))
                // у заявки на отлов нет организации, хотя по суди должна быть
                // пока не меняю, но потом из этого могут вырасти проблемы
                // например, сейчас не могу отфильтровать заявки для пользователя
                await responseStream.WriteAsync(app.ToReply());
        }

        public override Task<ReportReply> GetReport(IdRequest request, ServerCallContext context)
        {
            Report? app = ReportRepository.GetReport(request.Id);

            if (app is null)
                throw new RpcException(new Status(StatusCode.NotFound, "Item does not exist"));

            return Task.FromResult(app.ToReply());
        }

        public override Task<OperationResult> AddReport(ReportReply request, ServerCallContext context)
        {
            var report = request.FromReply();
            var successful = ReportRepository.AddReport(report);
            if (successful)
            {
                Subject.Instance.NotifyObservers(new ObserverArguments<Report>()
                {
                    ModifiedObjectId = report.Id,
                    TableName = "Report",
                    ActionType = ActionType.ActionAdd,
                    CacheProxy = reportCacheProxy,
                    User = request.Actor
                });
                //reportCacheProxy.Reset();
                //Log(ActionType.ActionAdd, "Report", report.Id, report.User.ToReply());
            }
            return CRUD(report.Id, successful);
        }

        

        public override Task<AvailableActions> GetAvailableActions(Id request, ServerCallContext context)
        {
            var actions = ReportRepository.GetAvailableActions(request.Id_).Select(action => action.ToString()).ToList();
            var reportResponse = new AvailableActions();
            reportResponse.AvailableActions_.AddRange(actions);
            return Task.FromResult(reportResponse);
        }

        public override Task<AvailableStatuses> GetAvailableStatuses(IdAndStatus request, ServerCallContext context)
        {
            
            var statuses = ReportRepository.GetAvailableStatuses(request.Id, request.ActionType, request.Status)
                .Select(status=> status.ToString()).ToList();
            var reportResponse = new AvailableStatuses();
            reportResponse.AvailableStatuses_.AddRange(statuses);
            return Task.FromResult(reportResponse);
        }

        public override Task<OperationResult> RemoveReport(IdRequest request, ServerCallContext context)
        {
            var successful = ReportRepository.RemoveReport(request.Id);
            if (successful)
            {
                Subject.Instance.NotifyObservers(new ObserverArguments<Report>()
                {
                    ModifiedObjectId = request.Id,
                    TableName = "Report",
                    ActionType = ActionType.ActionDelete,
                    CacheProxy = reportCacheProxy,
                    User = request.Actor
                });
                //reportCacheProxy.Reset();
                //Log(ActionType.ActionDelete, "Report", request.Id, request.Actor);
            }
            return CRUD(request.Id, successful);
        }

        public override Task<OperationResult> UpdateReport(ReportReply request, ServerCallContext context)
        {
            var rep = request.FromReply();
            //if (request.Actor.PrivelegeLevel == Roles.Operator_Po_Otlovy.ToString()
            //    && (rep.Status == ReportStatus.Draft || rep.Status == ReportStatus.ApprovalFromMunicipalContractExecutor))
            //{
            //    ; ; ;
            //}
            //else if (request.Actor.PrivelegeLevel == Roles.Curator_Po_Otlovy.ToString()
            //    && (rep.Status == ReportStatus.ApprovedByMunicipalContractExecutor || rep.Status == ReportStatus.Revision))
            //{
            //    ; ; ;
            //}
            //else if (request.Actor.PrivelegeLevel == Roles.Podpisant_Po_Otlovy.ToString()
            //    && (rep.Status == ReportStatus.Revision || rep.Status == ReportStatus.AgreedWithMunicipalContractExecutor))
            //{
            //    ; ; ;
            //}
            //else if (request.Actor.PrivelegeLevel == Roles.Curator_OMSY.ToString()
            //    && (rep.Status == ReportStatus.Revision || rep.Status == ReportStatus.ApprovedByOmsy))
            //{
            //    ; ; ;
            //}
            //else
            //{
            //    throw new RpcException(new Status(StatusCode.PermissionDenied, "У вас нет прав на это"));
            //}
            var successful = ReportRepository.UpdateReport(rep);
            if (successful)
            {
                Subject.Instance.NotifyObservers(new ObserverArguments<Report>()
                {
                    ModifiedObjectId = request.Id,
                    TableName = "Report",
                    ActionType = ActionType.ActionUpdate,
                    CacheProxy = reportCacheProxy,
                    User = request.Actor
                });
                //reportCacheProxy.Reset();
                //Log(ActionType.ActionUpdate, "Report", request.Id, request.Actor);
            }
            return CRUD(request.Id, successful);
        }

        public override Task<ReportReply> GenerateReport(Report_FilterReply request, ServerCallContext context)
        {
            var start = request.BeginDate.ToDateTime();
            var finish = request.EndDate.ToDateTime();

            var dataRequest = new DataRequest()
            {
                Actor = request.Actor,
                Page = -1,
            };

            var report = ReportRepository.GenereteReport(dataRequest, start, finish, request.Id);

            return Task.FromResult(report.ToReply());

            //foreach (var report in ReportRepository.GenereteReport(start, finish))
            //{
            //    var reportReply = new Report_ActCapture()
            //    {
            //        Start = report.DateStart.ToTimestamp(),
            //        End = report.DateFinish.ToTimestamp(),
            //        ClosedAppCount = report.Close,
            //        Locality = report.Loc.ToReply(),
            //        CapturedAnimalsCount = report.CountAnumals,
            //        Summary = report.Sum,
            //    };
            //}
        }
        //public override Task Generate_ActCaptureReport(Report_FilterReply request, IServerStreamWriter<ReportReply> responseStream, ServerCallContext context)
        //{
        //    var start = request.BeginDate.ToDateTime();
        //    var finish = request.EndDate.ToDateTime();
        //    foreach (var report in ReportRepository.GenereteReport(start, finish))
        //    {
        //        var reportReply = new Report_ActCapture()
        //        {
        //            Start = report.DateStart.ToTimestamp(),
        //            End = report.DateFinish.ToTimestamp(),
        //            ClosedAppCount = report.Close,
        //            Locality = report.Loc.ToReply(),
        //            CapturedAnimalsCount = report.CountAnumals,
        //            Summary = report.Sum,
        //        };
        //        await responseStream.WriteAsync(reportReply);
        //    }
        //}

    }
}
