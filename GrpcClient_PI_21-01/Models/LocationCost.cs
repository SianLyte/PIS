using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class LocationCost
    {
        public int Id { get; set; }
        public Location Locality { get; set; }
        public decimal Price { get; set; }
        public LocationCost(int id, Location locality, decimal price)
        {
            Id = id;
            Locality = locality;
            Price = price;
        }
    }
}
