using Grpc.Core;
using GrpcServer_PI_21_01.Data;
using Google.Protobuf.WellKnownTypes;

namespace GrpcServer_PI_21_01.Services
{
    public class ReportService : ReportGenerator.ReportGeneratorBase
    {
        private readonly ILogger<ReportService> _logger;
        public ReportService(ILogger<ReportService> logger)
        {
            _logger = logger;
        }

        public override async Task Generate_ActCaptureReport(Report_FilterReply request,
            IServerStreamWriter<Report_ActCapture> responseStream,
            ServerCallContext context)
        {
            var start = request.BeginDate.ToDateTime();
            var finish = request.EndDate.ToDateTime();
            foreach (var report in ReportRepository.GenereteReport(start, finish))
            {
                var reportReply = new Report_ActCapture()
                {
                    Start = report.DateStart.ToTimestamp(),
                    End = report.DateFinish.ToTimestamp(),
                    ClosedAppCount = report.Close,
                    Locality = report.Loc.ToReply(),
                    CapturedAnimalsCount = report.CountAnumals,
                    Summary = report.Sum,
                };
                await responseStream.WriteAsync(reportReply);
            }
        }
    }
}
