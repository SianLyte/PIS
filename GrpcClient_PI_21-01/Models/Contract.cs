using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class Contract
    {
        public int IdContract { get; set; }
        public DateTime DateConclusion { get; set; }
        public DateTime ActionDate { get; set; }
        public Location LocationCost { get; set; }
        public int Cost { get; set; }
        public Organization Executer { get; set; }
        public Organization Costumer { get; set; }

        public Contract(int idContract, 
            DateTime dateConclusion, DateTime actionDate, 
            Location location, int cost,
            Organization executer, Organization costumer)
        {
            IdContract = idContract;
            DateConclusion = dateConclusion;
            ActionDate = actionDate;
            LocationCost = location;
            Cost = cost;
            Executer = executer;
            Costumer = costumer;
        }

    }
}
