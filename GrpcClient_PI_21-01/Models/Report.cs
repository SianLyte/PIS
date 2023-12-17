using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class Report
    {
        [Filterable("id")]
        public int Id { get; set; }


        [Filterable("created_at")]
        public DateTime CreatedAt { get; set; }


        [Filterable("updated_at")]
        public DateTime UpdatedAt { get; set; }


        [Filterable("start_date")]
        public DateTime StartDate { get; set; }


        [Filterable("end_date")]
        public DateTime EndDate { get; set; }


        [Filterable("profit")]
        public double Profit { get; set; }


        [Filterable("closed_apps_count")]
        public int ClosedAppsCount { get; set; }


        [Filterable("animals_count")]
        public int AnimalsCount { get; set; }


        [Filterable("user_id")]
        public User User { get; set; }


        [Filterable("status")]
        public ReportStatus Status { get; set; }

        public Report(int id, DateTime createdAt, DateTime updatedAt, DateTime startDate, DateTime endDate,
            double profit, int closedAppsCount, int animalsCount, User user, ReportStatus status)
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            StartDate = startDate;
            EndDate = endDate;
            Profit = profit;
            AnimalsCount = animalsCount;
            ClosedAppsCount = closedAppsCount;
            User = user;
            Status = status;
        }
    }
}
