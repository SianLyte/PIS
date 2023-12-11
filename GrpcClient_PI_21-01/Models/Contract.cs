using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class Contract
    {
        [Filterable("id")]
        public int IdContract { get; set; }

        [Filterable("created_at")]
        public DateTime DateConclusion { get; set; }

        [Filterable("validity_date")]
        public DateTime ActionDate { get; set; }

        [Filterable("performer_id")]
        public Organization Executer { get; set; }

        [Filterable("customer_id")]
        public Organization Costumer { get; set; }

        public Contract(int idContract,
            DateTime dateConclusion, DateTime actionDate,
            Organization executer, Organization costumer)
        {
            IdContract = idContract;
            DateConclusion = dateConclusion;
            ActionDate = actionDate;
            Executer = executer;
            Costumer = costumer;
        }

    }
}
