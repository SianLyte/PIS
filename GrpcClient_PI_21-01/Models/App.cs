using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    //public enum AppStatus
    //{
    //    Awaiting_Registration,
    //    Registered,
    //    Performed,
    //    Fulfilled,
    //    Removed
    //}
    public class App
    {
        public DateTime date { get; set; }
        public int number { get; set; }
        public Models.Location locality { get; set; }
        public string territory { get; set; }
        public string animalHabiat { get; set; }
        public string urgencyOfExecution { get; set; }
        public string animaldescription { get; set; }
        public string applicantCategory { get; set; }
        public AppStatus status { get; set; }

        public App(DateTime date, int number, Location locality, string territory, string animalHabiat, string urgencyOfExecution, string animaldescription, string applicantCategory, AppStatus status)
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
