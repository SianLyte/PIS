using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class Organization
    {
        public int idOrg { get; set; }

        [Filterable("namee")]
        public string name { get; set; }

        [Filterable("inn")]
        public string INN { get; set; }

        [Filterable("kpp")]
        public string KPP { get; set; }

        [Filterable("registration")]
        public Location registrationAdress { get; set; }

        [Filterable("typee")]
        public OrganizationType type { get; set; }
        public string status { get; set; }

        public Organization(int IdOrg, string name, string iNN, string kPP,
            Location registrationAdress, OrganizationType type, string status)
        {
            this.idOrg = IdOrg;
            this.name = name;
            INN = iNN;
            KPP = kPP;
            this.registrationAdress = registrationAdress;
            this.type = type;
            this.status = status;
        }
    }
}
