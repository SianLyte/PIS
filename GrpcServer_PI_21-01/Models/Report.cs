using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    enum ReportStatus
    {
        Draft,
        ApprovalFromMunicipalContractExecutor,
        AgreedWithMunicipalContractExecutor,
        Revision,
        ApprovedByMunicipalContractExecutor,
        ApprovedByOMSY
    }
    class Report
    {
        public DateTime DateStart { get; set; }
        public DateTime DateFinish { get; set; }
        public Location Loc { get; set; }
        public int CountAnumals { get; set; }
        public int Close { get; set; }
        public double Sum { get; set; }
        public ReportStatus status { get; set; }
        public DateTime statusChangeDate { get; set; }

        public static string EnumToString(ReportStatus status)
        {
            if (status == ReportStatus.Draft)
            {
                return "draft";
            }
            if (status == ReportStatus.Revision)
            {
                return "revision";
            }
            if (status == ReportStatus.ApprovedByOMSY)
            {
                return "approved_by_omsy";
            }
            if (status == ReportStatus.ApprovedByMunicipalContractExecutor)
            {
                return "approved_by_municipal_contract_executor";
            }
            if (status == ReportStatus.AgreedWithMunicipalContractExecutor)
            {
                return "agreed_with_municipal_contract_executor";
            }
            if (status == ReportStatus.ApprovalFromMunicipalContractExecutor)
            {
                return "approval_from_municipal_contract_executor";
            }
            return "draft";
        }
        public static ReportStatus StringToEnum(string status)
        {
            if (status == "draft")
            {
                return ReportStatus.Draft;
            }
            if (status == "revision")
            {
                return ReportStatus.Revision;
            }
            if (status == "approved_by_omsy")
            {
                return ReportStatus.ApprovedByOMSY;
            }
            if (status == "approved_by_municipal_contract_executor")
            {
                return ReportStatus.ApprovedByMunicipalContractExecutor;
            }
            if (status == "agreed_with_municipal_contract_executor")
            {
                return ReportStatus.AgreedWithMunicipalContractExecutor;
            }
            if (status == "approval_from_municipal_contract_executor")
            {
                return ReportStatus.ApprovalFromMunicipalContractExecutor;
            }
            return ReportStatus.Draft;
        }

        public Report(DateTime dateStart, DateTime dateFinish, Location loc, int close, int countAnumals, double sum, ReportStatus status, DateTime statusChangeDate)
        {
            DateStart = dateStart;
            DateFinish = dateFinish;
            Loc = loc;
            Close = close;
            CountAnumals = countAnumals;
            Sum = sum;
            this.status = status;
            this.statusChangeDate = statusChangeDate;
        }
    }
}
