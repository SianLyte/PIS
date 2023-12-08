using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    [FilterableModel]
    public class Location_Contract
    {
        public int Id { get; set; }
        [Filterable("city_id")]
        public Location Locality { get; set; }
        [Filterable("cost")]
        public decimal Price { get; set; }
        [Filterable("contract_id")]
        public Contract Contract { get; set; }
        public Location_Contract(int id, Location locality, decimal price, Contract contract)
        {
            Id = id;
            Locality = locality;
            Price = price;
            Contract = contract;
        }

        public LocationContractReply ToReply()
        {
            return new LocationContractReply()
            {
                Id = Id,
                Location = Locality.ToReply(),
                Contract = Contract.ToReply(),
                Price = (double)Price,
            };
        }
    }
}
