using Grpc.Core;
using GrpcServer_PI_21_01.Data;
using Google.Protobuf.WellKnownTypes;
using GrpcServer_PI_21_01.Models;

namespace GrpcServer_PI_21_01.Services
{
    public class ReportService : ReportGenerator.ReportGeneratorBase
    {
        private readonly ILogger<ReportService> _logger;
        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
            
        }

    //    public override async Task GetReports(DataRequest request,
    //IServerStreamWriter<ApplicationReply> responseStream,
    //ServerCallContext ctx)
    //    {
    //        var filter = new Filter<App>(request.Filter);
    //        foreach (var app in appCacheProxy.GetAll(request))
    //            // у заявки на отлов нет организации, хотя по суди должна быть
    //            // пока не меняю, но потом из этого могут вырасти проблемы
    //            // например, сейчас не могу отфильтровать заявки для пользователя
    //            await responseStream.WriteAsync(app.ToReply());
    //    }

        //public override async Task Generate_ActCaptureReport(Report_FilterReply request,
        //    IServerStreamWriter<Report_ActCapture> responseStream,
        //    ServerCallContext context)
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
