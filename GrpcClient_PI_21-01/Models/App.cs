using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class App
    {

        [Filterable("created_at")]
        public DateTime date { get; set; }
        [Filterable("id")]
        public int number { get; set; }

        [Filterable("cityid")]
        public Location locality { get; set; }

        [Filterable("territory")]
        public string territory { get; set; }

        [Filterable("habitat")]
        public string animalHabiat { get; set; }

        [Filterable("urgency")]
        public string urgencyOfExecution { get; set; }

        [Filterable("descr")]
        public string animaldescription { get; set; }

        [Filterable("client_category")]
        public string applicantCategory { get; set; }

        [Filterable("status")]
        public AppStatus status { get; set; }

        [Filterable("organization_id")]
        public Organization organization { get; set; }

        [Filterable("animal_count")]
        public int animalCount { get; set; }

        public App(DateTime date, int number, Location locality, string territory, string animalHabiat, string urgencyOfExecution, string animaldescription, string applicantCategory, AppStatus status, Organization organization, int animalCount)
        {
            this.date = date;
            this.number = number;
            this.locality = locality;
            this.territory = territory;
            this.animalHabiat = animalHabiat;
            this.urgencyOfExecution = urgencyOfExecution;
            this.animaldescription = animaldescription;
            this.applicantCategory = applicantCategory;
            this.status=status;
            this.organization=organization;
            this.animalCount=animalCount;
        }
        public static string EnumToString(AppStatus status)
        {
            if (status == AppStatus.AwaitingRegistration)
            {
                return "awaiting registration";
            }
            if (status == AppStatus.Registered)
            {
                return "registered";
            }
            if (status == AppStatus.Performed)
            {
                return "performed";
            }
            if (status == AppStatus.Fulfilled)
            {
                return "fulfilled";
            }
            if (status == AppStatus.Removed)
            {
                return "removed";
            }
            return "awaiting registration";
        }
        public static AppStatus StringToEnum(string status)
        {
            if (status == "awaiting registration")
            {
                return AppStatus.AwaitingRegistration;
            }
            if (status == "registered")
            {
                return AppStatus.Registered;
            }
            if (status == "performed")
            {
                return AppStatus.Performed;
            }
            if (status == "fulfilled")
            {
                return AppStatus.Fulfilled;
            }
            if (status == "removed")
            {
                return AppStatus.Removed;
            }
            return AppStatus.AwaitingRegistration;
        }
    }
}
