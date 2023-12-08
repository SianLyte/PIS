using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
{
    [FilterableModel("city")]
    public class Location
    {
        public int IdLocation { get; set; }
        [Filterable("city")]
        public string City { get; set; }

        public Location(int idLocation, string city)
        {
            IdLocation = idLocation;
            City = city;
        }

        //public static Location GetById(int id, NpgsqlConnection cn, bool connectionAlreadyOpen = false)
        //{
        //    NpgsqlCommand cmd = new($"SELECT * FROM city WHERE id = {id}");
        //    cmd.Connection = cn;
        //    if (!connectionAlreadyOpen)
        //        cn.Open();

        //    var reader = cmd.ExecuteReader();
        //    if (!reader.Read()) throw new Exception("Unknown ID for location: " + id);
        //    var location = new Location(id, reader.GetString(reader.GetOrdinal("city")));

        //    reader.Close();
        //    if (!connectionAlreadyOpen)
        //        cn.Close();

        //    return location;
        //}
    }
}
