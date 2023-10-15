using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class Location_Contract
    {
        public int Id { get; set; }
        public Location Locality { get; set; }
        public decimal Price { get; set; }
        public Contract Contract { get; set; }
        public Location_Contract(int id, Location locality, decimal price, Contract contract)
        {
            Id = id;
            Locality = locality;
            Price = price;
            Contract = contract;
        }
    }
}
