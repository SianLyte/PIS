using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
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

        public static Location GetById(int id, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM city WHERE id = {id}");
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            string[] arr = { "0" };

            while (reader.Read())
                arr[0] = reader[1].ToString();
            reader.Close();
            cn.Close();
            return new Models.Location(id, arr[0]);
        }
    }
}
