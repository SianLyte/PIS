using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer_PI_21_01.Models
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

        public static Location_Contract GetAnimalCost(int localityId, int ContractId, NpgsqlConnection cn)
        {
            NpgsqlCommand cmd = new($"SELECT * FROM city_contract WHERE contract_id = {ContractId} AND city_id = {localityId}") { Connection = cn };
            string[] arr = { "0", "0", "0", "0"};
            cmd.Connection = cn;
            cn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                arr[0] = reader[0].ToString(); //id
                arr[1] = reader[1].ToString(); //cost
                arr[2] = reader[2].ToString(); //contract id
                arr[3] = reader[3].ToString(); //city id
            }
            reader.Close();
            cn.Close();
            return new Location_Contract(
                int.Parse(arr[0]),
                Location.GetById(int.Parse(arr[3]), cn),
                decimal.Parse(arr[1]),
                Contract.GetById(int.Parse(arr[2]), cn));
        }
    }
}
