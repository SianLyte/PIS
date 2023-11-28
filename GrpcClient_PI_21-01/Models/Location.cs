using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcClient_PI_21_01.Models
{
    public class Location
    {
        public int IdLocation { get; set; }
        public string City { get; set; }

        public Location(int idLocation, string city)
        {
            IdLocation = idLocation;
            City = city;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Location loc)
                return loc.IdLocation == IdLocation;
            return false;
        }

        public override int GetHashCode()
        {
            return IdLocation.GetHashCode();
        }
    }
}
